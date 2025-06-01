using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using cloudyLib.Data;
using cloudyLib.Models;
using BCrypt.Net; 

namespace cloudyLib.Forms
{
    public partial class RegisterView : UserControl
    {
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
            if (txtPassword != null) txtPassword.PasswordChar = '●';
            if (txtConfirmPassword != null) txtConfirmPassword.PasswordChar = '●';

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

            if (txtEmail != null) { txtEmail.Leave -= txtEmail_Leave; txtEmail.Leave += txtEmail_Leave; }
            if (txtPhone != null) { txtPhone.KeyPress -= txtPhone_KeyPress; txtPhone.KeyPress += txtPhone_KeyPress; }
            if (txtPhone != null) { txtPhone.Leave -= txtPhone_Leave; txtPhone.Leave += txtPhone_Leave; }

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

            if (this.txtFirstName == null || this.txtLastName == null || this.txtEmail == null ||
                this.txtPassword == null || this.txtConfirmPassword == null || this.txtPhone == null)
            {
                lblMessage.Text = "Błąd wewnętrzny: Pola formularza nie są dostępne.";
                lblMessage.Visible = true;
                return;
            }

            if (!ValidateForm())
            {
                return;
            }

            bool isEmailUnique = await IsEmailUniqueAsync(txtEmail.Text);
            if (!isEmailUnique)
            {
                lblMessage.Text = "Podany adres e-mail jest już zajęty.";
                lblMessage.Visible = true;
                return;
            }

            try
            {
                var newUser = new User
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    PasswordHash = HashPassword(txtPassword.Text),
                    PhoneNumber = txtPhone.Text.Trim(),
                    Role = "Reader" 
                };
                _db.Users.Add(newUser);
                await _db.SaveChangesAsync();

                MessageBox.Show("Rejestracja zakończona pomyślnie! Możesz się teraz zalogować.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var loginView = _serviceProvider.GetRequiredService<LoginView>();
                _mainForm.LoadView(loginView);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Błąd rejestracji: " + ex.Message;
                lblMessage.Visible = true;
                ;
            }
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                lblMessage.Text = "Wszystkie wymagane pola są puste lub niepoprawne.";
                lblMessage.Visible = true;
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblMessage.Text = "Niepoprawny format adresu e-mail.";
                lblMessage.Visible = true;
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblMessage.Text = "Hasła nie są zgodne.";
                lblMessage.Visible = true;
                return false;
            }

            if (txtPassword.Text.Length < 8 || 
                !Regex.IsMatch(txtPassword.Text, "[A-Z]") || 
                !Regex.IsMatch(txtPassword.Text, "[a-z]") || 
                !Regex.IsMatch(txtPassword.Text, "[0-9]") || 
                !Regex.IsMatch(txtPassword.Text, "[^a-zA-Z0-9]"))
            {
                lblMessage.Text = "Hasło musi mieć co najmniej 8 znaków, zawierać dużą literę, małą literę, cyfrę i znak specjalny.";
                lblMessage.Visible = true;
                return false;
            }

            if (txtPhone.Text.Length < 9 || !Regex.IsMatch(txtPhone.Text, @"^\d{9,12}$")) 
            {
                lblMessage.Text = "Numer telefonu musi zawierać od 9 do 12 cyfr.";
                lblMessage.Visible = true;
                return false;
            }

            lblMessage.Visible = false; 
            return true;
        }

        private async Task<bool> IsEmailUniqueAsync(string email)
        {
            var existingUser = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            return existingUser == null;
        }

        private async void txtEmail_Leave(object sender, EventArgs e) 
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
                    bool isUnique = await IsEmailUniqueAsync(txtEmail.Text); 
                    if (!isUnique)
                    {
                        lblMessage.Text = "Podany adres e-mail jest już zajęty.";
                        lblMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Text = "";
                        lblMessage.Visible = false;
                    }
                }
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Visible = false;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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

        private void lblLogin_Click(object sender, EventArgs e)
        {
            try
            {
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