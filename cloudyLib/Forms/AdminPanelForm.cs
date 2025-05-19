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
    public partial class AdminPanelForm : Form
    {
        public AdminPanelForm()
        {
            InitializeComponent();// Dodaj tutaj logikę inicjalizacji i ewentualne pobranie danych
        }

        // Przykładowe przyciski i akcje (do rozbudowy)
        private Button btnManageBooks;
        private Button btnManageUsers;
        private Button btnViewLoans;
        private Button btnViewPopularBooks;
        private Button btnLogout;



        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            // Otwórz formularz zarządzania książkami (BookListForm w trybie edycji)
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            // Otwórz formularz zarządzania użytkownikami
        }

        private void btnViewLoans_Click(object sender, EventArgs e)
        {
            // Otwórz formularz przeglądania aktywnych wypożyczeń
        }

        private void btnViewPopularBooks_Click(object sender, EventArgs e)
        {
            // Wyświetl listę najpopularniejszych książek
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Logika wylogowania
            this.Close();
            // Możesz też otworzyć LoginForm ponownie
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {

        }
    }
}
