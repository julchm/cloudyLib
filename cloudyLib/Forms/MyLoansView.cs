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
    public partial class MyLoansView : UserControl
    {
        private readonly LibraryDbContext _db;
        private readonly MainForm _mainForm;
        private readonly IServiceProvider _serviceProvider;

        public MyLoansView(LibraryDbContext db, MainForm mainForm, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            ConfigureMyLoansView();
        }

        private void ConfigureMyLoansView()
        {
            if (this.lblTitle != null)
            {
                this.lblTitle.Text = "Moje Wypożyczenia";
                this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (this.dgvMyLoans != null)
            {
                this.dgvMyLoans.AutoGenerateColumns = false;
                this.dgvMyLoans.ReadOnly = true;
                this.dgvMyLoans.AllowUserToAddRows = false;
                this.dgvMyLoans.AllowUserToDeleteRows = false;
                this.dgvMyLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvMyLoans.MultiSelect = false;

                this.dgvMyLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookTitle", HeaderText = "Tytuł Książki", DataPropertyName = "BookTitle", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                this.dgvMyLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoanDate", HeaderText = "Data Wypożyczenia", DataPropertyName = "LoanDate", ReadOnly = true, Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "d" } });
                this.dgvMyLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "PlannedReturnDate", HeaderText = "Planowany Zwrot", DataPropertyName = "PlannedReturnDate", ReadOnly = true, Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "d" } });
                this.dgvMyLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReturnDate", HeaderText = "Data Zwrotu", DataPropertyName = "ReturnDate", ReadOnly = true, Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "d" } });

                DataGridViewButtonColumn returnButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "ReturnBook",
                    HeaderText = "Zwrot",
                    Text = "Zwróć",
                    UseColumnTextForButtonValue = true,
                    Width = 80
                };
                this.dgvMyLoans.Columns.Add(returnButtonColumn);

                DataGridViewButtonColumn rateButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "RateBook",
                    HeaderText = "Oceń",
                    Text = "Oceń",
                    UseColumnTextForButtonValue = true,
                    Width = 80
                };
                this.dgvMyLoans.Columns.Add(rateButtonColumn);


                this.dgvMyLoans.CellFormatting += DgvMyLoans_CellFormatting;
                this.dgvMyLoans.CellContentClick += DgvMyLoans_CellContentClick;
            }

            if (this.lblMessage != null)
            {
                this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                this.lblMessage.Visible = false;
            }

            this.Load += async (s, e) => await LoadMyLoans();
        }

        public async Task LoadMyLoans()
        {
            ShowMessage("Ładowanie wypożyczeń...", false);
            try
            {
                if (_mainForm._currentUser == null)
                {
                    ShowMessage("Błąd: Użytkownik nie jest zalogowany.", true);
                    return;
                }

                var userId = _mainForm._currentUser.UserId;

                var loans = await _db.BookLoans
                                           .Include(bl => bl.Book)
                                           .Where(bl => bl.UserId == userId)
                                           .OrderByDescending(bl => bl.LoanDate)
                                           .Select(bl => new
                                           {
                                               bl.BookId,
                                               bl.LoanDate,
                                               bl.PlannedReturnDate,
                                               bl.ReturnDate,
                                               BookTitle = bl.Book.Title,
                                               DaysUntilReturn = (bl.ReturnDate == null && bl.PlannedReturnDate.HasValue)
                                                                 ? (double?)(bl.PlannedReturnDate.Value - DateTime.Today).TotalDays
                                                                 : (double?)null,
                                               IsReturned = bl.ReturnDate.HasValue
                                           })
                                           .ToListAsync();

                if (this.dgvMyLoans != null)
                {
                    this.dgvMyLoans.DataSource = loans;
                }

                ShowMessage("", false);
                if (!loans.Any())
                {
                    ShowMessage("Brak wypożyczeń w historii.", false);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas ładowania wypożyczeń: {ex.Message}", true);
            }
        }

        private void DgvMyLoans_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvMyLoans == null || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            dynamic rowData = this.dgvMyLoans.Rows[e.RowIndex].DataBoundItem;
            if (rowData == null) return;

            double? daysUntilReturnNullable = rowData.DaysUntilReturn as double?;

            if (daysUntilReturnNullable.HasValue) 
            {
                double days = daysUntilReturnNullable.Value; 
                if (days <= 0)
                {
                    this.dgvMyLoans.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else if (days <= 7)
                {
                    this.dgvMyLoans.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                }
            }


            if (this.dgvMyLoans.Columns[e.ColumnIndex].Name == "ReturnBook")
            {
                if (rowData.IsReturned)
                {
                    e.Value = "Zwrócona";
                    e.CellStyle.ForeColor = Color.DarkGray;
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.SelectionBackColor = Color.LightGray;
                    e.CellStyle.SelectionForeColor = Color.DarkGray;
                }
                else
                {
                    e.Value = "Zwróć";
                    e.CellStyle.ForeColor = this.dgvMyLoans.DefaultCellStyle.ForeColor;
                    e.CellStyle.BackColor = this.dgvMyLoans.DefaultCellStyle.BackColor;
                    e.CellStyle.SelectionBackColor = this.dgvMyLoans.DefaultCellStyle.SelectionBackColor;
                    e.CellStyle.SelectionForeColor = this.dgvMyLoans.DefaultCellStyle.SelectionForeColor;
                }
                e.FormattingApplied = true;
            }

            if (this.dgvMyLoans.Columns[e.ColumnIndex].Name == "RateBook")
            {
                if (!rowData.IsReturned)
                {
                    e.Value = "Nie zwrócona";
                    e.CellStyle.ForeColor = Color.DarkGray;
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.SelectionBackColor = Color.LightGray;
                    e.CellStyle.SelectionForeColor = Color.DarkGray;
                }
                else
                {
                    e.Value = "Oceń";
                    e.CellStyle.ForeColor = this.dgvMyLoans.DefaultCellStyle.ForeColor;
                    e.CellStyle.BackColor = this.dgvMyLoans.DefaultCellStyle.BackColor;
                    e.CellStyle.SelectionBackColor = this.dgvMyLoans.DefaultCellStyle.SelectionBackColor;
                    e.CellStyle.SelectionForeColor = this.dgvMyLoans.DefaultCellStyle.SelectionForeColor;
                }
                e.FormattingApplied = true;
            }
        }


        private async void DgvMyLoans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvMyLoans.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                dynamic rowData = this.dgvMyLoans.Rows[e.RowIndex].DataBoundItem;
                if (rowData == null) return;

                if (this.dgvMyLoans.Columns[e.ColumnIndex].Name == "ReturnBook")
                {
                    if (rowData.IsReturned)
                    {
                        MessageBox.Show("Ta książka została już zwrócona.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var confirmResult = MessageBox.Show($"Czy na pewno chcesz zwrócić książkę '{rowData.BookTitle}'?", "Potwierdź zwrot", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        await TryReturnBook(rowData.BookId, rowData.BookTitle);
                    }
                }
                else if (this.dgvMyLoans.Columns[e.ColumnIndex].Name == "RateBook")
                {
                    if (!rowData.IsReturned)
                    {
                        MessageBox.Show("Możesz ocenić książkę tylko po jej zwróceniu.", "Brak możliwości oceny", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (_mainForm._currentUser == null)
                    {
                        MessageBox.Show("Aby ocenić książkę, musisz być zalogowany.", "Błąd autoryzacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var rateReviewForm = new RateReviewForm(rowData.BookId, rowData.BookTitle, _db, _mainForm._currentUser);
                    if (rateReviewForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Dziękujemy za ocenę!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadMyLoans(); 
                    }
                }
            }
        }

        private async Task TryReturnBook(int bookId, string bookTitle)
        {
            try
            {
                var loanToReturn = await _db.BookLoans
                                            .Include(bl => bl.Book)
                                            .FirstOrDefaultAsync(bl => bl.BookId == bookId && bl.UserId == _mainForm._currentUser.UserId && bl.ReturnDate == null);

                if (loanToReturn == null)
                {
                    MessageBox.Show($"Błąd: Nie znaleziono aktywnego wypożyczenia dla książki '{bookTitle}'.", "Błąd zwrotu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                loanToReturn.ReturnDate = DateTime.Now;
                loanToReturn.Book.AvailableCopies++;
                await _db.SaveChangesAsync();

                MessageBox.Show($"Książka '{bookTitle}' została pomyślnie zwrócona.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadMyLoans();
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas zwrotu książki: {ex.Message}", true);
            }
        }


        private void ShowMessage(string message, bool isError)
        {
            if (this.lblMessage != null)
            {
                this.lblMessage.Text = message;
                this.lblMessage.ForeColor = isError ? Color.Red : Color.DarkGreen;
                this.lblMessage.Visible = !string.IsNullOrEmpty(message);
            }
        }
    }
}