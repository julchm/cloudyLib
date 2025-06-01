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
            if (lblTitle != null)
            {
                lblTitle.Text = "Moje Wypożyczenia";
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (dgvMyLoans != null)
            {
                dgvMyLoans.AutoGenerateColumns = false;
                dgvMyLoans.ReadOnly = true;
                dgvMyLoans.AllowUserToAddRows = false;
                dgvMyLoans.AllowUserToDeleteRows = false;
                dgvMyLoans.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvMyLoans.MultiSelect = false;

                dgvMyLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookTitle", HeaderText = "Tytuł Książki", DataPropertyName = "BookTitle", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvMyLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoanDate", HeaderText = "Data Wypożyczenia", DataPropertyName = "LoanDate", ReadOnly = true, Width = 150 });
                dgvMyLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "PlannedReturnDate", HeaderText = "Planowany Zwrot", DataPropertyName = "PlannedReturnDate", ReadOnly = true, Width = 150 });
                dgvMyLoans.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReturnDate", HeaderText = "Data Zwrotu", DataPropertyName = "ReturnDate", ReadOnly = true, Width = 150 });

                DataGridViewButtonColumn rateButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "RateBook",
                    HeaderText = "Oceń",
                    Text = "Oceń",
                    UseColumnTextForButtonValue = true,
                    Width = 80,
                    Tag = "RateButton" 
                };
                dgvMyLoans.Columns.Add(rateButtonColumn);

                dgvMyLoans.CellFormatting += DgvMyLoans_CellFormatting;
                dgvMyLoans.CellContentClick += DgvMyLoans_CellContentClick; 
            }

            if (lblMessage != null)
            {
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblMessage.Visible = false;
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
                                                            ? (bl.PlannedReturnDate.Value - DateTime.Today).TotalDays
                                                            : (double?)null,
                                         CanRate = bl.ReturnDate.HasValue 
                                     })
                                     .ToListAsync();

                if (dgvMyLoans != null)
                {
                    dgvMyLoans.DataSource = loans;
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
            if (e.RowIndex >= 0 && dgvMyLoans.Rows[e.RowIndex].DataBoundItem != null)
            {
                dynamic rowData = dgvMyLoans.Rows[e.RowIndex].DataBoundItem;

                if (rowData.DaysUntilReturn.HasValue)
                {
                    double days = rowData.DaysUntilReturn.Value;
                    if (days <= 0) 
                    {
                        dgvMyLoans.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral; 
                    }
                    else if (days <= 7) 
                    {
                        dgvMyLoans.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow; 
                    }
                }
            }
        }

        private async void DgvMyLoans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMyLoans.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var clickedColumn = dgvMyLoans.Columns[e.ColumnIndex];
                if (clickedColumn.Name == "RateBook")
                {
                    dynamic rowData = dgvMyLoans.Rows[e.RowIndex].DataBoundItem;
                    int bookId = rowData.BookId;
                    bool canRate = rowData.CanRate;

                    if (!canRate)
                    {
                        MessageBox.Show("Możesz ocenić książkę tylko po jej zwróceniu.", "Brak możliwości oceny", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (_mainForm._currentUser == null)
                    {
                        MessageBox.Show("Aby ocenić książkę, musisz być zalogowany.", "Błąd autoryzacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    
                    var bookTitle = rowData.BookTitle;

                    // Otwórz formularz oceny i recenzji
                    var rateReviewForm = new RateReviewForm(bookId, bookTitle, _db, _mainForm._currentUser);


                    if (rateReviewForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Dziękujemy za ocenę!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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
    }
}