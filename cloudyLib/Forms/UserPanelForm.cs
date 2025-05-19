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
    public partial class UserPanelForm: Form
    {
        public UserPanelForm()
        {
            InitializeComponent();
        }

        private Button btnBrowseBooks;
        private Button btnViewBorrowedBooks;
        private Button btnEditProfile;
        private Button btnLogout;

        private void btnBrowseBooks_Click(object sender, EventArgs e)
        {
            // Otwórz formularz listy książek (BookListForm w trybie przeglądania)
        }

        private void btnViewBorrowedBooks_Click(object sender, EventArgs e)
        {
            // Otwórz formularz z historią wypożyczeń zalogowanego użytkownika (do zaimplementowania)
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            // Otwórz formularz edycji danych kontaktowych użytkownika (do zaimplementowania)
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Logika wylogowania
            this.Close();
            // Możesz też otworzyć LoginForm ponownie
        }

        private void UserPanelForm_Load(object sender, EventArgs e)
        {

        }
    }
}
