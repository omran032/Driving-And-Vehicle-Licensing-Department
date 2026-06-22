namespace DVLD_Management_System.Manage_Users
{
    partial class FrmAdd_UpdateUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdd_UpdateUser));
            this.TabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlFelterPersons1 = new DVLD_Management_System.Manage_Persons.User_Control.CtrlFelterPersons();
            this.btnAddPerson = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ctrl_InfoPerson = new DVLD_Management_System.Manage_Persons.User_Control.ctrl_InfoPerson();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.TxtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.TxtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.Chck_IsActive = new Guna.UI2.WinForms.Guna2CheckBox();
            this.TxtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_IDUser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox6 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CombxRoles = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TabCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // TabCtrl
            // 
            this.TabCtrl.Controls.Add(this.tabPage1);
            this.TabCtrl.Controls.Add(this.tabPage2);
            this.TabCtrl.Location = new System.Drawing.Point(12, 45);
            this.TabCtrl.Name = "TabCtrl";
            this.TabCtrl.SelectedIndex = 0;
            this.TabCtrl.Size = new System.Drawing.Size(867, 547);
            this.TabCtrl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.AliceBlue;
            this.tabPage1.Controls.Add(this.ctrlFelterPersons1);
            this.tabPage1.Controls.Add(this.btnAddPerson);
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.ctrl_InfoPerson);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(859, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personal Info";
            // 
            // ctrlFelterPersons1
            // 
            this.ctrlFelterPersons1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlFelterPersons1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlFelterPersons1.Location = new System.Drawing.Point(6, 8);
            this.ctrlFelterPersons1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrlFelterPersons1.Name = "ctrlFelterPersons1";
            this.ctrlFelterPersons1.Size = new System.Drawing.Size(535, 66);
            this.ctrlFelterPersons1.TabIndex = 31;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BorderRadius = 10;
            this.btnAddPerson.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddPerson.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPerson.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPerson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPerson.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPerson.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddPerson.FillColor = System.Drawing.Color.PowderBlue;
            this.btnAddPerson.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddPerson.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.Image")));
            this.btnAddPerson.ImageSize = new System.Drawing.Size(40, 40);
            this.btnAddPerson.Location = new System.Drawing.Point(721, 20);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(124, 45);
            this.btnAddPerson.TabIndex = 30;
            this.btnAddPerson.Text = "Add";
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnNext
            // 
            this.btnNext.BorderColor = System.Drawing.Color.Gray;
            this.btnNext.BorderRadius = 10;
            this.btnNext.BorderThickness = 1;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.White;
            this.btnNext.FillColor2 = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.Navy;
            this.btnNext.Image = global::DVLD_Management_System.Properties.Resources.Next;
            this.btnNext.ImageSize = new System.Drawing.Size(32, 32);
            this.btnNext.Location = new System.Drawing.Point(721, 457);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(124, 45);
            this.btnNext.TabIndex = 26;
            this.btnNext.Text = "Next";
            this.btnNext.TextOffset = new System.Drawing.Point(2, 0);
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrl_InfoPerson
            // 
            this.ctrl_InfoPerson.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctrl_InfoPerson.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_InfoPerson.Location = new System.Drawing.Point(0, 75);
            this.ctrl_InfoPerson.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrl_InfoPerson.Name = "ctrl_InfoPerson";
            this.ctrl_InfoPerson.person = null;
            this.ctrl_InfoPerson.PersonID = 0;
            this.ctrl_InfoPerson.Size = new System.Drawing.Size(795, 427);
            this.ctrl_InfoPerson.TabIndex = 28;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.AliceBlue;
            this.tabPage2.Controls.Add(this.CombxRoles);
            this.tabPage2.Controls.Add(this.guna2PictureBox6);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.guna2PictureBox4);
            this.tabPage2.Controls.Add(this.guna2PictureBox3);
            this.tabPage2.Controls.Add(this.guna2PictureBox2);
            this.tabPage2.Controls.Add(this.guna2PictureBox1);
            this.tabPage2.Controls.Add(this.TxtConfirmPassword);
            this.tabPage2.Controls.Add(this.TxtPassword);
            this.tabPage2.Controls.Add(this.Chck_IsActive);
            this.tabPage2.Controls.Add(this.TxtUserName);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.lbl_IDUser);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(859, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Login Info";
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.Image = global::DVLD_Management_System.Properties.Resources.Number_32;
            this.guna2PictureBox4.ImageRotate = 0F;
            this.guna2PictureBox4.Location = new System.Drawing.Point(277, 56);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.Size = new System.Drawing.Size(41, 35);
            this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox4.TabIndex = 12;
            this.guna2PictureBox4.TabStop = false;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.Image = global::DVLD_Management_System.Properties.Resources.Password_32;
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(277, 239);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(41, 35);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 11;
            this.guna2PictureBox3.TabStop = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = global::DVLD_Management_System.Properties.Resources.Password_32;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(277, 178);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(41, 35);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 10;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DVLD_Management_System.Properties.Resources.User_32__2;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(277, 116);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(41, 35);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 9;
            this.guna2PictureBox1.TabStop = false;
            // 
            // TxtConfirmPassword
            // 
            this.TxtConfirmPassword.BorderColor = System.Drawing.Color.Silver;
            this.TxtConfirmPassword.BorderRadius = 10;
            this.TxtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtConfirmPassword.DefaultText = "";
            this.TxtConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtConfirmPassword.Location = new System.Drawing.Point(324, 238);
            this.TxtConfirmPassword.Name = "TxtConfirmPassword";
            this.TxtConfirmPassword.PlaceholderText = "";
            this.TxtConfirmPassword.SelectedText = "";
            this.TxtConfirmPassword.Size = new System.Drawing.Size(226, 36);
            this.TxtConfirmPassword.TabIndex = 8;
            // 
            // TxtPassword
            // 
            this.TxtPassword.BorderColor = System.Drawing.Color.Silver;
            this.TxtPassword.BorderRadius = 10;
            this.TxtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtPassword.DefaultText = "";
            this.TxtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPassword.Location = new System.Drawing.Point(324, 177);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PlaceholderText = "";
            this.TxtPassword.SelectedText = "";
            this.TxtPassword.Size = new System.Drawing.Size(226, 36);
            this.TxtPassword.TabIndex = 7;
            // 
            // Chck_IsActive
            // 
            this.Chck_IsActive.AutoSize = true;
            this.Chck_IsActive.Checked = true;
            this.Chck_IsActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Chck_IsActive.CheckedState.BorderRadius = 0;
            this.Chck_IsActive.CheckedState.BorderThickness = 0;
            this.Chck_IsActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Chck_IsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chck_IsActive.Location = new System.Drawing.Point(365, 363);
            this.Chck_IsActive.Name = "Chck_IsActive";
            this.Chck_IsActive.Size = new System.Drawing.Size(99, 26);
            this.Chck_IsActive.TabIndex = 6;
            this.Chck_IsActive.Text = "Is Active";
            this.Chck_IsActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Chck_IsActive.UncheckedState.BorderRadius = 0;
            this.Chck_IsActive.UncheckedState.BorderThickness = 0;
            this.Chck_IsActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Chck_IsActive.CheckedChanged += new System.EventHandler(this.Chck_IsActive_CheckedChanged);
            // 
            // TxtUserName
            // 
            this.TxtUserName.BorderColor = System.Drawing.Color.Silver;
            this.TxtUserName.BorderRadius = 10;
            this.TxtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtUserName.DefaultText = "";
            this.TxtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtUserName.Location = new System.Drawing.Point(324, 116);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.PlaceholderText = "";
            this.TxtUserName.SelectedText = "";
            this.TxtUserName.Size = new System.Drawing.Size(226, 36);
            this.TxtUserName.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(143, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "User Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(156, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Confirm Password";
            // 
            // lbl_IDUser
            // 
            this.lbl_IDUser.AutoSize = true;
            this.lbl_IDUser.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IDUser.Location = new System.Drawing.Point(361, 67);
            this.lbl_IDUser.Name = "lbl_IDUser";
            this.lbl_IDUser.Size = new System.Drawing.Size(43, 24);
            this.lbl_IDUser.TabIndex = 1;
            this.lbl_IDUser.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(174, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID User";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(340, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(247, 42);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "Add New User";
            // 
            // btnSave
            // 
            this.btnSave.BorderColor = System.Drawing.Color.Gray;
            this.btnSave.BorderRadius = 10;
            this.btnSave.BorderThickness = 1;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.White;
            this.btnSave.FillColor2 = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSave.Image = global::DVLD_Management_System.Properties.Resources.Save;
            this.btnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(737, 598);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 45);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.TextOffset = new System.Drawing.Point(2, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox5.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(27, 9);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.Size = new System.Drawing.Size(232, 42);
            this.guna2PictureBox5.TabIndex = 31;
            this.guna2PictureBox5.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.Gray;
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
            this.btnClose.Location = new System.Drawing.Point(606, 598);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 45);
            this.btnClose.TabIndex = 131;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // guna2PictureBox6
            // 
            this.guna2PictureBox6.Image = global::DVLD_Management_System.Properties.Resources.Role;
            this.guna2PictureBox6.ImageRotate = 0F;
            this.guna2PictureBox6.Location = new System.Drawing.Point(277, 298);
            this.guna2PictureBox6.Name = "guna2PictureBox6";
            this.guna2PictureBox6.Size = new System.Drawing.Size(41, 35);
            this.guna2PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox6.TabIndex = 15;
            this.guna2PictureBox6.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Role ";
            // 
            // CombxRoles
            // 
            this.CombxRoles.BackColor = System.Drawing.Color.Transparent;
            this.CombxRoles.BorderColor = System.Drawing.Color.Silver;
            this.CombxRoles.BorderRadius = 10;
            this.CombxRoles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CombxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CombxRoles.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxRoles.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxRoles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombxRoles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CombxRoles.ItemHeight = 30;
            this.CombxRoles.Items.AddRange(new object[] {
            "Employee"});
            this.CombxRoles.Location = new System.Drawing.Point(324, 297);
            this.CombxRoles.Name = "CombxRoles";
            this.CombxRoles.Size = new System.Drawing.Size(226, 36);
            this.CombxRoles.TabIndex = 16;
            // 
            // FrmAdd_UpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(884, 655);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2PictureBox5);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.TabCtrl);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "FrmAdd_UpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New User";
            this.TabCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2GradientButton btnNext;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private Guna.UI2.WinForms.Guna2TextBox TxtConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox TxtPassword;
        private Guna.UI2.WinForms.Guna2CheckBox Chck_IsActive;
        private Guna.UI2.WinForms.Guna2TextBox TxtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_IDUser;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Manage_Persons.User_Control.ctrl_InfoPerson ctrl_InfoPerson;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddPerson;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private Manage_Persons.User_Control.CtrlFelterPersons ctrlFelterPersons1;
        private Guna.UI2.WinForms.Guna2GradientButton btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox6;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox CombxRoles;
    }
}