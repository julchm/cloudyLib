namespace cloudyLib.Forms
{
    partial class LoginView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblRegister;

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
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblMessage = new Label();
            btnLogin = new Button();
            lblRegister = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.AntiqueWhite;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 1);
            tableLayoutPanel1.Controls.Add(lblEmail, 1, 3);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 4);
            tableLayoutPanel1.Controls.Add(lblPassword, 1, 5);
            tableLayoutPanel1.Controls.Add(txtPassword, 1, 6);
            tableLayoutPanel1.Controls.Add(lblMessage, 1, 7);
            tableLayoutPanel1.Controls.Add(btnLogin, 1, 8);
            tableLayoutPanel1.Controls.Add(lblRegister, 0, 10);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 12;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            tableLayoutPanel1.SetColumnSpan(lblTitle, 3);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Georgia", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(3, 60);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(794, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Logowanie do cloudyLib";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Left;
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Georgia", 10F);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(228, 142);
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
            txtEmail.Location = new Point(228, 169);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(344, 26);
            txtEmail.TabIndex = 2;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Left;
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Georgia", 10F);
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(228, 202);
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
            txtPassword.Location = new Point(228, 229);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(344, 26);
            txtPassword.TabIndex = 4;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // lblMessage
            // 
            lblMessage.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblMessage.Font = new Font("Georgia", 9F, FontStyle.Italic);
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(228, 262);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(344, 25);
            lblMessage.TabIndex = 7;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Visible = false;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.BackColor = Color.ForestGreen;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Georgia", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(300, 295);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 40);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Zaloguj się";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // lblRegister
            // 
            tableLayoutPanel1.SetColumnSpan(lblRegister, 3);
            lblRegister.Cursor = Cursors.Hand;
            lblRegister.Dock = DockStyle.Fill;
            lblRegister.Font = new Font("Georgia", 9.75F, FontStyle.Underline);
            lblRegister.ForeColor = Color.SaddleBrown;
            lblRegister.Location = new Point(3, 360);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(794, 30);
            lblRegister.TabIndex = 6;
            lblRegister.Text = "Nie masz konta? Zarejestruj się";
            lblRegister.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "LoginView";
            Size = new Size(800, 450);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

    }
}