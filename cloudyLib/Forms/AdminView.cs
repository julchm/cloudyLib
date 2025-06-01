using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection; // Potrzebne do IServiceProvider
using cloudyLib.Data; // Dla LibraryDbContext (jeśli potrzebne w AdminView bezpośrednio)
using cloudyLib.Models; // Dla modeli

namespace cloudyLib.Forms
{
    public partial class AdminView : UserControl
    {
        private readonly LibraryDbContext _db;
        private readonly MainForm _mainForm;
        private readonly IServiceProvider _serviceProvider;


        public AdminView(LibraryDbContext db, MainForm mainForm, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            ConfigureAdminView();
        }

        private void ConfigureAdminView()
        {
            if (lblTitle != null)
            {
                lblTitle.Text = "Panel Administratora";
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            }

            // Załaduj sub-widoki do odpowiednich zakładek
            if (adminTabControl != null)
            {
                // Zakładka 'Zarządzaj Książkami'
                if (manageBooksTab != null)
                {
                    var manageBooksView = _serviceProvider.GetRequiredService<ManageBooksView>();
                    manageBooksView.Dock = DockStyle.Fill;
                    manageBooksTab.Controls.Add(manageBooksView);
                }

                // Zakładka 'Zarządzaj Użytkownikami'
                if (manageUsersTab != null)
                {
                    var manageUsersView = _serviceProvider.GetRequiredService<ManageUsersView>();
                    manageUsersView.Dock = DockStyle.Fill;
                    manageUsersTab.Controls.Add(manageUsersView);
                }

                // Zakładka 'Wypożyczenia'
                if (allLoansTab != null)
                {
                    var allLoansView = _serviceProvider.GetRequiredService<AllLoansView>();
                    allLoansView.Dock = DockStyle.Fill;
                    allLoansTab.Controls.Add(allLoansView);
                }

                // Zakładka 'Najpopularniejsze Książki'
                if (popularBooksTab != null)
                {
                    var popularBooksView = _serviceProvider.GetRequiredService<PopularBooksView>();
                    popularBooksView.Dock = DockStyle.Fill;
                    popularBooksTab.Controls.Add(popularBooksView);
                }
            }
        }

        // Obsługa zdarzenia zmiany zakładki w TabControl
        private void AdminTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // Możesz tutaj dodać logikę, która odświeża zawartość zakładki
            // lub wykonuje jakieś operacje, gdy użytkownik wybiera inną zakładkę.
            // Na przykład, jeśli dane na zakładce "Aktywne Wypożyczenia" mają być zawsze aktualne,
            // możesz wywołać metodę odświeżającą w AllLoansView:
            // if (e.TabPage == allLoansTab)
            // {
            //     if (allLoansTab.Controls.Count > 0 && allLoansTab.Controls[0] is AllLoansView loansView)
            //     {
            //         // loansView.RefreshData(); // Zakładając, że AllLoansView ma taką metodę
            //     }
            // }
            // Obecnie zostawiamy pustą, ale wymagana jest do kompilacji,
            // skoro Designer.cs próbuje ją podłączyć.
        }
    }
}