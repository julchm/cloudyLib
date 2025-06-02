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
        protected internal System.Windows.Forms.LinkLabel lnkChangePassword; 
        protected internal System.Windows.Forms.Label lblCurrentPassword;   
        protected internal System.Windows.Forms.TextBox txtCurrentPassword; 
        protected internal System.Windows.Forms.Label lblNewPassword;       
        protected internal System.Windows.Forms.TextBox txtNewPassword;     
        protected internal System.Windows.Forms.Label lblConfirmNewPassword;
        protected internal System.Windows.Forms.TextBox txtConfirmNewPassword; 
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTitle = new Label();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            btnSaveChanges = new Button();
            lblMessage = new Label();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblConfirmNewPassword = new Label();
            txtConfirmNewPassword = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.BackColor = Color.AntiqueWhite;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(lblFirstName, 0, 1);
            tableLayoutPanel1.Controls.Add(txtFirstName, 1, 1);
            tableLayoutPanel1.Controls.Add(lblLastName, 0, 2);
            tableLayoutPanel1.Controls.Add(txtLastName, 1, 2);
            tableLayoutPanel1.Controls.Add(lblEmail, 0, 3);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 3);
            tableLayoutPanel1.Controls.Add(lblPhone, 0, 4);
            tableLayoutPanel1.Controls.Add(txtPhone, 1, 4);
            tableLayoutPanel1.Controls.Add(btnSaveChanges, 0, 9);
            tableLayoutPanel1.Controls.Add(lblMessage, 0, 10);
            tableLayoutPanel1.Controls.Add(lblCurrentPassword, 0, 5);
            tableLayoutPanel1.Controls.Add(txtCurrentPassword, 1, 5);
            tableLayoutPanel1.Controls.Add(lblNewPassword, 0, 6);
            tableLayoutPanel1.Controls.Add(txtNewPassword, 1, 6);
            tableLayoutPanel1.Controls.Add(lblConfirmNewPassword, 0, 7);
            tableLayoutPanel1.Controls.Add(txtConfirmNewPassword, 1, 7);
            tableLayoutPanel1.Location = new Point(50, 50);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20);
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.Size = new Size(650, 500);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            tableLayoutPanel1.SetColumnSpan(lblTitle, 2);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Georgia", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(23, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(604, 55);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Edytuj Swój Profil";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFirstName
            // 
            lblFirstName.Anchor = AnchorStyles.Right;
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Georgia", 10F);
            lblFirstName.ForeColor = Color.Black;
            lblFirstName.Location = new Point(212, 80);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(49, 20);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "Imię:";
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFirstName.BackColor = Color.WhiteSmoke;
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Font = new Font("Georgia", 10F);
            txtFirstName.ForeColor = Color.Black;
            txtFirstName.Location = new Point(267, 78);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(360, 26);
            txtFirstName.TabIndex = 2;
            // 
            // lblLastName
            // 
            lblLastName.Anchor = AnchorStyles.Right;
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Georgia", 10F);
            lblLastName.ForeColor = Color.Black;
            lblLastName.Location = new Point(174, 112);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(87, 20);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Nazwisko:";
            // 
            // txtLastName
            // 
            txtLastName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtLastName.BackColor = Color.WhiteSmoke;
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Georgia", 10F);
            txtLastName.ForeColor = Color.Black;
            txtLastName.Location = new Point(267, 109);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(360, 26);
            txtLastName.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Right;
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Georgia", 10F);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(202, 147);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 20);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BackColor = Color.WhiteSmoke;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Georgia", 10F);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(267, 144);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(360, 26);
            txtEmail.TabIndex = 6;
            // 
            // lblPhone
            // 
            lblPhone.Anchor = AnchorStyles.Right;
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Georgia", 10F);
            lblPhone.ForeColor = Color.Black;
            lblPhone.Location = new Point(190, 182);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(71, 20);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Telefon:";
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.BackColor = Color.WhiteSmoke;
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Georgia", 10F);
            txtPhone.ForeColor = Color.Black;
            txtPhone.Location = new Point(267, 179);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(360, 26);
            txtPhone.TabIndex = 8;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Anchor = AnchorStyles.None;
            btnSaveChanges.BackColor = Color.ForestGreen;
            tableLayoutPanel1.SetColumnSpan(btnSaveChanges, 2);
            btnSaveChanges.FlatAppearance.BorderSize = 0;
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.Font = new Font("Georgia", 11F, FontStyle.Bold);
            btnSaveChanges.ForeColor = Color.White;
            btnSaveChanges.Location = new Point(250, 354);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(150, 35);
            btnSaveChanges.TabIndex = 16;
            btnSaveChanges.Text = "Zapisz zmiany";
            btnSaveChanges.UseVisualStyleBackColor = false;
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(lblMessage, 2);
            lblMessage.Font = new Font("Georgia", 9F, FontStyle.Italic);
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(23, 416);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(604, 40);
            lblMessage.TabIndex = 17;
            lblMessage.Text = "Komunikat";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Visible = false;
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.Anchor = AnchorStyles.Right;
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Font = new Font("Georgia", 10F);
            lblCurrentPassword.ForeColor = Color.Black;
            lblCurrentPassword.Location = new Point(146, 217);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(115, 20);
            lblCurrentPassword.TabIndex = 10;
            lblCurrentPassword.Text = "Obecne hasło:";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCurrentPassword.BackColor = Color.WhiteSmoke;
            txtCurrentPassword.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentPassword.Font = new Font("Georgia", 10F);
            txtCurrentPassword.ForeColor = Color.Black;
            txtCurrentPassword.Location = new Point(267, 214);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(360, 26);
            txtCurrentPassword.TabIndex = 11;
            // 
            // lblNewPassword
            // 
            lblNewPassword.Anchor = AnchorStyles.Right;
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Georgia", 10F);
            lblNewPassword.ForeColor = Color.Black;
            lblNewPassword.Location = new Point(160, 252);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(101, 20);
            lblNewPassword.TabIndex = 12;
            lblNewPassword.Text = "Nowe hasło:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNewPassword.BackColor = Color.WhiteSmoke;
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("Georgia", 10F);
            txtNewPassword.ForeColor = Color.Black;
            txtNewPassword.Location = new Point(267, 249);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(360, 26);
            txtNewPassword.TabIndex = 13;
            // 
            // lblConfirmNewPassword
            // 
            lblConfirmNewPassword.Anchor = AnchorStyles.Right;
            lblConfirmNewPassword.AutoSize = true;
            lblConfirmNewPassword.Font = new Font("Georgia", 10F);
            lblConfirmNewPassword.ForeColor = Color.Black;
            lblConfirmNewPassword.Location = new Point(83, 287);
            lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            lblConfirmNewPassword.Size = new Size(178, 20);
            lblConfirmNewPassword.TabIndex = 14;
            lblConfirmNewPassword.Text = "Potwierdź nowe hasło:";
            // 
            // txtConfirmNewPassword
            // 
            txtConfirmNewPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmNewPassword.BackColor = Color.WhiteSmoke;
            txtConfirmNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmNewPassword.Font = new Font("Georgia", 10F);
            txtConfirmNewPassword.ForeColor = Color.Black;
            txtConfirmNewPassword.Location = new Point(267, 284);
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.Size = new Size(360, 26);
            txtConfirmNewPassword.TabIndex = 15;
            // 
            // EditProfileView
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "EditProfileView";
            Size = new Size(700, 500);
            SizeChanged += EditProfileView_SizeChanged;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
    }
}