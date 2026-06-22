namespace DVLD_Management_System.Local_Licenses
{
    partial class FrmIssueDriverLicenseFirstTime
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.ctrl_DLApplInfo1 = new DVLD_Management_System.ctrl_DLApplInfo();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIssueLicense = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 500);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 179;
            this.label1.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(151, 504);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(783, 127);
            this.txtNotes.TabIndex = 176;
            // 
            // ctrl_DLApplInfo1
            // 
            this.ctrl_DLApplInfo1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_DLApplInfo1.InfoLicenseAplication = null;
            this.ctrl_DLApplInfo1.Location = new System.Drawing.Point(11, 13);
            this.ctrl_DLApplInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_DLApplInfo1.Name = "ctrl_DLApplInfo1";
            this.ctrl_DLApplInfo1.Size = new System.Drawing.Size(945, 465);
            this.ctrl_DLApplInfo1.TabIndex = 181;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Management_System.Properties.Resources.Documents1;
            this.pictureBox1.Location = new System.Drawing.Point(118, 503);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 180;
            this.pictureBox1.TabStop = false;
            // 
            // btnIssueLicense
            // 
            this.btnIssueLicense.BorderColor = System.Drawing.Color.Gray;
            this.btnIssueLicense.BorderRadius = 10;
            this.btnIssueLicense.BorderThickness = 1;
            this.btnIssueLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIssueLicense.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIssueLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIssueLicense.FillColor = System.Drawing.Color.White;
            this.btnIssueLicense.FillColor2 = System.Drawing.Color.White;
            this.btnIssueLicense.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueLicense.ForeColor = System.Drawing.Color.Navy;
            this.btnIssueLicense.Image = global::DVLD_Management_System.Properties.Resources.Save;
            this.btnIssueLicense.ImageSize = new System.Drawing.Size(30, 30);
            this.btnIssueLicense.Location = new System.Drawing.Point(810, 639);
            this.btnIssueLicense.Name = "btnIssueLicense";
            this.btnIssueLicense.Size = new System.Drawing.Size(124, 45);
            this.btnIssueLicense.TabIndex = 182;
            this.btnIssueLicense.Text = "Issue";
            this.btnIssueLicense.TextOffset = new System.Drawing.Point(2, 0);
            this.btnIssueLicense.Click += new System.EventHandler(this.btnIssueLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.BorderRadius = 10;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.FillColor2 = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnClose.Image = global::DVLD_Management_System.Properties.Resources.Close_32;
            this.btnClose.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.Location = new System.Drawing.Point(675, 639);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 45);
            this.btnClose.TabIndex = 183;
            this.btnClose.Text = "Close";
            // 
            // FrmIssueDriverLicenseFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(969, 709);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssueLicense);
            this.Controls.Add(this.ctrl_DLApplInfo1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNotes);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmIssueDriverLicenseFirstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Driver License For The First Time";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotes;
        private ctrl_DLApplInfo ctrl_DLApplInfo1;
        private Guna.UI2.WinForms.Guna2GradientButton btnIssueLicense;
        private Guna.UI2.WinForms.Guna2GradientButton btnClose;
    }
}