using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using cloudyLib.Data;
using cloudyLib.Models;
using System.Linq;

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
            this.Load += (s, e) => AdminView_Load();
        }

        private void ConfigureAdminView()
        {
            if (lblTitle != null)
            {
                lblTitle.Text = "Panel Administratora";
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            }

            if (adminTabControl != null)
            {

                if (manageBooksTab != null && !manageBooksTab.Controls.Cast<Control>().Any())
                {
                    var manageBooksView = _serviceProvider.GetRequiredService<ManageBooksView>();
                    manageBooksView.Dock = DockStyle.Fill;
                    manageBooksTab.Controls.Add(manageBooksView);
                }

                if (manageUsersTab != null && !manageUsersTab.Controls.Cast<Control>().Any())
                {
                    var manageUsersView = _serviceProvider.GetRequiredService<ManageUsersView>();
                    manageUsersView.Dock = DockStyle.Fill;
                    manageUsersTab.Controls.Add(manageUsersView);
                }

                if (allLoansTab != null && !allLoansTab.Controls.Cast<Control>().Any())
                {
                    var allLoansView = _serviceProvider.GetRequiredService<AllLoansView>();
                    allLoansView.Dock = DockStyle.Fill;
                    allLoansTab.Controls.Add(allLoansView);
                }

                
            }
        }

        private void AdminView_Load()
        {
            if (adminTabControl != null && allLoansTab != null)
            {
                adminTabControl.SelectedTab = allLoansTab; 
            }
        }

        private void AdminTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
        }
    }
}