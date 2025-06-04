namespace cloudyLib.Forms
{
    partial class AllLoansView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        protected internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected internal System.Windows.Forms.Label lblTitle;
        protected internal System.Windows.Forms.TextBox txtSearch;
        protected internal System.Windows.Forms.Button btnSearch;
        protected internal System.Windows.Forms.DataGridView dgvAllLoans;
        protected internal System.Windows.Forms.FlowLayoutPanel actionButtonsPanel;
        protected internal System.Windows.Forms.Button btnAddLoan;
        protected internal System.Windows.Forms.Button btnEditLoan;
        protected internal System.Windows.Forms.Button btnDeleteLoan;
        protected internal System.Windows.Forms.Button btnReturnBook; 
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvAllLoans = new DataGridView();
            actionButtonsPanel = new FlowLayoutPanel();
            btnDeleteLoan = new Button();
            btnReturnBook = new Button();
            btnEditLoan = new Button();
            btnAddLoan = new Button();
            lblMessage = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAllLoans).BeginInit();
            actionButtonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.AntiqueWhite;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(txtSearch, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSearch, 1, 1);
            tableLayoutPanel1.Controls.Add(dgvAllLoans, 0, 2);
            tableLayoutPanel1.Controls.Add(actionButtonsPanel, 0, 3);
            tableLayoutPanel1.Controls.Add(lblMessage, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(900, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            tableLayoutPanel1.SetColumnSpan(lblTitle, 2);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Georgia", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(13, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(874, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Zarządzanie Wypożyczeniami";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Georgia", 10F);
            txtSearch.ForeColor = Color.Black;
            txtSearch.Location = new Point(13, 63);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Szukaj po tytule książki, imieniu, nazwisku lub e-mailu użytkownika...";
            txtSearch.Size = new Size(754, 26);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.SaddleBrown;
            btnSearch.Dock = DockStyle.Fill;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(773, 63);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 34);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Szukaj";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // dgvAllLoans
            // 
            dgvAllLoans.BackgroundColor = Color.WhiteSmoke;
            dgvAllLoans.BorderStyle = BorderStyle.Fixed3D;
            dgvAllLoans.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.ForestGreen;
            dataGridViewCellStyle1.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAllLoans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAllLoans.ColumnHeadersHeight = 30;
            tableLayoutPanel1.SetColumnSpan(dgvAllLoans, 2);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.AntiqueWhite;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAllLoans.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAllLoans.Dock = DockStyle.Fill;
            dgvAllLoans.EnableHeadersVisualStyles = false;
            dgvAllLoans.GridColor = Color.LightGray;
            dgvAllLoans.Location = new Point(13, 103);
            dgvAllLoans.Name = "dgvAllLoans";
            dgvAllLoans.RowHeadersVisible = false;
            dgvAllLoans.RowHeadersWidth = 51;
            dgvAllLoans.RowTemplate.Height = 24;
            dgvAllLoans.Size = new Size(874, 404);
            dgvAllLoans.TabIndex = 3;
            // 
            // actionButtonsPanel
            // 
            tableLayoutPanel1.SetColumnSpan(actionButtonsPanel, 2);
            actionButtonsPanel.Controls.Add(btnDeleteLoan);
            actionButtonsPanel.Controls.Add(btnReturnBook);
            actionButtonsPanel.Controls.Add(btnEditLoan);
            actionButtonsPanel.Controls.Add(btnAddLoan);
            actionButtonsPanel.Dock = DockStyle.Fill;
            actionButtonsPanel.FlowDirection = FlowDirection.RightToLeft;
            actionButtonsPanel.Location = new Point(13, 513);
            actionButtonsPanel.Name = "actionButtonsPanel";
            actionButtonsPanel.Padding = new Padding(0, 5, 0, 0);
            actionButtonsPanel.Size = new Size(874, 44);
            actionButtonsPanel.TabIndex = 4;
            // 
            // btnDeleteLoan
            // 
            btnDeleteLoan.BackColor = Color.Red;
            btnDeleteLoan.FlatAppearance.BorderSize = 0;
            btnDeleteLoan.FlatStyle = FlatStyle.Flat;
            btnDeleteLoan.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnDeleteLoan.ForeColor = Color.White;
            btnDeleteLoan.Location = new Point(751, 8);
            btnDeleteLoan.Name = "btnDeleteLoan";
            btnDeleteLoan.Size = new Size(120, 35);
            btnDeleteLoan.TabIndex = 3;
            btnDeleteLoan.Text = "Usuń";
            btnDeleteLoan.UseVisualStyleBackColor = false;
            // 
            // btnReturnBook
            // 
            btnReturnBook.BackColor = Color.Goldenrod;
            btnReturnBook.FlatAppearance.BorderSize = 0;
            btnReturnBook.FlatStyle = FlatStyle.Flat;
            btnReturnBook.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnReturnBook.ForeColor = Color.White;
            btnReturnBook.Location = new Point(625, 8);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(120, 35);
            btnReturnBook.TabIndex = 2;
            btnReturnBook.Text = "Zwróć książkę";
            btnReturnBook.UseVisualStyleBackColor = false;
            // 
            // btnEditLoan
            // 
            btnEditLoan.BackColor = Color.SaddleBrown;
            btnEditLoan.FlatAppearance.BorderSize = 0;
            btnEditLoan.FlatStyle = FlatStyle.Flat;
            btnEditLoan.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnEditLoan.ForeColor = Color.White;
            btnEditLoan.Location = new Point(499, 8);
            btnEditLoan.Name = "btnEditLoan";
            btnEditLoan.Size = new Size(120, 35);
            btnEditLoan.TabIndex = 1;
            btnEditLoan.Text = "Edytuj";
            btnEditLoan.UseVisualStyleBackColor = false;
            // 
            // btnAddLoan
            // 
            btnAddLoan.BackColor = Color.ForestGreen;
            btnAddLoan.FlatAppearance.BorderSize = 0;
            btnAddLoan.FlatStyle = FlatStyle.Flat;
            btnAddLoan.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnAddLoan.ForeColor = Color.White;
            btnAddLoan.Location = new Point(373, 8);
            btnAddLoan.Name = "btnAddLoan";
            btnAddLoan.Size = new Size(120, 35);
            btnAddLoan.TabIndex = 0;
            btnAddLoan.Text = "Dodaj";
            btnAddLoan.UseVisualStyleBackColor = false;
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Georgia", 9F, FontStyle.Italic);
            lblMessage.ForeColor = Color.DarkGreen;
            lblMessage.Location = new Point(13, 560);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(754, 30);
            lblMessage.TabIndex = 5;
            lblMessage.Text = "Wczytuję wypożyczenia...";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Visible = false;
            // 
            // AllLoansView
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "AllLoansView";
            Size = new Size(900, 600);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAllLoans).EndInit();
            actionButtonsPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
    }
}