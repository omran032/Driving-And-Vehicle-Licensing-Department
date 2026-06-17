namespace DVLD_Management_System.Local_Licenses
{
    partial class frmShowLicenseInfo
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfo1 = new DVLD_Management_System.Local_Licenses.Ctrl.CtrlDriverLicenseInfo();
            this.pbTestTypeImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(264, 134);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(441, 39);
            this.lblTitle.TabIndex = 137;
            this.lblTitle.Text = "Driver License Info";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(13, 177);
            this.ctrlDriverLicenseInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(927, 338);
            this.ctrlDriverLicenseInfo1.TabIndex = 0;
            // 
            // pbTestTypeImage
            // 
            this.pbTestTypeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTestTypeImage.Image = global::DVLD_Management_System.Properties.Resources.DrivigLicense;
            this.pbTestTypeImage.InitialImage = null;
            this.pbTestTypeImage.Location = new System.Drawing.Point(431, 39);
            this.pbTestTypeImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbTestTypeImage.Name = "pbTestTypeImage";
            this.pbTestTypeImage.Size = new System.Drawing.Size(100, 90);
            this.pbTestTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTestTypeImage.TabIndex = 136;
            this.pbTestTypeImage.TabStop = false;
            // 
            // frmShowLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 531);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbTestTypeImage);
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmShowLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License Info";
            this.Load += new System.EventHandler(this.frmShowLicenseInfo_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Ctrl.CtrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbTestTypeImage;
    }
}