using System;
using System.Drawing;
using System.Windows.Forms;
using cloudyLib.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using cloudyLib.Models;
using BCrypt.Net; 

namespace cloudyLib.Forms
{
    public partial class LoginView : UserControl
    {
        private readonly LibraryDbContext _db;
        private readonly MainForm _mainForm;
        private readonly IServiceProvider _serviceProvider;

        public LoginView(LibraryDbContext db, MainForm mainForm, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            ConfigureLoginControls();
        }

        private void ConfigureLoginControls()
        {
            if (this.txtPassword != null)
            {
                this.txtPassword.PasswordChar = '●';
            }

            if (this.btnLogin != null)
            {
                this.btnLogin.Click -= btnLogin_Click;
                this.btnLogin.Click += btnLogin_Click;
                this.btnLogin.Cursor = Cursors.Hand;
            }

            if (this.lblRegister != null)
            {
                this.lblRegister.Click -= lblRegister_Click;
                this.lblRegister.Click += lblRegister_Click;
                this.lblRegister.Cursor = Cursors.Hand;
            }

            if (this.lblMessage != null)
            {
                this.lblMessage.Text = "";
                this.lblMessage.Visible = false;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (lblMessage == null)
            {
                MessageBox.Show("Błąd wewnętrzny: Brak możliwości wyświetlenia komunikatu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblMessage.Visible = false;

            if (this.txtEmail == null || this.txtPassword == null)
            {
                lblMessage.Text = "Błąd wewnętrzny: Pola formularza nie są dostępne.";
                lblMessage.Visible = true;
                return;
            }

            var email = this.txtEmail.Text.Trim();
            var password = this.txtPassword.Text; 

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Adres e-mail i hasło są wymagane.";
                lblMessage.Visible = true;
                return;
            }

            try
            {
                var user = await _db.Users
                                    .AsNoTracking() 
                                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user != null && VerifyPassword(password, user.PasswordHash)) 
                {
                    _mainForm.UserLoggedIn(user); 
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

        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
            }
            catch (Exception ex)
            {
                
                Console.Error.WriteLine($"Błąd weryfikacji hasła BCrypt: {ex.Message}");
                return false;
            }
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var registerView = _serviceProvider.GetRequiredService<RegisterView>();
                _mainForm.LoadView(registerView);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie można załadować widoku rejestracji: {ex.Message}", "Błąd Nawigacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

    }
}