using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using cloudyLib.Data;
using cloudyLib.Models;
using System.Text.RegularExpressions;

namespace cloudyLib.Forms
{
    public partial class AddEditBookForm : Form
    {
        private readonly LibraryDbContext _db;
        private int? _bookIdToEdit;
        private Book _bookBeingEdited;

        public AddEditBookForm(LibraryDbContext db)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            ConfigureFormControls();

            this.Load += async (s, e) => await PrepareFormAsync();
        }

        
        public void SetBookToEdit(int? bookId)
        {
            _bookIdToEdit = bookId;
        }

        
        private async Task PrepareFormAsync()
        {
            await LoadAuthorsAndGenres(); 
            await LoadBookData();         
        }


        private void ConfigureFormControls()
        {
            this.Text = "Dodaj/Edytuj Książkę";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.AntiqueWhite;

            if (numYearOfRelease != null)
            {
                numYearOfRelease.Minimum = 1000;
                numYearOfRelease.Maximum = DateTime.Now.Year + 5;
                numYearOfRelease.Value = DateTime.Now.Year;
            }

            if (numAvailableCopies != null)
            {
                numAvailableCopies.Minimum = 0;
                numAvailableCopies.Maximum = 1000;
                numAvailableCopies.Value = 1;
            }

            if (btnSave != null) btnSave.Click += BtnSave_Click;
            if (btnCancel != null) btnCancel.Click += (s, e) => this.Close();

            if (clbAuthors != null)
            {
                clbAuthors.DisplayMember = "Display";
                clbAuthors.ValueMember = "Value";
            }

            if (clbGenres != null)
            {
                clbGenres.DisplayMember = "Display";
                clbGenres.ValueMember = "Value";
            }

            if (txtISBN != null) txtISBN.Leave += TxtISBN_Leave;

            ShowMessage("", false);
        }

