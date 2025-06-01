namespace cloudyLib.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Ważne: Deklaracje tych kontrolek powinny być `protected internal` lub `public`
        // aby były dostępne w MainForm.cs, jeśli nie są tworzone tam programowo.
        // Jeśli są tworzone programowo w MainForm.cs, te deklaracje w Designerze są zbędne.
        // Biorąc pod uwagę Twój kod w MainForm.cs, te są tworzone w Designerze,
        // a ich zawartość (przyciski) jest dodawana programowo.
        protected internal System.Windows.Forms.Panel leftPanel;
        protected internal System.Windows.Forms.FlowLayoutPanel navButtonsPanel; // Zmieniono na protected internal
        protected internal System.Windows.Forms.Label lblWelcomeMessage; // Zmieniono na protected internal
        protected internal System.Windows.Forms.Label lblAppTitle;       // Zmieniono na protected internal
        protected internal System.Windows.Forms.Panel contentPanel;     // Zmieniono na protected internal


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
            this.lblWelcomeMessage = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.leftPanel.SuspendLayout();
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
            this.navButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill; // Może być Full, jeśli lblWelcomeMessage i lblAppTitle są dokowane inaczej
            this.navButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.navButtonsPanel.Location = new System.Drawing.Point(0, 140); // Zakładam, że zaczyna się pod tytułem i powitaniem
            this.navButtonsPanel.Name = "navButtonsPanel";
            this.navButtonsPanel.Size = new System.Drawing.Size(200, 635);
            this.navButtonsPanel.TabIndex = 2;
            this.navButtonsPanel.WrapContents = false;
            this.navButtonsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.navButtonsPanel_Paint);
            //
            // lblWelcomeMessage
            //
            this.lblWelcomeMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcomeMessage.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeMessage.ForeColor = System.Drawing.Color.LightGreen;
            this.lblWelcomeMessage.Location = new System.Drawing.Point(0, 80); // Pod lblAppTitle
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
            this.lblAppTitle.Padding = new Padding(10, 20, 10, 10);
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
            this.ResumeLayout(false);

        }

        #endregion
    }
}