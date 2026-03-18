namespace DVLD_Management_System.الواجهة_الرئيسية
{
    partial class FormShowUsers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShowUsers));
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFelter = new Guna.UI2.WinForms.Guna2TextBox();
            this.ComboFelter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNumberInfo = new System.Windows.Forms.Label();
            this.DGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberUsers = new System.Windows.Forms.Label();
            this.ElipseDGV = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.MyContextMenuStrip = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.CTMS_btnShowInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.CTMS_btnUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CTMS_btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CTMS_btnSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.CTMS_btnSend = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PicNext = new System.Windows.Forms.PictureBox();
            this.PicPrevious = new System.Windows.Forms.PictureBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.MyContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPrevious)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Location = new System.Drawing.Point(-144, 82);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(59, 22);
            this.label3.TabIndex = 21;
            this.label3.Text = "Felter";
            // 
            // TxtFelter
            // 
            this.TxtFelter.BorderRadius = 15;
            this.TxtFelter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtFelter.DefaultText = "";
            this.TxtFelter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtFelter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtFelter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtFelter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtFelter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtFelter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFelter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtFelter.Location = new System.Drawing.Point(201, 124);
            this.TxtFelter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtFelter.Name = "TxtFelter";
            this.TxtFelter.PlaceholderText = "";
            this.TxtFelter.SelectedText = "";
            this.TxtFelter.Size = new System.Drawing.Size(206, 36);
            this.TxtFelter.TabIndex = 20;
            // 
            // ComboFelter
            // 
            this.ComboFelter.BackColor = System.Drawing.Color.Transparent;
            this.ComboFelter.BorderRadius = 15;
            this.ComboFelter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboFelter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboFelter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboFelter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboFelter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboFelter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboFelter.ItemHeight = 30;
            this.ComboFelter.Items.AddRange(new object[] {
            "البحث برقم الشخص",
            "البحث بالاسم",
            "البحث بالرقم الوطني"});
            this.ComboFelter.Location = new System.Drawing.Point(27, 124);
            this.ComboFelter.Name = "ComboFelter";
            this.ComboFelter.Size = new System.Drawing.Size(167, 36);
            this.ComboFelter.TabIndex = 19;
            // 
            // lblNumberInfo
            // 
            this.lblNumberInfo.AutoSize = true;
            this.lblNumberInfo.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberInfo.Location = new System.Drawing.Point(571, 131);
            this.lblNumberInfo.Name = "lblNumberInfo";
            this.lblNumberInfo.Size = new System.Drawing.Size(24, 26);
            this.lblNumberInfo.TabIndex = 18;
            this.lblNumberInfo.Text = "0";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV.ColumnHeadersHeight = 35;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV.Location = new System.Drawing.Point(12, 163);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.Size = new System.Drawing.Size(877, 377);
            this.DGV.TabIndex = 14;
            this.DGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGV.ThemeStyle.HeaderStyle.Height = 35;
            this.DGV.ThemeStyle.ReadOnly = true;
            this.DGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGV.ThemeStyle.RowsStyle.Height = 22;
            this.DGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGV.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_CellMouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(429, 33);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(104, 42);
            this.label1.TabIndex = 23;
            this.label1.Text = "Usres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 564);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(113, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "عدد  الاشخاص :";
            // 
            // lblNumberUsers
            // 
            this.lblNumberUsers.AutoSize = true;
            this.lblNumberUsers.Location = new System.Drawing.Point(32, 564);
            this.lblNumberUsers.Name = "lblNumberUsers";
            this.lblNumberUsers.Size = new System.Drawing.Size(20, 22);
            this.lblNumberUsers.TabIndex = 24;
            this.lblNumberUsers.Text = "0";
            // 
            // ElipseDGV
            // 
            this.ElipseDGV.BorderRadius = 20;
            this.ElipseDGV.TargetControl = this.DGV;
            // 
            // MyContextMenuStrip
            // 
            this.MyContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CTMS_btnShowInfo,
            this.CTMS_btnUpdate,
            this.toolStripMenuItem1,
            this.CTMS_btnDelete,
            this.toolStripSeparator1,
            this.CTMS_btnSendEmail,
            this.CTMS_btnSend});
            this.MyContextMenuStrip.Name = "MyContextMenuStrip";
            this.MyContextMenuStrip.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.MyContextMenuStrip.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.MyContextMenuStrip.RenderStyle.ColorTable = null;
            this.MyContextMenuStrip.RenderStyle.RoundedEdges = true;
            this.MyContextMenuStrip.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.MyContextMenuStrip.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.MyContextMenuStrip.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.MyContextMenuStrip.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.MyContextMenuStrip.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.MyContextMenuStrip.Size = new System.Drawing.Size(204, 166);
            // 
            // CTMS_btnShowInfo
            // 
            this.CTMS_btnShowInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTMS_btnShowInfo.Image = ((System.Drawing.Image)(resources.GetObject("CTMS_btnShowInfo.Image")));
            this.CTMS_btnShowInfo.Name = "CTMS_btnShowInfo";
            this.CTMS_btnShowInfo.Size = new System.Drawing.Size(203, 26);
            this.CTMS_btnShowInfo.Text = "Display Information";
            this.CTMS_btnShowInfo.Click += new System.EventHandler(this.CTMS_btnShowInfo_Click);
            // 
            // CTMS_btnUpdate
            // 
            this.CTMS_btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTMS_btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("CTMS_btnUpdate.Image")));
            this.CTMS_btnUpdate.Name = "CTMS_btnUpdate";
            this.CTMS_btnUpdate.Size = new System.Drawing.Size(203, 26);
            this.CTMS_btnUpdate.Text = "Update";
            this.CTMS_btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CTMS_btnUpdate.Click += new System.EventHandler(this.CTMS_btnUpdate_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(203, 26);
            this.toolStripMenuItem1.Text = "Change Password";
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // CTMS_btnDelete
            // 
            this.CTMS_btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTMS_btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("CTMS_btnDelete.Image")));
            this.CTMS_btnDelete.Name = "CTMS_btnDelete";
            this.CTMS_btnDelete.Size = new System.Drawing.Size(203, 26);
            this.CTMS_btnDelete.Text = "Delete";
            this.CTMS_btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CTMS_btnDelete.Click += new System.EventHandler(this.CTMS_btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // CTMS_btnSendEmail
            // 
            this.CTMS_btnSendEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTMS_btnSendEmail.Image = ((System.Drawing.Image)(resources.GetObject("CTMS_btnSendEmail.Image")));
            this.CTMS_btnSendEmail.Name = "CTMS_btnSendEmail";
            this.CTMS_btnSendEmail.Size = new System.Drawing.Size(203, 26);
            this.CTMS_btnSendEmail.Text = "Send Email";
            // 
            // CTMS_btnSend
            // 
            this.CTMS_btnSend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTMS_btnSend.Image = ((System.Drawing.Image)(resources.GetObject("CTMS_btnSend.Image")));
            this.CTMS_btnSend.Name = "CTMS_btnSend";
            this.CTMS_btnSend.Size = new System.Drawing.Size(203, 26);
            this.CTMS_btnSend.Text = "Call";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(328, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(370, 128);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // PicNext
            // 
            this.PicNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicNext.Image = ((System.Drawing.Image)(resources.GetObject("PicNext.Image")));
            this.PicNext.Location = new System.Drawing.Point(621, 123);
            this.PicNext.Name = "PicNext";
            this.PicNext.Size = new System.Drawing.Size(33, 34);
            this.PicNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicNext.TabIndex = 17;
            this.PicNext.TabStop = false;
            this.PicNext.Click += new System.EventHandler(this.PicNext_Click);
            // 
            // PicPrevious
            // 
            this.PicPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicPrevious.Image = ((System.Drawing.Image)(resources.GetObject("PicPrevious.Image")));
            this.PicPrevious.Location = new System.Drawing.Point(509, 123);
            this.PicPrevious.Name = "PicPrevious";
            this.PicPrevious.Size = new System.Drawing.Size(33, 34);
            this.PicPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicPrevious.TabIndex = 16;
            this.PicPrevious.TabStop = false;
            this.PicPrevious.Click += new System.EventHandler(this.PicPrevious_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 15;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAdd.FillColor2 = System.Drawing.Color.DarkGray;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageSize = new System.Drawing.Size(50, 45);
            this.btnAdd.Location = new System.Drawing.Point(766, 114);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(123, 43);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FormShowUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 598);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNumberUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtFelter);
            this.Controls.Add(this.ComboFelter);
            this.Controls.Add(this.lblNumberInfo);
            this.Controls.Add(this.PicNext);
            this.Controls.Add(this.PicPrevious);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.DGV);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FormShowUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Information";
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.MyContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicPrevious)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox TxtFelter;
        private Guna.UI2.WinForms.Guna2ComboBox ComboFelter;
        private System.Windows.Forms.Label lblNumberInfo;
        private System.Windows.Forms.PictureBox PicNext;
        private System.Windows.Forms.PictureBox PicPrevious;
        private Guna.UI2.WinForms.Guna2GradientButton btnAdd;
        private Guna.UI2.WinForms.Guna2DataGridView DGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberUsers;
        private Guna.UI2.WinForms.Guna2Elipse ElipseDGV;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip MyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CTMS_btnShowInfo;
        private System.Windows.Forms.ToolStripMenuItem CTMS_btnUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CTMS_btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CTMS_btnSendEmail;
        private System.Windows.Forms.ToolStripMenuItem CTMS_btnSend;
    }
}