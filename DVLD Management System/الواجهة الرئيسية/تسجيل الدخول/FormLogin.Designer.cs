namespace DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.pnl_TopBar = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.PicMinimize = new System.Windows.Forms.PictureBox();
            this.PicClose = new System.Windows.Forms.PictureBox();
            this.ElipseForm = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.TxtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.ComboRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ErrorProviderLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbl_ISError = new System.Windows.Forms.Label();
            this.Chk_RememberMy = new Guna.UI2.WinForms.Guna2CheckBox();
            this.pnl_TopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProviderLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_TopBar
            // 
            this.pnl_TopBar.BackColor = System.Drawing.Color.Transparent;
            this.pnl_TopBar.Controls.Add(this.label1);
            this.pnl_TopBar.Controls.Add(this.PicMinimize);
            this.pnl_TopBar.Controls.Add(this.PicClose);
            this.pnl_TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_TopBar.FillColor = System.Drawing.Color.White;
            this.pnl_TopBar.Location = new System.Drawing.Point(0, 0);
            this.pnl_TopBar.Name = "pnl_TopBar";
            this.pnl_TopBar.ShadowColor = System.Drawing.Color.IndianRed;
            this.pnl_TopBar.ShadowDepth = 200;
            this.pnl_TopBar.ShadowShift = 3;
            this.pnl_TopBar.Size = new System.Drawing.Size(857, 53);
            this.pnl_TopBar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login";
            // 
            // PicMinimize
            // 
            this.PicMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicMinimize.Image = ((System.Drawing.Image)(resources.GetObject("PicMinimize.Image")));
            this.PicMinimize.Location = new System.Drawing.Point(741, 7);
            this.PicMinimize.Name = "PicMinimize";
            this.PicMinimize.Size = new System.Drawing.Size(42, 36);
            this.PicMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicMinimize.TabIndex = 2;
            this.PicMinimize.TabStop = false;
            this.PicMinimize.Click += new System.EventHandler(this.PicMinimize_Click);
            // 
            // PicClose
            // 
            this.PicClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicClose.Image = ((System.Drawing.Image)(resources.GetObject("PicClose.Image")));
            this.PicClose.Location = new System.Drawing.Point(803, 7);
            this.PicClose.Name = "PicClose";
            this.PicClose.Size = new System.Drawing.Size(42, 36);
            this.PicClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicClose.TabIndex = 1;
            this.PicClose.TabStop = false;
            this.PicClose.Click += new System.EventHandler(this.PicClose_Click);
            // 
            // ElipseForm
            // 
            this.ElipseForm.BorderRadius = 20;
            this.ElipseForm.TargetControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserName";
            // 
            // TxtUserName
            // 
            this.TxtUserName.BorderRadius = 15;
            this.TxtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtUserName.DefaultText = "";
            this.TxtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtUserName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtUserName.Location = new System.Drawing.Point(516, 249);
            this.TxtUserName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.PlaceholderText = "";
            this.TxtUserName.SelectedText = "";
            this.TxtUserName.Size = new System.Drawing.Size(299, 36);
            this.TxtUserName.TabIndex = 2;
            // 
            // ComboRole
            // 
            this.ComboRole.BackColor = System.Drawing.Color.Transparent;
            this.ComboRole.BorderRadius = 15;
            this.ComboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboRole.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboRole.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboRole.ItemHeight = 30;
            this.ComboRole.Items.AddRange(new object[] {
            "Employee",
            "Admin"});
            this.ComboRole.Location = new System.Drawing.Point(516, 402);
            this.ComboRole.Name = "ComboRole";
            this.ComboRole.Size = new System.Drawing.Size(299, 36);
            this.ComboRole.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 10;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(124)))), ((int)(((byte)(255)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageOffset = new System.Drawing.Point(-4, 0);
            this.btnLogin.ImageSize = new System.Drawing.Size(50, 50);
            this.btnLogin.Location = new System.Drawing.Point(548, 510);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(217, 41);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Log in";
            this.btnLogin.TextOffset = new System.Drawing.Point(-3, 0);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(741, 601);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(113, 27);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 24);
            this.label3.TabIndex = 6;
            this.label3.Tag = "الدخول كـ";
            this.label3.Text = "Role";
            // 
            // TxtPassword
            // 
            this.TxtPassword.BorderRadius = 15;
            this.TxtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtPassword.DefaultText = "";
            this.TxtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPassword.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtPassword.Location = new System.Drawing.Point(516, 327);
            this.TxtPassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PlaceholderText = "";
            this.TxtPassword.SelectedText = "";
            this.TxtPassword.Size = new System.Drawing.Size(299, 36);
            this.TxtPassword.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(139)))), ((int)(((byte)(171)))));
            this.guna2Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel1.BackgroundImage")));
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 53);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(377, 593);
            this.guna2Panel1.TabIndex = 9;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(548, 70);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(180, 155);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // ErrorProviderLogin
            // 
            this.ErrorProviderLogin.ContainerControl = this;
            // 
            // lbl_ISError
            // 
            this.lbl_ISError.AutoSize = true;
            this.lbl_ISError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ISError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_ISError.Location = new System.Drawing.Point(544, 488);
            this.lbl_ISError.Name = "lbl_ISError";
            this.lbl_ISError.Size = new System.Drawing.Size(231, 19);
            this.lbl_ISError.TabIndex = 10;
            this.lbl_ISError.Text = "اسم المستخدم أو كلمة المرور غير صحيحة";
            this.lbl_ISError.Visible = false;
            // 
            // Chk_RememberMy
            // 
            this.Chk_RememberMy.AutoSize = true;
            this.Chk_RememberMy.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Chk_RememberMy.CheckedState.BorderRadius = 0;
            this.Chk_RememberMy.CheckedState.BorderThickness = 0;
            this.Chk_RememberMy.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Chk_RememberMy.Location = new System.Drawing.Point(579, 457);
            this.Chk_RememberMy.Name = "Chk_RememberMy";
            this.Chk_RememberMy.Size = new System.Drawing.Size(161, 28);
            this.Chk_RememberMy.TabIndex = 11;
            this.Chk_RememberMy.Text = "Remember Me";
            this.Chk_RememberMy.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Chk_RememberMy.UncheckedState.BorderRadius = 0;
            this.Chk_RememberMy.UncheckedState.BorderThickness = 0;
            this.Chk_RememberMy.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Chk_RememberMy.CheckedChanged += new System.EventHandler(this.Chk_RememberMy_CheckedChanged);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(857, 646);
            this.Controls.Add(this.Chk_RememberMy);
            this.Controls.Add(this.lbl_ISError);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.ComboRole);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnl_TopBar);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.pnl_TopBar.ResumeLayout(false);
            this.pnl_TopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProviderLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel pnl_TopBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicMinimize;
        private System.Windows.Forms.PictureBox PicClose;
        private Guna.UI2.WinForms.Guna2Elipse ElipseForm;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2ComboBox ComboRole;
        private Guna.UI2.WinForms.Guna2TextBox TxtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox TxtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider ErrorProviderLogin;
        private System.Windows.Forms.Label lbl_ISError;
        private Guna.UI2.WinForms.Guna2CheckBox Chk_RememberMy;
    }
}