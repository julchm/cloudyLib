namespace cloudyLib.Forms
{
    partial class RegisterView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
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
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cmbCountry;
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRegisterTitle = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.AutoScroll = true; // Pozostawiamy AutoScroll na wypadek mniejszych ekranów
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.AntiqueWhite; // Jasny beżowy
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.lblRegisterTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblEmail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPassword, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblConfirmPassword, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtConfirmPassword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFirstName, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtFirstName, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblLastName, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtLastName, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtAddress, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblCity, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtCity, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblPostalCode, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtPostalCode, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblCountry, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.cmbCountry, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblPhone, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtPhone, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.btnRegister, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.lblLogin, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 13);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F)); // Tytuł
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Email
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Hasło
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Potwierdź Hasło
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Imię
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Nazwisko
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Adres
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Miasto
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Kod Pocztowy
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Kraj
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Telefon
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // Przycisk Register
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); // Link Login
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // Wiadomość o błędzie
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            //
            // lblRegisterTitle
            //
            this.tableLayoutPanel1.SetColumnSpan(this.lblRegisterTitle, 2);
            this.lblRegisterTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRegisterTitle.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Georgia, pogrubiona
            this.lblRegisterTitle.ForeColor = System.Drawing.Color.DarkGreen; // Ciemna zieleń
            this.lblRegisterTitle.Location = new System.Drawing.Point(33, 20);
            this.lblRegisterTitle.Name = "lblRegisterTitle";
            this.lblRegisterTitle.Size = new System.Drawing.Size(734, 60);
            this.lblRegisterTitle.TabIndex = 0;
            this.lblRegisterTitle.Text = "Zarejestruj się w cloudyLib";
            this.lblRegisterTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblEmail
            //
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.lblEmail.ForeColor = System.Drawing.Color.Black; // Czarny
            this.lblEmail.Location = new System.Drawing.Point(220, 89);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(55, 23);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BackColor = System.Drawing.Color.WhiteSmoke; // Jaśniejszy beżowy/szarobiały dla pól
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.txtEmail.ForeColor = System.Drawing.Color.Black; // Czarny
            this.txtEmail.Location = new System.Drawing.Point(281, 89);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(486, 30);
            this.txtEmail.TabIndex = 2;
            //
            // lblPassword
            //
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.lblPassword.ForeColor = System.Drawing.Color.Black; // Czarny
            this.lblPassword.Location = new System.Drawing.Point(218, 124);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 23);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Hasło:";
            //
            // txtPassword
            //
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke; // Jaśniejszy beżowy/szarobiały dla pól
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.txtPassword.ForeColor = System.Drawing.Color.Black; // Czarny
            this.txtPassword.Location = new System.Drawing.Point(281, 124);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(486, 30);
            this.txtPassword.TabIndex = 4;
            //
            // lblConfirmPassword
            //
            this.lblConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.Black; // Czarny
            this.lblConfirmPassword.Location = new System.Drawing.Point(145, 159);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(130, 23);
            this.lblConfirmPassword.TabIndex = 5;
            this.lblConfirmPassword.Text = "Potwierdź hasło:";
            //
            // txtConfirmPassword
            //
            this.txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPassword.BackColor = System.Drawing.Color.WhiteSmoke; // Jaśniejszy beżowy/szarobiały dla pól
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.Black; // Czarny
            this.txtConfirmPassword.Location = new System.Drawing.Point(281, 159);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(486, 30);
            this.txtConfirmPassword.TabIndex = 6;
            //
            // lblFirstName
            //
            this.lblFirstName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.lblFirstName.ForeColor = System.Drawing.Color.Black; // Czarny
            this.lblFirstName.Location = new System.Drawing.Point(229, 194);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(46, 23);
            this.lblFirstName.TabIndex = 7;
            this.lblFirstName.Text = "Imię:";
            //
            // txtFirstName
            //
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.BackColor = System.Drawing.Color.WhiteSmoke; // Jaśniejszy beżowy/szarobiały dla pól
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.txtFirstName.ForeColor = System.Drawing.Color.Black; // Czarny
            this.txtFirstName.Location = new System.Drawing.Point(281, 194);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(486, 30);
            this.txtFirstName.TabIndex = 8;
            //
            // lblLastName
            //
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.lblLastName.ForeColor = System.Drawing.Color.Black; // Czarny
            this.lblLastName.Location = new System.Drawing.Point(192, 229);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(83, 23);
            this.lblLastName.TabIndex = 9;
            this.lblLastName.Text = "Nazwisko:";
            //
            // txtLastName
            //
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.BackColor = System.Drawing.Color.WhiteSmoke; // Jaśniejszy beżowy/szarobiały dla pól
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.txtLastName.ForeColor = System.Drawing.Color.Black; // Czarny
            this.txtLastName.Location = new System.Drawing.Point(281, 229);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(486, 30);
            this.txtLastName.TabIndex = 10;
            //
            // lblAddress
            //
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.lblAddress.ForeColor = System.Drawing.Color.Black; // Czarny
            this.lblAddress.Location = new System.Drawing.Point(62, 264);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(213, 23);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Ulica i numer domu/miesz.:";
            //
            // txtAddress
            //
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.BackColor = System.Drawing.Color.WhiteSmoke; // Jaśniejszy beżowy/szarobiały dla pól
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.txtAddress.ForeColor = System.Drawing.Color.Black; // Czarny
            this.txtAddress.Location = new System.Drawing.Point(281, 264);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(486, 30);
            this.txtAddress.TabIndex = 12;
            //
            // lblCity
            //
            this.lblCity.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.lblCity.ForeColor = System.Drawing.Color.Black; // Czarny
            this.lblCity.Location = new System.Drawing.Point(215, 299);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(60, 23);
            this.lblCity.TabIndex = 13;
            this.lblCity.Text = "Miasto:";
            //
            // txtCity
            //
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.BackColor = System.Drawing.Color.WhiteSmoke; // Jaśniejszy beżowy/szarobiały dla pól
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.txtCity.ForeColor = System.Drawing.Color.Black; // Czarny
            this.txtCity.Location = new System.Drawing.Point(281, 299);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(486, 30);
            this.txtCity.TabIndex = 14;
            //
            // lblPostalCode
            //
            this.lblPostalCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.lblPostalCode.ForeColor = System.Drawing.Color.Black; // Czarny
            this.lblPostalCode.Location = new System.Drawing.Point(152, 334);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(123, 23);
            this.lblPostalCode.TabIndex = 15;
            this.lblPostalCode.Text = "Kod Pocztowy:";
            //
            // txtPostalCode
            //
            this.txtPostalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostalCode.BackColor = System.Drawing.Color.WhiteSmoke; // Jaśniejszy beżowy/szarobiały dla pól
            this.txtPostalCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPostalCode.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.txtPostalCode.ForeColor = System.Drawing.Color.Black; // Czarny
            this.txtPostalCode.Location = new System.Drawing.Point(281, 334);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(486, 30);
            this.txtPostalCode.TabIndex = 16;
            //
            // lblCountry
            //
            this.lblCountry.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.lblCountry.ForeColor = System.Drawing.Color.Black; // Czarny
            this.lblCountry.Location = new System.Drawing.Point(229, 369);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(46, 23);
            this.lblCountry.TabIndex = 17;
            this.lblCountry.Text = "Kraj:";
            //
            // cmbCountry
            //
            this.cmbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCountry.BackColor = System.Drawing.Color.WhiteSmoke; // Jaśniejszy beżowy/szarobiały dla pól
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.cmbCountry.ForeColor = System.Drawing.Color.Black; // Czarny
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(281, 369);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(486, 31);
            this.cmbCountry.TabIndex = 18;
            //
            // lblPhone
            //
            this.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.lblPhone.ForeColor = System.Drawing.Color.Black; // Czarny
            this.lblPhone.Location = new System.Drawing.Point(207, 404);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(68, 23);
            this.lblPhone.TabIndex = 19;
            this.lblPhone.Text = "Telefon:";
            //
            // txtPhone
            //
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.BackColor = System.Drawing.Color.WhiteSmoke; // Jaśniejszy beżowy/szarobiały dla pól
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Georgia", 10F); // Georgia
            this.txtPhone.ForeColor = System.Drawing.Color.Black; // Czarny
            this.txtPhone.Location = new System.Drawing.Point(281, 404);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(486, 30);
            this.txtPhone.TabIndex = 20;
            //
            // btnRegister
            //
            this.btnRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegister.BackColor = System.Drawing.Color.ForestGreen; // Ciemniejsza zieleń dla przycisku
            this.tableLayoutPanel1.SetColumnSpan(this.btnRegister, 2);
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Georgia", 11F, System.Drawing.FontStyle.Bold); // Georgia, pogrubiona
            this.btnRegister.ForeColor = System.Drawing.Color.White; // Biały tekst
            this.btnRegister.Location = new System.Drawing.Point(294, 452);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(200, 40);
            this.btnRegister.TabIndex = 21;
            this.btnRegister.Text = "Zarejestruj się";
            this.btnRegister.UseVisualStyleBackColor = false;
            //
            // lblLogin
            //
            this.lblLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLogin.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblLogin, 2);
            this.lblLogin.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Underline); // Georgia, podkreślona
            this.lblLogin.ForeColor = System.Drawing.Color.SaddleBrown; // Brązowy link
            this.lblLogin.Location = new System.Drawing.Point(286, 507);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(228, 23);
            this.lblLogin.TabIndex = 22;
            this.lblLogin.Text = "Masz już konto? Zaloguj się.";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblMessage
            //
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.lblMessage, 2);
            this.lblMessage.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Italic); // Georgia, kursywa
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(33, 545);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(734, 25);
            this.lblMessage.TabIndex = 23;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            //
            // RegisterView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite; // Jasny beżowy dla całego UserControl
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Domyślna czcionka dla widoku
            this.Name = "RegisterView";
            this.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

    }
}