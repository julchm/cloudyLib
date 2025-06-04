namespace cloudyLib.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected internal System.Windows.Forms.Panel leftPanel;
        protected internal System.Windows.Forms.FlowLayoutPanel navButtonsPanel;
        protected internal System.Windows.Forms.Label lblWelcomeMessage;
        protected internal System.Windows.Forms.Label lblAppTitle;
        protected internal System.Windows.Forms.Panel contentPanel;
        protected internal System.Windows.Forms.Button btnBrowseBooks;
        protected internal System.Windows.Forms.Button btnMyLoans;
        protected internal System.Windows.Forms.Button btnMyReviews;
        protected internal System.Windows.Forms.Button btnEditProfile;
        protected internal System.Windows.Forms.Button btnLogout;
        protected internal System.Windows.Forms.Button btnAdminPanel;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.leftPanel = new System.Windows.Forms.Panel();
            this.navButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();

            
            this.btnBrowseBooks = new System.Windows.Forms.Button();
            this.btnMyLoans = new System.Windows.Forms.Button();
            this.btnMyReviews = new System.Windows.Forms.Button();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.btnAdminPanel = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button(); 

            this.lblWelcomeMessage = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.leftPanel.SuspendLayout();
            this.navButtonsPanel.SuspendLayout(); 
            this.SuspendLayout();
            //
            // leftPanel
            //
            this.leftPanel.BackColor = System.Drawing.Color.DarkGreen;
            this.leftPanel.Controls.Add(this.navButtonsPanel);
            this.leftPanel.Controls.Add(this.lblWelcomeMessage);
            this.leftPanel.Controls.Add(this.lblAppTitle);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 775);
            this.leftPanel.TabIndex = 0;
            //
            // navButtonsPanel
            //
            this.navButtonsPanel.AutoScroll = true;
            this.navButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.navButtonsPanel.WrapContents = false; 
            this.navButtonsPanel.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10); 
            this.navButtonsPanel.Location = new System.Drawing.Point(0, 140); 
            this.navButtonsPanel.Name = "navButtonsPanel";
            this.navButtonsPanel.Size = new System.Drawing.Size(200, 635); 
            this.navButtonsPanel.TabIndex = 2;
            this.navButtonsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.navButtonsPanel_Paint); 
            this.navButtonsPanel.Controls.Add(this.btnBrowseBooks);
            this.navButtonsPanel.Controls.Add(this.btnMyLoans);
            this.navButtonsPanel.Controls.Add(this.btnMyReviews);
            this.navButtonsPanel.Controls.Add(this.btnEditProfile);
            this.navButtonsPanel.Controls.Add(this.btnAdminPanel);
            this.navButtonsPanel.Controls.Add(this.btnLogout); 

            this.ConfigureButtonDefaults(this.btnBrowseBooks, "Przeglądaj książki");
            this.ConfigureButtonDefaults(this.btnMyLoans, "Wypożyczenia");
            this.ConfigureButtonDefaults(this.btnMyReviews, "Moje recenzje");
            this.ConfigureButtonDefaults(this.btnEditProfile, "Edytuj profil");
            this.ConfigureButtonDefaults(this.btnAdminPanel, "Panel Administratora");
            this.ConfigureButtonDefaults(this.btnLogout, "Wyloguj");

            //
            // lblWelcomeMessage
            //
            this.lblWelcomeMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcomeMessage.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeMessage.ForeColor = System.Drawing.Color.LightGreen;
            this.lblWelcomeMessage.Location = new System.Drawing.Point(0, 80);
            this.lblWelcomeMessage.Name = "lblWelcomeMessage";
            this.lblWelcomeMessage.Padding = new System.Windows.Forms.Padding(10);
            this.lblWelcomeMessage.Size = new System.Drawing.Size(200, 60);
            this.lblWelcomeMessage.TabIndex = 1;
            this.lblWelcomeMessage.Text = "Witaj Użytkowniku!";
            this.lblWelcomeMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWelcomeMessage.Visible = false;
            this.lblWelcomeMessage.Click += new System.EventHandler(this.lblWelcomeMessage_Click_1);
            //
            // lblAppTitle
            //
            this.lblAppTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppTitle.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.lblAppTitle.Size = new System.Drawing.Size(200, 80);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "cloudyLib";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAppTitle.Click += new System.EventHandler(this.lblAppTitle_Click);
            //
            // contentPanel
            //
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(200, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1000, 775);
            this.contentPanel.TabIndex = 1;
            this.contentPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.contentPanel_Paint);
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 775);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.leftPanel);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "cloudyLib";
            this.leftPanel.ResumeLayout(false);
            this.navButtonsPanel.ResumeLayout(false); 
            this.ResumeLayout(false);

        }

        
        private void ConfigureButtonDefaults(System.Windows.Forms.Button button, string text)
        {
            button.Text = text;
            button.Size = new System.Drawing.Size(180, 45);
            button.Font = new System.Drawing.Font("Georgia", 11F, System.Drawing.FontStyle.Bold);
            button.BackColor = System.Drawing.Color.ForestGreen;
            button.ForeColor = System.Drawing.Color.White;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            button.Cursor = System.Windows.Forms.Cursors.Hand;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
        }

        #endregion
    }
}