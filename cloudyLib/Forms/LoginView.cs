using System;
using System.Drawing;
using System.Windows.Forms;
using cloudyLib.Data;
using Microsoft.EntityFrameworkCore; // Potrzebne do interakcji z bazą danych
using Microsoft.Extensions.DependencyInjection; // Potrzebne do IServiceProvider
using cloudyLib.Models;

// Zakładam, że masz te przestrzenie nazw
// using cloudyLib.Data; // Dla AppDbContext
// using cloudyLib.Models; // Dla modeli użytkowników (User)
// using cloudyLib.Services; // Dla ewentualnych serwisów (AuthService, UserService)

namespace cloudyLib.Forms
{
    public partial class LoginView : UserControl
    {

        private readonly LibraryDbContext _db; // Zgodnie z Twoim plikiem LibraryDbContext.cs
        private readonly MainForm _mainForm; // Główny formularz aplikacji
        private readonly IServiceProvider _serviceProvider; // Do wstrzykiwania innych widoków

        public LoginView(LibraryDbContext db, MainForm mainForm, IServiceProvider serviceProvider)
        {
            InitializeComponent(); // Wywołane przez projektanta
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            ConfigureLoginControls();
        }

        private void ConfigureLoginControls()
        {
            // Ustawienia początkowe kontrolek
            if (this.txtPassword != null)
            {
                this.txtPassword.PasswordChar = '●'; // Użycie symbolu dla hasła
            }

            // Przypisanie zdarzeń do przycisków i linków
            if (this.btnLogin != null)
            {
                this.btnLogin.Click -= btnLogin_Click; // Usuń istniejący, aby uniknąć podwójnego przypisania
                this.btnLogin.Click += btnLogin_Click;
                this.btnLogin.Cursor = Cursors.Hand; // Zmień kursor na łapkę
            }

            if (this.lblRegister != null)
            {
                this.lblRegister.Click -= lblRegister_Click;
                this.lblRegister.Click += lblRegister_Click;
                this.lblRegister.Cursor = Cursors.Hand; // Zmień kursor na łapkę
            }

            // Inicjalizacja wiadomości o błędach
            if (this.lblMessage != null)
            {
                this.lblMessage.Text = ""; // Upewnij się, że jest pusta na początku
                this.lblMessage.Visible = false; // Ukryj na początku
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (lblMessage == null)
            {
                MessageBox.Show("Błąd wewnętrzny: Brak możliwości wyświetlenia komunikatu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblMessage.Visible = false; // Ukryj poprzedni błąd

            if (this.txtEmail == null || this.txtPassword == null) // Zmienione z txtUsername
            {
                lblMessage.Text = "Błąd wewnętrzny: Pola formularza nie są dostępne.";
                lblMessage.Visible = true;
                return;
            }

            var email = this.txtEmail.Text.Trim(); // Zmienione z username
            var password = this.txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Adres e-mail i hasło są wymagane.";
                lblMessage.Visible = true;
                return;
            }

            try
            {
                // W Twojej bazie danych jest pole Email_varchar i Password_hash
                // Należy tutaj zaimplementować prawdziwą logikę logowania.
                // Upewnij się, że PasswordHasher jest dostępny.

                // Przykładowa logika logowania (DO ZASTĄPIENIA WŁASNĄ IMPLEMENTACJĄ)
                // Zakładam, że masz statyczną klasę PasswordHasher lub serwis do haszowania
                var user = await _db.Users
                                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user != null && VerifyPassword(password, user.Password)) // Użyj Twojej funkcji VerifyPassword
                {
                    // Użytkownik zalogowany pomyślnie
                    _mainForm.UserLoggedIn(user); // Przekaż obiekt User do MainForm
                }
                else
                {
                    lblMessage.Text = "Nieprawidłowy adres e-mail lub hasło.";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Wystąpił błąd podczas logowania. Spróbuj ponownie. (" + ex.Message + ")";
                lblMessage.Visible = true;
            }
        }

        // PRZYKŁADOWA FUNKCJA WERYFIKACJI HASŁA (DO ZASTĄPIENIA PRZEZ BEZPIECZNĄ BIBLIOTEKĘ HASZUJĄCĄ)
        // W rzeczywistości powinieneś używać bezpiecznej biblioteki (np. BCrypt.Net) i
        // umieścić tę logikę w warstwie serwisowej.
        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            // Pamiętaj, że tutaj powinieneś użyć biblioteki do haszowania/weryfikacji
            // np. return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
            // NA RAZIE TYLKO DLA DEMONSTRACJI:
            return enteredPassword == storedHashedPassword; // TO NIE JEST BEZPIECZNE!
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Załaduj widok rejestracji
                var registerView = _serviceProvider.GetRequiredService<RegisterView>();
                _mainForm.LoadView(registerView);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie można załadować widoku rejestracji: {ex.Message}", "Błąd Nawigacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // W UserControl nie ma bezpośrednio zdarzenia Load, jeśli jest osadzony
        // ale można dodać np. OnVisibleChanged lub OnHandleCreated
        // private void LoginView_Load(object sender, EventArgs e) { }
    }
}