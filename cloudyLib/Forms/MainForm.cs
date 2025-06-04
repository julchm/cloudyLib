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

            
            if (btnBrowseBooks != null) btnBrowseBooks.Click += BrowseBooks_Click;
            if (btnMyLoans != null) btnMyLoans.Click += MyLoans_Click;
            if (btnMyReviews != null) btnMyReviews.Click += MyReviews_Click;
            if (btnEditProfile != null) btnEditProfile.Click += EditProfile_Click;
            if (btnAdminPanel != null) btnAdminPanel.Click += AdminPanel_Click;
            if (btnLogout != null) btnLogout.Click += Logout_Click;

            UpdateNavigationView(null);
            this.Load += (s, e) => LoadView(_serviceProvider.GetRequiredService<LoginView>());
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

            if (btnBrowseBooks != null) btnBrowseBooks.Visible = isReader; 
            if (btnMyLoans != null) btnMyLoans.Visible = isReader;
            if (btnMyReviews != null) btnMyReviews.Visible = isReader;

            if (btnEditProfile != null) btnEditProfile.Visible = isLoggedIn;
            if (btnLogout != null) btnLogout.Visible = isLoggedIn;

            if (btnAdminPanel != null) btnAdminPanel.Visible = isAdmin;
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