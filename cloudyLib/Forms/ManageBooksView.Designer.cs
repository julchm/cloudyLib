namespace cloudyLib.Forms
{
    partial class ManageBooksView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.FlowLayoutPanel actionButtonsPanel; 
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnEditBook;
        private System.Windows.Forms.Button btnDeleteBook;
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
            dgvBooks = new DataGridView();
            actionButtonsPanel = new FlowLayoutPanel();
            btnAddBook = new Button();
            btnEditBook = new Button();
            btnDeleteBook = new Button();
            lblMessage = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            actionButtonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.AntiqueWhite;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvBooks, 0, 1);
            tableLayoutPanel1.Controls.Add(actionButtonsPanel, 0, 2);
            tableLayoutPanel1.Controls.Add(lblMessage, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(860, 476);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Georgia", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(13, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(834, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Zarządzanie Książkami";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
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
            dgvBooks.Location = new Point(13, 63);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.RowTemplate.Height = 24;
            dgvBooks.Size = new Size(834, 320);
            dgvBooks.TabIndex = 1;
            dgvBooks.CellContentClick += dgvBooks_CellContentClick;
            // 
            // actionButtonsPanel
            // 
            actionButtonsPanel.Controls.Add(btnAddBook);
            actionButtonsPanel.Controls.Add(btnEditBook);
            actionButtonsPanel.Controls.Add(btnDeleteBook);
            actionButtonsPanel.Dock = DockStyle.Fill;
            actionButtonsPanel.FlowDirection = FlowDirection.RightToLeft;
            actionButtonsPanel.Location = new Point(13, 389);
            actionButtonsPanel.Name = "actionButtonsPanel";
            actionButtonsPanel.Padding = new Padding(0, 5, 0, 0);
            actionButtonsPanel.Size = new Size(834, 44);
            actionButtonsPanel.TabIndex = 2;
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.ForestGreen;
            btnAddBook.FlatAppearance.BorderSize = 0;
            btnAddBook.FlatStyle = FlatStyle.Flat;
            btnAddBook.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnAddBook.ForeColor = Color.White;
            btnAddBook.Location = new Point(711, 8);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(120, 35);
            btnAddBook.TabIndex = 0;
            btnAddBook.Text = "Dodaj";
            btnAddBook.UseVisualStyleBackColor = false;
            btnAddBook.Click += BtnAddBook_Click;
            // 
            // btnEditBook
            // 
            btnEditBook.BackColor = Color.SaddleBrown;
            btnEditBook.FlatAppearance.BorderSize = 0;
            btnEditBook.FlatStyle = FlatStyle.Flat;
            btnEditBook.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnEditBook.ForeColor = Color.White;
            btnEditBook.Location = new Point(585, 8);
            btnEditBook.Name = "btnEditBook";
            btnEditBook.Size = new Size(120, 35);
            btnEditBook.TabIndex = 1;
            btnEditBook.Text = "Edytuj";
            btnEditBook.UseVisualStyleBackColor = false;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.BackColor = Color.Red;
            btnDeleteBook.FlatAppearance.BorderSize = 0;
            btnDeleteBook.FlatStyle = FlatStyle.Flat;
            btnDeleteBook.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnDeleteBook.ForeColor = Color.White;
            btnDeleteBook.Location = new Point(459, 8);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(120, 35);
            btnDeleteBook.TabIndex = 2;
            btnDeleteBook.Text = "Usuń";
            btnDeleteBook.UseVisualStyleBackColor = false;
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Georgia", 9F, FontStyle.Italic);
            lblMessage.ForeColor = Color.DarkGreen;
            lblMessage.Location = new Point(13, 436);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(834, 30);
            lblMessage.TabIndex = 3;
            lblMessage.Text = "Wczytuję książki...";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Visible = false;
            // 
            // ManageBooksView
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ManageBooksView";
            Size = new Size(860, 476);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            actionButtonsPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
    }
}