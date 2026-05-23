namespace DVLD_Management_System
{
    partial class FrmLDLAppInfo
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
            this.ctrl_DLApplInfo1 = new DVLD_Management_System.ctrl_DLApplInfo();
            this.SuspendLayout();
            // 
            // ctrl_DLApplInfo1
            // 
            this.ctrl_DLApplInfo1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_DLApplInfo1.InfoLicenseAplication = null;
            this.ctrl_DLApplInfo1.Location = new System.Drawing.Point(13, 28);
            this.ctrl_DLApplInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_DLApplInfo1.Name = "ctrl_DLApplInfo1";
            this.ctrl_DLApplInfo1.Size = new System.Drawing.Size(945, 458);
            this.ctrl_DLApplInfo1.TabIndex = 0;
            // 
            // FrmLDLAppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 486);
            this.Controls.Add(this.ctrl_DLApplInfo1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmLDLAppInfo";
            this.Text = "FrmLDLAppInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrl_DLApplInfo ctrl_DLApplInfo1;
    }
}