namespace cloudyLib.Forms
{
    partial class RegisterView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel mainContainerTableLayoutPanel; 
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRegisterTitle;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblMessage;

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
            mainContainerTableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblRegisterTitle = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            btnRegister = new Button();
            lblLogin = new Label();
            lblMessage = new Label();
            mainContainerTableLayoutPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // mainContainerTableLayoutPanel
            // 
            mainContainerTableLayoutPanel.BackColor = Color.AntiqueWhite;
            mainContainerTableLayoutPanel.ColumnCount = 3;
            mainContainerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainContainerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 508F));
            mainContainerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainContainerTableLayoutPanel.Controls.Add(tableLayoutPanel1, 1, 1);
            mainContainerTableLayoutPanel.Dock = DockStyle.Fill;
            mainContainerTableLayoutPanel.Location = new Point(0, 0);
            mainContainerTableLayoutPanel.Name = "mainContainerTableLayoutPanel";
            mainContainerTableLayoutPanel.RowCount = 3;
            mainContainerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainContainerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 450F));
            mainContainerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainContainerTableLayoutPanel.Size = new Size(800, 450);
            mainContainerTableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.BackColor = Color.AntiqueWhite;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.7011948F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.2988052F));
            tableLayoutPanel1.Controls.Add(lblRegisterTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(lblEmail, 0, 1);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 1);
            tableLayoutPanel1.Controls.Add(lblPassword, 0, 2);
            tableLayoutPanel1.Controls.Add(txtPassword, 1, 2);
            tableLayoutPanel1.Controls.Add(lblConfirmPassword, 0, 3);
            tableLayoutPanel1.Controls.Add(txtConfirmPassword, 1, 3);
            tableLayoutPanel1.Controls.Add(lblFirstName, 0, 4);
            tableLayoutPanel1.Controls.Add(txtFirstName, 1, 4);
            tableLayoutPanel1.Controls.Add(lblLastName, 0, 5);
            tableLayoutPanel1.Controls.Add(txtLastName, 1, 5);
            tableLayoutPanel1.Controls.Add(lblPhone, 0, 6);
            tableLayoutPanel1.Controls.Add(txtPhone, 1, 6);
            tableLayoutPanel1.Controls.Add(btnRegister, 0, 7);
            tableLayoutPanel1.Controls.Add(lblLogin, 0, 8);
            tableLayoutPanel1.Controls.Add(lblMessage, 0, 9);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(149, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 81F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.Size = new Size(502, 444);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblRegisterTitle
            // 
            tableLayoutPanel1.SetColumnSpan(lblRegisterTitle, 2);
            lblRegisterTitle.Dock = DockStyle.Fill;
            lblRegisterTitle.Font = new Font("Georgia", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegisterTitle.ForeColor = Color.DarkGreen;
            lblRegisterTitle.Location = new Point(3, 0);
            lblRegisterTitle.Name = "lblRegisterTitle";
            lblRegisterTitle.Size = new Size(496, 60);
            lblRegisterTitle.TabIndex = 0;
            lblRegisterTitle.Text = "Zarejestruj się w cloudyLib";
            lblRegisterTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Right;
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Georgia", 10F);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(62, 70);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BackColor = Color.WhiteSmoke;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Georgia", 10F);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(127, 67);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(372, 26);
            txtEmail.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Right;
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Georgia", 10F);
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(63, 108);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(58, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Hasło:";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BackColor = Color.WhiteSmoke;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Georgia", 10F);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(127, 105);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(372, 26);
            txtPassword.TabIndex = 4;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Anchor = AnchorStyles.Right;
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Georgia", 10F);
            lblConfirmPassword.ForeColor = Color.Black;
            lblConfirmPassword.Location = new Point(32, 136);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(89, 39);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "Potwierdź hasło:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmPassword.BackColor = Color.WhiteSmoke;
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Georgia", 10F);
            txtConfirmPassword.ForeColor = Color.Black;
            txtConfirmPassword.Location = new Point(127, 142);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(372, 26);
            txtConfirmPassword.TabIndex = 6;
            // 
            // lblFirstName
            // 
            lblFirstName.Anchor = AnchorStyles.Right;
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Georgia", 10F);
            lblFirstName.ForeColor = Color.Black;
            lblFirstName.Location = new Point(72, 183);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(49, 20);
            lblFirstName.TabIndex = 7;
            lblFirstName.Text = "Imię:";
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFirstName.BackColor = Color.WhiteSmoke;
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Font = new Font("Georgia", 10F);
            txtFirstName.ForeColor = Color.Black;
            txtFirstName.Location = new Point(127, 180);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(372, 26);
            txtFirstName.TabIndex = 8;
            // 
            // lblLastName
            // 
            lblLastName.Anchor = AnchorStyles.Right;
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Georgia", 10F);
            lblLastName.ForeColor = Color.Black;
            lblLastName.Location = new Point(34, 221);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(87, 20);
            lblLastName.TabIndex = 9;
            lblLastName.Text = "Nazwisko:";
            // 
            // txtLastName
            // 
            txtLastName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtLastName.BackColor = Color.WhiteSmoke;
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Georgia", 10F);
            txtLastName.ForeColor = Color.Black;
            txtLastName.Location = new Point(127, 218);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(372, 26);
            txtLastName.TabIndex = 10;
            // 
            // lblPhone
            // 
            lblPhone.Anchor = AnchorStyles.Right;
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Georgia", 10F);
            lblPhone.ForeColor = Color.Black;
            lblPhone.Location = new Point(50, 259);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(71, 20);
            lblPhone.TabIndex = 11;
            lblPhone.Text = "Telefon:";
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.BackColor = Color.WhiteSmoke;
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Georgia", 10F);
            txtPhone.ForeColor = Color.Black;
            txtPhone.Location = new Point(127, 256);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(372, 26);
            txtPhone.TabIndex = 12;
            // 
            // btnRegister
            // 
            btnRegister.Anchor = AnchorStyles.None;
            btnRegister.BackColor = Color.ForestGreen;
            tableLayoutPanel1.SetColumnSpan(btnRegister, 2);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Georgia", 11F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(151, 308);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(200, 40);
            btnRegister.TabIndex = 13;
            btnRegister.Text = "Zarejestruj się";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // lblLogin
            // 
            lblLogin.Anchor = AnchorStyles.None;
            lblLogin.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(lblLogin, 2);
            lblLogin.Font = new Font("Georgia", 9.75F, FontStyle.Underline);
            lblLogin.ForeColor = Color.SaddleBrown;
            lblLogin.Location = new Point(140, 372);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(221, 20);
            lblLogin.TabIndex = 14;
            lblLogin.Text = "Masz już konto? Zaloguj się.";
            lblLogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(lblMessage, 2);
            lblMessage.Font = new Font("Georgia", 9F, FontStyle.Italic);
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(3, 407);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(496, 25);
            lblMessage.TabIndex = 15;
            lblMessage.Text = "Komunikat";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Visible = false;
            // 
            // RegisterView
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(mainContainerTableLayoutPanel);
            Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "RegisterView";
            Size = new Size(800, 450);
            mainContainerTableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

    }
}