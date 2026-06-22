namespace DVLD_Management_System.Applications.Manage_Application.Local_Driving_License_Application.UI
{
    partial class FrmShowLicenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PicTitle = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.DGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblCountRecords = new System.Windows.Forms.Label();
            this.CombxTypeLicense = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CombxDateRange = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CombxLicenseStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // PicTitle
            // 
            this.PicTitle.Image = global::DVLD_Management_System.Properties.Resources.Local_32;
            this.PicTitle.ImageRotate = 0F;
            this.PicTitle.Location = new System.Drawing.Point(644, 150);
            this.PicTitle.Name = "PicTitle";
            this.PicTitle.Size = new System.Drawing.Size(47, 41);
            this.PicTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicTitle.TabIndex = 14;
            this.PicTitle.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DVLD_Management_System.Properties.Resources.DrivigLicense;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(538, 67);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(130, 117);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 13;
            this.guna2PictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(426, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(376, 42);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Show Local Licenses";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            this.DGV.Location = new System.Drawing.Point(34, 300);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGV.Size = new System.Drawing.Size(1153, 368);
            this.DGV.TabIndex = 15;
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
            // 
            // lblCountRecords
            // 
            this.lblCountRecords.AutoSize = true;
            this.lblCountRecords.Location = new System.Drawing.Point(71, 689);
            this.lblCountRecords.Name = "lblCountRecords";
            this.lblCountRecords.Size = new System.Drawing.Size(93, 22);
            this.lblCountRecords.TabIndex = 16;
            this.lblCountRecords.Text = "Records : ";
            // 
            // CombxTypeLicense
            // 
            this.CombxTypeLicense.BackColor = System.Drawing.Color.Transparent;
            this.CombxTypeLicense.BorderRadius = 10;
            this.CombxTypeLicense.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CombxTypeLicense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CombxTypeLicense.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxTypeLicense.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxTypeLicense.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombxTypeLicense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CombxTypeLicense.ItemHeight = 30;
            this.CombxTypeLicense.Items.AddRange(new object[] {
            "Local Licnse",
            "International License"});
            this.CombxTypeLicense.Location = new System.Drawing.Point(159, 244);
            this.CombxTypeLicense.Name = "CombxTypeLicense";
            this.CombxTypeLicense.Size = new System.Drawing.Size(210, 36);
            this.CombxTypeLicense.TabIndex = 17;
            this.CombxTypeLicense.SelectedIndexChanged += new System.EventHandler(this.CombxTypeLicense_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Type License";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(440, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Date Range";
            // 
            // CombxDateRange
            // 
            this.CombxDateRange.BackColor = System.Drawing.Color.Transparent;
            this.CombxDateRange.BorderRadius = 10;
            this.CombxDateRange.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CombxDateRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CombxDateRange.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxDateRange.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxDateRange.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombxDateRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CombxDateRange.ItemHeight = 30;
            this.CombxDateRange.Items.AddRange(new object[] {
            "This Month",
            "This Year"});
            this.CombxDateRange.Location = new System.Drawing.Point(563, 244);
            this.CombxDateRange.Name = "CombxDateRange";
            this.CombxDateRange.Size = new System.Drawing.Size(210, 36);
            this.CombxDateRange.TabIndex = 19;
            this.CombxDateRange.SelectedIndexChanged += new System.EventHandler(this.CombxDateRange_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(843, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 22);
            this.label3.TabIndex = 22;
            this.label3.Text = "License Status";
            // 
            // CombxLicenseStatus
            // 
            this.CombxLicenseStatus.BackColor = System.Drawing.Color.Transparent;
            this.CombxLicenseStatus.BorderRadius = 10;
            this.CombxLicenseStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CombxLicenseStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CombxLicenseStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxLicenseStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CombxLicenseStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CombxLicenseStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CombxLicenseStatus.ItemHeight = 30;
            this.CombxLicenseStatus.Items.AddRange(new object[] {
            "New License",
            "Expired License"});
            this.CombxLicenseStatus.Location = new System.Drawing.Point(977, 244);
            this.CombxLicenseStatus.Name = "CombxLicenseStatus";
            this.CombxLicenseStatus.Size = new System.Drawing.Size(210, 36);
            this.CombxLicenseStatus.TabIndex = 21;
            this.CombxLicenseStatus.SelectedIndexChanged += new System.EventHandler(this.CombxLicenseStatus_SelectedIndexChanged);
            // 
            // FrmShowLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1218, 750);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CombxLicenseStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CombxDateRange);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CombxTypeLicense);
            this.Controls.Add(this.lblCountRecords);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.PicTitle);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "FrmShowLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Licenses";
            this.Load += new System.EventHandler(this.FrmShowLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox PicTitle;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2DataGridView DGV;
        private System.Windows.Forms.Label lblCountRecords;
        private Guna.UI2.WinForms.Guna2ComboBox CombxTypeLicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox CombxDateRange;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox CombxLicenseStatus;
    }
}