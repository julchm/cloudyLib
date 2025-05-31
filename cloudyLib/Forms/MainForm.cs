using System;
using System.Drawing;
using System.Windows.Forms;
using cloudyLib.Models; // Dla obiektu User
using cloudyLib.Forms; // Dla LoginView, RegisterView i innych UserControl
using Microsoft.Extensions.DependencyInjection; // Dla IServiceProvider

namespace cloudyLib.Forms
{
    public partial class MainForm : Form
    {
        public User _currentUser;
        private Button btnBrowseBooks;
        private Button btnMyLoans;
        private Button btnMyReviews;
        private Button btnEditProfile;
        private Button btnLogout;
        private Button btnAdminPanel;

        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            InitializeCustomComponents(); // Konfiguracja po wygenerowanym kodzie designera

            this.Text = "cloudyLib - System Zarządzania Biblioteką";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(1200, 800); // Duży rozmiar
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.BackColor = Color.AntiqueWhite; // Jasny beżowy dla całego formularza
        }

        private void InitializeCustomComponents()
        {
            // Panel główny na zawartość (jeśli nie jest już w Designer.cs)
            // Upewnij się, że contentPanel i leftPanel są zdefiniowane w Designer.cs
            // i mają odpowiednie DockStyle.
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.AntiqueWhite; // Tło zawartości

            leftPanel.Dock = DockStyle.Left;
            leftPanel.Width = 200; // Szerokość paska nawigacyjnego
            leftPanel.BackColor = Color.DarkGreen; // Ciemna zieleń dla nawigacji

            // Konfiguracja panelu na przyciski w lewym panelu
            navButtonsPanel = new FlowLayoutPanel();
            navButtonsPanel.Dock = DockStyle.Fill;
            navButtonsPanel.FlowDirection = FlowDirection.TopDown; // Ułożenie przycisków w kolumnie
            navButtonsPanel.WrapContents = false; // Nie zawijaj przycisków
            navButtonsPanel.Padding = new Padding(10, 20, 10, 10); // Odstępy
            navButtonsPanel.AutoScroll = true; // Włącz scrollowanie, jeśli będzie dużo przycisków
            leftPanel.Controls.Add(navButtonsPanel); // Dodaj panel na przyciski do lewego panelu

            // Inicjalizacja przycisków nawigacyjnych
            btnBrowseBooks = CreateNavButton("Przeglądaj książki", BrowseBooks_Click);
            btnMyLoans = CreateNavButton("Moje wypożyczenia", MyLoans_Click);
            btnMyReviews = CreateNavButton("Moje recenzje", MyReviews_Click);
            btnEditProfile = CreateNavButton("Edytuj profil", EditProfile_Click);
            btnAdminPanel = CreateNavButton("Panel Administratora", AdminPanel_Click);
            btnLogout = CreateNavButton("Wyloguj", Logout_Click);

            // Dodanie przycisków do FlowLayoutPanel
            navButtonsPanel.Controls.Add(btnBrowseBooks);
            navButtonsPanel.Controls.Add(btnMyLoans);
            navButtonsPanel.Controls.Add(btnMyReviews);
            navButtonsPanel.Controls.Add(btnEditProfile);
            navButtonsPanel.Controls.Add(btnAdminPanel);
            navButtonsPanel.Controls.Add(btnLogout);

            // Ustawienia początkowe widoczności
            UpdateNavigationView(null); // Brak zalogowanego użytkownika na start

            // Załaduj początkowy widok (LoginView) po załadowaniu formularza
            this.Load += (s, e) => LoadView(_serviceProvider.GetRequiredService<LoginView>());
        }

        // Pomocnicza metoda do tworzenia stylizowanych przycisków nawigacyjnych
        private Button CreateNavButton(string text, EventHandler clickHandler)
        {
            var button = new Button();
            button.Text = text;
            button.Size = new Size(180, 45); // Rozmiar przycisku
            button.Font = new Font("Georgia", 11F, FontStyle.Bold);
            button.BackColor = Color.ForestGreen; // Taki sam jak navbar
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Margin = new Padding(0, 5, 0, 5); // Marginesy pionowe
            button.Cursor = Cursors.Hand;
            button.TextAlign = ContentAlignment.MiddleLeft; // Tekst po lewej
            button.Padding = new Padding(10, 0, 0, 0); // Wcięcie tekstu
            button.Click += clickHandler;
            return button;
        }

