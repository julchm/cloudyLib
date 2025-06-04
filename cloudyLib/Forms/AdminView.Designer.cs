namespace cloudyLib.Forms
{
    partial class AdminView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTitle;
        protected internal System.Windows.Forms.TabControl adminTabControl;
        protected internal System.Windows.Forms.TabPage manageBooksTab;
        protected internal System.Windows.Forms.TabPage manageUsersTab;
        protected internal System.Windows.Forms.TabPage allLoansTab;


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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTitle = new Label();
            adminTabControl = new TabControl();
            manageBooksTab = new TabPage();
            manageUsersTab = new TabPage();
            allLoansTab = new TabPage();
            tableLayoutPanel1.SuspendLayout();
            adminTabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.AntiqueWhite;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(adminTabControl, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(900, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Georgia", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(13, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(874, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Panel Administratora";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adminTabControl
            // 
            adminTabControl.Controls.Add(manageBooksTab);
            adminTabControl.Controls.Add(manageUsersTab);
            adminTabControl.Controls.Add(allLoansTab);
            adminTabControl.Dock = DockStyle.Fill;
            adminTabControl.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            adminTabControl.Location = new Point(13, 73);
            adminTabControl.Name = "adminTabControl";
            adminTabControl.SelectedIndex = 0;
            adminTabControl.Size = new Size(874, 514);
            adminTabControl.TabIndex = 1;
            adminTabControl.Selecting += AdminTabControl_Selecting;
            // 
            // manageBooksTab
            // 
            manageBooksTab.BackColor = Color.AntiqueWhite;
            manageBooksTab.Location = new Point(4, 27);
            manageBooksTab.Name = "manageBooksTab";
            manageBooksTab.Padding = new Padding(3);
            manageBooksTab.Size = new Size(866, 483);
            manageBooksTab.TabIndex = 0;
            manageBooksTab.Text = "Zarządzaj Książkami";
            // 
            // manageUsersTab
            // 
            manageUsersTab.BackColor = Color.AntiqueWhite;
            manageUsersTab.Location = new Point(4, 27);
            manageUsersTab.Name = "manageUsersTab";
            manageUsersTab.Padding = new Padding(3);
            manageUsersTab.Size = new Size(866, 483);
            manageUsersTab.TabIndex = 1;
            manageUsersTab.Text = "Zarządzaj Użytkownikami";
            // 
            // allLoansTab
            // 
            allLoansTab.BackColor = Color.AntiqueWhite;
            allLoansTab.Location = new Point(4, 27);
            allLoansTab.Name = "allLoansTab";
            allLoansTab.Padding = new Padding(3);
            allLoansTab.Size = new Size(866, 483);
            allLoansTab.TabIndex = 2;
            allLoansTab.Text = "Wszystkie Wypożyczenia";
            
            // 
            // AdminView
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "AdminView";
            Size = new Size(900, 600);
            tableLayoutPanel1.ResumeLayout(false);
            adminTabControl.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
    }
}