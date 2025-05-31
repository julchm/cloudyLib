namespace cloudyLib.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            leftPanel = new Panel();
            navButtonsPanel = new FlowLayoutPanel();
            lblWelcomeMessage = new Label();
            lblAppTitle = new Label();
            contentPanel = new Panel();
            leftPanel.SuspendLayout();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.DarkGreen;
            leftPanel.Controls.Add(navButtonsPanel);
            leftPanel.Controls.Add(lblWelcomeMessage);
            leftPanel.Controls.Add(lblAppTitle);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(200, 775);
            leftPanel.TabIndex = 0;
            // 
            // navButtonsPanel
            // 
            navButtonsPanel.AutoScroll = true;
            navButtonsPanel.Dock = DockStyle.Fill;
            navButtonsPanel.FlowDirection = FlowDirection.TopDown;
            navButtonsPanel.Location = new Point(0, 140);
            navButtonsPanel.Name = "navButtonsPanel";
            navButtonsPanel.Size = new Size(200, 635);
            navButtonsPanel.TabIndex = 2;
            navButtonsPanel.WrapContents = false;
            navButtonsPanel.Paint += navButtonsPanel_Paint;
            // 
            // lblWelcomeMessage
            // 
            lblWelcomeMessage.Dock = DockStyle.Top;
            lblWelcomeMessage.Font = new Font("Georgia", 12F, FontStyle.Bold);
            lblWelcomeMessage.ForeColor = Color.LightGreen;
            lblWelcomeMessage.Location = new Point(0, 80);
            lblWelcomeMessage.Name = "lblWelcomeMessage";
            lblWelcomeMessage.Padding = new Padding(10);
            lblWelcomeMessage.Size = new Size(200, 60);
            lblWelcomeMessage.TabIndex = 1;
            lblWelcomeMessage.Text = "Witaj Użytkowniku!";
            lblWelcomeMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcomeMessage.Visible = false;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Dock = DockStyle.Top;
            lblAppTitle.Font = new Font("Georgia", 16F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(0, 0);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Padding = new Padding(10, 20, 10, 10);
            lblAppTitle.Size = new Size(200, 80);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "cloudyLib";
            lblAppTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblAppTitle.Click += lblAppTitle_Click;
            // 
            // contentPanel
            // 
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(200, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1000, 775);
            contentPanel.TabIndex = 1;
            contentPanel.Paint += contentPanel_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 775);
            Controls.Add(contentPanel);
            Controls.Add(leftPanel);
            Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "MainForm";
            Text = "cloudyLib";
            leftPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        // Ważne: deklaracje prywatnych pól, aby były dostępne w MainForm.cs
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblWelcomeMessage;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.FlowLayoutPanel navButtonsPanel; // Deklaracja FlowLayoutPanel
    }
}