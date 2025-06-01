namespace cloudyLib.Forms
{
    partial class RateReviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        // Zmieniono modyfikatory dostępu na protected internal
        protected internal System.Windows.Forms.Label lblBookTitle;
        protected internal System.Windows.Forms.Label lblRating;
        protected internal System.Windows.Forms.NumericUpDown numRating;
        protected internal System.Windows.Forms.Label lblReview;
        protected internal System.Windows.Forms.TextBox txtReview; // Zgodnie z Twoim plikiem, jest 'txtReview'
        protected internal System.Windows.Forms.Button btnSubmit;
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
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.numRating = new System.Windows.Forms.NumericUpDown();
            this.lblReview = new System.Windows.Forms.Label();
            this.txtReview = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).BeginInit();
            this.SuspendLayout();
            //
            // lblBookTitle
            //
            this.lblBookTitle.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblBookTitle.Location = new System.Drawing.Point(12, 9);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(460, 30);
            this.lblBookTitle.TabIndex = 0;
            this.lblBookTitle.Text = "Tytuł książki";
            this.lblBookTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBookTitle.Click += new System.EventHandler(this.lblBookTitle_Click);
            //
            // lblRating
            //
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblRating.ForeColor = System.Drawing.Color.Black;
            this.lblRating.Location = new System.Drawing.Point(12, 50);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(62, 20);
            this.lblRating.TabIndex = 1;
            this.lblRating.Text = "Ocena:";
            //
            // numRating
            //
            this.numRating.Font = new System.Drawing.Font("Georgia", 10F);
            this.numRating.Location = new System.Drawing.Point(130, 48);
            this.numRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRating.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRating.Name = "numRating";
            this.numRating.Size = new System.Drawing.Size(120, 26);
            this.numRating.TabIndex = 2;
            this.numRating.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            //
            // lblReview
            //
            this.lblReview.AutoSize = true;
            this.lblReview.Font = new System.Drawing.Font("Georgia", 10F);
            this.lblReview.ForeColor = System.Drawing.Color.Black;
            this.lblReview.Location = new System.Drawing.Point(12, 90);
            this.lblReview.Name = "lblReview";
            this.lblReview.Size = new System.Drawing.Size(82, 20);
            this.lblReview.TabIndex = 3;
            this.lblReview.Text = "Recenzja:";
            //
            // txtReview
            //
            this.txtReview.Font = new System.Drawing.Font("Georgia", 10F);
            this.txtReview.ForeColor = System.Drawing.Color.Black;
            this.txtReview.Location = new System.Drawing.Point(16, 113);
            this.txtReview.Multiline = true;
            this.txtReview.Name = "txtReview";
            this.txtReview.Size = new System.Drawing.Size(456, 150);
            this.txtReview.TabIndex = 4;
            this.txtReview.TextChanged += new System.EventHandler(this.txtReview_TextChanged);
            //
            // btnSubmit
            //
            this.btnSubmit.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(110, 290);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(120, 35);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Zapisz";
            this.btnSubmit.UseVisualStyleBackColor = false;
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.DarkGray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(260, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // lblMessage
            //
            this.lblMessage.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(16, 266);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(456, 20);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "Komunikat";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            //
            // RateReviewForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(484, 337);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtReview);
            this.Controls.Add(this.lblReview);
            this.Controls.Add(this.numRating);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblBookTitle);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RateReviewForm";
            this.Text = "RateReviewForm";
            this.Load += new System.EventHandler(this.RateReviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout(); 
        }

        #endregion
    }
}