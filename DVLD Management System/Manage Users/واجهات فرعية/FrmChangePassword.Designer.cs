namespace DVLD_Management_System.Manage_Users
{
    partial class FrmChangePassword
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
            this.components = new System.ComponentModel.Container();
            this.ctrlInfoUser1 = new DVLD_Management_System.Manage_Users.User_Control.CtrlInfoUser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrl_InfoPerson1 = new DVLD_Management_System.Manage_Persons.User_Control.ctrl_InfoPerson();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.TxtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.TxtNewPasswprd = new Guna.UI2.WinForms.Guna2TextBox();
            this.TxtOldPasswprd = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlInfoUser1
            // 
            this.ctrlInfoUser1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlInfoUser1.Location = new System.Drawing.Point(12, 420);
            this.ctrlInfoUser1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlInfoUser1.Name = "ctrlInfoUser1";
            this.ctrlInfoUser1.Size = new System.Drawing.Size(736, 135);
            this.ctrlInfoUser1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrl_InfoPerson1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 401);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Person Information";
            // 
            // ctrl_InfoPerson1
            // 
            this.ctrl_InfoPerson1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_InfoPerson1.Location = new System.Drawing.Point(11, 16);
            this.ctrl_InfoPerson1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrl_InfoPerson1.Name = "ctrl_InfoPerson1";
            this.ctrl_InfoPerson1.person = null;
            this.ctrl_InfoPerson1.PersonID = 0;
            this.ctrl_InfoPerson1.Size = new System.Drawing.Size(585, 376);
            this.ctrl_InfoPerson1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.White;
            this.btnSave.FillColor2 = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.Location = new System.Drawing.Point(634, 612);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.TextOffset = new System.Drawing.Point(15, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TxtConfirmPassword
            // 
            this.TxtConfirmPassword.BorderRadius = 15;
            this.TxtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtConfirmPassword.DefaultText = "";
            this.TxtConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtConfirmPassword.Location = new System.Drawing.Point(523, 557);
            this.TxtConfirmPassword.Name = "TxtConfirmPassword";
            this.TxtConfirmPassword.PlaceholderText = "تأكيد كلمة المرور";
            this.TxtConfirmPassword.SelectedText = "";
            this.TxtConfirmPassword.Size = new System.Drawing.Size(223, 36);
            this.TxtConfirmPassword.TabIndex = 30;
            // 
            // TxtNewPasswprd
            // 
            this.TxtNewPasswprd.BorderRadius = 15;
            this.TxtNewPasswprd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtNewPasswprd.DefaultText = "";
            this.TxtNewPasswprd.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtNewPasswprd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtNewPasswprd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtNewPasswprd.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtNewPasswprd.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtNewPasswprd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtNewPasswprd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtNewPasswprd.Location = new System.Drawing.Point(265, 557);
            this.TxtNewPasswprd.Name = "TxtNewPasswprd";
            this.TxtNewPasswprd.PlaceholderText = "كلمة المرور الجديدة";
            this.TxtNewPasswprd.SelectedText = "";
            this.TxtNewPasswprd.Size = new System.Drawing.Size(223, 36);
            this.TxtNewPasswprd.TabIndex = 29;
            // 
            // TxtOldPasswprd
            // 
            this.TxtOldPasswprd.BorderRadius = 15;
            this.TxtOldPasswprd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtOldPasswprd.DefaultText = "";
            this.TxtOldPasswprd.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtOldPasswprd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtOldPasswprd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtOldPasswprd.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtOldPasswprd.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtOldPasswprd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtOldPasswprd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtOldPasswprd.Location = new System.Drawing.Point(15, 557);
            this.TxtOldPasswprd.Name = "TxtOldPasswprd";
            this.TxtOldPasswprd.PlaceholderText = "كلمة المرور القديمة";
            this.TxtOldPasswprd.SelectedText = "";
            this.TxtOldPasswprd.Size = new System.Drawing.Size(223, 36);
            this.TxtOldPasswprd.TabIndex = 28;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 10;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.FillColor2 = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnClose.Location = new System.Drawing.Point(499, 612);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 35);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.TextOffset = new System.Drawing.Point(15, 0);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 659);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.TxtConfirmPassword);
            this.Controls.Add(this.TxtNewPasswprd);
            this.Controls.Add(this.TxtOldPasswprd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlInfoUser1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmChangePassword";
            this.Text = "FrmChangePassword";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private User_Control.CtrlInfoUser ctrlInfoUser1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Manage_Persons.User_Control.ctrl_InfoPerson ctrl_InfoPerson1;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private Guna.UI2.WinForms.Guna2TextBox TxtConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox TxtNewPasswprd;
        private Guna.UI2.WinForms.Guna2TextBox TxtOldPasswprd;
        private Guna.UI2.WinForms.Guna2GradientButton btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}