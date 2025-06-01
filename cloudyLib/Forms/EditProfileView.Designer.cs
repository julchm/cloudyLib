namespace cloudyLib.Forms
{
    partial class EditProfileView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        protected internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected internal System.Windows.Forms.Label lblTitle;
        protected internal System.Windows.Forms.Label lblFirstName;
        protected internal System.Windows.Forms.TextBox txtFirstName;
        protected internal System.Windows.Forms.Label lblLastName;
        protected internal System.Windows.Forms.TextBox txtLastName;
        protected internal System.Windows.Forms.Label lblEmail;
        protected internal System.Windows.Forms.TextBox txtEmail;
        protected internal System.Windows.Forms.Label lblPhone;
        protected internal System.Windows.Forms.TextBox txtPhone;
        protected internal System.Windows.Forms.LinkLabel lnkChangePassword; // Link do zmiany hasła
        protected internal System.Windows.Forms.Label lblCurrentPassword;   // Etykieta dla obecnego hasła
        protected internal System.Windows.Forms.TextBox txtCurrentPassword; // Pole dla obecnego hasła
        protected internal System.Windows.Forms.Label lblNewPassword;       // Etykieta dla nowego hasła
        protected internal System.Windows.Forms.TextBox txtNewPassword;     // Pole dla nowego hasła
        protected internal System.Windows.Forms.Label lblConfirmNewPassword; // Etykieta dla potwierdzenia nowego hasła
        protected internal System.Windows.Forms.TextBox txtConfirmNewPassword; // Pole dla potwierdzenia nowego hasła
        protected internal System.Windows.Forms.Button btnSaveChanges;
        protected internal System.Windows.Forms.Label lblMessage;


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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lnkChangePassword = new System.Windows.Forms.LinkLabel();
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmNewPassword = new System.Windows.Forms.Label();
            this.txtConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFirstName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFirstName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLastName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtLastName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblEmail, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPhone, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPhone, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lnkChangePassword, 0, 5); // Link do zmiany hasła
            this.tableLayoutPanel1.Controls.Add(this.lblCurrentPassword, 0, 6); // Obecne hasło
            this.tableLayoutPanel1.Controls.Add(this.txtCurrentPassword, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblNewPassword, 0, 7);     // Nowe hasło
            this.tableLayoutPanel1.Controls.Add(this.txtNewPassword, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblConfirmNewPassword, 0, 8); // Potwierdzenie nowego hasła
            this.tableLayoutPanel1.Controls.Add(this.txtConfirmNewPassword, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveChanges, 0, 9); // Przycisk zapisu
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 10);     // Komunikat
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.RowCount = 11; // 1 tytuł + 4 pola danych + 1 link + 3 hasła + 1 przycisk + 1 komunikat = 11
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Tytuł
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Imię
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Nazwisko
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Email
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Telefon
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F)); // Link zmiany hasła
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Obecne hasło
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Nowe hasło
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Potwierdź nowe hasło
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Przycisk zapisu
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // Komunikat
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 500); // Docelowy rozmiar UserControl
            this.tableLayoutPanel1.TabIndex = 0;
            //
            // lblTitle
            //
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTitle.Location = new System.Drawing.Point(23, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(657, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Edytuj Swój Profil";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblFirstName
            //
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblFirstName.ForeColor = System.Drawing.Color.Black;
            this.lblFirstName.Location = new System.Drawing.Point(219, 85);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(49, 20);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "Imię:";
            //
            // txtFirstName
            //
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Georgia", 10F);
            this.txtFirstName.ForeColor = System.Drawing.Color.Black;
            this.txtFirstName.Location = new System.Drawing.Point(274, 83);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(406, 26);
            this.txtFirstName.TabIndex = 2;
            //
            // lblLastName
            //
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblLastName.ForeColor = System.Drawing.Color.Black;
            this.lblLastName.Location = new System.Drawing.Point(181, 120);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(87, 20);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Nazwisko:";
            //
            // txtLastName
            //
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Georgia", 10F);
            this.txtLastName.ForeColor = System.Drawing.Color.Black;
            this.txtLastName.Location = new System.Drawing.Point(274, 118);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(406, 26);
            this.txtLastName.TabIndex = 4;
            //
            // lblEmail
            //
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.Location = new System.Drawing.Point(219, 155);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(59, 20);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Georgia", 10F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(274, 153);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(406, 26);
            this.txtEmail.TabIndex = 6;
            //
            // lblPhone
            //
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.Location = new System.Drawing.Point(202, 190);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(68, 20);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "Telefon:";
            //
            // txtPhone
            //
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Georgia", 10F);
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.Location = new System.Drawing.Point(274, 188);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(406, 26);
            this.txtPhone.TabIndex = 8;
            //
            // lnkChangePassword
            //
            this.lnkChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.lnkChangePassword, 2);
            this.lnkChangePassword.AutoSize = true;
            this.lnkChangePassword.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Underline);
            this.lnkChangePassword.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lnkChangePassword.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkChangePassword.Location = new System.Drawing.Point(23, 225);
            this.lnkChangePassword.Name = "lnkChangePassword";
            this.lnkChangePassword.Size = new System.Drawing.Size(657, 18);
            this.lnkChangePassword.TabIndex = 9;
            this.lnkChangePassword.TabStop = true;
            this.lnkChangePassword.Text = "Zmień hasło";
            this.lnkChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblCurrentPassword
            //
            this.lblCurrentPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblCurrentPassword.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentPassword.Location = new System.Drawing.Point(149, 258);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(119, 20);
            this.lblCurrentPassword.TabIndex = 10;
            this.lblCurrentPassword.Text = "Obecne hasło:";
            //
            // txtCurrentPassword
            //
            this.txtCurrentPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrentPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentPassword.Font = new System.Drawing.Font("Georgia", 10F);
            this.txtCurrentPassword.ForeColor = System.Drawing.Color.Black;
            this.txtCurrentPassword.Location = new System.Drawing.Point(274, 256);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(406, 26);
            this.txtCurrentPassword.TabIndex = 11;
            //
            // lblNewPassword
            //
            this.lblNewPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblNewPassword.ForeColor = System.Drawing.Color.Black;
            this.lblNewPassword.Location = new System.Drawing.Point(167, 293);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(101, 20);
            this.lblNewPassword.TabIndex = 12;
            this.lblNewPassword.Text = "Nowe hasło:";
            //
            // txtNewPassword
            //
            this.txtNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword.Font = new System.Drawing.Font("Georgia", 10F);
            this.txtNewPassword.ForeColor = Color.Black;
            this.txtNewPassword.Location = new System.Drawing.Point(274, 291);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(406, 26);
            this.txtNewPassword.TabIndex = 13;
            //
            // lblConfirmNewPassword
            //
            this.lblConfirmNewPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblConfirmNewPassword.AutoSize = true;
            this.lblConfirmNewPassword.Font = new Font("Georgia", 10F);
            this.lblConfirmNewPassword.ForeColor = Color.Black;
            this.lblConfirmNewPassword.Location = new Point(66, 328);
            this.lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            this.lblConfirmNewPassword.Size = new Size(202, 20);
            this.lblConfirmNewPassword.TabIndex = 14;
            this.lblConfirmNewPassword.Text = "Potwierdź nowe hasło:";
            //
            // txtConfirmNewPassword
            //
            this.txtConfirmNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmNewPassword.BackColor = Color.WhiteSmoke;
            this.txtConfirmNewPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtConfirmNewPassword.Font = new Font("Georgia", 10F);
            this.txtConfirmNewPassword.ForeColor = Color.Black;
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(274, 326);
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(406, 26);
            this.txtConfirmNewPassword.TabIndex = 15;
            //
            // btnSaveChanges
            //
            this.btnSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveChanges.BackColor = Color.ForestGreen;
            this.tableLayoutPanel1.SetColumnSpan(this.btnSaveChanges, 2);
            this.btnSaveChanges.FlatAppearance.BorderSize = 0;
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.Font = new Font("Georgia", 11F, FontStyle.Bold);
            this.btnSaveChanges.ForeColor = Color.White;
            this.btnSaveChanges.Location = new Point(275, 365);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new Size(150, 40);
            this.btnSaveChanges.TabIndex = 16;
            this.btnSaveChanges.Text = "Zapisz zmiany";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            //
            // lblMessage
            //
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.lblMessage, 2);
            this.lblMessage.Font = new Font("Georgia", 9F, FontStyle.Italic);
            this.lblMessage.ForeColor = Color.Red;
            this.lblMessage.Location = new Point(23, 420);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new Size(657, 40);
            this.lblMessage.TabIndex = 17;
            this.lblMessage.Text = "Komunikat";
            this.lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            //
            // EditProfileView
            //
            this.AutoScaleDimensions = new SizeF(8F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.AntiqueWhite;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Name = "EditProfileView";
            this.Size = new Size(700, 500);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}