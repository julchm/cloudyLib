using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using cloudyLib.Data;
using cloudyLib.Models;

namespace cloudyLib.Forms
{
    public partial class RateReviewForm : Form
    {
        private readonly int _bookId;
        private readonly string _bookTitle;
        private readonly LibraryDbContext _db;
        private readonly User _currentUser;

        // Kontrolki z Designer.cs (zmienione nazwy z txtReview na txtReviewContent dla spójności z wcześniejszą sugestią)
        // Zakładam, że w Designer.cs kontrolka TextBox dla recenzji nazywa się 'txtReview'.
        // Jeśli tak, to w kodzie poniżej użyję 'txtReview'. Jeśli zmienisz ją na 'txtReviewContent' w Designerze,
        // to zmień też tutaj.

        public RateReviewForm(int bookId, string bookTitle, LibraryDbContext db, User currentUser)
        {
            InitializeComponent();
            _bookId = bookId;
            _bookTitle = bookTitle;
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            ConfigureFormControls();
            // LoadExistingReview(); // Wywołane w LoadExistingReviewAndRate dla kompleksowości
            // Zmieniono: LoadExistingReview jest teraz częścią LoadExistingReviewAndRate (moja poprzednia nazwa)
            // LUB LoadExistingReview() jest wystarczające, jeśli występuje w tym miejscu.
            // Zakładam, że LoadExistingReview jest OK, ale muszę zaktualizować odwołania w niej.
        }

        private void ConfigureFormControls()
        {
            this.Text = $"Oceń i zrecenzuj: {_bookTitle}";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.AntiqueWhite;

            if (lblBookTitle != null) lblBookTitle.Text = _bookTitle;
            if (numRating != null)
            {
                numRating.Minimum = 1;
                numRating.Maximum = 5;
                numRating.Value = 3;
            }
            // Zmieniono z txtReview na txtReviewContent dla spójności, jeśli to zmieniono w Designerze
            // Jeśli Twoja kontrolka to nadal 'txtReview', zostaw 'txtReview'.
            // Zakładam, że to jest 'txtReview' na podstawie Twojego Designera.
            // if (txtReview != null) { /* txtReview.TextChanged += TxtReview_TextChanged; */ }
            // Usuwamy zakomentowane linie, jeśli nie są używane.
            if (btnSubmit != null) btnSubmit.Click += BtnSubmit_Click;
            if (btnCancel != null) btnCancel.Click += (s, e) => this.Close();
            if (lblMessage != null)
            {
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblMessage.Visible = false;
            }

            // Załaduj istniejące oceny/recenzje po skonfigurowaniu kontrolek
            this.Load += async (s, e) => await LoadExistingReview();
        }

        private async Task LoadExistingReview()
        {
            try
            {
                // Zmieniono na PascalCase: BookId, UserId, RateValue, Contents
                var existingRate = await _db.Rates
                                            .FirstOrDefaultAsync(r => r.BookId == _bookId && r.UserId == _currentUser.UserId);
                if (existingRate != null)
                {
                    if (numRating != null) numRating.Value = existingRate.RateValue;
                }

                // Zmieniono na PascalCase: BookId, UserId, Contents
                var existingReview = await _db.Reviews
                                              .FirstOrDefaultAsync(r => r.BookId == _bookId && r.UserId == _currentUser.UserId);
                if (existingReview != null)
                {
                    if (txtReview != null) txtReview.Text = existingReview.Contents; // Upewnij się, że nazwa kontrolki to 'txtReview'
                }
                // Komunikat tylko, jeśli faktycznie coś edytujemy
                if (existingRate != null || existingReview != null)
                {
                    ShowMessage("Edytujesz istniejącą ocenę/recenzję.", false);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas ładowania istniejącej recenzji: {ex.Message}", true);
            }
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            ShowMessage("Zapisywanie...", false);

            // Dodajemy walidację formularza przed zapisem
            if (!ValidateForm())
            {
                return;
            }

            try
            {
                // Zapis oceny
                var existingRate = await _db.Rates
                                            .FirstOrDefaultAsync(r => r.BookId == _bookId && r.UserId == _currentUser.UserId);
                if (existingRate != null)
                {
                    existingRate.RateValue = (int)numRating.Value;
                    _db.Rates.Update(existingRate);
                }
                else
                {
                    var newRate = new Rate
                    {
                        BookId = _bookId,
                        UserId = _currentUser.UserId,
                        RateValue = (int)numRating.Value
                    };
                    _db.Rates.Add(newRate);
                }

                // Zapis recenzji
                if (!string.IsNullOrWhiteSpace(txtReview.Text)) // Upewnij się, że nazwa kontrolki to 'txtReview'
                {
                    var existingReview = await _db.Reviews
                                                    .FirstOrDefaultAsync(r => r.BookId == _bookId && r.UserId == _currentUser.UserId);
                    if (existingReview != null)
                    {
                        existingReview.Contents = txtReview.Text.Trim(); // Upewnij się, że nazwa kontrolki to 'txtReview'
                        existingReview.DateAdded = DateTime.Now; // Zaktualizuj datę dodania recenzji
                        _db.Reviews.Update(existingReview);
                    }
                    else
                    {
                        var newReview = new Review
                        {
                            BookId = _bookId,
                            UserId = _currentUser.UserId,
                            Contents = txtReview.Text.Trim(), // Upewnij się, że nazwa kontrolki to 'txtReview'
                            DateAdded = DateTime.Now
                        };
                        _db.Reviews.Add(newReview);
                    }
                }
                else // Jeśli recenzja została usunięta przez użytkownika
                {
                    var existingReviewToDelete = await _db.Reviews
                                                            .FirstOrDefaultAsync(r => r.BookId == _bookId && r.UserId == _currentUser.UserId);
                    if (existingReviewToDelete != null)
                    {
                        _db.Reviews.Remove(existingReviewToDelete);
                    }
                }

                await _db.SaveChangesAsync();
                MessageBox.Show("Ocena i recenzja zostały zapisane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas zapisywania: {ex.Message}", true);
            }
        }

        // DODANA METODA WALIDACJI FORMULARZA
        private bool ValidateForm()
        {
            if (numRating == null || numRating.Value < 1 || numRating.Value > 5)
            {
                ShowMessage("Ocena musi być liczbą od 1 do 5.", true);
                return false;
            }
            // Możesz dodać walidację dla treści recenzji, np. min/max długość.
            // if (txtReview != null && txtReview.Text.Length > 1000) // Przykład
            // {
            //     ShowMessage("Recenzja jest za długa.", true);
            //     return false;
            // }
            return true;
        }


        private void ShowMessage(string message, bool isError)
        {
            if (lblMessage != null)
            {
                // Upewnij się, że dostęp do lblMessage jest bezpieczny wątkowo,
                // jeśli ShowMessage może być wywoływane z wątków innych niż UI.
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

        private void RateReviewForm_Load(object sender, EventArgs e) { /* Empty */ }
        private void lblBookTitle_Click(object sender, EventArgs e) { /* Empty */ }
        private void txtReview_TextChanged(object sender, EventArgs e) { /* Empty */ }
    }
}