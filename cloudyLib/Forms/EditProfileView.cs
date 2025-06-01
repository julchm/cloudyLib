using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; // Potrzebne do IServiceProvider
using cloudyLib.Data;
using cloudyLib.Models;

namespace cloudyLib.Forms
{
    public partial class EditProfileView : UserControl
    {
        private readonly LibraryDbContext _db;
        private readonly MainForm _mainForm;
        private User _userToEdit; 

        public EditProfileView(LibraryDbContext db, MainForm mainForm)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));

            ConfigureEditProfileControls();
            // Ładowanie danych użytkownika nastąpi w zdarzeniu Load tego UserControl
            this.Load += async (s, e) => await LoadUserProfile();
        }

        private void ConfigureEditProfileControls()
        {
            if (lblTitle != null)
            {
                lblTitle.Text = "Edytuj Swój Profil";
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            }

            // Ustawienia dla pól haseł
            if (txtCurrentPassword != null) txtCurrentPassword.PasswordChar = '●';
            if (txtNewPassword != null) txtNewPassword.PasswordChar = '●';
            if (txtConfirmNewPassword != null) txtConfirmNewPassword.PasswordChar = '●';

            // Domyślnie ukrywamy pola zmiany hasła
            SetPasswordFieldsVisibility(false);

            if (lnkChangePassword != null)
            {
                lnkChangePassword.Click -= LnkChangePassword_Click; // Usuń, aby uniknąć podwójnego przypisania
                lnkChangePassword.Click += LnkChangePassword_Click;
                lnkChangePassword.Cursor = Cursors.Hand;
            }

            if (btnSaveChanges != null)
            {
                btnSaveChanges.Click -= BtnSaveChanges_Click;
                btnSaveChanges.Click += BtnSaveChanges_Click;
            }

            if (lblMessage != null)
            {
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblMessage.Visible = false;
            }
        }

        private void SetPasswordFieldsVisibility(bool visible)
        {
            // Zakładam, że masz labelki dla tych pól też (np. lblCurrentPassword, lblNewPassword, lblConfirmNewPassword)
            // Jeśli nie, dodaj je w Designerze.
            // if (lblCurrentPassword != null) lblCurrentPassword.Visible = visible;
            if (txtCurrentPassword != null) txtCurrentPassword.Visible = visible;
            // if (lblNewPassword != null) lblNewPassword.Visible = visible;
            if (txtNewPassword != null) txtNewPassword.Visible = visible;
            // if (lblConfirmNewPassword != null) lblConfirmNewPassword.Visible = visible;
            if (txtConfirmNewPassword != null) txtConfirmNewPassword.Visible = visible;

            // Zmień tekst linku
            if (lnkChangePassword != null)
            {
                lnkChangePassword.Text = visible ? "Anuluj zmianę hasła" : "Zmień hasło";
            }
        }

        private void LnkChangePassword_Click(object sender, EventArgs e)
        {
            // Przełącz widoczność pól hasła
            bool currentVisibility = (txtNewPassword != null && txtNewPassword.Visible);
            SetPasswordFieldsVisibility(!currentVisibility);

            // Wyczyść pola hasła po zmianie widoczności
            if (txtCurrentPassword != null) txtCurrentPassword.Text = "";
            if (txtNewPassword != null) txtNewPassword.Text = "";
            if (txtConfirmNewPassword != null) txtConfirmNewPassword.Text = "";
            ShowMessage("", false); // Wyczyść komunikaty
        }


        private async Task LoadUserProfile()
        {
            ShowMessage("Ładowanie danych profilu...", false);
            try
            {
                if (_mainForm._currentUser == null)
                {
                    ShowMessage("Błąd: Użytkownik nie jest zalogowany.", true);
                    return;
                }

                _userToEdit = await _db.Users
                                        .FirstOrDefaultAsync(u => u.UserId == _mainForm._currentUser.UserId);

                if (_userToEdit != null)
                {
                    if (txtFirstName != null) txtFirstName.Text = _userToEdit.FirstName;
                    if (txtLastName != null) txtLastName.Text = _userToEdit.LastName;
                    if (txtEmail != null) txtEmail.Text = _userToEdit.Email;
                    if (txtPhone != null) txtPhone.Text = _userToEdit.PhoneNumber;
                    ShowMessage("", false);
                }
                else
                {
                    ShowMessage("Nie znaleziono danych użytkownika.", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas ładowania danych profilu: {ex.Message}", true);
            }
        }

        private async void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            ShowMessage("Zapisywanie zmian...", false);

            if (!ValidateForm())
            {
                return;
            }

            try
            {
                if (_userToEdit == null)
                {
                    ShowMessage("Błąd: Brak użytkownika do edycji.", true);
                    return;
                }

                bool emailChanged = (txtEmail != null && _userToEdit.Email != txtEmail.Text.Trim());

                // Walidacja unikalności emaila, jeśli został zmieniony
                if (emailChanged)
                {
                    bool isEmailUnique = await IsEmailUniqueAsync(txtEmail.Text.Trim(), _userToEdit.UserId);
                    if (!isEmailUnique)
                    {
                        ShowMessage("Podany adres e-mail jest już zajęty.", true);
                        return;
                    }
                }

                _userToEdit.FirstName = txtFirstName?.Text.Trim() ?? _userToEdit.FirstName;
                _userToEdit.LastName = txtLastName?.Text.Trim() ?? _userToEdit.LastName;
                _userToEdit.Email = txtEmail?.Text.Trim() ?? _userToEdit.Email;
                _userToEdit.PhoneNumber = txtPhone?.Text.Trim(); // PhoneNumber może być null

                // Zmiana hasła (jeśli pola są widoczne i wypełnione)
                if (txtNewPassword != null && txtNewPassword.Visible && !string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    // Weryfikacja obecnego hasła
                    if (txtCurrentPassword == null || !VerifyPassword(txtCurrentPassword.Text, _userToEdit.PasswordHash))
                    {
                        ShowMessage("Obecne hasło jest nieprawidłowe.", true);
                        return;
                    }
                    _userToEdit.PasswordHash = PasswordHasher.HashPassword(txtNewPassword.Text); // Haszowanie nowego hasła
                }

                _db.Users.Update(_userToEdit);
                await _db.SaveChangesAsync();

                // Aktualizuj obiekt _currentUser w MainFormie, jeśli zmieniono dane (np. imię)
                if (_mainForm._currentUser != null)
                {
                    _mainForm._currentUser.FirstName = _userToEdit.FirstName;
                    _mainForm._currentUser.LastName = _userToEdit.LastName;
                    _mainForm._currentUser.Email = _userToEdit.Email;
                    _mainForm._currentUser.PhoneNumber = _userToEdit.PhoneNumber;
                    _mainForm._currentUser.PasswordHash = _userToEdit.PasswordHash; // Aktualizuj hash w pamięci
                }

                ShowMessage("Profil został zaktualizowany pomyślnie!", false);
                // Ukryj pola zmiany hasła po udanej aktualizacji
                SetPasswordFieldsVisibility(false);
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas zapisu zmian: {ex.Message}", true);
            }
        }

        private bool ValidateForm()
        {
            // Walidacja podstawowych pól
            if (txtFirstName == null || string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                txtLastName == null || string.IsNullOrWhiteSpace(txtLastName.Text) ||
                txtEmail == null || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                txtPhone == null || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                ShowMessage("Wszystkie pola (imię, nazwisko, email, telefon) są wymagane.", true);
                return false;
            }

            // Walidacja formatu emaila
            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowMessage("Niepoprawny format adresu e-mail.", true);
                return false;
            }

            // Walidacja telefonu (tylko cyfry, min. 9 znaków)
            if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^\d{9,12}$")) // Zakładam, że MaxLength to 12
            {
                ShowMessage("Numer telefonu musi zawierać od 9 do 12 cyfr.", true);
                return false;
            }

            // Walidacja haseł, jeśli są widoczne (czyli użytkownik chce zmienić hasło)
            if (txtNewPassword != null && txtNewPassword.Visible)
            {
                if (txtCurrentPassword == null || string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
                {
                    ShowMessage("Wprowadź obecne hasło, aby je zmienić.", true);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txtNewPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmNewPassword.Text))
                {
                    ShowMessage("Nowe hasło i potwierdzenie są wymagane.", true);
                    return false;
                }
                if (txtNewPassword.Text != txtConfirmNewPassword.Text)
                {
                    ShowMessage("Nowe hasła nie są zgodne.", true);
                    return false;
                }
                // Walidacja siły hasła (to samo co w rejestracji)
                if (txtNewPassword.Text.Length < 6 ||
                    !Regex.IsMatch(txtNewPassword.Text, "[A-Z]") ||
                    !Regex.IsMatch(txtNewPassword.Text, "[0-9]") ||
                    !Regex.IsMatch(txtNewPassword.Text, "[^a-zA-Z0-9]"))
                {
                    ShowMessage("Nowe hasło musi mieć co najmniej 6 znaków, zawierać dużą literę, cyfrę i znak specjalny.", true);
                    return false;
                }
            }

            return true;
        }

        private async Task<bool> IsEmailUniqueAsync(string email, int currentUserId)
        {
            var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            // Email jest unikalny, jeśli nie ma żadnego użytkownika z takim emailem,
            // LUB jeśli jest to użytkownik, którego edytujemy.
            return existingUser == null || (existingUser.UserId == currentUserId);
        }

        // PRZYKŁADOWA FUNKCJA WERYFIKACJI HASŁA (DO ZASTĄPIENIA PRZEZ BEZPIECZNĄ BIBLIOTEKĘ HASZUJĄCĄ)
        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            // TO JEST TYLKO DLA TESTÓW! W RZECZYWISTEJ APLIKACJI UŻYJ BCrypt.Net lub podobnej
            // np. return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
            return enteredPassword == storedHashedPassword; // NIEBEZPIECZNE!
        }

        // PRZYKŁADOWA FUNKCJA HASZOWANIA HASŁA (DO ZASTĄPIENIA PRZEZ BEZPIECZNĄ BIBLIOTEKĘ HASZUJĄCĄ)
        private static class PasswordHasher // Możesz przenieść to do oddzielnego serwisu
        {
            public static string HashPassword(string password)
            {
                // TO JEST TYLKO DLA TESTÓW! W RZECZYWISTEJ APLIKACJI UŻYJ BCrypt.Net lub podobnej
                // np. return BCrypt.Net.BCrypt.HashPassword(password);
                return password; // Zwraca jawne hasło - NIEBEZPIECZNE!
            }
        }

        private void ShowMessage(string message, bool isError)
        {
            if (lblMessage != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() => ShowMessage(message, isError)));
                    return;
                }
                lblMessage.Text = message;
                lblMessage.ForeColor = isError ? Color.Red : Color.DarkGreen;
                lblMessage.Visible = !string.IsNullOrEmpty(message);
            }
        }
    }
}