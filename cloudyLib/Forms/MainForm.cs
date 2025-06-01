using System;
using System.Drawing;
using System.Windows.Forms;
using cloudyLib.Models; 
using cloudyLib.Forms; 
using Microsoft.Extensions.DependencyInjection; 

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

            InitializeCustomComponents();

            this.Text = "cloudyLib - System Zarządzania Biblioteką";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.BackColor = Color.AntiqueWhite;
        }

        private void InitializeCustomComponents()
        {
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Color.AntiqueWhite;

            leftPanel.Dock = DockStyle.Left;
            leftPanel.Width = 200;
            leftPanel.BackColor = Color.DarkGreen;


            navButtonsPanel.Dock = DockStyle.Fill;
            navButtonsPanel.FlowDirection = FlowDirection.TopDown;
            navButtonsPanel.WrapContents = false;
            navButtonsPanel.Padding = new Padding(10, 20, 10, 10);
            navButtonsPanel.AutoScroll = true;

            btnBrowseBooks = CreateNavButton("Przeglądaj książki", BrowseBooks_Click);
            btnMyLoans = CreateNavButton("Moje wypożyczenia", MyLoans_Click);
            btnMyReviews = CreateNavButton("Moje recenzje", MyReviews_Click);
            btnEditProfile = CreateNavButton("Edytuj profil", EditProfile_Click);
            btnAdminPanel = CreateNavButton("Panel Administratora", AdminPanel_Click);
            btnLogout = CreateNavButton("Wyloguj", Logout_Click);

            navButtonsPanel.Controls.Add(btnBrowseBooks);
            navButtonsPanel.Controls.Add(btnMyLoans);
            navButtonsPanel.Controls.Add(btnMyReviews);
            navButtonsPanel.Controls.Add(btnEditProfile);
            navButtonsPanel.Controls.Add(btnAdminPanel);
            navButtonsPanel.Controls.Add(btnLogout);

            UpdateNavigationView(null);
            this.Load += (s, e) => LoadView(_serviceProvider.GetRequiredService<LoginView>());
        }

        private Button CreateNavButton(string text, EventHandler clickHandler)
        {
            var button = new Button();
            button.Text = text;
            button.Size = new Size(180, 45);
            button.Font = new Font("Georgia", 11F, FontStyle.Bold);
            button.BackColor = Color.ForestGreen;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Margin = new Padding(0, 5, 0, 5);
            button.Cursor = Cursors.Hand;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(10, 0, 0, 0);
            button.Click += clickHandler;
            return button;
        }

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

        public void UserLoggedIn(User user)
        {
            _currentUser = user;

            lblWelcomeMessage.Text = $"Witaj {user.FirstName}!";
            lblWelcomeMessage.Visible = true;
            lblAppTitle.Visible = false;

            MessageBox.Show($"Zalogowano pomyślnie jako {user.Role}!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateNavigationView(user);

            if (_currentUser.Role == "Administrator")
            {
                LoadView(_serviceProvider.GetRequiredService<AdminView>());
            }
            else
            {
                LoadView(_serviceProvider.GetRequiredService<BookListView>());
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            _currentUser = null;
            MessageBox.Show("Wylogowano.", "Wylogowanie", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblWelcomeMessage.Text = "";
            lblWelcomeMessage.Visible = false;
            lblAppTitle.Visible = true;

            UpdateNavigationView(null);

            LoadView(_serviceProvider.GetRequiredService<LoginView>());
        }

        private void UpdateNavigationView(User user)
        {
            bool isLoggedIn = (user != null);
            bool isAdmin = isLoggedIn && user.Role == "Administrator";
            bool isReader = isLoggedIn && user.Role == "Reader"; 

            leftPanel.Visible = isLoggedIn;

            btnBrowseBooks.Visible = isLoggedIn;
            btnLogout.Visible = isLoggedIn;
            btnEditProfile.Visible = isLoggedIn;

            btnMyLoans.Visible = isReader;
            btnMyReviews.Visible = isReader;

            btnAdminPanel.Visible = isAdmin;
        }

        private void BrowseBooks_Click(object sender, EventArgs e)
        {
            LoadView(_serviceProvider.GetRequiredService<BookListView>());
        }

        private void MyLoans_Click(object sender, EventArgs e)
        {
            if (_currentUser?.Role == "Reader")
            {
                LoadView(_serviceProvider.GetRequiredService<MyLoansView>());
            }
        }

        private void MyReviews_Click(object sender, EventArgs e)
        {
            if (_currentUser?.Role == "Reader")
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

        private void lblWelcomeMessage_Click(object sender, EventArgs e) { }
        private void lblAppTitle_Click(object sender, EventArgs e) { }
        private void navButtonsPanel_Paint(object sender, PaintEventArgs e) { }
        private void contentPanel_Paint(object sender, PaintEventArgs e) { }
        private void lblWelcomeMessage_Click_1(object sender, EventArgs e) { }
    }
}