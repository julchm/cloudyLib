namespace cloudyLib.Forms
{
    partial class AddEditLoanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        protected internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected internal System.Windows.Forms.Label lblTitle;
        protected internal System.Windows.Forms.Label lblBook;
        protected internal System.Windows.Forms.ComboBox cmbBook;
        protected internal System.Windows.Forms.Label lblUser;
        protected internal System.Windows.Forms.ComboBox cmbUser;
        protected internal System.Windows.Forms.Label lblLoanDate;
        protected internal System.Windows.Forms.DateTimePicker dtpLoanDate;
        protected internal System.Windows.Forms.Label lblPlannedReturnDate;
        protected internal System.Windows.Forms.DateTimePicker dtpPlannedReturnDate;
        protected internal System.Windows.Forms.CheckBox chkReturned;
        protected internal System.Windows.Forms.Label lblReturnDate;
        protected internal System.Windows.Forms.DateTimePicker dtpReturnDate;
        protected internal System.Windows.Forms.Button btnSave;
        protected internal System.Windows.Forms.Button btnCancel;
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBook = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblLoanDate = new System.Windows.Forms.Label();
            this.dtpLoanDate = new System.Windows.Forms.DateTimePicker();
            this.lblPlannedReturnDate = new System.Windows.Forms.Label();
            this.dtpPlannedReturnDate = new System.Windows.Forms.DateTimePicker();
            this.chkReturned = new System.Windows.Forms.CheckBox();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Controls.Add(this.lblBook, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbBook, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUser, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbUser, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLoanDate, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpLoanDate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPlannedReturnDate, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtpPlannedReturnDate, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkReturned, 0, 5); 
            this.tableLayoutPanel1.Controls.Add(this.lblReturnDate, 0, 6); 
            this.tableLayoutPanel1.Controls.Add(this.dtpReturnDate, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 7); 
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 8); 
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.RowCount = 9; 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); 
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 400); 
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
            this.lblTitle.Size = new System.Drawing.Size(507, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dodaj/Edytuj Wypożyczenie";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblBook
            //
            this.lblBook.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBook.AutoSize = true;
            this.lblBook.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblBook.ForeColor = System.Drawing.Color.Black;
            this.lblBook.Location = new System.Drawing.Point(145, 85);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(58, 20);
            this.lblBook.TabIndex = 1;
            this.lblBook.Text = "Książka:";
            //
            // cmbBook
            //
            this.cmbBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBook.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBook.Font = new System.Drawing.Font("Georgia", 10F);
            this.cmbBook.ForeColor = System.Drawing.Color.Black;
            this.cmbBook.FormattingEnabled = true;
            this.cmbBook.Location = new System.Drawing.Point(209, 83);
            this.cmbBook.Name = "cmbBook";
            this.cmbBook.Size = new System.Drawing.Size(321, 28);
            this.cmbBook.TabIndex = 2;
            //
            // lblUser
            //
            this.lblUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(131, 120);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(72, 20);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Użytkow.:";
            //
            // cmbUser
            //
            this.cmbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Font = new System.Drawing.Font("Georgia", 10F);
            this.cmbUser.ForeColor = System.Drawing.Color.Black;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(209, 118);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(321, 28);
            this.cmbUser.TabIndex = 4;
            //
            // lblLoanDate
            //
            this.lblLoanDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLoanDate.AutoSize = true;
            this.lblLoanDate.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblLoanDate.ForeColor = System.Drawing.Color.Black;
            this.lblLoanDate.Location = new System.Drawing.Point(54, 155);
            this.lblLoanDate.Name = "lblLoanDate";
            this.lblLoanDate.Size = new System.Drawing.Size(149, 20);
            this.lblLoanDate.TabIndex = 5;
            this.lblLoanDate.Text = "Data wypożyczenia:";
            //
            // dtpLoanDate
            //
            this.dtpLoanDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpLoanDate.CalendarFont = new System.Drawing.Font("Georgia", 9F);
            this.dtpLoanDate.Font = new System.Drawing.Font("Georgia", 10F);
            this.dtpLoanDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLoanDate.Location = new System.Drawing.Point(209, 153);
            this.dtpLoanDate.Name = "dtpLoanDate";
            this.dtpLoanDate.Size = new System.Drawing.Size(321, 26);
            this.dtpLoanDate.TabIndex = 6;
            //
            // lblPlannedReturnDate
            //
            this.lblPlannedReturnDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPlannedReturnDate.AutoSize = true;
            this.lblPlannedReturnDate.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblPlannedReturnDate.ForeColor = System.Drawing.Color.Black;
            this.lblPlannedReturnDate.Location = new System.Drawing.Point(23, 190);
            this.lblPlannedReturnDate.Name = "lblPlannedReturnDate";
            this.lblPlannedReturnDate.Size = new System.Drawing.Size(180, 20);
            this.lblPlannedReturnDate.TabIndex = 7;
            this.lblPlannedReturnDate.Text = "Planowana data zwrotu:";
            //
            // dtpPlannedReturnDate
            //
            this.dtpPlannedReturnDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpPlannedReturnDate.CalendarFont = new System.Drawing.Font("Georgia", 9F);
            this.dtpPlannedReturnDate.Font = new System.Drawing.Font("Georgia", 10F);
            this.dtpPlannedReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlannedReturnDate.Location = new System.Drawing.Point(209, 188);
            this.dtpPlannedReturnDate.Name = "dtpPlannedReturnDate";
            this.dtpPlannedReturnDate.Size = new System.Drawing.Size(321, 26);
            this.dtpPlannedReturnDate.TabIndex = 8;
            //
            // chkReturned
            //
            this.chkReturned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkReturned.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkReturned, 2);
            this.chkReturned.Font = new System.Drawing.Font("Georgia", 10F);
            this.chkReturned.ForeColor = System.Drawing.Color.Black;
            this.chkReturned.Location = new System.Drawing.Point(23, 222);
            this.chkReturned.Name = "chkReturned";
            this.chkReturned.Size = new System.Drawing.Size(507, 24);
            this.chkReturned.TabIndex = 9;
            this.chkReturned.Text = "Książka została zwrócona";
            this.chkReturned.UseVisualStyleBackColor = true;
            //
            // lblReturnDate
            //
            this.lblReturnDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblReturnDate.ForeColor = System.Drawing.Color.Black;
            this.lblReturnDate.Location = new System.Drawing.Point(103, 257); 
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(100, 20);
            this.lblReturnDate.TabIndex = 10;
            this.lblReturnDate.Text = "Data zwrotu:";
            //
            // dtpReturnDate
            //
            this.dtpReturnDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpReturnDate.CalendarFont = new System.Drawing.Font("Georgia", 9F);
            this.dtpReturnDate.Font = new System.Drawing.Font("Georgia", 10F);
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(209, 255); 
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(321, 26);
            this.dtpReturnDate.TabIndex = 11;
            //
            // btnSave
            //
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(79, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 35);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Zapisz";
            this.btnSave.UseVisualStyleBackColor = false;
            //
            // btnCancel
            //
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.BackColor = System.Drawing.Color.DarkGray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(209, 298); 
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 35);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // lblMessage
            //
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Italic);
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(23, 340); 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(507, 40);
            this.lblMessage.TabIndex = 14;
            this.lblMessage.Text = "Komunikat";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            //
            // AddEditLoanForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 400); 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AddEditLoanForm";
            this.Text = "AddEditLoanForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}