        private async Task LoadBookData() 
        {

            if (_bookIdToEdit.HasValue)
            {
                lblTitle.Text = "Edytuj Książkę";
                try
                {
                    _bookBeingEdited = await _db.Books
                                                .Include(b => b.BookAuthors)
                                                    .ThenInclude(ba => ba.Author)
                                                .Include(b => b.BookGenres)
                                                    .ThenInclude(bg => bg.Genre)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync(b => b.BookId == _bookIdToEdit.Value);

                    if (_bookBeingEdited != null)
                    {
                        txtBookTitle.Text = _bookBeingEdited.Title;
                        txtISBN.Text = _bookBeingEdited.ISBN;
                        numYearOfRelease.Value = _bookBeingEdited.YearOfRelease;
                        numAvailableCopies.Value = _bookBeingEdited.AvailableCopies;

                        if (clbAuthors.Items.Count > 0)
                        {
                            for (int i = 0; i < clbAuthors.Items.Count; i++)
                            {
                                dynamic authorItem = clbAuthors.Items[i];
                                int currentAuthorId = (int)authorItem.Value;
                                if (_bookBeingEdited.BookAuthors.Any(ba => ba.AuthorId == currentAuthorId))
                                {
                                    clbAuthors.SetItemChecked(i, true);
                                }
                            }
                        }

                        
                        if (clbGenres.Items.Count > 0)
                        {
                            for (int i = 0; i < clbGenres.Items.Count; i++)
                            {
                                dynamic genreItem = clbGenres.Items[i];
                                int currentGenreId = (int)genreItem.Value;
                                if (genreItem != null && _bookBeingEdited.BookGenres.Any(bg => bg.GenreId == currentGenreId))
                                {
                                    clbGenres.SetItemChecked(i, true);
                                }
                            }
                        }
                    }
                    else
                    {
                        ShowMessage("Nie znaleziono książki do edycji.", true);
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage($"Błąd podczas ładowania danych książki: {ex.Message}", true);
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                lblTitle.Text = "Dodaj Nową Książkę";
            }
        }

        private async Task LoadAuthorsAndGenres()
        {
            try
            {
                var authors = await _db.Authors.AsNoTracking().OrderBy(a => a.LastName).ThenBy(a => a.FirstName).ToListAsync();
                var genres = await _db.Genres.AsNoTracking().OrderBy(g => g.Name).ToListAsync();

                clbAuthors.Items.Clear();
                foreach (var author in authors)
                {
                    clbAuthors.Items.Add(new { Display = $"{author.FirstName} {author.LastName}", Value = author.AuthorId });
                }

                clbGenres.Items.Clear();
                foreach (var genre in genres)
                {
                    clbGenres.Items.Add(new { Display = genre.Name, Value = genre.GenreId });
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd ładowania autorów/gatunków: {ex.Message}", true);
                Console.WriteLine(ex.ToString());
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
                bool isISBNUnique = await IsISBNUniqueAsync(txtISBN.Text.Trim(), _bookIdToEdit);
                if (!isISBNUnique)
                {
                    ShowMessage("Książka o podanym numerze ISBN już istnieje.", true);
                    return;
                }

                if (_bookIdToEdit.HasValue) 
                {
                    var bookToUpdate = await _db.Books
                                                .Include(b => b.BookAuthors)
                                                .Include(b => b.BookGenres)
                                                .FirstOrDefaultAsync(b => b.BookId == _bookIdToEdit.Value);

                    if (bookToUpdate == null)
                    {
                        ShowMessage("Błąd: Książka do edycji nie została znaleziona.", true);
                        return;
                    }

                    bookToUpdate.Title = txtBookTitle.Text.Trim();
                    bookToUpdate.ISBN = txtISBN.Text.Trim();
                    bookToUpdate.YearOfRelease = (short)numYearOfRelease.Value;
                    bookToUpdate.AvailableCopies = (int)numAvailableCopies.Value;

                    _db.BookAuthors.RemoveRange(bookToUpdate.BookAuthors);
                    foreach (var item in clbAuthors.CheckedItems)
                    {
                        dynamic authorItem = item;
                        var authorId = (int)authorItem.Value;
                        bookToUpdate.BookAuthors.Add(new BookAuthor { BookId = bookToUpdate.BookId, AuthorId = authorId });
                    }

                    _db.BookGenres.RemoveRange(bookToUpdate.BookGenres);
                    foreach (var item in clbGenres.CheckedItems)
                    {
                        dynamic genreItem = item;
                        var genreId = (int)genreItem.Value;
                        bookToUpdate.BookGenres.Add(new BookGenre { BookId = bookToUpdate.BookId, GenreId = genreId });
                    }

                    await _db.SaveChangesAsync();
                    MessageBox.Show("Dane książki zostały zaktualizowane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    var newBook = new Book
                    {
                        Title = txtBookTitle.Text.Trim(),
                        ISBN = txtISBN.Text.Trim(),
                        YearOfRelease = (short)numYearOfRelease.Value,
                        AvailableCopies = (int)numAvailableCopies.Value,
                        DateAdded = DateTime.UtcNow,
                    };

                    foreach (var item in clbAuthors.CheckedItems)
                    {
                        dynamic authorItem = item;
                        var authorId = (int)authorItem.Value;
                        newBook.BookAuthors.Add(new BookAuthor { AuthorId = authorId });
                    }

                    foreach (var item in clbGenres.CheckedItems)
                    {
                        dynamic genreItem = item;
                        var genreId = (int)genreItem.Value;
                        newBook.BookGenres.Add(new BookGenre { GenreId = genreId });
                    }

                    _db.Books.Add(newBook);
                    await _db.SaveChangesAsync();
                    MessageBox.Show("Nowa książka została dodana.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas zapisu: {ex.Message}", true);
                Console.WriteLine(ex.ToString());
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtBookTitle.Text) ||
                string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                ShowMessage("Tytuł i ISBN są wymagane.", true);
                return false;
            }

            string isbnClean = txtISBN.Text.Trim().Replace("-", "").Replace(" ", "");

            if (!Regex.IsMatch(isbnClean, @"^(?:\d{9}[\dX]|\d{13})$", RegexOptions.IgnoreCase))
            {
                ShowMessage("Niepoprawny format ISBN. Wprowadź 10 lub 13 cyfr (ostatnia może być X).", true);
                return false;
            }

            if (numAvailableCopies.Value < 0)
            {
                ShowMessage("Liczba dostępnych kopii nie może być ujemna.", true);
                return false;
            }

            if (clbAuthors.CheckedItems.Count == 0)
            {
                ShowMessage("Musisz wybrać co najmniej jednego autora.", true);
                return false;
            }

            if (clbGenres.CheckedItems.Count == 0)
            {
                ShowMessage("Musisz wybrać co najmniej jeden gatunek.", true);
                return false;
            }

            return true;
        }

        private async Task<bool> IsISBNUniqueAsync(string isbn, int? currentBookId)
        {
            string isbnClean = isbn.Replace("-", "").Replace(" ", "");
            var existingBook = await _db.Books.AsNoTracking().FirstOrDefaultAsync(b => b.ISBN != null && b.ISBN.Replace("-", "").Replace(" ", "") == isbnClean);
            return existingBook == null || (existingBook.BookId == currentBookId);
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

        private async void TxtISBN_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                string isbnClean = txtISBN.Text.Trim().Replace("-", "").Replace(" ", "");
                if (!Regex.IsMatch(isbnClean, @"^(?:\d{9}[\dX]|\d{13})$", RegexOptions.IgnoreCase))
                {
                    ShowMessage("Niepoprawny format ISBN. Wprowadź 10 lub 13 cyfr (ostatnia może być X).", true);
                }
                else
                {
                    bool isUnique = await IsISBNUniqueAsync(txtISBN.Text, _bookIdToEdit);
                    if (!isUnique)
                    {
                        ShowMessage("Książka o podanym numerze ISBN już istnieje.", true);
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
    }
}