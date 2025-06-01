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
    public partial class MyReviewsView : UserControl
    {
        private readonly LibraryDbContext _db;
        private readonly MainForm _mainForm;
        private readonly IServiceProvider _serviceProvider;


        public MyReviewsView(LibraryDbContext db, MainForm mainForm, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            ConfigureMyReviewsView();
            this.Load += async (s, e) => await LoadMyReviews();
        }

        private void ConfigureMyReviewsView()
        {
            if (lblTitle != null)
            {
                lblTitle.Text = "Moje Recenzje i Oceny";
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (dgvMyReviews != null)
            {
                dgvMyReviews.AutoGenerateColumns = false;
                dgvMyReviews.ReadOnly = true;
                dgvMyReviews.AllowUserToAddRows = false;
                dgvMyReviews.AllowUserToDeleteRows = false;
                dgvMyReviews.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvMyReviews.MultiSelect = false;

                dgvMyReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookTitle", HeaderText = "Tytuł Książki", DataPropertyName = "BookTitle", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvMyReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "Rating", HeaderText = "Ocena", DataPropertyName = "Rating", ReadOnly = true, Width = 80 });
                dgvMyReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "ReviewContent", HeaderText = "Treść Recenzji", DataPropertyName = "ReviewContent", ReadOnly = true, Width = 300 });
                dgvMyReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "DateAdded", HeaderText = "Data Dodania", DataPropertyName = "DateAdded", ReadOnly = true, Width = 150 });

                dgvMyReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookId", DataPropertyName = "BookId", Visible = false });
                dgvMyReviews.Columns.Add(new DataGridViewTextBoxColumn { Name = "UserId", DataPropertyName = "UserId", Visible = false });

                dgvMyReviews.CellDoubleClick += DgvMyReviews_CellDoubleClick; 
            }

            if (btnEditReview != null) btnEditReview.Click += BtnEditReview_Click;
            if (btnDeleteReview != null) btnDeleteReview.Click += BtnDeleteReview_Click;

            if (lblMessage != null)
            {
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblMessage.Visible = false;
            }
        }

        public async Task LoadMyReviews()
        {
            ShowMessage("Ładowanie recenzji i ocen...", false);
            try
            {
                if (_mainForm._currentUser == null)
                {
                    ShowMessage("Błąd: Użytkownik nie jest zalogowany.", true);
                    return;
                }

                var userId = _mainForm._currentUser.UserId;


                var reviewsAndRates = await _db.Books
                    .Select(b => new 
                    {
                        BookId = b.BookId,
                        BookTitle = b.Title,
                        UserReview = b.Reviews.FirstOrDefault(r => r.UserId == userId),
                        UserRate = b.Rates.FirstOrDefault(r => r.UserId == userId)
                    })
                    .Where(x => x.UserReview != null || x.UserRate != null) 
                    .Select(x => new
                    {
                        x.BookId,
                        x.BookTitle,
                        Rating = x.UserRate != null ? (int?)x.UserRate.RateValue : null, 
                        ReviewContent = x.UserReview != null ? x.UserReview.Contents : "Brak recenzji",
                        DateAdded = x.UserReview != null ? x.UserReview.DateAdded : (DateTime?)null, 
                        UserId = userId 
                    })
                    .OrderByDescending(x => x.DateAdded ?? DateTime.MinValue) 
                    .ToListAsync();

                if (dgvMyReviews != null)
                {
                    dgvMyReviews.DataSource = reviewsAndRates;
                }

                ShowMessage("", false);
                if (!reviewsAndRates.Any())
                {
                    ShowMessage("Brak recenzji i ocen w Twojej historii.", false);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas ładowania recenzji i ocen: {ex.Message}", true);
            }
        }

        private async void BtnEditReview_Click(object sender, EventArgs e)
        {
            if (dgvMyReviews.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać recenzję/ocenę do edycji.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            dynamic selectedRowData = dgvMyReviews.SelectedRows[0].DataBoundItem;
            int bookId = selectedRowData.BookId;
            string bookTitle = selectedRowData.BookTitle;
            int userId = selectedRowData.UserId; 

           
            var rateReviewForm = new RateReviewForm(bookId, bookTitle, _db, _mainForm._currentUser);

            if (rateReviewForm.ShowDialog() == DialogResult.OK)
            {
                await LoadMyReviews(); 
                MessageBox.Show("Recenzja/Ocena została zaktualizowana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void DgvMyReviews_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                BtnEditReview_Click(this, EventArgs.Empty); 
            }
        }

        private async void BtnDeleteReview_Click(object sender, EventArgs e)
        {
            if (dgvMyReviews.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać recenzję/ocenę do usunięcia.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dynamic selectedRowData = dgvMyReviews.SelectedRows[0].DataBoundItem;
            int bookId = selectedRowData.BookId;
            string bookTitle = selectedRowData.BookTitle;
            int userId = selectedRowData.UserId;

            var confirmResult = MessageBox.Show($"Czy na pewno chcesz usunąć recenzję i ocenę dla książki '{bookTitle}'?", "Potwierdź usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                ShowMessage("Usuwanie recenzji i ocen...", false);
                try
                {
                    var reviewToDelete = await _db.Reviews.FirstOrDefaultAsync(r => r.BookId == bookId && r.UserId == userId);
                    if (reviewToDelete != null)
                    {
                        _db.Reviews.Remove(reviewToDelete);
                    }

          
                    var rateToDelete = await _db.Rates.FirstOrDefaultAsync(r => r.BookId == bookId && r.UserId == userId);
                    if (rateToDelete != null)
                    {
                        _db.Rates.Remove(rateToDelete);
                    }

                    await _db.SaveChangesAsync();
                    await LoadMyReviews(); 
                    MessageBox.Show($"Recenzja i ocena dla '{bookTitle}' zostały usunięte pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ShowMessage($"Błąd podczas usuwania: {ex.Message}", true);
                }
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