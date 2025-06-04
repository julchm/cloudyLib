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
            this.Load += async (s, e) => await LoadUsers(); 
        }

        private void ConfigureManageUsersControls()
        {
            if (this.lblTitle != null)
            {
                this.lblTitle.Text = "Zarządzanie Użytkownikami";
                this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (this.dgvUsers != null)
            {
                this.dgvUsers.AutoGenerateColumns = false;
                this.dgvUsers.ReadOnly = true;
                this.dgvUsers.AllowUserToAddRows = false;
                this.dgvUsers.AllowUserToDeleteRows = false;
                this.dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvUsers.MultiSelect = false;

               
                this.dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "UserId", HeaderText = "ID", DataPropertyName = "UserId", ReadOnly = true, Width = 50 });
                this.dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "FirstName", HeaderText = "Imię", DataPropertyName = "FirstName", ReadOnly = true, Width = 120 });
                this.dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "LastName", HeaderText = "Nazwisko", DataPropertyName = "LastName", ReadOnly = true, Width = 150 });
                this.dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", DataPropertyName = "Email", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                this.dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Phone", HeaderText = "Telefon", DataPropertyName = "PhoneNumber", ReadOnly = true, Width = 120 });
                this.dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Role", HeaderText = "Rola", DataPropertyName = "Role", ReadOnly = true, Width = 100 });

            }

            
            if (this.btnAddUser != null) this.btnAddUser.Click += BtnAddUser_Click;
            if (this.btnEditUser != null) this.btnEditUser.Click += BtnEditUser_Click;
            if (this.btnDeleteUser != null) this.btnDeleteUser.Click += BtnDeleteUser_Click;

            if (this.txtSearchUser != null) this.txtSearchUser.KeyPress += TxtSearchUser_KeyPress;
            if (this.btnSearchUser != null) this.btnSearchUser.Click += (s, e) => LoadUsers();

            if (this.lblMessage != null)
            {
                this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                this.lblMessage.Visible = false;
            }
        }

        public async Task LoadUsers()
        {
            this.ShowMessage("Ładowanie użytkowników...", false);
            try
            {
                var query = _db.Users.AsQueryable();

                if (this.txtSearchUser != null && !string.IsNullOrWhiteSpace(this.txtSearchUser.Text))
                {
                    var searchTerm = this.txtSearchUser.Text.Trim().ToLower();
                    query = query.Where(u => u.Email.ToLower().Contains(searchTerm) ||
                                             u.FirstName.ToLower().Contains(searchTerm) ||
                                             u.LastName.ToLower().Contains(searchTerm));
                }

                var users = await query
                                           .OrderBy(u => u.UserId) 
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

                if (this.dgvUsers != null)
                {
                    this.dgvUsers.DataSource = users;
                }

                this.ShowMessage("", false);
                if (!users.Any())
                {
                    this.ShowMessage("Brak użytkowników spełniających kryteria.", false);
                }
            }
            catch (Exception ex)
            {
                this.ShowMessage($"Błąd podczas ładowania użytkowników: {ex.Message}", true);
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
            if (this.dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać użytkownika do edycji.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedUserId = (int)this.dgvUsers.SelectedRows[0].Cells["UserId"].Value;
            var addEditUserForm = _serviceProvider.GetRequiredService<AddEditUserForm>();
            addEditUserForm.SetUserToEdit(selectedUserId);

            if (addEditUserForm.ShowDialog() == DialogResult.OK)
            {
                await LoadUsers();
            }
        }

        private async void BtnDeleteUser_Click(object sender, EventArgs EventArgs)
        {
            if (this.dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać użytkownika do usunięcia.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedUserId = (int)this.dgvUsers.SelectedRows[0].Cells["UserId"].Value;
            var userEmail = this.dgvUsers.SelectedRows[0].Cells["Email"].Value?.ToString();

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
            this.ShowMessage("Usuwanie użytkownika...", false);
            try
            {
                var hasActiveLoans = await _db.BookLoans.AnyAsync(bl => bl.UserId == userId && bl.ReturnDate == null);
                if (hasActiveLoans)
                {
                    MessageBox.Show($"Nie można usunąć użytkownika '{userEmail}', ponieważ posiada aktywne wypożyczenia. Najpierw musi zwrócić wszystkie książki.", "Błąd usuwania", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var userReviews = await _db.Reviews.Where(r => r.UserId == userId).ToListAsync();
                if (userReviews.Any()) this._db.Reviews.RemoveRange(userReviews);

                var userRates = await _db.Rates.Where(r => r.UserId == userId).ToListAsync();
                if (userRates.Any()) this._db.Rates.RemoveRange(userRates);

                var userToDelete = await _db.Users
                                            .FirstOrDefaultAsync(u => u.UserId == userId);
                if (userToDelete != null)
                {
                    this._db.Users.Remove(userToDelete);
                    await _db.SaveChangesAsync();
                    MessageBox.Show($"Użytkownik '{userEmail}' został usunięty pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsers();
                }
            }
            catch (Exception ex)
            {
                this.ShowMessage($"Błąd podczas usuwania użytkownika: {ex.Message}", true);
            }
        }

        private void TxtSearchUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnSearchUser?.PerformClick();
                e.Handled = true;
            }
        }

        private void ShowMessage(string message, bool isError)
        {
            if (this.lblMessage != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() => ShowMessage(message, isError)));
                    return;
                }
                this.lblMessage.Text = message;
                this.lblMessage.ForeColor = isError ? Color.Red : Color.DarkGreen;
                this.lblMessage.Visible = !string.IsNullOrEmpty(message);
            }
        }

    }
}