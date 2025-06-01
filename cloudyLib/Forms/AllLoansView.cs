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
            this.Load += async (s, e) => await LoadLoans(); // Załaduj wypożyczenia przy starcie widoku
        }

        private void ConfigureAllLoansView()
        {
            if (lblTitle != null)
            {
                lblTitle.Text = "Zarządzanie Wypożyczeniami";
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (dgvAllLoans != null)
            {
                dgvAllLoans.AutoGenerateColumns = false;
                dgvAllLoans.ReadOnly = true; // Ogólnie tylko do odczytu, edycja przez formularz
                dgvAllLoans.AllowUserToAddRows = false;
                dgvAllLoans.AllowUserToDeleteRows = false;
                dgvAllLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvAllLoans.MultiSelect = false;

                // Definicja kolumn
                dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookLoanId", HeaderText = "ID Wypożyczenia", DataPropertyName = "BookLoanId", ReadOnly = true, Width = 80 });
                dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookTitle", HeaderText = "Tytuł Książki", DataPropertyName = "BookTitle", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "UserFullName", HeaderText = "Użytkownik", DataPropertyName = "UserFullName", ReadOnly = true, Width = 200 });
                dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoanDate", HeaderText = "Data Wypożyczenia", DataPropertyName = "LoanDate", ReadOnly = true, Width = 150 });
                dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "PlannedReturnDate", HeaderText = "Planowany Zwrot", DataPropertyName = "PlannedReturnDate", ReadOnly = true, Width = 150 });
                dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReturnDate", HeaderText = "Data Zwrotu", DataPropertyName = "ReturnDate", ReadOnly = true, Width = 150 });
                dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status", ReadOnly = true, Width = 100 }); // Status wypożyczenia

                // Ukryte kolumny dla danych Book/User ID
                dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookId", DataPropertyName = "BookId", Visible = false });
                dgvAllLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "UserId", DataPropertyName = "UserId", Visible = false });

                // Obsługa zdarzeń
                dgvAllLoans.CellFormatting += DgvAllLoans_CellFormatting;
                dgvAllLoans.CellDoubleClick += DgvAllLoans_CellDoubleClick; // Edycja przez podwójne kliknięcie
            }

            if (txtSearch != null) txtSearch.KeyPress += TxtSearch_KeyPress;
            if (btnSearch != null) btnSearch.Click += (s, e) => LoadLoans();

            if (btnAddLoan != null) btnAddLoan.Click += BtnAddLoan_Click;
            if (btnEditLoan != null) btnEditLoan.Click += BtnEditLoan_Click;
            if (btnDeleteLoan != null) btnDeleteLoan.Click += BtnDeleteLoan_Click;
            if (btnReturnBook != null) btnReturnBook.Click += BtnReturnBook_Click;

            if (lblMessage != null)
            {
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblMessage.Visible = false;
            }
        }

        public async Task LoadLoans()
        {
            ShowMessage("Ładowanie wypożyczeń...", false);
            try
            {
                var query = _db.BookLoans
                                 .Include(bl => bl.Book) // Dołącz dane książki
                                 .Include(bl => bl.User) // Dołącz dane użytkownika
                                 .AsQueryable();

                if (txtSearch != null && !string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    var searchTerm = txtSearch.Text.Trim().ToLower();
                    query = query.Where(bl => bl.Book.Title.ToLower().Contains(searchTerm) ||
                                              bl.User.FirstName.ToLower().Contains(searchTerm) ||
                                              bl.User.LastName.ToLower().Contains(searchTerm) ||
                                              bl.User.Email.ToLower().Contains(searchTerm));
                }

                // Domyślnie najpierw aktywne wypożyczenia (ReturnDate == null)
                var loans = await query
                                     .OrderBy(bl => bl.ReturnDate.HasValue) // false (null) przed true (nie-null)
                                     .ThenByDescending(bl => bl.LoanDate) // Najnowsze na górze
                                     .Select(bl => new
                                     {
                                         bl.BookLoanId,
                                         bl.BookId,
                                         bl.UserId,
                                         BookTitle = bl.Book.Title,
                                         UserFullName = $"{bl.User.FirstName} {bl.User.LastName} ({bl.User.Email})",
                                         LoanDate = bl.LoanDate.ToShortDateString(), // Formatowanie daty
                                         PlannedReturnDate = bl.PlannedReturnDate.HasValue ? bl.PlannedReturnDate.Value.ToShortDateString() : "-",
                                         ReturnDate = bl.ReturnDate.HasValue ? bl.ReturnDate.Value.ToShortDateString() : "Aktywne",
                                         Status = bl.ReturnDate == null ? "Aktywne" : "Zwrócono"
                                     })
                                     .ToListAsync();

                if (dgvAllLoans != null)
                {
                    dgvAllLoans.DataSource = loans;
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
            // Koloryzacja wierszy dla wypożyczeń
            if (e.RowIndex >= 0 && dgvAllLoans.Rows[e.RowIndex].DataBoundItem != null)
            {
                dynamic rowData = dgvAllLoans.Rows[e.RowIndex].DataBoundItem;

                if (rowData.Status == "Aktywne" && rowData.PlannedReturnDate != "-") // Tylko dla aktywnych z datą planowanego zwrotu
                {
                    // Konwersja PlannedReturnDate z stringa na DateTime, aby obliczyć różnicę
                    if (DateTime.TryParse(rowData.PlannedReturnDate, out DateTime plannedReturn))
                    {
                        TimeSpan timeLeft = plannedReturn - DateTime.Today;
                        if (timeLeft.TotalDays <= 0) // Termin minął lub jest dzisiaj
                        {
                            dgvAllLoans.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral; // Czerwony dla przeterminowanych
                            dgvAllLoans.Rows[e.RowIndex].Cells["Status"].Value = "PRZETERMINOWANE!";
                            dgvAllLoans.Rows[e.RowIndex].Cells["Status"].Style.Font = new Font(dgvAllLoans.Font, FontStyle.Bold);
                        }
                        else if (timeLeft.TotalDays <= 7) // Tydzień lub mniej do zwrotu
                        {
                            dgvAllLoans.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow; // Żółty dla zbliżających się
                        }
                    }
                }
            }
        }

        private async void BtnAddLoan_Click(object sender, EventArgs e)
        {
            // Otwórz formularz dodawania wypożyczenia
            var addEditLoanForm = _serviceProvider.GetRequiredService<AddEditLoanForm>();
            addEditLoanForm.SetLoanToEdit(null); // Tryb dodawania

            if (addEditLoanForm.ShowDialog() == DialogResult.OK)
            {
                await LoadLoans(); // Odśwież listę po dodaniu
                ShowMessage("Nowe wypożyczenie zostało dodane.", false);
            }
        }

        private async void BtnEditLoan_Click(object sender, EventArgs e)
        {
            if (dgvAllLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać wypożyczenie do edycji.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedLoanId = (int)dgvAllLoans.SelectedRows[0].Cells["BookLoanId"].Value;
            var addEditLoanForm = _serviceProvider.GetRequiredService<AddEditLoanForm>();
            addEditLoanForm.SetLoanToEdit(selectedLoanId); // Tryb edycji

            if (addEditLoanForm.ShowDialog() == DialogResult.OK)
            {
                await LoadLoans(); // Odśwież listę po edycji
                ShowMessage("Wypożyczenie zostało zaktualizowane.", false);
            }
        }

        private async void DgvAllLoans_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnEditLoan_Click(this, EventArgs.Empty); // Edycja przez podwójne kliknięcie
            }
        }

        private async void BtnDeleteLoan_Click(object sender, EventArgs e)
        {
            if (dgvAllLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać wypożyczenie do usunięcia.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedLoanId = (int)dgvAllLoans.SelectedRows[0].Cells["BookLoanId"].Value;
            var bookTitle = dgvAllLoans.SelectedRows[0].Cells["BookTitle"].Value.ToString();

            var confirmResult = MessageBox.Show($"Czy na pewno chcesz usunąć wypożyczenie książki '{bookTitle}'?", "Potwierdź usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                ShowMessage("Usuwanie wypożyczenia...", false);
                try
                {
                    var loanToDelete = await _db.BookLoans.FindAsync(selectedLoanId);
                    if (loanToDelete != null)
                    {
                        // Logika aktualizacji dostępności książki po usunięciu wypożyczenia (jeśli było aktywne)
                        if (loanToDelete.ReturnDate == null)
                        {
                            var book = await _db.Books.FindAsync(loanToDelete.BookId);
                            if (book != null)
                            {
                                book.AvailableCopies++; // Zwiększ dostępność
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
                    ShowMessage($"Błąd podczas usuwania wypożyczenia: {ex.Message}", true);
                }
            }
        }

        private async void BtnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvAllLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać wypożyczenie do oznaczenia jako zwrócone.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedLoanId = (int)dgvAllLoans.SelectedRows[0].Cells["BookLoanId"].Value;

            try
            {
                var loanToReturn = await _db.BookLoans
                                            .Include(bl => bl.Book) // Dołącz książkę, aby zaktualizować jej dostępność
                                            .FirstOrDefaultAsync(bl => bl.BookLoanId == selectedLoanId);

                if (loanToReturn != null && loanToReturn.ReturnDate == null) // Jeśli wypożyczenie jest aktywne
                {
                    loanToReturn.ReturnDate = DateTime.Today; // Ustaw dzisiejszą datę zwrotu
                    _db.BookLoans.Update(loanToReturn);

                    // Zwiększ dostępność książki
                    if (loanToReturn.Book != null)
                    {
                        loanToReturn.Book.AvailableCopies++; // Zwiększ AvailableCopies
                        _db.Books.Update(loanToReturn.Book);
                    }

                    await _db.SaveChangesAsync();
                    MessageBox.Show($"Książka '{loanToReturn.Book.Title}' została oznaczona jako zwrócona.", "Zwrot książki", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadLoans(); // Odśwież listę
                }
                else
                {
                    MessageBox.Show("Wybrane wypożyczenie zostało już zwrócone lub jest nieaktywne.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas oznaczania zwrotu: {ex.Message}", true);
            }
        }


        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch?.PerformClick();
                e.Handled = true;
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