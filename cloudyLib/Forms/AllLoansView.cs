using System;
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
    public partial class AllLoansView : UserControl
    {
        private readonly LibraryDbContext _db;
        private readonly IServiceProvider _serviceProvider;


        public AllLoansView(LibraryDbContext db, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            ConfigureAllLoansView();
            this.Load += async (s, e) => await LoadLoans();
        }

        private void ConfigureAllLoansView()
        {
            if (this.lblTitle != null)
            {
                this.lblTitle.Text = "Zarządzanie Wypożyczeniami";
                this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (this.dgvAllLoans != null)
            {
                this.dgvAllLoans.AutoGenerateColumns = false;
                this.dgvAllLoans.ReadOnly = true;
                this.dgvAllLoans.AllowUserToAddRows = false;
                this.dgvAllLoans.AllowUserToDeleteRows = false;
                this.dgvAllLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvAllLoans.MultiSelect = false;

                this.dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookLoanId", HeaderText = "ID Wypożyczenia", DataPropertyName = "BookLoanId", ReadOnly = true, Width = 80 });
                this.dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookTitle", HeaderText = "Tytuł Książki", DataPropertyName = "BookTitle", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                this.dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "UserFullName", HeaderText = "Użytkownik", DataPropertyName = "UserFullName", ReadOnly = true, Width = 200 });
             
                this.dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoanDate", HeaderText = "Data Wypożyczenia", DataPropertyName = "LoanDate", ReadOnly = true, Width = 150 });
                this.dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "PlannedReturnDate", HeaderText = "Planowany Zwrot", DataPropertyName = "PlannedReturnDate", ReadOnly = true, Width = 150 });
                this.dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReturnDate", HeaderText = "Data Zwrotu", DataPropertyName = "ReturnDate", ReadOnly = true, Width = 150 });
                this.dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "StatusDisplay", ReadOnly = true, Width = 120 }); 

                this.dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookId", DataPropertyName = "BookId", Visible = false });
                this.dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "UserId", DataPropertyName = "UserId", Visible = false });

                this.dgvAllLoans.CellFormatting += DgvAllLoans_CellFormatting;
                this.dgvAllLoans.CellDoubleClick += DgvAllLoans_CellDoubleClick;
            }

            if (this.txtSearch != null) this.txtSearch.KeyPress += TxtSearch_KeyPress;
            if (this.btnSearch != null) this.btnSearch.Click += (s, e) => LoadLoans();

            if (this.btnAddLoan != null) this.btnAddLoan.Click += BtnAddLoan_Click;
            if (this.btnEditLoan != null) this.btnEditLoan.Click += BtnEditLoan_Click;
            if (this.btnDeleteLoan != null) this.btnDeleteLoan.Click += BtnDeleteLoan_Click;
            if (this.btnReturnBook != null) this.btnReturnBook.Click += BtnReturnBook_Click;

            if (this.lblMessage != null)
            {
                this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                this.lblMessage.Visible = false;
            }
        }

        public async Task LoadLoans()
        {
            ShowMessage("Ładowanie wypożyczeń...", false);
            try
            {
                var query = _db.BookLoans
                                   .Include(bl => bl.Book)
                                   .Include(bl => bl.User)
                                   .AsQueryable();

                if (this.txtSearch != null && !string.IsNullOrWhiteSpace(this.txtSearch.Text))
                {
                    var searchTerm = this.txtSearch.Text.Trim().ToLower();
                    query = query.Where(bl => bl.Book.Title.ToLower().Contains(searchTerm) ||
                                              bl.User.FirstName.ToLower().Contains(searchTerm) ||
                                              bl.User.LastName.ToLower().Contains(searchTerm) ||
                                              bl.User.Email.ToLower().Contains(searchTerm));
                }

                var loans = await query
                                           .OrderBy(bl => bl.BookLoanId)
                                           .Select(bl => new
                                           {
                                               bl.BookLoanId,
                                               bl.BookId,
                                               bl.UserId,
                                               BookTitle = bl.Book.Title,
                                               UserFullName = $"{bl.User.FirstName} {bl.User.LastName} ({bl.User.Email})",
                                               LoanDate = bl.LoanDate,
                                               PlannedReturnDate = bl.PlannedReturnDate,
                                               ReturnDate = bl.ReturnDate,
                                               StatusDisplay = bl.ReturnDate.HasValue ? "Zwrócono" : (bl.PlannedReturnDate.HasValue && (bl.PlannedReturnDate.Value - DateTime.Today).TotalDays <= 0 ? "PRZETERMINOWANE!" : "Aktywne")
                                           })
                                           .ToListAsync();

                if (this.dgvAllLoans != null)
                {
                    this.dgvAllLoans.DataSource = loans;
                }

                ShowMessage("", false);
                if (!loans.Any())
                {
                    ShowMessage("Brak wypożyczeń spełniających kryteria.", false);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas ładowania wypożyczeń: {ex.Message}", true);
            }
        }

        private void DgvAllLoans_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || this.dgvAllLoans.Rows[e.RowIndex].DataBoundItem == null) return;

            dynamic rowData = this.dgvAllLoans.Rows[e.RowIndex].DataBoundItem;
            string columnName = this.dgvAllLoans.Columns[e.ColumnIndex].Name;


            if (columnName == "LoanDate" || columnName == "PlannedReturnDate" || columnName == "ReturnDate")
            {
                DateTime? dateValue = null;
                if (columnName == "LoanDate") dateValue = rowData.LoanDate as DateTime?;
                else if (columnName == "PlannedReturnDate") dateValue = rowData.PlannedReturnDate as DateTime?;
                else if (columnName == "ReturnDate") dateValue = rowData.ReturnDate as DateTime?;

                if (dateValue.HasValue)
                {
                    e.Value = dateValue.Value.ToShortDateString();
                    e.FormattingApplied = true;
                }
                else if (columnName == "ReturnDate") 
                {
                    e.Value = "Aktywne";
                    e.FormattingApplied = true;
                }
                else 
                {
                    e.Value = "-";
                    e.FormattingApplied = true;
                }
            }

            if (columnName == "Status")
            {
                string statusText = rowData.StatusDisplay;
                e.Value = statusText;
                e.FormattingApplied = true; 

                if (statusText == "PRZETERMINOWANE!")
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.Font = new Font(this.dgvAllLoans.Font, FontStyle.Bold);
                }
                else if (statusText == "Zbliża się termin")
                {
                    e.CellStyle.BackColor = Color.LightYellow;
                }
                else if (statusText == "Zwrócono")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else 
                {
                    e.CellStyle.BackColor = Color.AntiqueWhite; 
                }
            }
        }


        private async void BtnAddLoan_Click(object sender, EventArgs e)
        {
            var addEditLoanForm = _serviceProvider.GetRequiredService<AddEditLoanForm>();
            addEditLoanForm.SetLoanToEdit(null);

            if (addEditLoanForm.ShowDialog() == DialogResult.OK)
            {
                await LoadLoans();
                this.ShowMessage("Nowe wypożyczenie zostało dodane.", false);
            }
        }

        private async void BtnEditLoan_Click(object sender, EventArgs e)
        {
            if (this.dgvAllLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać wypożyczenie do edycji.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedLoanId = (int)this.dgvAllLoans.SelectedRows[0].Cells["BookLoanId"].Value;
            var addEditLoanForm = _serviceProvider.GetRequiredService<AddEditLoanForm>();
            addEditLoanForm.SetLoanToEdit(selectedLoanId);

            if (addEditLoanForm.ShowDialog() == DialogResult.OK)
            {
                await LoadLoans();
                this.ShowMessage("Wypożyczenie zostało zaktualizowane.", false);
            }
        }

        private async void DgvAllLoans_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEditLoan_Click(this, EventArgs.Empty);
            }
        }

        private async void BtnDeleteLoan_Click(object sender, EventArgs e)
        {
            if (this.dgvAllLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać wypożyczenie do usunięcia.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedLoanId = (int)this.dgvAllLoans.SelectedRows[0].Cells["BookLoanId"].Value;
            var bookTitle = this.dgvAllLoans.SelectedRows[0].Cells["BookTitle"].Value?.ToString();

            var confirmResult = MessageBox.Show($"Czy na pewno chcesz usunąć wypożyczenie książki '{bookTitle}'?", "Potwierdź usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                this.ShowMessage("Usuwanie wypożyczenia...", false);
                try
                {
                    var loanToDelete = await _db.BookLoans.Include(bl => bl.Book).FirstOrDefaultAsync(bl => bl.BookLoanId == selectedLoanId);
                    if (loanToDelete != null)
                    {
                        if (loanToDelete.ReturnDate == null)
                        {
                            var book = await _db.Books.FindAsync(loanToDelete.BookId);
                            if (book != null)
                            {
                                book.AvailableCopies++;
                                _db.Books.Update(book);
                            }
                        }

                        _db.BookLoans.Remove(loanToDelete);
                        await _db.SaveChangesAsync();
                        MessageBox.Show($"Wypożyczenie książki '{bookTitle}' zostało usunięte pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadLoans();
                    }
                }
                catch (Exception ex)
                {
                    this.ShowMessage($"Błąd podczas usuwania wypożyczenia: {ex.Message}", true);
                }
            }
        }

        private async void BtnReturnBook_Click(object sender, EventArgs e)
        {
            if (this.dgvAllLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać wypożyczenie do oznaczenia jako zwrócone.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dynamic selectedLoanRowData = this.dgvAllLoans.SelectedRows[0].DataBoundItem;
            if (selectedLoanRowData == null) return;

            DateTime? returnDateFromRow = selectedLoanRowData.ReturnDate as DateTime?;

            if (returnDateFromRow.HasValue)
            {
                MessageBox.Show("Wybrane wypożyczenie zostało już zwrócone.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmResult = MessageBox.Show($"Czy na pewno chcesz oznaczyć wypożyczenie książki '{selectedLoanRowData.BookTitle}' jako zwrócone?", "Potwierdź zwrot", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                this.ShowMessage("Oznaczanie jako zwrócone...", false);
                try
                {
                    int selectedLoanId = selectedLoanRowData.BookLoanId;
                    var loanToReturn = await _db.BookLoans
                                                .Include(bl => bl.Book)
                                                .FirstOrDefaultAsync(bl => bl.BookLoanId == selectedLoanId);

                    if (loanToReturn != null && loanToReturn.ReturnDate == null)
                    {
                        loanToReturn.ReturnDate = DateTime.Today;
                        _db.BookLoans.Update(loanToReturn);

                        if (loanToReturn.Book != null)
                        {
                            loanToReturn.Book.AvailableCopies++;
                            _db.Books.Update(loanToReturn.Book);
                        }

                        await _db.SaveChangesAsync();
                        MessageBox.Show($"Książka '{loanToReturn.Book.Title}' została oznaczona jako zwrócona.", "Zwrot książki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadLoans();
                    }
                    else
                    {
                        MessageBox.Show("Wybrane wypożyczenie zostało już zwrócone lub jest nieaktywne.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    this.ShowMessage($"Błąd podczas oznaczania zwrotu: {ex.Message}", true);
                }
            }
        }


        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnSearch?.PerformClick();
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