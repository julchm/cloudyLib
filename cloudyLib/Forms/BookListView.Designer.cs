namespace cloudyLib.Forms
{
    partial class BookListView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearchTitle;
        private System.Windows.Forms.ComboBox cmbFilterGenre; 
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.DataGridView dgvBooks;
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTitle = new Label();
            txtSearchTitle = new TextBox();
            btnSearch = new Button();
            cmbFilterGenre = new ComboBox();
            cmbSortBy = new ComboBox();
            btnApplyFilters = new Button();
            dgvBooks = new DataGridView();
            lblMessage = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.AntiqueWhite;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 159F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(txtSearchTitle, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSearch, 1, 1);
            tableLayoutPanel1.Controls.Add(cmbFilterGenre, 0, 2);
            tableLayoutPanel1.Controls.Add(cmbSortBy, 1, 2);
            tableLayoutPanel1.Controls.Add(btnApplyFilters, 2, 2);
            tableLayoutPanel1.Controls.Add(dgvBooks, 0, 3);
            tableLayoutPanel1.Controls.Add(lblMessage, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(15);
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(900, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            tableLayoutPanel1.SetColumnSpan(lblTitle, 3);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Georgia", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(18, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(864, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Dostępne Książki";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearchTitle
            // 
            txtSearchTitle.Dock = DockStyle.Fill;
            txtSearchTitle.Font = new Font("Georgia", 10F);
            txtSearchTitle.ForeColor = Color.Black;
            txtSearchTitle.Location = new Point(18, 78);
            txtSearchTitle.Name = "txtSearchTitle";
            txtSearchTitle.PlaceholderText = "Szukaj po tytule lub autorze...";
            txtSearchTitle.Size = new Size(485, 26);
            txtSearchTitle.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.SaddleBrown;
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(509, 78);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(153, 34);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Szukaj";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // cmbFilterGenre
            // 
            cmbFilterGenre.Dock = DockStyle.Fill;
            cmbFilterGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterGenre.Font = new Font("Georgia", 10F);
            cmbFilterGenre.ForeColor = Color.Black;
            cmbFilterGenre.FormattingEnabled = true;
            cmbFilterGenre.Location = new Point(18, 118);
            cmbFilterGenre.Name = "cmbFilterGenre";
            cmbFilterGenre.Size = new Size(485, 28);
            cmbFilterGenre.TabIndex = 4;
            // 
            // cmbSortBy
            // 
            cmbSortBy.Dock = DockStyle.Fill;
            cmbSortBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSortBy.Font = new Font("Georgia", 10F);
            cmbSortBy.ForeColor = Color.Black;
            cmbSortBy.FormattingEnabled = true;
            cmbSortBy.Location = new Point(509, 118);
            cmbSortBy.Name = "cmbSortBy";
            cmbSortBy.Size = new Size(153, 28);
            cmbSortBy.TabIndex = 5;
            // 
            // btnApplyFilters
            // 
            btnApplyFilters.BackColor = Color.ForestGreen;
            btnApplyFilters.Dock = DockStyle.Fill;
            btnApplyFilters.FlatAppearance.BorderSize = 0;
            btnApplyFilters.FlatStyle = FlatStyle.Flat;
            btnApplyFilters.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnApplyFilters.ForeColor = Color.White;
            btnApplyFilters.Location = new Point(668, 118);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(214, 34);
            btnApplyFilters.TabIndex = 8;
            btnApplyFilters.Text = "Zastosuj Filtry i Sortowanie";
            btnApplyFilters.UseVisualStyleBackColor = false;
            // 
            // dgvBooks
            // 
            dgvBooks.BackgroundColor = Color.WhiteSmoke;
            dgvBooks.BorderStyle = BorderStyle.Fixed3D;
            dgvBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.ForestGreen;
            dataGridViewCellStyle1.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBooks.ColumnHeadersHeight = 30;
            tableLayoutPanel1.SetColumnSpan(dgvBooks, 3);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.AntiqueWhite;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBooks.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.EnableHeadersVisualStyles = false;
            dgvBooks.GridColor = Color.LightGray;
            dgvBooks.Location = new Point(18, 158);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.RowTemplate.Height = 24;
            dgvBooks.Size = new Size(864, 394);
            dgvBooks.TabIndex = 6;
            // 
            // lblMessage
            // 
            tableLayoutPanel1.SetColumnSpan(lblMessage, 3);
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Georgia", 9F, FontStyle.Italic);
            lblMessage.ForeColor = Color.DarkGreen;
            lblMessage.Location = new Point(18, 555);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(864, 30);
            lblMessage.TabIndex = 7;
            lblMessage.Text = "Wczytuję książki...";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Visible = false;
            // 
            // BookListView
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "BookListView";
            Size = new Size(900, 600);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);

        }

        #endregion
    }
}