namespace DVLD_Management_System.Manage_Persons.User_Control
{
    partial class Ctrl_Add_UpdatePerson
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ctrl_Add_UpdatePerson));
            this.label2 = new System.Windows.Forms.Label();
            this.ComboCountry = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.RdoMale = new Guna.UI2.WinForms.Guna2RadioButton();
            this.RdoFemale = new Guna.UI2.WinForms.Guna2RadioButton();
            this.ComboHousing = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtNationalNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.DT_BirthDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtnumPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.AddPicture = new System.Windows.Forms.LinkLabel();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Picture = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbl_IDPerson = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "الاسم الكامل";
            // 
            // ComboCountry
            // 
            this.ComboCountry.BackColor = System.Drawing.Color.Transparent;
            this.ComboCountry.BorderRadius = 15;
            this.ComboCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboCountry.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboCountry.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboCountry.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboCountry.ItemHeight = 30;
            this.ComboCountry.Items.AddRange(new object[] {
            "سوري",
            "فلسطيني",
            "اردني",
            "لبناني"});
            this.ComboCountry.Location = new System.Drawing.Point(553, 112);
            this.ComboCountry.Name = "ComboCountry";
            this.ComboCountry.Size = new System.Drawing.Size(229, 36);
            this.ComboCountry.TabIndex = 11;
            // 
            // txtFullName
            // 
            this.txtFullName.BorderRadius = 15;
            this.txtFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.DefaultText = "";
            this.txtFullName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFullName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFullName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFullName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullName.Location = new System.Drawing.Point(147, 54);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PlaceholderText = "";
            this.txtFullName.SelectedText = "";
            this.txtFullName.Size = new System.Drawing.Size(246, 29);
            this.txtFullName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(442, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "السكن";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 15;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(147, 240);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(246, 29);
            this.txtEmail.TabIndex = 14;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "رقم الهاتف";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "الجنسية";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 19);
            this.label6.TabIndex = 19;
            this.label6.Text = "الرقم الوطني";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(421, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 19);
            this.label9.TabIndex = 22;
            this.label9.Text = "تاريخ الميلاد";
            // 
            // RdoMale
            // 
            this.RdoMale.AutoSize = true;
            this.RdoMale.Checked = true;
            this.RdoMale.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RdoMale.CheckedState.BorderThickness = 0;
            this.RdoMale.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RdoMale.CheckedState.InnerColor = System.Drawing.Color.White;
            this.RdoMale.CheckedState.InnerOffset = -4;
            this.RdoMale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdoMale.Location = new System.Drawing.Point(545, 245);
            this.RdoMale.Name = "RdoMale";
            this.RdoMale.Size = new System.Drawing.Size(45, 23);
            this.RdoMale.TabIndex = 23;
            this.RdoMale.TabStop = true;
            this.RdoMale.Tag = "Male";
            this.RdoMale.Text = "ذكر";
            this.RdoMale.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.RdoMale.UncheckedState.BorderThickness = 2;
            this.RdoMale.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.RdoMale.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.RdoMale.CheckedChanged += new System.EventHandler(this.RdoMale_CheckedChanged);
            // 
            // RdoFemale
            // 
            this.RdoFemale.AutoSize = true;
            this.RdoFemale.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RdoFemale.CheckedState.BorderThickness = 0;
            this.RdoFemale.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RdoFemale.CheckedState.InnerColor = System.Drawing.Color.White;
            this.RdoFemale.CheckedState.InnerOffset = -4;
            this.RdoFemale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdoFemale.Location = new System.Drawing.Point(701, 245);
            this.RdoFemale.Name = "RdoFemale";
            this.RdoFemale.Size = new System.Drawing.Size(48, 23);
            this.RdoFemale.TabIndex = 24;
            this.RdoFemale.Tag = "Female";
            this.RdoFemale.Text = "انثى";
            this.RdoFemale.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.RdoFemale.UncheckedState.BorderThickness = 2;
            this.RdoFemale.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.RdoFemale.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.RdoFemale.CheckedChanged += new System.EventHandler(this.RdoFemale_CheckedChanged);
            // 
            // ComboHousing
            // 
            this.ComboHousing.BackColor = System.Drawing.Color.Transparent;
            this.ComboHousing.BorderRadius = 15;
            this.ComboHousing.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboHousing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboHousing.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboHousing.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboHousing.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboHousing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboHousing.ItemHeight = 30;
            this.ComboHousing.Items.AddRange(new object[] {
            "خارج القطر",
            "دمشق",
            "ريف دمشق",
            "درعا",
            "حلب",
            "حمص",
            "السويداء",
            "القنيطرة",
            "دير الزور",
            "الحسكة",
            "الرقة",
            "حلب",
            "ادلب",
            "اللاذقية",
            "طرطوس"});
            this.ComboHousing.Location = new System.Drawing.Point(553, 54);
            this.ComboHousing.Name = "ComboHousing";
            this.ComboHousing.Size = new System.Drawing.Size(229, 36);
            this.ComboHousing.TabIndex = 29;
            // 
            // txtNationalNumber
            // 
            this.txtNationalNumber.BorderRadius = 15;
            this.txtNationalNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNationalNumber.DefaultText = "";
            this.txtNationalNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNationalNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNationalNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNationalNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNationalNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNationalNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNationalNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNationalNumber.Location = new System.Drawing.Point(147, 116);
            this.txtNationalNumber.Name = "txtNationalNumber";
            this.txtNationalNumber.PlaceholderText = "";
            this.txtNationalNumber.SelectedText = "";
            this.txtNationalNumber.Size = new System.Drawing.Size(246, 29);
            this.txtNationalNumber.TabIndex = 30;
            this.txtNationalNumber.Leave += new System.EventHandler(this.txtNationalNumber_Leave);
            // 
            // DT_BirthDate
            // 
            this.DT_BirthDate.BorderRadius = 10;
            this.DT_BirthDate.Checked = true;
            this.DT_BirthDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DT_BirthDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_BirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DT_BirthDate.Location = new System.Drawing.Point(553, 175);
            this.DT_BirthDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DT_BirthDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DT_BirthDate.Name = "DT_BirthDate";
            this.DT_BirthDate.Size = new System.Drawing.Size(229, 34);
            this.DT_BirthDate.TabIndex = 31;
            this.DT_BirthDate.TextOffset = new System.Drawing.Point(35, 0);
            this.DT_BirthDate.Value = new System.DateTime(2026, 2, 27, 12, 31, 54, 899);
            // 
            // txtnumPhone
            // 
            this.txtnumPhone.BorderRadius = 15;
            this.txtnumPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnumPhone.DefaultText = "";
            this.txtnumPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtnumPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtnumPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtnumPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtnumPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtnumPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtnumPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtnumPhone.Location = new System.Drawing.Point(147, 178);
            this.txtnumPhone.Name = "txtnumPhone";
            this.txtnumPhone.PlaceholderText = "";
            this.txtnumPhone.SelectedText = "";
            this.txtnumPhone.Size = new System.Drawing.Size(246, 29);
            this.txtnumPhone.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 15;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(281, 446);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(319, 41);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "حفظ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddPicture
            // 
            this.AddPicture.AutoSize = true;
            this.AddPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddPicture.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPicture.Location = new System.Drawing.Point(398, 407);
            this.AddPicture.Name = "AddPicture";
            this.AddPicture.Size = new System.Drawing.Size(86, 22);
            this.AddPicture.TabIndex = 43;
            this.AddPicture.TabStop = true;
            this.AddPicture.Text = "تعيين صورة";
            this.AddPicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddPicture_LinkClicked);
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Picture
            // 
            this.Picture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Picture.Image = global::DVLD_Management_System.Properties.Resources.Male;
            this.Picture.Location = new System.Drawing.Point(370, 280);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(137, 124);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture.TabIndex = 40;
            this.Picture.TabStop = false;
            this.Picture.Tag = "Default";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(507, 179);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(27, 28);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 39;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(502, 55);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(36, 28);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 37;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(502, 111);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(36, 38);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 36;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(101, 51);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(36, 35);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 35;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(101, 112);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(36, 37);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 34;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(101, 179);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(36, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 33;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(101, 242);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(755, 244);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(594, 244);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 27;
            this.pictureBox3.TabStop = false;
            // 
            // lbl_IDPerson
            // 
            this.lbl_IDPerson.AutoSize = true;
            this.lbl_IDPerson.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IDPerson.ForeColor = System.Drawing.Color.Navy;
            this.lbl_IDPerson.Location = new System.Drawing.Point(29, 5);
            this.lbl_IDPerson.Name = "lbl_IDPerson";
            this.lbl_IDPerson.Size = new System.Drawing.Size(41, 22);
            this.lbl_IDPerson.TabIndex = 44;
            this.lbl_IDPerson.Text = "ID :";
            // 
            // Ctrl_Add_UpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_IDPerson);
            this.Controls.Add(this.AddPicture);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DT_BirthDate);
            this.Controls.Add(this.txtNationalNumber);
            this.Controls.Add(this.ComboHousing);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.RdoFemale);
            this.Controls.Add(this.RdoMale);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtnumPhone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComboCountry);
            this.Controls.Add(this.txtFullName);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ctrl_Add_UpdatePerson";
            this.Size = new System.Drawing.Size(845, 498);
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox ComboCountry;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2RadioButton RdoMale;
        private Guna.UI2.WinForms.Guna2RadioButton RdoFemale;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2ComboBox ComboHousing;
        private Guna.UI2.WinForms.Guna2TextBox txtNationalNumber;
        private Guna.UI2.WinForms.Guna2DateTimePicker DT_BirthDate;
        private Guna.UI2.WinForms.Guna2TextBox txtnumPhone;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox Picture;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.LinkLabel AddPicture;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbl_IDPerson;
    }
}
