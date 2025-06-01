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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.adminTabControl = new System.Windows.Forms.TabControl();
            this.manageBooksTab = new System.Windows.Forms.TabPage();
            this.manageUsersTab = new System.Windows.Forms.TabPage();
            this.allLoansTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.adminTabControl.SuspendLayout();
            this.SuspendLayout();
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.AntiqueWhite; 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.adminTabControl, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); 
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 600); 
            this.tableLayoutPanel1.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTitle.Location = new System.Drawing.Point(13, 10); 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(874, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Panel Administratora";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // adminTabControl
            //
            this.adminTabControl.Controls.Add(this.manageBooksTab);
            this.adminTabControl.Controls.Add(this.manageUsersTab);
            this.adminTabControl.Controls.Add(this.allLoansTab);
            this.adminTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminTabControl.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminTabControl.Location = new System.Drawing.Point(13, 73); 
            this.adminTabControl.Name = "adminTabControl";
            this.adminTabControl.SelectedIndex = 0;
            this.adminTabControl.Size = new System.Drawing.Size(874, 514);
            this.adminTabControl.TabIndex = 1;
            this.adminTabControl.Selecting += AdminTabControl_Selecting; // Dodaj obsługę zdarzenia zmiany zakładki
            //
            // manageBooksTab
            //
            this.manageBooksTab.BackColor = System.Drawing.Color.AntiqueWhite; 
            this.manageBooksTab.Location = new System.Drawing.Point(4, 28);
            this.manageBooksTab.Name = "manageBooksTab";
            this.manageBooksTab.Padding = new System.Windows.Forms.Padding(3);
            this.manageBooksTab.Size = new System.Drawing.Size(866, 482);
            this.manageBooksTab.TabIndex = 0;
            this.manageBooksTab.Text = "Zarządzaj Książkami";
            //
            // manageUsersTab
            //
            this.manageUsersTab.BackColor = System.Drawing.Color.AntiqueWhite;
            this.manageUsersTab.Location = new System.Drawing.Point(4, 28);
            this.manageUsersTab.Name = "manageUsersTab";
            this.manageUsersTab.Padding = new System.Windows.Forms.Padding(3);
            this.manageUsersTab.Size = new System.Drawing.Size(866, 482);
            this.manageUsersTab.TabIndex = 1;
            this.manageUsersTab.Text = "Zarządzaj Użytkownikami";
            //
            // allLoansTab
            //
            this.allLoansTab.BackColor = System.Drawing.Color.AntiqueWhite;
            this.allLoansTab.Location = new System.Drawing.Point(4, 28);
            this.allLoansTab.Name = "allLoansTab";
            this.allLoansTab.Padding = new System.Windows.Forms.Padding(3);
            this.allLoansTab.Size = new System.Drawing.Size(866, 482);
            this.allLoansTab.TabIndex = 2;
            this.allLoansTab.Text = "Wypożyczenia";
         
            //
            // AdminView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AdminView";
            this.Size = new System.Drawing.Size(900, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.adminTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}