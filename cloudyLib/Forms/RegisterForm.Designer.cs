namespace cloudyLib.Forms
{
    partial class RegisterForm
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

            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new TextBox();
            this.lblFirstName = new Label();
            this.txtFirstName = new TextBox();
            this.lblLastName = new Label();
            this.txtLastName = new TextBox();
            this.btnRegister = new Button();
            this.llLogin = new LinkLabel();
            this.SuspendLayout();
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(20, 20);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(36, 15);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            this.txtEmail.Location = new Point(130, 17);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(200, 23);
            this.txtEmail.TabIndex = 1;
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(20, 50);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(40, 15);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Hasło:";
            //
            // txtPassword
            //
            this.txtPassword.Location = new Point(130, 47);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(200, 23);
            this.txtPassword.TabIndex = 3;
            //
            // lblConfirmPassword
            //
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new Point(20, 80);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new Size(95, 15);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Potwierdź hasło:";
            //
            // txtConfirmPassword
            //
            this.txtConfirmPassword.Location = new Point(130, 77);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new Size(200, 23);
            this.txtConfirmPassword.TabIndex = 5;
            //
            // lblFirstName
            //
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new Point(20, 110);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new Size(30, 15);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "Imię:";
            //
            // txtFirstName
            //
            this.txtFirstName.Location = new Point(130, 107);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new Size(200, 23);
            this.txtFirstName.TabIndex = 7;
            //
            // lblLastName
            //
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new Point(20, 140);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new Size(58, 15);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "Nazwisko:";
            //
            // txtLastName
            //
            this.txtLastName.Location = new Point(130, 137);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new Size(200, 23);
            this.txtLastName.TabIndex = 9;
            //
            // btnRegister
            //
            this.btnRegister.Location = new Point(20, 180);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new Size(120, 30);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "Zarejestruj";
            this.btnRegister.UseVisualStyleBackColor = true;
            //this.btnRegister.Click += new EventArgs(this.btnRegister_Click);
            //
            // llLogin
            //
            this.llLogin.AutoSize = true;
            this.llLogin.Location = new Point(160, 187);
            this.llLogin.Name = "llLogin";
            this.llLogin.Size = new Size(170, 15);
            this.llLogin.TabIndex = 11;
            this.llLogin.TabStop = true;
            this.llLogin.Text = "Masz już konto? Zaloguj się.";
            this.llLogin.LinkClicked += new LinkLabelLinkClickedEventHandler(this.llLogin_LinkClicked);
            //
            // RegisterForm
            //
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new TextBox();
            this.lblFirstName = new Label();
            this.txtFirstName = new TextBox();
            this.lblLastName = new Label();
            this.txtLastName = new TextBox();
            this.btnRegister = new Button();
            this.llLogin = new LinkLabel();
            this.SuspendLayout();
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(20, 20);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(36, 15);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            this.txtEmail.Location = new Point(130, 17);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(200, 23);
            this.txtEmail.TabIndex = 1;
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(20, 50);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(40, 15);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Hasło:";
            //
            // txtPassword
            //
            this.txtPassword.Location = new Point(130, 47);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(200, 23);
            this.txtPassword.TabIndex = 3;
            //
            // lblConfirmPassword
            //
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new Point(20, 80);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new Size(95, 15);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Potwierdź hasło:";
            //
            // txtConfirmPassword
            //
            this.txtConfirmPassword.Location = new Point(130, 77);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new Size(200, 23);
            this.txtConfirmPassword.TabIndex = 5;
            //
            // lblFirstName
            //
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new Point(20, 110);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new Size(30, 15);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "Imię:";
            //
            // txtFirstName
            //
            this.txtFirstName.Location = new Point(130, 107);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new Size(200, 23);
            this.txtFirstName.TabIndex = 7;
            //
            // lblLastName
            //
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new Point(20, 140);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new Size(58, 15);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "Nazwisko:";
            //
            // txtLastName
            //
            this.txtLastName.Location = new Point(130, 137);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new Size(200, 23);
            this.txtLastName.TabIndex = 9;
            //
            // btnRegister
            //
            this.btnRegister.Location = new Point(20, 180);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new Size(120, 30);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "Zarejestruj";
            this.btnRegister.UseVisualStyleBackColor = true;
            //this.btnRegister.Click += new EventArgs(this.btnRegister_Click);
            //
            // llLogin
            //
            this.llLogin.AutoSize = true;
            this.llLogin.Location = new Point(160, 187);
            this.llLogin.Name = "llLogin";
            this.llLogin.Size = new Size(170, 15);
            this.llLogin.TabIndex = 11;
            this.llLogin.TabStop = true;
            this.llLogin.Text = "Masz już konto? Zaloguj się.";
            this.llLogin.LinkClicked += new LinkLabelLinkClickedEventHandler(this.llLogin_LinkClicked);
            //
            // RegisterForm
            //
            this.ClientSize = new Size(350, 280);
            this.Controls.Add(this.llLogin);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Name = "RegisterForm";
            this.Text = "Rejestracja";
            this.ResumeLayout(false);


            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "RegisterForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
    }
}