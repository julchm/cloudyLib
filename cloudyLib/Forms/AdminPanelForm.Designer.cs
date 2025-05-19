namespace cloudyLib.Forms
{
    partial class AdminPanelForm
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
            SuspendLayout();
            this.btnManageBooks = new Button();
            this.btnManageUsers = new Button();
            this.btnViewLoans = new Button();
            this.btnViewPopularBooks = new Button();
            this.btnLogout = new Button();
            this.SuspendLayout();
            //
            // btnManageBooks
            //
            this.btnManageBooks.Location = new System.Drawing.Point(20, 20);
            this.btnManageBooks.Name = "btnManageBooks";
            this.btnManageBooks.Size = new System.Drawing.Size(150, 40);
            this.btnManageBooks.TabIndex = 0;
            this.btnManageBooks.Text = "Zarządzaj Książkami";
            this.btnManageBooks.UseVisualStyleBackColor = true;
            this.btnManageBooks.Click += new System.EventHandler(this.btnManageBooks_Click);
            //
            // btnManageUsers
            //
            this.btnManageUsers.Location = new System.Drawing.Point(180, 20);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(150, 40);
            this.btnManageUsers.TabIndex = 1;
            this.btnManageUsers.Text = "Zarządzaj Użytkownikami";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            //
            // btnViewLoans
            //
            this.btnViewLoans.Location = new System.Drawing.Point(20, 70);
            this.btnViewLoans.Name = "btnViewLoans";
            this.btnViewLoans.Size = new System.Drawing.Size(150, 40);
            this.btnViewLoans.TabIndex = 2;
            this.btnViewLoans.Text = "Przeglądaj Wypożyczenia";
            this.btnViewLoans.UseVisualStyleBackColor = true;
            this.btnViewLoans.Click += new System.EventHandler(this.btnViewLoans_Click);
            //
            // btnViewPopularBooks
            //
            this.btnViewPopularBooks.Location = new System.Drawing.Point(180, 70);
            this.btnViewPopularBooks.Name = "btnViewPopularBooks";
            this.btnViewPopularBooks.Size = new System.Drawing.Size(150, 40);
            this.btnViewPopularBooks.TabIndex = 3;
            this.btnViewPopularBooks.Text = "Najpopularniejsze Książki";
            this.btnViewPopularBooks.UseVisualStyleBackColor = true;
            this.btnViewPopularBooks.Click += new System.EventHandler(this.btnViewPopularBooks_Click);
            //
            // btnLogout
            //
            this.btnLogout.Location = new System.Drawing.Point(this.ClientSize.Width - 100 - 20, this.ClientSize.Height - 40 - 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 30);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Wyloguj";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // AdminPanelForm
            //
            this.ClientSize = new System.Drawing.Size(350, 220);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewPopularBooks);
            this.Controls.Add(this.btnViewLoans);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnManageBooks);
            this.Name = "AdminPanelForm";
            this.Text = "Panel Administratora";
            this.ResumeLayout(false);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "AdminPanelForm";
            Text = "Form1";
            Load += AdminPanelForm_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}