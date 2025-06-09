using System;
using System.Collections.Generic;
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
    public partial class BookListView : UserControl
    {
        private readonly LibraryDbContext _db;
        private readonly MainForm _mainForm;
        private readonly IServiceProvider _serviceProvider;


        public BookListView(LibraryDbContext db, MainForm mainForm, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            ConfigureBookListControls();
            LoadInitialData();
        }

        private void ConfigureBookListControls()
        {
            if (dgvBooks != null)
            {
                dgvBooks.AutoGenerateColumns = false;
                dgvBooks.ReadOnly = true;
                dgvBooks.AllowUserToAddRows = false;
                dgvBooks.AllowUserToDeleteRows = false;
                dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvBooks.MultiSelect = false;


                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Title", HeaderText = "Tytuł", DataPropertyName = "Title", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Author", HeaderText = "Autor", DataPropertyName = "AuthorNames", ReadOnly = true, Width = 180 });
                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Genre", HeaderText = "Gatunek", DataPropertyName = "GenreNames", ReadOnly = true, Width = 150 });
                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "ISBN", HeaderText = "ISBN", DataPropertyName = "ISBN", ReadOnly = true, Width = 120 });
                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Availability", HeaderText = "Dostępność", DataPropertyName = "AvailableCopies", ReadOnly = true, Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "AverageRating", HeaderText = "Średnia Ocena", DataPropertyName = "AverageRating", ReadOnly = true, Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });

                var borrowButtonColumn = new DataGridViewButtonColumn();
                borrowButtonColumn.Name = "Borrow";
                borrowButtonColumn.HeaderText = "Akcja";
                borrowButtonColumn.Text = "Wypożycz";
                borrowButtonColumn.UseColumnTextForButtonValue = true;
                borrowButtonColumn.Width = 100;
                dgvBooks.Columns.Add(borrowButtonColumn);

                dgvBooks.CellContentClick += DgvBooks_CellContentClick;
            }

            if (btnSearch != null) btnSearch.Click += (s, e) => FilterAndSortBooks();
            if (txtSearchTitle != null) txtSearchTitle.KeyPress += TxtSearchTitle_KeyPress;

            if (cmbFilterGenre != null) cmbFilterGenre.SelectedIndexChanged += (s, e) => { };
            if (cmbSortBy != null) cmbSortBy.SelectedIndexChanged += (s, e) => {};
            if (btnApplyFilters != null) btnApplyFilters.Click += (s, e) => FilterAndSortBooks();

            if (cmbSortBy != null)
            {
                cmbSortBy.Items.AddRange(new object[] { "Tytuł (A-Z)", "Autor (A-Z)", "Ocena rosnąco", "Ocena malejąco", "Top popularność", "Najmniej popularne", "Najnowsze" });
                cmbSortBy.SelectedIndex = 0;
            }

            if (lblMessage != null)
            {
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblMessage.Visible = false;
            }
        }

        private async void LoadInitialData()
        {
            await PopulateFilterComboBoxes();
            await FilterAndSortBooks();
        }

        private async Task PopulateFilterComboBoxes()
        {
            try
            {

                var genres = await _db.Genres.OrderBy(g => g.Name).ToListAsync();
                if (cmbFilterGenre != null)
                {
                    cmbFilterGenre.Items.Clear();
                    cmbFilterGenre.Items.Add(new { Name = "Wszystkie gatunki", Id = 0 });
                    foreach (var genre in genres)
                    {
                        cmbFilterGenre.Items.Add(new { Name = genre.Name, Id = genre.GenreId });
                    }
                    cmbFilterGenre.DisplayMember = "Name";
                    cmbFilterGenre.ValueMember = "Id";
                    cmbFilterGenre.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas ładowania filtrów: {ex.Message}", true);
            }
        }

        private async Task FilterAndSortBooks()
        {
            ShowMessage("Ładowanie książek...", false);

            try
            {
                IQueryable<Book> query = _db.Books;

                query = query.Include(b => b.BookAuthors)
                               .ThenInclude(ba => ba.Author)
                           .Include(b => b.BookGenres)
                               .ThenInclude(bg => bg.Genre)
                           .Include(b => b.Rates)
                           .Include(b => b.BookLoans); 


                if (txtSearchTitle != null && !string.IsNullOrWhiteSpace(txtSearchTitle.Text))
                {
                    var searchTerm = txtSearchTitle.Text.Trim().ToLower();
                    query = query.Where(b => b.Title.ToLower().Contains(searchTerm) ||
                                             b.BookAuthors.Any(ba => (ba.Author.FirstName + " " + ba.Author.LastName).ToLower().Contains(searchTerm)));
                }


                if (cmbFilterGenre != null && cmbFilterGenre.SelectedIndex > 0)
                {
                    var selectedGenreId = (int)((dynamic)cmbFilterGenre.SelectedItem).Id;
                    query = query.Where(b => b.BookGenres.Any(bg => bg.GenreId == selectedGenreId));
                }

                var bookDtos = await query
                    .Select(b => new
                    {
                        BookId = b.BookId,
                        b.Title,
                        AuthorNames = string.Join(", ", b.BookAuthors.Select(ba => $"{ba.Author.FirstName} {ba.Author.LastName}")),
                        GenreNames = string.Join(", ", b.BookGenres.Select(bg => bg.Genre.Name)),
                        b.ISBN,
                        AvailableCopies = b.AvailableCopies,
                        NumberOfLoans = b.BookLoans.Count(), 
                        DateAdded = b.DateAdded,
                        AverageRating = b.Rates.Any() ? Math.Round(b.Rates.Average(r => r.RateValue), 1) : 0.0, 
                        IsNew = (DateTime.Now - b.DateAdded).TotalDays <= 30, 
                        IsPopular = b.BookLoans.Count() >= 5 
                    })
                    .ToListAsync();

                if (cmbSortBy != null)
                {
                    switch (cmbSortBy.SelectedItem.ToString())
                    {
                        case "Tytuł (A-Z)":
                            bookDtos = bookDtos.OrderBy(b => b.Title).ToList();
                            break;
                        case "Autor (A-Z)":
                            bookDtos = bookDtos.OrderBy(b => b.AuthorNames).ToList();
                            break;
                        case "Ocena rosnąco":
                            bookDtos = bookDtos.OrderBy(b => b.AverageRating).ToList();
                            break;
                        case "Ocena malejąco":
                            bookDtos = bookDtos.OrderByDescending(b => b.AverageRating).ToList();
                            break;
                        case "Top popularność":
                            bookDtos = bookDtos.OrderBy(b => b.NumberOfLoans).ToList();
                            break;
                        case "Najmniej popularne":
                            bookDtos = bookDtos.OrderByDescending(b => b.NumberOfLoans).ToList();
                            break;
                        case "Najnowsze":
                            bookDtos = bookDtos.OrderByDescending(b => b.DateAdded).ToList();
                            break;
                    }
                }

                var finalBookList = bookDtos.Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.AuthorNames,
                    b.GenreNames,
                    b.ISBN,
                    b.AvailableCopies,
                    b.AverageRating,
                }).ToList();


                if (dgvBooks != null)
                {
                    dgvBooks.DataSource = finalBookList;
                }

                ShowMessage("", false);
                if (!finalBookList.Any())
                {
                    ShowMessage("Brak książek spełniających kryteria.", false);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas ładowania książek: {ex.Message}", true);
            }
        }

        private async void DgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBooks == null || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvBooks.Columns[e.ColumnIndex].Name == "Borrow")
            {
                var selectedBook = dgvBooks.Rows[e.RowIndex].DataBoundItem as dynamic;
                if (selectedBook == null) return;

                if (_mainForm._currentUser == null)
                {
                    MessageBox.Show("Musisz być zalogowany, aby wypożyczyć książkę.", "Błąd wypożyczenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectedBook.AvailableCopies <= 0)
                {
                    MessageBox.Show("Ta książka jest obecnie niedostępna.", "Brak dostępności", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirmResult = MessageBox.Show($"Czy na pewno chcesz wypożyczyć książkę '{selectedBook.Title}'?", "Potwierdź wypożyczenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    await TryBorrowBook(selectedBook.BookId, selectedBook.Title);
                }
            }
        }

        private async Task TryBorrowBook(int bookId, string bookTitle)
        {
            try
            {
                var book = await _db.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
                if (book == null || book.AvailableCopies <= 0)
                {
                    MessageBox.Show($"Książka '{bookTitle}' jest niedostępna lub nie istnieje.", "Błąd wypożyczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var existingLoan = await _db.BookLoans
                                            .Where(bl => bl.UserId == _mainForm._currentUser.UserId && bl.BookId == bookId && bl.ReturnDate == null) 
                                            .AnyAsync();
                if (existingLoan)
                {
                    MessageBox.Show($"Już masz wypożyczoną książkę '{bookTitle}'.", "Wypożyczono", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var newLoan = new BookLoan
                {
                    BookId = bookId,
                    UserId = _mainForm._currentUser.UserId,
                    LoanDate = DateTime.Now,
                    PlannedReturnDate = DateTime.Now.AddDays(30),
                    ReturnDate = null
                };

                _db.BookLoans.Add(newLoan);
                book.AvailableCopies--;
                await _db.SaveChangesAsync();

                MessageBox.Show($"Pomyślnie wypożyczono książkę '{bookTitle}'. Planowana data zwrotu: {newLoan.PlannedReturnDate:d}", "Wypożyczono!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await FilterAndSortBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wypożyczania książki: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void TxtSearchTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch?.PerformClick();
                e.Handled = true;
            }
        }
    }
}