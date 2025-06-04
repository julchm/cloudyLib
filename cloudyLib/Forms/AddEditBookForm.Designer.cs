namespace cloudyLib.Forms
{
    partial class AddEditBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected internal System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        protected internal System.Windows.Forms.Label lblTitle;
        protected internal System.Windows.Forms.Label lblBookTitle;
        protected internal System.Windows.Forms.TextBox txtBookTitle;
        protected internal System.Windows.Forms.Label lblISBN;
        protected internal System.Windows.Forms.TextBox txtISBN;
        protected internal System.Windows.Forms.Label lblYearOfRelease;
        protected internal System.Windows.Forms.NumericUpDown numYearOfRelease;
        protected internal System.Windows.Forms.Label lblAvailableCopies;
        protected internal System.Windows.Forms.NumericUpDown numAvailableCopies;
        protected internal System.Windows.Forms.Label lblAuthors;
        protected internal System.Windows.Forms.CheckedListBox clbAuthors; 
        protected internal System.Windows.Forms.Label lblGenres;
        protected internal System.Windows.Forms.CheckedListBox clbGenres; 
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
            tableLayoutPanelMain = new TableLayoutPanel();
            lblTitle = new Label();
            lblBookTitle = new Label();
            txtBookTitle = new TextBox();
            lblISBN = new Label();
            txtISBN = new TextBox();
            lblYearOfRelease = new Label();
            numYearOfRelease = new NumericUpDown();
            lblAvailableCopies = new Label();
            numAvailableCopies = new NumericUpDown();
            lblAuthors = new Label();
            clbAuthors = new CheckedListBox();
            lblGenres = new Label();
            clbGenres = new CheckedListBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblMessage = new Label();
            tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numYearOfRelease).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAvailableCopies).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.BackColor = Color.AntiqueWhite;
            tableLayoutPanelMain.ColumnCount = 2;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanelMain.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanelMain.Controls.Add(lblBookTitle, 0, 1);
            tableLayoutPanelMain.Controls.Add(txtBookTitle, 1, 1);
            tableLayoutPanelMain.Controls.Add(lblISBN, 0, 2);
            tableLayoutPanelMain.Controls.Add(txtISBN, 1, 2);
            tableLayoutPanelMain.Controls.Add(lblYearOfRelease, 0, 3);
            tableLayoutPanelMain.Controls.Add(numYearOfRelease, 1, 3);
            tableLayoutPanelMain.Controls.Add(lblAvailableCopies, 0, 4);
            tableLayoutPanelMain.Controls.Add(numAvailableCopies, 1, 4);
            tableLayoutPanelMain.Controls.Add(lblAuthors, 0, 5);
            tableLayoutPanelMain.Controls.Add(clbAuthors, 1, 5);
            tableLayoutPanelMain.Controls.Add(lblGenres, 0, 6);
            tableLayoutPanelMain.Controls.Add(clbGenres, 1, 6);
            tableLayoutPanelMain.Controls.Add(btnSave, 0, 7);
            tableLayoutPanelMain.Controls.Add(btnCancel, 1, 7);
            tableLayoutPanelMain.Controls.Add(lblMessage, 0, 8);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.Padding = new Padding(20);
            tableLayoutPanelMain.RowCount = 9;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanelMain.Size = new Size(700, 500);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            tableLayoutPanelMain.SetColumnSpan(lblTitle, 2);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Georgia", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(23, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(654, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Dodaj/Edytuj Książkę";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBookTitle
            // 
            lblBookTitle.Anchor = AnchorStyles.Right;
            lblBookTitle.AutoSize = true;
            lblBookTitle.Location = new Point(122, 79);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(93, 17);
            lblBookTitle.TabIndex = 1;
            lblBookTitle.Text = "Tytuł książki:";
            // 
            // txtBookTitle
            // 
            txtBookTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtBookTitle.Location = new Point(221, 76);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(456, 23);
            txtBookTitle.TabIndex = 2;
            // 
            // lblISBN
            // 
            lblISBN.Anchor = AnchorStyles.Right;
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(169, 114);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(46, 17);
            lblISBN.TabIndex = 3;
            lblISBN.Text = "ISBN:";
            // 
            // txtISBN
            // 
            txtISBN.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtISBN.Location = new Point(221, 111);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(456, 23);
            txtISBN.TabIndex = 4;
            // 
            // lblYearOfRelease
            // 
            lblYearOfRelease.Anchor = AnchorStyles.Right;
            lblYearOfRelease.AutoSize = true;
            lblYearOfRelease.Location = new Point(122, 149);
            lblYearOfRelease.Name = "lblYearOfRelease";
            lblYearOfRelease.Size = new Size(93, 17);
            lblYearOfRelease.TabIndex = 5;
            lblYearOfRelease.Text = "Rok wydania:";
            // 
            // numYearOfRelease
            // 
            numYearOfRelease.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numYearOfRelease.Location = new Point(221, 146);
            numYearOfRelease.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            numYearOfRelease.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numYearOfRelease.Name = "numYearOfRelease";
            numYearOfRelease.Size = new Size(456, 23);
            numYearOfRelease.TabIndex = 6;
            numYearOfRelease.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // lblAvailableCopies
            // 
            lblAvailableCopies.Anchor = AnchorStyles.Right;
            lblAvailableCopies.AutoSize = true;
            lblAvailableCopies.Location = new Point(106, 184);
            lblAvailableCopies.Name = "lblAvailableCopies";
            lblAvailableCopies.Size = new Size(109, 17);
            lblAvailableCopies.TabIndex = 7;
            lblAvailableCopies.Text = "Dostępne kopie:";
            // 
            // numAvailableCopies
            // 
            numAvailableCopies.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numAvailableCopies.Location = new Point(221, 181);
            numAvailableCopies.Name = "numAvailableCopies";
            numAvailableCopies.Size = new Size(456, 23);
            numAvailableCopies.TabIndex = 8;
            // 
            // lblAuthors
            // 
            lblAuthors.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAuthors.AutoSize = true;
            lblAuthors.Location = new Point(152, 210);
            lblAuthors.Name = "lblAuthors";
            lblAuthors.Size = new Size(63, 17);
            lblAuthors.TabIndex = 9;
            lblAuthors.Text = "Autorzy:";
            // 
            // clbAuthors
            // 
            clbAuthors.Dock = DockStyle.Fill;
            clbAuthors.FormattingEnabled = true;
            clbAuthors.Location = new Point(221, 213);
            clbAuthors.Name = "clbAuthors";
            clbAuthors.Size = new Size(456, 94);
            clbAuthors.TabIndex = 10;
            // 
            // lblGenres
            // 
            lblGenres.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGenres.AutoSize = true;
            lblGenres.Location = new Point(153, 310);
            lblGenres.Name = "lblGenres";
            lblGenres.Size = new Size(62, 17);
            lblGenres.TabIndex = 11;
            lblGenres.Text = "Gatunki:";
            // 
            // clbGenres
            // 
            clbGenres.Dock = DockStyle.Fill;
            clbGenres.FormattingEnabled = true;
            clbGenres.Location = new Point(221, 313);
            clbGenres.Name = "clbGenres";
            clbGenres.Size = new Size(456, 94);
            clbGenres.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Right;
            btnSave.BackColor = Color.ForestGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(115, 417);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 13;
            btnSave.Text = "Zapisz";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Left;
            btnCancel.BackColor = Color.SaddleBrown;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(221, 417);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblMessage
            // 
            tableLayoutPanelMain.SetColumnSpan(lblMessage, 2);
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Georgia", 9F, FontStyle.Italic);
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(23, 460);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(654, 40);
            lblMessage.TabIndex = 15;
            lblMessage.Text = "Komunikat";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Visible = false;
            // 
            // AddEditBookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 500);
            Controls.Add(tableLayoutPanelMain);
            Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "AddEditBookForm";
            Text = "Dodaj/Edytuj Książkę";
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numYearOfRelease).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAvailableCopies).EndInit();
            ResumeLayout(false);

        }

        #endregion
    }
}