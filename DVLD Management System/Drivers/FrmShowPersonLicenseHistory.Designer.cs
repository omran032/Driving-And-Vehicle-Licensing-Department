namespace DVLD_Management_System.Drivers
{
    partial class FrmShowPersonLicenseHistory
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
            this.ctrlDriverLicenses1 = new DVLD_Management_System.Drivers.Ctrl.CtrlDriverLicenses();
            this.ctrlFelterPersons1 = new DVLD_Management_System.Manage_Persons.User_Control.CtrlFelterPersons();
            this.ctrl_InfoPerson1 = new DVLD_Management_System.Manage_Persons.User_Control.ctrl_InfoPerson();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(51, 480);
            this.ctrlDriverLicenses1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.PersonID = 0;
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(1068, 354);
            this.ctrlDriverLicenses1.TabIndex = 0;
            // 
            // ctrlFelterPersons1
            // 
            this.ctrlFelterPersons1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlFelterPersons1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlFelterPersons1.Location = new System.Drawing.Point(332, 53);
            this.ctrlFelterPersons1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrlFelterPersons1.Name = "ctrlFelterPersons1";
            this.ctrlFelterPersons1.Size = new System.Drawing.Size(535, 66);
            this.ctrlFelterPersons1.TabIndex = 1;
            // 
            // ctrl_InfoPerson1
            // 
            this.ctrl_InfoPerson1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_InfoPerson1.Location = new System.Drawing.Point(343, 116);
            this.ctrl_InfoPerson1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ctrl_InfoPerson1.Name = "ctrl_InfoPerson1";
            this.ctrl_InfoPerson1.person = null;
            this.ctrl_InfoPerson1.PersonID = 0;
            this.ctrl_InfoPerson1.Size = new System.Drawing.Size(634, 383);
            this.ctrl_InfoPerson1.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(57, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1062, 39);
            this.lblTitle.TabIndex = 130;
            this.lblTitle.Text = "License History";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 832);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrl_InfoPerson1);
            this.Controls.Add(this.ctrlFelterPersons1);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "FrmShowPersonLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.FrmShowPersonLicenseHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Ctrl.CtrlDriverLicenses ctrlDriverLicenses1;
        private Manage_Persons.User_Control.CtrlFelterPersons ctrlFelterPersons1;
        private Manage_Persons.User_Control.ctrl_InfoPerson ctrl_InfoPerson1;
        private System.Windows.Forms.Label lblTitle;
    }
}