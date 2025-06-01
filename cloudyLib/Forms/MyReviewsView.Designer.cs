namespace cloudyLib.Forms
{
    partial class MyReviewsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        protected internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected internal System.Windows.Forms.Label lblTitle;
        protected internal System.Windows.Forms.DataGridView dgvMyReviews;
        protected internal System.Windows.Forms.FlowLayoutPanel actionButtonsPanel;
        protected internal System.Windows.Forms.Button btnEditReview;
        protected internal System.Windows.Forms.Button btnDeleteReview;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvMyReviews = new System.Windows.Forms.DataGridView();
            this.actionButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeleteReview = new System.Windows.Forms.Button();
            this.btnEditReview = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyReviews)).BeginInit();
            this.actionButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvMyReviews, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.actionButtonsPanel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); 
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F)); 
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 600); 
            this.tableLayoutPanel1.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTitle.Location = new System.Drawing.Point(13, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(874, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Moje Recenzje";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // dgvMyReviews
            //
            this.dgvMyReviews.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMyReviews.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMyReviews.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMyReviews.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMyReviews.ColumnHeadersHeight = 30;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMyReviews.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMyReviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMyReviews.EnableHeadersVisualStyles = false;
            this.dgvMyReviews.GridColor = System.Drawing.Color.LightGray;
            this.dgvMyReviews.Location = new System.Drawing.Point(13, 63);
            this.dgvMyReviews.Name = "dgvMyReviews";
            this.dgvMyReviews.RowHeadersVisible = false;
            this.dgvMyReviews.RowHeadersWidth = 51;
            this.dgvMyReviews.RowTemplate.Height = 24;
            this.dgvMyReviews.Size = new System.Drawing.Size(874, 444);
            this.dgvMyReviews.TabIndex = 1;
            //
            // actionButtonsPanel
            //
            this.actionButtonsPanel.Controls.Add(this.btnDeleteReview);
            this.actionButtonsPanel.Controls.Add(this.btnEditReview);
            this.actionButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.actionButtonsPanel.Location = new System.Drawing.Point(13, 513);
            this.actionButtonsPanel.Name = "actionButtonsPanel";
            this.actionButtonsPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.actionButtonsPanel.Size = new System.Drawing.Size(874, 44);
            this.actionButtonsPanel.TabIndex = 2;
            //
            // btnDeleteReview
            //
            this.btnDeleteReview.BackColor = System.Drawing.Color.Red;
            this.btnDeleteReview.FlatAppearance.BorderSize = 0;
            this.btnDeleteReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteReview.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteReview.ForeColor = System.Drawing.Color.White;
            this.btnDeleteReview.Location = new System.Drawing.Point(751, 8);
            this.btnDeleteReview.Name = "btnDeleteReview";
            this.btnDeleteReview.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteReview.TabIndex = 1;
            this.btnDeleteReview.Text = "Usuń";
            this.btnDeleteReview.UseVisualStyleBackColor = false;
            //
            // btnEditReview
            //
            this.btnEditReview.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnEditReview.FlatAppearance.BorderSize = 0;
            this.btnEditReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditReview.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditReview.ForeColor = System.Drawing.Color.White;
            this.btnEditReview.Location = new System.Drawing.Point(625, 8);
            this.btnEditReview.Name = "btnEditReview";
            this.btnEditReview.Size = new System.Drawing.Size(120, 35);
            this.btnEditReview.TabIndex = 0;
            this.btnEditReview.Text = "Edytuj";
            this.btnEditReview.UseVisualStyleBackColor = false;
            //
            // lblMessage
            //
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Italic);
            this.lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblMessage.Location = new System.Drawing.Point(13, 560);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(874, 30);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Wczytuję recenzje...";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            //
            // MyReviewsView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MyReviewsView";
            this.Size = new System.Drawing.Size(900, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyReviews)).EndInit();
            this.actionButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}