namespace cloudyLib.Forms
{
    partial class ManageUsersView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        protected internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected internal System.Windows.Forms.Label lblTitle; 
        protected internal System.Windows.Forms.DataGridView dgvUsers; 
        protected internal System.Windows.Forms.TextBox txtSearchUser; 
        protected internal System.Windows.Forms.Button btnSearchUser; 
        protected internal System.Windows.Forms.FlowLayoutPanel actionButtonsPanel; 
        protected internal System.Windows.Forms.Button btnAddUser;     
        protected internal System.Windows.Forms.Button btnEditUser;    
        protected internal System.Windows.Forms.Button btnDeleteUser; 
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
            txtSearchUser = new TextBox();
            btnSearchUser = new Button();
            dgvUsers = new DataGridView();
            actionButtonsPanel = new FlowLayoutPanel();
            btnDeleteUser = new Button();
            btnEditUser = new Button();
            btnAddUser = new Button();
            lblMessage = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
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
            tableLayoutPanel1.Controls.Add(txtSearchUser, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSearchUser, 1, 1);
            tableLayoutPanel1.Controls.Add(dgvUsers, 0, 2);
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
            tableLayoutPanel1.Size = new Size(860, 476);
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
            lblTitle.Size = new Size(834, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Zarządzanie Użytkownikami";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSearchUser
            // 
            txtSearchUser.Dock = DockStyle.Fill;
            txtSearchUser.Font = new Font("Georgia", 10F);
            txtSearchUser.ForeColor = Color.Black;
            txtSearchUser.Location = new Point(13, 63);
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.PlaceholderText = "Szukaj po e-mailu, imieniu, nazwisku...";
            txtSearchUser.Size = new Size(714, 26);
            txtSearchUser.TabIndex = 1;
            // 
            // btnSearchUser
            // 
            btnSearchUser.BackColor = Color.SaddleBrown;
            btnSearchUser.Dock = DockStyle.Fill;
            btnSearchUser.FlatAppearance.BorderSize = 0;
            btnSearchUser.FlatStyle = FlatStyle.Flat;
            btnSearchUser.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnSearchUser.ForeColor = Color.White;
            btnSearchUser.Location = new Point(733, 63);
            btnSearchUser.Name = "btnSearchUser";
            btnSearchUser.Size = new Size(114, 34);
            btnSearchUser.TabIndex = 2;
            btnSearchUser.Text = "Szukaj";
            btnSearchUser.UseVisualStyleBackColor = false;
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = Color.WhiteSmoke;
            dgvUsers.BorderStyle = BorderStyle.Fixed3D;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.ForestGreen;
            dataGridViewCellStyle1.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.ColumnHeadersHeight = 30;
            tableLayoutPanel1.SetColumnSpan(dgvUsers, 2);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.AntiqueWhite;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.LightGray;
            dgvUsers.Location = new Point(13, 103);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.RowTemplate.Height = 24;
            dgvUsers.Size = new Size(834, 280);
            dgvUsers.TabIndex = 3;
            dgvUsers.CellContentClick += dgvUsers_CellContentClick;
            // 
            // actionButtonsPanel
            // 
            tableLayoutPanel1.SetColumnSpan(actionButtonsPanel, 2);
            actionButtonsPanel.Controls.Add(btnDeleteUser);
            actionButtonsPanel.Controls.Add(btnEditUser);
            actionButtonsPanel.Controls.Add(btnAddUser);
            actionButtonsPanel.Dock = DockStyle.Fill;
            actionButtonsPanel.FlowDirection = FlowDirection.RightToLeft;
            actionButtonsPanel.Location = new Point(13, 389);
            actionButtonsPanel.Name = "actionButtonsPanel";
            actionButtonsPanel.Padding = new Padding(0, 5, 0, 0);
            actionButtonsPanel.Size = new Size(834, 44);
            actionButtonsPanel.TabIndex = 4;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.Red;
            btnDeleteUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(711, 8);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(120, 35);
            btnDeleteUser.TabIndex = 2;
            btnDeleteUser.Text = "Usuń";
            btnDeleteUser.UseVisualStyleBackColor = false;
            // 
            // btnEditUser
            // 
            btnEditUser.BackColor = Color.SaddleBrown;
            btnEditUser.FlatAppearance.BorderSize = 0;
            btnEditUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnEditUser.ForeColor = Color.White;
            btnEditUser.Location = new Point(585, 8);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(120, 35);
            btnEditUser.TabIndex = 1;
            btnEditUser.Text = "Edytuj";
            btnEditUser.UseVisualStyleBackColor = false;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.ForestGreen;
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Georgia", 9F, FontStyle.Bold);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(459, 8);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(120, 35);
            btnAddUser.TabIndex = 0;
            btnAddUser.Text = "Dodaj";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click_1;
            // 
            // lblMessage
            // 
            tableLayoutPanel1.SetColumnSpan(lblMessage, 2);
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Georgia", 9F, FontStyle.Italic);
            lblMessage.ForeColor = Color.DarkGreen;
            lblMessage.Location = new Point(13, 436);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(834, 30);
            lblMessage.TabIndex = 5;
            lblMessage.Text = "Wczytuję użytkowników...";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Visible = false;
            // 
            // ManageUsersView
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Georgia", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ManageUsersView";
            Size = new Size(860, 476);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            actionButtonsPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
    }
}