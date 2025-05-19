using System.ComponentModel;

namespace cloudyLib.Forms
{
    partial class BookListForm
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
            dgvBooks = new DataGridView();
            txtFilterTitle = new TextBox();
            txtFilterAuthor = new TextBox();
            cmbFilterGenre = new ComboBox();
            cmbSortBy = new ComboBox();
            btnAddBook = new Button();
            btnEditBook = new Button();
            btnDeleteBook = new Button();
            ((ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(12, 46);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.Size = new Size(719, 345);
            dgvBooks.TabIndex = 0;
            dgvBooks.CellDoubleClick += dgvBooks_CellDoubleClick;
            // 
            // txtFilterTitle
            // 
            txtFilterTitle.Location = new Point(12, 12);
            txtFilterTitle.Name = "txtFilterTitle";
            txtFilterTitle.PlaceholderText = "Filtruj po tytule";
            txtFilterTitle.Size = new Size(150, 27);
            txtFilterTitle.TabIndex = 1;
            txtFilterTitle.TextChanged += txtFilterTitle_TextChanged;
            // 
            // txtFilterAuthor
            // 
            txtFilterAuthor.Location = new Point(168, 12);
            txtFilterAuthor.Name = "txtFilterAuthor";
            txtFilterAuthor.PlaceholderText = "Filtruj po autorze";
            txtFilterAuthor.Size = new Size(150, 27);
            txtFilterAuthor.TabIndex = 2;
            txtFilterAuthor.TextChanged += txtFilterAuthor_TextChanged;
            // 
            // cmbFilterGenre
            // 
            cmbFilterGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterGenre.FormattingEnabled = true;
            cmbFilterGenre.Location = new Point(324, 12);
            cmbFilterGenre.Name = "cmbFilterGenre";
            cmbFilterGenre.Size = new Size(150, 28);
            cmbFilterGenre.TabIndex = 3;
            cmbFilterGenre.SelectedIndexChanged += cmbFilterGenre_SelectedIndexChanged;
            // 
            // cmbSortBy
            // 
            cmbSortBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSortBy.FormattingEnabled = true;
            cmbSortBy.Items.AddRange(new object[] { "Tytuł (A-Z)", "Tytuł (Z-A)", "Autor (A-Z)", "Autor (Z-A)", "Data Dodania (Najnowsze)", "Data Dodania (Najstarsze)", "Popularność (Rosnąco)", "Popularność (Malejąco)" });
            cmbSortBy.Location = new Point(480, 12);
            cmbSortBy.Name = "cmbSortBy";
            cmbSortBy.Size = new Size(150, 28);
            cmbSortBy.TabIndex = 4;
            cmbSortBy.SelectedIndexChanged += cmbSortBy_SelectedIndexChanged;
            // 
            // btnAddBook
            // 
            btnAddBook.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddBook.Location = new Point(12, 397);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(100, 30);
            btnAddBook.TabIndex = 5;
            btnAddBook.Text = "Dodaj Książkę";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnEditBook
            // 
            btnEditBook.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditBook.Location = new Point(118, 397);
            btnEditBook.Name = "btnEditBook";
            btnEditBook.Size = new Size(100, 30);
            btnEditBook.TabIndex = 6;
            btnEditBook.Text = "Edytuj Książkę";
            btnEditBook.UseVisualStyleBackColor = true;
            btnEditBook.Click += btnEditBook_Click;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteBook.Location = new Point(224, 397);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(100, 30);
            btnDeleteBook.TabIndex = 7;
            btnDeleteBook.Text = "Usuń Książkę";
            btnDeleteBook.UseVisualStyleBackColor = true;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // BookListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteBook);
            Controls.Add(btnEditBook);
            Controls.Add(btnAddBook);
            Controls.Add(cmbSortBy);
            Controls.Add(cmbFilterGenre);
            Controls.Add(txtFilterAuthor);
            Controls.Add(txtFilterTitle);
            Controls.Add(dgvBooks);
            Name = "BookListForm";
            Text = "Form1";
            Load += BookListForm_Load;
            ((ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}