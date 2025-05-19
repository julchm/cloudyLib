using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cloudyLib.Forms
{
    public partial class BookListForm : Form
    {
        public BookListForm()
        {
            InitializeComponent();
        }

        private DataGridView dgvBooks;
        private TextBox txtFilterTitle;
        private TextBox txtFilterAuthor;
        private ComboBox cmbFilterGenre;
        private ComboBox cmbSortBy;
        private Button btnAddBook;
        private Button btnEditBook;
        private Button btnDeleteBook;

        private void txtFilterTitle_TextChanged(object sender, EventArgs e)
        {
            // Filtruj listę książek po tytule
        }

        private void txtFilterAuthor_TextChanged(object sender, EventArgs e)
        {
            // Filtruj listę książek po autorze
        }

        private void cmbFilterGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Filtruj listę książek po gatunku
        }

        private void cmbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sortuj listę książek
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            // Otwórz formularz dodawania nowej książki (może oddzielny formularz)
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            // Otwórz formularz edycji wybranej książki (BookEditForm)
            if (dgvBooks.SelectedRows.Count > 0)
            {
                // Pobierz ID wybranej książki i otwórz BookEditForm
            }
            else
            {
                MessageBox.Show("Wybierz książkę do edycji.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            // Usuń wybraną książkę (z walidacją, czy nie jest wypożyczona)
            if (dgvBooks.SelectedRows.Count > 0)
            {
                // Pobierz ID wybranej książki i wykonaj usunięcie po potwierdzeniu
            }
            else
            {
                MessageBox.Show("Wybierz książkę do usunięcia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Otwórz formularz szczegółów książki (do zaimplementowania)
        }
        private void BookListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
