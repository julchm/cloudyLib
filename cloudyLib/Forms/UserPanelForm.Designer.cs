namespace cloudyLib.Forms
{
    partial class UserPanelForm : Form
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
            btnBrowseBooks = new Button();
            btnViewBorrowedBooks = new Button();
            btnEditProfile = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // btnBrowseBooks
            // 
            btnBrowseBooks.Location = new Point(20, 20);
            btnBrowseBooks.Name = "btnBrowseBooks";
            btnBrowseBooks.Size = new Size(150, 40);
            btnBrowseBooks.TabIndex = 0;
            btnBrowseBooks.Text = "Przeglądaj Książki";
            btnBrowseBooks.UseVisualStyleBackColor = true;
            btnBrowseBooks.Click += btnBrowseBooks_Click;
            // 
            // btnViewBorrowedBooks
            // 
            btnViewBorrowedBooks.Location = new Point(20, 70);
            btnViewBorrowedBooks.Name = "btnViewBorrowedBooks";
            btnViewBorrowedBooks.Size = new Size(150, 40);
            btnViewBorrowedBooks.TabIndex = 1;
            btnViewBorrowedBooks.Text = "Moje Wypożyczenia";
            btnViewBorrowedBooks.UseVisualStyleBackColor = true;
            btnViewBorrowedBooks.Click += btnViewBorrowedBooks_Click;
            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(20, 120);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(150, 40);
            btnEditProfile.TabIndex = 2;
            btnEditProfile.Text = "Edytuj Profil";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(342, 353);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 30);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Wyloguj";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // UserPanelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogout);
            Controls.Add(btnEditProfile);
            Controls.Add(btnViewBorrowedBooks);
            Controls.Add(btnBrowseBooks);
            Name = "UserPanelForm";
            Text = "UserPanelForm";
            Load += UserPanelForm_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}