using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using cloudyLib.Data;

// Zakładam, że masz te przestrzenie nazw
// using cloudyLib.Data; // Dla LibraryDbContext
// using cloudyLib.Models;   // Modele User i Address
// using cloudyLib.Services; // Dla User-Service

namespace cloudyLib.Forms
{
    public partial class RegisterView : UserControl
    {
        // Kontrolki z Designer.cs
        

        private readonly LibraryDbContext _db;
        private readonly MainForm _mainForm;
        private readonly IServiceProvider _serviceProvider;

        public RegisterView(LibraryDbContext db, MainForm mainForm, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            ConfigureRegisterControls();
        }

        private void ConfigureRegisterControls()
        {
            // Ustawienia początkowe
            if (txtPassword != null) txtPassword.PasswordChar = '●';
            if (txtConfirmPassword != null) txtConfirmPassword.PasswordChar = '●';

            if (cmbCountry != null)
            {
                cmbCountry.Items.Add("Polska");
                cmbCountry.SelectedItem = "Polska";
                cmbCountry.Enabled = false; // Zablokuj wybór, bo ma być tylko Polska
                cmbCountry.ForeColor = Color.DarkGray; // Oznacz jako nieaktywne
            }

            // Przypisanie zdarzeń
            if (btnRegister != null)
            {
                btnRegister.Click -= btnRegister_Click;
                btnRegister.Click += btnRegister_Click;
                btnRegister.Cursor = Cursors.Hand;
            }

            if (lblLogin != null)
            {
                lblLogin.Click -= lblLogin_Click;
                lblLogin.Click += lblLogin_Click;
                lblLogin.Cursor = Cursors.Hand;
            }

            // Walidacja na bieżąco
            if (txtEmail != null) txtEmail.Leave -= txtEmail_Leave; txtEmail.Leave += txtEmail_Leave;
            if (txtPhone != null) txtPhone.KeyPress -= txtPhone_KeyPress; txtPhone.KeyPress += txtPhone_KeyPress;
            if (txtPhone != null) txtPhone.Leave -= txtPhone_Leave; txtPhone.Leave += txtPhone_Leave;
            if (txtPostalCode != null) txtPostalCode.Leave -= txtPostalCode_Leave; txtPostalCode.Leave += txtPostalCode_Leave;

            if (lblMessage != null)
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
            }
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (lblMessage == null)
            {
                MessageBox.Show("Błąd wewnętrzny: Brak możliwości wyświetlenia komunikatu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblMessage.Visible = false;

            if (!ValidateForm())
            {
                return;
            }

            // Asynchroniczna walidacja unikalności emaila
            bool isEmailUnique = await IsEmailUniqueAsync(txtEmail.Text);
            if (!isEmailUnique)
            {
                lblMessage.Text = "Podany adres e-mail jest już zajęty.";
                lblMessage.Visible = true;
                return;
            }

            try
            {
                // TUTAJ FAKTYCZNA LOGIKA REJESTRACJI Z WYKORZYSTANIEM _db i Twoich modeli
                // PRZYKŁAD:
                // 1. Stwórz obiekt Address
                // var newAddress = new Address
                // {
                //     Town = txtCity.Text.Trim(),
                //     Zip_Code = txtPostalCode.Text.Trim(),
                //     Street = txtAddress.Text.Trim(),
                //     Voivodeship = "brak_danych", // Lub wywnioskuj z kodu pocztowego/miasta
                //     // Apartment_number i House_number mogą być parsowane z txtAddress, lub dodaj osobne pola
                // };
                // _db.Addresses.Add(newAddress);
                // await _db.SaveChangesAsync();

                // 2. Stwórz obiekt User
                // var newUser = new User
                // {
                //     First_name = txtFirstName.Text.Trim(),
                //     Last_name = txtLastName.Text.Trim(),
                //     Email_varchar = txtEmail.Text.Trim(),
                //     Password_hash = HashPassword(txtPassword.Text), // <--- KLUCZOWE: HASZUJ HASŁO!
                //     Phone_number = txtPhone.Text.Trim(),
                //     Role_varchar = "Czytelnik", // Domyślna rola
                //     Address_id = newAddress.Address_id // Powiąż z nowo utworzonym adresem
                // };
                // _db.Users.Add(newUser);
                // await _db.SaveChangesAsync();


                MessageBox.Show("Rejestracja zakończona pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Po rejestracji wróć do widoku logowania
                var loginView = _serviceProvider.GetRequiredService<LoginView>();
                _mainForm.LoadView(loginView);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Błąd rejestracji: " + ex.Message;
                lblMessage.Visible = true;
            }
        }

        private bool ValidateForm()
        {
            // Podstawowa walidacja (czy pola są wypełnione)
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtCity.Text) ||
                string.IsNullOrWhiteSpace(txtPostalCode.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                lblMessage.Text = "Wszystkie pola są wymagane.";
                lblMessage.Visible = true;
                return false;
            }

            // Walidacja formatu emaila
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblMessage.Text = "Niepoprawny format adresu e-mail.";
                lblMessage.Visible = true;
                return false;
            }

            // Walidacja zgodności haseł
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblMessage.Text = "Hasła nie są zgodne.";
                lblMessage.Visible = true;
                return false;
            }

