using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using cloudyLib.Data;
using cloudyLib.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cloudyLib.Forms
{
    public partial class ManageBooksView : UserControl
    {
        private readonly LibraryDbContext _db;
        private readonly MainForm _mainForm; 
        private readonly IServiceProvider _serviceProvider; 


        public ManageBooksView(LibraryDbContext db, MainForm mainForm, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            ConfigureManageBooksControls();
            LoadBooks(); 
        }

        private void ConfigureManageBooksControls()
        {
            if (lblTitle != null)
            {
                lblTitle.Text = "Zarządzanie Książkami";
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (dgvBooks != null)
            {
                dgvBooks.AutoGenerateColumns = false;
                dgvBooks.ReadOnly = true;
                dgvBooks.AllowUserToAddRows = false;
                dgvBooks.AllowUserToDeleteRows = false;
                dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvBooks.MultiSelect = false;

                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "BookId", HeaderText = "ID", DataPropertyName = "BookId", ReadOnly = true, Width = 50 });
                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Title", HeaderText = "Tytuł", DataPropertyName = "Title", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "ISBN", HeaderText = "ISBN", DataPropertyName = "ISBN", ReadOnly = true, Width = 120 });
                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Author", HeaderText = "Autor(zy)", DataPropertyName = "AuthorNames", ReadOnly = true, Width = 150 });
                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Genre", HeaderText = "Gatunek(ki)", DataPropertyName = "GenreNames", ReadOnly = true, Width = 120 });
                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "AvailableCopies", HeaderText = "Dostępne", DataPropertyName = "AvailableCopies", ReadOnly = true, Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } }); 
                dgvBooks.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalCopies", HeaderText = "Wszystkie", DataPropertyName = "TotalCopies", ReadOnly = true, Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            }

            if (btnAddBook != null) btnAddBook.Click += BtnAddBook_Click;
            if (btnEditBook != null) btnEditBook.Click += BtnEditBook_Click;
            if (btnDeleteBook != null) btnDeleteBook.Click += BtnDeleteBook_Click;

            if (lblMessage != null)
            {
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblMessage.Visible = false;
            }
        }

        public async Task LoadBooks()
        {
            ShowMessage("Ładowanie książek...", false);
            try
            {
                var books = await _db.Books
                                     .Include(b => b.BookAuthors)
                                         .ThenInclude(ba => ba.Author)
                                     .Include(b => b.BookGenres)
                                         .ThenInclude(bg => bg.Genre)
                                     .Select(b => new
                                     {
                                         BookId = b.BookId, 
                                         b.Title, 
                                         b.ISBN, 
                                         AuthorNames = string.Join(", ", b.BookAuthors.Select(ba => $"{ba.Author.FirstName} {ba.Author.LastName}")),
                                         GenreNames = string.Join(", ", b.BookGenres.Select(bg => bg.Genre.Name)),
                                         AvailableCopies = b.AvailableCopies, 
                                         TotalCopies = b.AvailableCopies + b.BookLoans.Count(bl => bl.ReturnDate == null)
                                     })
                                     .ToListAsync();

                dgvBooks.DataSource = books;
                ShowMessage("", false);
                if (!books.Any())
                {
                    ShowMessage("Brak książek w systemie.", false);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas ładowania książek: {ex.Message}", true);
            }
        }

        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            // Otwórz formularz dodawania książki
            MessageBox.Show("Dodawanie nowej książki.", "Informacja");
            // Example of how to use _serviceProvider to get a new form instance:
            // var addBookForm = _serviceProvider.GetRequiredService<AddEditBookForm>();
            // addBookForm.ShowDialog();
            // await LoadBooks(); // Odśwież listę
        }

        private void BtnEditBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać książkę do edycji.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedBookId = (int)dgvBooks.SelectedRows[0].Cells["BookId"].Value;
            MessageBox.Show($"Edycja książki o ID: {selectedBookId}.", "Informacja");
            // Example of how to use _serviceProvider to get a new form instance:
            // var editBookForm = _serviceProvider.GetRequiredService<AddEditBookForm>();
            // editBookForm.LoadBook(selectedBookId); // Assume AddEditBookForm has a LoadBook method
            // editBookForm.ShowDialog();
            // await LoadBooks(); // Odśwież listę
        }

        private async void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę wybrać książkę do usunięcia.", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedBookId = (int)dgvBooks.SelectedRows[0].Cells["BookId"].Value;
            var bookTitle = dgvBooks.SelectedRows[0].Cells["Title"].Value.ToString();

            var confirmResult = MessageBox.Show($"Czy na pewno chcesz usunąć książkę '{bookTitle}'?", "Potwierdź usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                await TryDeleteBook(selectedBookId, bookTitle);
            }
        }

        private async Task TryDeleteBook(int bookId, string bookTitle)
        {
            try
            {
                var isActiveLoan = await _db.BookLoans.AnyAsync(bl => bl.BookId == bookId && bl.ReturnDate == null);
                if (isActiveLoan)
                {
                    MessageBox.Show($"Nie można usunąć książki '{bookTitle}', ponieważ jest aktualnie wypożyczona.", "Błąd usuwania", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var bookToDelete = await _db.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
                if (bookToDelete != null)
                {
                    _db.Books.Remove(bookToDelete);
                    await _db.SaveChangesAsync();
                    MessageBox.Show($"Książka '{bookTitle}' została usunięta pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadBooks(); 
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Błąd podczas usuwania książki: {ex.Message}", true);
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

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Możesz dodać logikę obsługi kliknięcia komórki, np. otwarcie widoku szczegółów
        }
    }
}