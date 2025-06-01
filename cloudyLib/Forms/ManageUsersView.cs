using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using cloudyLib.Data;
using cloudyLib.Models;

namespace cloudyLib.Forms
{
    public partial class ManageUsersView : UserControl
    {
        private readonly LibraryDbContext _db;
        private readonly MainForm _mainForm;
        private readonly IServiceProvider _serviceProvider;

        public ManageUsersView(LibraryDbContext db, MainForm mainForm, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            ConfigureManageUsersControls();
            LoadUsers();
        }

        private void ConfigureManageUsersControls()
        {
            if (lblTitle != null)
            {
                lblTitle.Text = "Zarządzanie Użytkownikami";
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (dgvUsers != null)
            {
                dgvUsers.AutoGenerateColumns = false;
                dgvUsers.ReadOnly = true;
                dgvUsers.AllowUserToAddRows = false;
                dgvUsers.AllowUserToDeleteRows = false;
                dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsers.MultiSelect = false;

                dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "UserId", HeaderText = "ID", DataPropertyName = "UserId", ReadOnly = true, Width = 50 }); 
                dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "FirstName", HeaderText = "Imię", DataPropertyName = "FirstName", ReadOnly = true, Width = 120 }); 
                dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "LastName", HeaderText = "Nazwisko", DataPropertyName = "LastName", ReadOnly = true, Width = 150 });
                dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }); 
                dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Telefon", DataPropertyName = "PhoneNumber", ReadOnly = true, Width = 120 }); 
                dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Role", HeaderText = "Rola", DataPropertyName = "Role", ReadOnly = true, Width = 100 }); 
                
            }

            if (btnAddUser != null) btnAddUser.Click += BtnAddUser_Click;
            if (btnEditUser != null) btnEditUser.Click += BtnEditUser_Click;
            if (btnDeleteUser != null) btnDeleteUser.Click += BtnDeleteUser_Click;

            if (txtSearchUser != null) txtSearchUser.KeyPress += TxtSearchUser_KeyPress;
            if (btnSearchUser != null) btnSearchUser.Click += (s, e) => LoadUsers();

            if (lblMessage != null)
            {
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblMessage.Visible = false;
            }
        }

        public async Task LoadUsers()
        {
            ShowMessage("Ładowanie użytkowników...", false);
            try
            {
                var query = _db.Users.AsQueryable();

                if (txtSearchUser != null && !string.IsNullOrWhiteSpace(txtSearchUser.Text))
                {
                    var searchTerm = txtSearchUser.Text.Trim().ToLower();
                    query = query.Where(u => u.Email.ToLower().Contains(searchTerm) || 
                                             u.FirstName.ToLower().Contains(searchTerm) || 
                                             u.LastName.ToLower().Contains(searchTerm)); 
                }

                var users = await query
                                     .OrderBy(u => u.LastName) 
                                     .Select(u => new
                                     {
                                         u.UserId, 
                                         u.FirstName, 
                                         u.LastName, 
                                         u.Email, 
                                         u.PhoneNumber, 
                                         u.Role, 
                                     })
                                     .ToListAsync();

                if (dgvUsers != null)
                {
                    dgvUsers.DataSource = users;
                }

                ShowMessage("", false);
                if (!users.Any())
                {
                    ShowMessage("Brak użytkowników spełniających kryteria.", false);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas ładowania użytkowników: {ex.Message}", true);
            }
        }


        private async void BtnAddUser_Click(object sender, EventArgs e)
        {
            var addEditUserForm = _serviceProvider.GetRequiredService<AddEditUserForm>();
            addEditUserForm.SetUserToEdit(null);

            if (addEditUserForm.ShowDialog() == DialogResult.OK)
            {
                await LoadUsers();
            }
        }

        private async void BtnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać użytkownika do edycji.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedUserId = (int)dgvUsers.SelectedRows[0].Cells["UserId"].Value;
            var addEditUserForm = _serviceProvider.GetRequiredService<AddEditUserForm>();
            addEditUserForm.SetUserToEdit(selectedUserId);

            if (addEditUserForm.ShowDialog() == DialogResult.OK)
            {
                await LoadUsers();
            }
        }

        private async void BtnDeleteUser_Click(object sender, EventArgs EventArgs)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać użytkownika do usunięcia.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedUserId = (int)dgvUsers.SelectedRows[0].Cells["UserId"].Value; 
            var userEmail = dgvUsers.SelectedRows[0].Cells["Email"].Value.ToString(); 

            if (_mainForm._currentUser != null && selectedUserId == _mainForm._currentUser.UserId) 
            {
                MessageBox.Show("Nie możesz usunąć własnego konta.", "Błąd usuwania", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show($"Czy na pewno chcesz usunąć użytkownika '{userEmail}'?", "Potwierdź usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                await TryDeleteUser(selectedUserId, userEmail);
            }
        }

        private async Task TryDeleteUser(int userId, string userEmail)
        {
            ShowMessage("Usuwanie użytkownika...", false);
            try
            {
                // Sprawdzenie aktywnych wypożyczeń 
                var hasActiveLoans = await _db.BookLoans.AnyAsync(bl => bl.UserId == userId && bl.ReturnDate == null); 
                if (hasActiveLoans)
                {
                    MessageBox.Show($"Nie można usunąć użytkownika '{userEmail}', ponieważ posiada aktywne wypożyczenia. Najpierw musi zwrócić wszystkie książki.", "Błąd usuwania", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var userReviews = await _db.Reviews.Where(r => r.UserId == userId).ToListAsync(); 
                if (userReviews.Any()) _db.Reviews.RemoveRange(userReviews);

                var userRates = await _db.Rates.Where(r => r.UserId == userId).ToListAsync(); 
                if (userRates.Any()) _db.Rates.RemoveRange(userRates);

                var userToDelete = await _db.Users
                                                .FirstOrDefaultAsync(u => u.UserId == userId); 
                if (userToDelete != null)
                {
                    _db.Users.Remove(userToDelete);
                    await _db.SaveChangesAsync();
                    MessageBox.Show($"Użytkownik '{userEmail}' został usunięty pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsers();
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas usuwania użytkownika: {ex.Message}", true);
            }
        }

        private void TxtSearchUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearchUser?.PerformClick();
                e.Handled = true;
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

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btnAddUser_Click_1(object sender, EventArgs e) { } // Ta metoda wydaje się być duplikatem BtnAddUser_Click. Sprawdź, czy nie jest to błąd projektanta.
    }
}