            // Walidacja siły hasła (przynajmniej 6 znaków, jedna duża litera, jedna cyfra, jeden znak specjalny)
            if (txtPassword.Text.Length < 6 ||
                !Regex.IsMatch(txtPassword.Text, "[A-Z]") ||
                !Regex.IsMatch(txtPassword.Text, "[0-9]") ||
                !Regex.IsMatch(txtPassword.Text, "[^a-zA-Z0-9]"))
            {
                lblMessage.Text = "Hasło musi mieć co najmniej 6 znaków, zawierać dużą literę, cyfrę i znak specjalny.";
                lblMessage.Visible = true;
                return false;
            }

            // Walidacja długości telefonu (min. 9 cyfr)
            if (txtPhone.Text.Length < 9)
            {
                lblMessage.Text = "Numer telefonu musi zawierać co najmniej 9 cyfr.";
                lblMessage.Visible = true;
                return false;
            }

            // Walidacja kodu pocztowego dla Polski (XX-XXX)
            if (!Regex.IsMatch(txtPostalCode.Text, @"^\d{2}-\d{3}$"))
            {
                lblMessage.Text = "Niepoprawny format kodu pocztowego (np. 00-000).";
                lblMessage.Visible = true;
                return false;
            }

            // Walidacja kontekstowa - kraj to tylko Polska
            if (cmbCountry.SelectedItem?.ToString() != "Polska")
            {
                lblMessage.Text = "Rejestracja możliwa tylko dla użytkowników z Polski.";
                lblMessage.Visible = true;
                return false;
            }

            return true;
        }

        // Symulacja asynchronicznej walidacji unikalności emaila (powinna być w serwisie)
        private async Task<bool> IsEmailUniqueAsync(string email)
        {
            // W rzeczywistości:
            // return await _userService.IsEmailUnique(email);
            await Task.Delay(500); // Symulacja opóźnienia
            // Sprawdzenie w bazie danych
            var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Email== email);
            return existingUser == null; // Jest unikalny, jeśli nie ma użytkownika z tym emailem
        }

        // Walidacja formatu emaila przy opuszczaniu pola
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    lblMessage.Text = "Niepoprawny format adresu e-mail.";
                    lblMessage.Visible = true;
                }
                else
                {
                    // Asynchroniczna walidacja unikalności
                    _ = IsEmailUniqueAsync(txtEmail.Text).ContinueWith(task => {
                        if (!task.Result)
                        {
                            Invoke((MethodInvoker)delegate {
                                lblMessage.Text = "Podany adres e-mail jest już zajęty.";
                                lblMessage.Visible = true;
                            });
                        }
                        else
                        {
                            Invoke((MethodInvoker)delegate {
                                lblMessage.Text = "";
                                lblMessage.Visible = false;
                            });
                        }
                    });
                }
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
            }
        }

        // Tylko cyfry dla numeru telefonu
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Walidacja długości telefonu przy opuszczaniu pola
        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPhone.Text) && txtPhone.Text.Length < 9)
            {
                lblMessage.Text = "Numer telefonu musi zawierać co najmniej 9 cyfr.";
                lblMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
            }
        }

        // Walidacja kodu pocztowego przy opuszczaniu pola
        private void txtPostalCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPostalCode.Text) && !Regex.IsMatch(txtPostalCode.Text, @"^\d{2}-\d{3}$"))
            {
                lblMessage.Text = "Niepoprawny format kodu pocztowego (np. 00-000).";
                lblMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Wróć do widoku logowania
                var loginView = _serviceProvider.GetRequiredService<LoginView>();
                _mainForm.LoadView(loginView);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie można załadować widoku logowania: {ex.Message}", "Błąd Nawigacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}