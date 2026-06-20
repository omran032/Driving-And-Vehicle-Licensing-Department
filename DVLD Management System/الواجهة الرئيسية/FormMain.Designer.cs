namespace DVLD_Management_System.الواجهة_الرئيسية
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsDdb_Application = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_LocalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_InternationalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_RenewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_Replacement = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_RetakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_LocalDrivingLicenseApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_internationalLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_ManageDetainedLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_DetaunLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_ReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_ManageApplicationTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolS_ManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDdb_People = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_Drivers = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDdb_Users = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolSM_CurrentUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolSM_ChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolSM_SingOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDdb_Application,
            this.toolStripSeparator1,
            this.tsDdb_People,
            this.toolStripSeparator2,
            this.toolStrip_Drivers,
            this.toolStripSeparator3,
            this.tsDdb_Users,
            this.toolStripSeparator4,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1368, 55);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsDdb_Application
            // 
            this.tsDdb_Application.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.ToolS_ManageApplicationTypes,
            this.ToolS_ManageTestTypes});
            this.tsDdb_Application.Image = ((System.Drawing.Image)(resources.GetObject("tsDdb_Application.Image")));
            this.tsDdb_Application.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsDdb_Application.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDdb_Application.Name = "tsDdb_Application";
            this.tsDdb_Application.Size = new System.Drawing.Size(168, 52);
            this.tsDdb_Application.Text = "Application  ";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.ToolS_RenewDrivingLicense,
            this.ToolS_Replacement,
            this.releaseDetainedDrivingLicenseToolStripMenuItem,
            this.ToolS_RetakeTest});
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(290, 30);
            this.toolStripMenuItem1.Text = "Driver Licenses Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolS_LocalLicense,
            this.ToolS_InternationalLicense});
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(399, 26);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // ToolS_LocalLicense
            // 
            this.ToolS_LocalLicense.Name = "ToolS_LocalLicense";
            this.ToolS_LocalLicense.Size = new System.Drawing.Size(240, 26);
            this.ToolS_LocalLicense.Text = "Local License";
            this.ToolS_LocalLicense.Click += new System.EventHandler(this.ToolS_LocalLicense_Click);
            // 
            // ToolS_InternationalLicense
            // 
            this.ToolS_InternationalLicense.Name = "ToolS_InternationalLicense";
            this.ToolS_InternationalLicense.Size = new System.Drawing.Size(240, 26);
            this.ToolS_InternationalLicense.Text = "International License";
            // 
            // ToolS_RenewDrivingLicense
            // 
            this.ToolS_RenewDrivingLicense.Name = "ToolS_RenewDrivingLicense";
            this.ToolS_RenewDrivingLicense.Size = new System.Drawing.Size(399, 26);
            this.ToolS_RenewDrivingLicense.Text = "Renew Driving License";
            this.ToolS_RenewDrivingLicense.Click += new System.EventHandler(this.ToolS_RenewDrivingLicense_Click);
            // 
            // ToolS_Replacement
            // 
            this.ToolS_Replacement.Name = "ToolS_Replacement";
            this.ToolS_Replacement.Size = new System.Drawing.Size(399, 26);
            this.ToolS_Replacement.Text = "Replacement for Lost or Damaged License";
            this.ToolS_Replacement.Click += new System.EventHandler(this.ToolS_Replacement_Click);
            // 
            // releaseDetainedDrivingLicenseToolStripMenuItem
            // 
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Name = "releaseDetainedDrivingLicenseToolStripMenuItem";
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(399, 26);
            this.releaseDetainedDrivingLicenseToolStripMenuItem.Text = "Release Detained Driving License";
            // 
            // ToolS_RetakeTest
            // 
            this.ToolS_RetakeTest.Name = "ToolS_RetakeTest";
            this.ToolS_RetakeTest.Size = new System.Drawing.Size(399, 26);
            this.ToolS_RetakeTest.Text = "Retake Test";
            this.ToolS_RetakeTest.Click += new System.EventHandler(this.ToolS_RetakeTest_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolS_LocalDrivingLicenseApplication,
            this.ToolS_internationalLicenseApplications});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(290, 30);
            this.toolStripMenuItem2.Text = "manage Applications";
            // 
            // ToolS_LocalDrivingLicenseApplication
            // 
            this.ToolS_LocalDrivingLicenseApplication.Name = "ToolS_LocalDrivingLicenseApplication";
            this.ToolS_LocalDrivingLicenseApplication.Size = new System.Drawing.Size(340, 26);
            this.ToolS_LocalDrivingLicenseApplication.Text = "Local Driving license Application";
            this.ToolS_LocalDrivingLicenseApplication.Click += new System.EventHandler(this.ToolS_LocalDrivingLicenseApplication_Click);
            // 
            // ToolS_internationalLicenseApplications
            // 
            this.ToolS_internationalLicenseApplications.Name = "ToolS_internationalLicenseApplications";
            this.ToolS_internationalLicenseApplications.Size = new System.Drawing.Size(340, 26);
            this.ToolS_internationalLicenseApplications.Text = "International License Applications";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolS_ManageDetainedLicenses,
            this.ToolS_DetaunLicense,
            this.ToolS_ReleaseDetainedLicense});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(290, 30);
            this.toolStripMenuItem3.Text = "Detain Lisenses";
            // 
            // ToolS_ManageDetainedLicenses
            // 
            this.ToolS_ManageDetainedLicenses.Name = "ToolS_ManageDetainedLicenses";
            this.ToolS_ManageDetainedLicenses.Size = new System.Drawing.Size(283, 26);
            this.ToolS_ManageDetainedLicenses.Text = "manage Detained Licenses";
            this.ToolS_ManageDetainedLicenses.Click += new System.EventHandler(this.ToolS_ManageDetainedLicenses_Click);
            // 
            // ToolS_DetaunLicense
            // 
            this.ToolS_DetaunLicense.Name = "ToolS_DetaunLicense";
            this.ToolS_DetaunLicense.Size = new System.Drawing.Size(283, 26);
            this.ToolS_DetaunLicense.Text = "Detaun License";
            this.ToolS_DetaunLicense.Click += new System.EventHandler(this.ToolS_DetaunLicense_Click);
            // 
            // ToolS_ReleaseDetainedLicense
            // 
            this.ToolS_ReleaseDetainedLicense.Name = "ToolS_ReleaseDetainedLicense";
            this.ToolS_ReleaseDetainedLicense.Size = new System.Drawing.Size(283, 26);
            this.ToolS_ReleaseDetainedLicense.Text = "Release Detained License";
            this.ToolS_ReleaseDetainedLicense.Click += new System.EventHandler(this.ToolS_ReleaseDetainedLicense_Click);
            // 
            // ToolS_ManageApplicationTypes
            // 
            this.ToolS_ManageApplicationTypes.Name = "ToolS_ManageApplicationTypes";
            this.ToolS_ManageApplicationTypes.Size = new System.Drawing.Size(290, 30);
            this.ToolS_ManageApplicationTypes.Text = "Manage Application Types";
            this.ToolS_ManageApplicationTypes.Click += new System.EventHandler(this.ToolS_ManageApplicationTypes_Click);
            // 
            // ToolS_ManageTestTypes
            // 
            this.ToolS_ManageTestTypes.Name = "ToolS_ManageTestTypes";
            this.ToolS_ManageTestTypes.Size = new System.Drawing.Size(290, 30);
            this.ToolS_ManageTestTypes.Text = "Manage Test Types";
            this.ToolS_ManageTestTypes.Click += new System.EventHandler(this.ToolS_ManageTestTypes_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // tsDdb_People
            // 
            this.tsDdb_People.Image = ((System.Drawing.Image)(resources.GetObject("tsDdb_People.Image")));
            this.tsDdb_People.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsDdb_People.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDdb_People.Name = "tsDdb_People";
            this.tsDdb_People.Size = new System.Drawing.Size(132, 52);
            this.tsDdb_People.Text = "People  ";
            this.tsDdb_People.Click += new System.EventHandler(this.tsDdb_People_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStrip_Drivers
            // 
            this.toolStrip_Drivers.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_Drivers.Image")));
            this.toolStrip_Drivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStrip_Drivers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_Drivers.Name = "toolStrip_Drivers";
            this.toolStrip_Drivers.Size = new System.Drawing.Size(137, 52);
            this.toolStrip_Drivers.Text = "Drivers   ";
            this.toolStrip_Drivers.Click += new System.EventHandler(this.toolStrip_Drivers_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // tsDdb_Users
            // 
            this.tsDdb_Users.Image = ((System.Drawing.Image)(resources.GetObject("tsDdb_Users.Image")));
            this.tsDdb_Users.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsDdb_Users.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDdb_Users.Name = "tsDdb_Users";
            this.tsDdb_Users.Size = new System.Drawing.Size(124, 52);
            this.tsDdb_Users.Text = "Users   ";
            this.tsDdb_Users.Click += new System.EventHandler(this.tsDdb_Users_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolSM_CurrentUserInfo,
            this.ToolSM_ChangePassword,
            this.ToolSM_SingOut});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(208, 52);
            this.toolStripDropDownButton1.Text = "Account Sittings   ";
            // 
            // ToolSM_CurrentUserInfo
            // 
            this.ToolSM_CurrentUserInfo.Image = ((System.Drawing.Image)(resources.GetObject("ToolSM_CurrentUserInfo.Image")));
            this.ToolSM_CurrentUserInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolSM_CurrentUserInfo.Name = "ToolSM_CurrentUserInfo";
            this.ToolSM_CurrentUserInfo.Size = new System.Drawing.Size(230, 38);
            this.ToolSM_CurrentUserInfo.Text = "Current User Info";
            this.ToolSM_CurrentUserInfo.Click += new System.EventHandler(this.ToolSM_CurrentUserInfo_Click);
            // 
            // ToolSM_ChangePassword
            // 
            this.ToolSM_ChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("ToolSM_ChangePassword.Image")));
            this.ToolSM_ChangePassword.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolSM_ChangePassword.Name = "ToolSM_ChangePassword";
            this.ToolSM_ChangePassword.Size = new System.Drawing.Size(230, 38);
            this.ToolSM_ChangePassword.Text = "Change Password";
            this.ToolSM_ChangePassword.Click += new System.EventHandler(this.ToolSM_ChangePassword_Click);
            // 
            // ToolSM_SingOut
            // 
            this.ToolSM_SingOut.Image = ((System.Drawing.Image)(resources.GetObject("ToolSM_SingOut.Image")));
            this.ToolSM_SingOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolSM_SingOut.Name = "ToolSM_SingOut";
            this.ToolSM_SingOut.Size = new System.Drawing.Size(230, 38);
            this.ToolSM_SingOut.Text = "Sign out";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 807);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tsDdb_People;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStrip_Drivers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton tsDdb_Users;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton tsDdb_Application;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ToolS_ManageApplicationTypes;
        private System.Windows.Forms.ToolStripMenuItem ToolS_ManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem ToolS_ManageDetainedLicenses;
        private System.Windows.Forms.ToolStripMenuItem ToolS_DetaunLicense;
        private System.Windows.Forms.ToolStripMenuItem ToolS_ReleaseDetainedLicense;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolS_RenewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem ToolS_Replacement;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolS_RetakeTest;
        private System.Windows.Forms.ToolStripMenuItem ToolS_LocalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem ToolS_internationalLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem ToolSM_CurrentUserInfo;
        private System.Windows.Forms.ToolStripMenuItem ToolSM_ChangePassword;
        private System.Windows.Forms.ToolStripMenuItem ToolSM_SingOut;
        private System.Windows.Forms.ToolStripMenuItem ToolS_LocalLicense;
        private System.Windows.Forms.ToolStripMenuItem ToolS_InternationalLicense;
    }
}