        // Metoda do ładowania UserControl do contentPanel
        public void LoadView(UserControl view)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => LoadView(view)));
                return;
            }

            contentPanel.Controls.Clear();
            view.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(view);
        }

        // Metoda wywoływana po udanym zalogowaniu
        public void UserLoggedIn(User user)
        {
            _currentUser = user;

            lblWelcomeMessage.Text = $"Witaj {user.First_Name}!"; // Zaktualizuj powitanie
            lblWelcomeMessage.Visible = true; // Pokaż powitanie
            lblAppTitle.Visible = false; // Ukryj nazwę aplikacji, jeśli jest powitanie

            MessageBox.Show($"Zalogowano pomyślnie jako {user.Role}!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateNavigationView(user); // Zaktualizuj pasek nawigacyjny

            // Po zalogowaniu załaduj domyślny widok
            if (_currentUser.Role == "Administrator")
            {
                LoadView(_serviceProvider.GetRequiredService<AdminView>()); // Ładujemy AdminView dla administratora
            }
            else // Czytelnik
            {
                LoadView(_serviceProvider.GetRequiredService<BookListView>()); // Ładujemy BookListView dla czytelnika
            }
        }

        // Metoda do wylogowywania
        private void Logout_Click(object sender, EventArgs e)
        {
            _currentUser = null;
            MessageBox.Show("Wylogowano.", "Wylogowanie", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblWelcomeMessage.Text = ""; // Wyczyść powitanie
            lblWelcomeMessage.Visible = false;
            lblAppTitle.Visible = true; // Pokaż nazwę aplikacji

            UpdateNavigationView(null); // Ukryj przyciski nawigacyjne

            // Wróć do widoku logowania
            LoadView(_serviceProvider.GetRequiredService<LoginView>());
        }

        // Metoda aktualizująca widoczność przycisków nawigacyjnych na podstawie roli
        private void UpdateNavigationView(User user)
        {
            bool isLoggedIn = (user != null);
            bool isAdmin = isLoggedIn && user.Role == "Administrator";
            bool isReader = isLoggedIn && user.Role == "Czytelnik";

            leftPanel.Visible = isLoggedIn; // Cały lewy panel widoczny tylko po zalogowaniu

            // Widoki dla wszystkich zalogowanych
            btnBrowseBooks.Visible = isLoggedIn;
            btnLogout.Visible = isLoggedIn;
            btnEditProfile.Visible = isLoggedIn;

            // Widoki specyficzne dla Czytelnika
            btnMyLoans.Visible = isReader;
            btnMyReviews.Visible = isReader;

            // Widoki specyficzne dla Administratora
            btnAdminPanel.Visible = isAdmin;
        }

        // Obsługa kliknięć przycisków nawigacyjnych
        private void BrowseBooks_Click(object sender, EventArgs e)
        {
            LoadView(_serviceProvider.GetRequiredService<BookListView>());
        }

        private void MyLoans_Click(object sender, EventArgs e)
        {
            if (_currentUser?.Role == "Czytelnik")
            {
                LoadView(_serviceProvider.GetRequiredService<MyLoansView>());
            }
        }

        private void MyReviews_Click(object sender, EventArgs e)
        {
            if (_currentUser?.Role == "Czytelnik")
            {
                LoadView(_serviceProvider.GetRequiredService<MyReviewsView>());
            }
        }

        private void EditProfile_Click(object sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                LoadView(_serviceProvider.GetRequiredService<EditProfileView>());
            }
        }

        private void AdminPanel_Click(object sender, EventArgs e)
        {
            if (_currentUser?.Role == "Administrator")
            {
                LoadView(_serviceProvider.GetRequiredService<AdminView>());
            }
        }

        private void lblWelcomeMessage_Click(object sender, EventArgs e)
        {

        }

        private void lblAppTitle_Click(object sender, EventArgs e)
        {

        }

        private void navButtonsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}