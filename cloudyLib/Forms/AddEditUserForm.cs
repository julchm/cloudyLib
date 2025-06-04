using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using cloudyLib.Data;
using cloudyLib.Models;
using BCrypt.Net; 

namespace cloudyLib.Forms
{
    public partial class AddEditUserForm : Form
    {
        private readonly LibraryDbContext _db;
        private int? _userIdToEdit;
        private User? _userBeingEdited;

        public AddEditUserForm(LibraryDbContext db)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            ConfigureFormControls();
        }

        public void SetUserToEdit(int? userId)
        {
            _userIdToEdit = userId;
            this.Load += async (s, e) => await LoadUserData();
        }

        private void ConfigureFormControls()
        {
            this.Text = "Dodaj/Edytuj Użytkownika";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.AntiqueWhite;

            if (txtPassword != null) txtPassword.PasswordChar = '●';
            if (txtConfirmPassword != null) txtConfirmPassword.PasswordChar = '●';


            if (cmbRole != null)
            {
                cmbRole.Items.AddRange(new object[] { "Reader", "Administrator" });
                cmbRole.SelectedIndex = 0;
                cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            if (btnSave != null) btnSave.Click += BtnSave_Click;
            if (btnCancel != null) btnCancel.Click += (s, e) => this.Close();

            if (txtEmail != null) txtEmail.Leave += TxtEmail_Leave;
            if (txtPhone != null) txtPhone.KeyPress += TxtPhone_KeyPress;
            if (txtPhone != null) txtPhone.Leave += TxtPhone_Leave;

            if (lblMessage != null)
            {
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblMessage.Visible = false;
            }
        }

        private async Task LoadUserData()
        {
            if (_userIdToEdit.HasValue)
            {
                lblTitle.Text = "Edytuj Użytkownika";
                try
                {
                    _userBeingEdited = await _db.Users
                                                .AsNoTracking() 
                                                .FirstOrDefaultAsync(u => u.UserId == _userIdToEdit.Value);

                    if (_userBeingEdited != null)
                    {
                        txtEmail.Text = _userBeingEdited.Email;
                        txtFirstName.Text = _userBeingEdited.FirstName;
                        txtLastName.Text = _userBeingEdited.LastName;
                        txtPhone.Text = _userBeingEdited.PhoneNumber;
                        cmbRole.SelectedItem = _userBeingEdited.Role;

                        lblPassword.Visible = false;
                        txtPassword.Visible = false;
                        lblConfirmPassword.Visible = false;
                        txtConfirmPassword.Visible = false;
                    }
                    else
                    {
                        ShowMessage("Nie znaleziono użytkownika do edycji.", true);
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage($"Błąd podczas ładowania danych użytkownika: {ex.Message}", true);
                }
            }
            else
            {
                lblTitle.Text = "Dodaj Nowego Użytkownika";
                lblPassword.Visible = true;
                txtPassword.Visible = true;
                lblConfirmPassword.Visible = true;
                txtConfirmPassword.Visible = true;
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            ShowMessage("Zapisywanie...", false);

            if (!ValidateForm())
            {
                return;
            }

            try
            {
                if (_userIdToEdit.HasValue) 
                {
                    if (_userBeingEdited != null)
                    {
                        var userToUpdate = await _db.Users.FindAsync(_userIdToEdit.Value);
                        if (userToUpdate == null)
                        {
                            ShowMessage("Błąd: Użytkownik do edycji nie został znaleziony.", true);
                            return;
                        }

                        userToUpdate.FirstName = txtFirstName.Text.Trim();
                        userToUpdate.LastName = txtLastName.Text.Trim();
                        userToUpdate.PhoneNumber = txtPhone.Text.Trim();
                        userToUpdate.Role = cmbRole.SelectedItem.ToString();


                        _db.Users.Update(userToUpdate); 
                        await _db.SaveChangesAsync();
                        MessageBox.Show("Dane użytkownika zostały zaktualizowane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {
                    
                    bool isEmailUnique = await IsEmailUniqueAsync(txtEmail.Text);
                    if (!isEmailUnique)
                    {
                        lblMessage.Text = "Podany adres e-mail jest już zajęty.";
                        lblMessage.Visible = true;
                        return;
                    }

                   
                    var newUser = new User
                    {
                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        PasswordHash = PasswordHasher.HashPassword(txtPassword.Text), 
                        PhoneNumber = txtPhone.Text.Trim(),
                        Role = cmbRole.SelectedItem.ToString(),
                    };
                    _db.Users.Add(newUser);
                    await _db.SaveChangesAsync();
                    MessageBox.Show("Nowy użytkownik został dodany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas zapisu: {ex.Message}", true);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                ShowMessage("Pola email, imię, nazwisko i telefon są wymagane.", true);
                return false;
            }

            if (!_userIdToEdit.HasValue)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    ShowMessage("Hasło i potwierdzenie hasła są wymagane dla nowego użytkownika.", true);
                    return false;
                }
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    ShowMessage("Hasła nie są zgodne.", true);
                    return false;
                }
                if (txtPassword.Text.Length < 8 || 
                    !Regex.IsMatch(txtPassword.Text, "[A-Z]") || 
                    !Regex.IsMatch(txtPassword.Text, "[a-z]") || 
                    !Regex.IsMatch(txtPassword.Text, "[0-9]") || 
                    !Regex.IsMatch(txtPassword.Text, "[^a-zA-Z0-9]")) 
                {
                    ShowMessage("Hasło musi mieć co najmniej 8 znaków, zawierać dużą literę, małą literę, cyfrę i znak specjalny.", true);
                    return false;
                }
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowMessage("Niepoprawny format adresu e-mail.", true);
                return false;
            }

            if (txtPhone.Text.Length < 9 || !Regex.IsMatch(txtPhone.Text, @"^\d{9,12}$")) 
            {
                ShowMessage("Numer telefonu musi zawierać od 9 do 12 cyfr i składać się tylko z cyfr.", true);
                return false;
            }

            ShowMessage("", false); 
            return true;
        }

        private async Task<bool> IsEmailUniqueAsync(string email)
        {
            var existingUser = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            return existingUser == null || (existingUser.UserId == _userIdToEdit);
        }

        private async void TxtEmail_Leave(object sender, EventArgs e) 
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    ShowMessage("Niepoprawny format adresu e-mail.", true);
                }
                else
                {
                    bool isUnique = await IsEmailUniqueAsync(txtEmail.Text); 
                    if (!isUnique)
                    {
                        ShowMessage("Podany adres e-mail jest już zajęty.", true);
                    }
                    else
                    {
                        ShowMessage("", false); 
                    }
                }
            }
            else
            {
                ShowMessage("", false);
            }
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtPhone_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPhone.Text) && (txtPhone.Text.Length < 9 || !Regex.IsMatch(txtPhone.Text, @"^\d+$")))
            {
                ShowMessage("Numer telefonu musi zawierać co najmniej 9 cyfr i składać się tylko z cyfr.", true);
            }
            else
            {
                ShowMessage("", false);
            }
        }

        private void ShowMessage(string message, bool isError)
        {
            if (lblMessage != null)
            {
                lblMessage.Text = message;
                lblMessage.ForeColor = isError ? Color.Red : Color.DarkGreen;
                lblMessage.Visible = !string.IsNullOrEmpty(message);
            }
        }

        private static class PasswordHasher
        {
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }
        }
    }
}