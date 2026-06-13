namespace DVLD_Management_System.Applications
{
    partial class FrmLocalDrivingLicenseApplication
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocalDrivingLicenseApplication));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCountRecords = new System.Windows.Forms.Label();
            this.DGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddLocalDrivingLicenseApp = new Guna.UI2.WinForms.Guna2GradientButton();
            this.MyContextMenuStrip = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.Context_btnAddLocalDrivingLicenseApp = new System.Windows.Forms.ToolStripMenuItem();
            this.Context_btnEditLocalDrivingLicenseApp = new System.Windows.Forms.ToolStripMenuItem();
            this.Context_btnDeleteLocalDrivingLicenseApp = new System.Windows.Forms.ToolStripMenuItem();
            this.Context_btnCancleApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Context_btnSchedualeVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.Context_btnSchedualeWnitteTest = new System.Windows.Forms.ToolStripMenuItem();
            this.Context_btnSchedualeStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.lssueDrivingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lssueDrivingLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ctrlLicenseAppFelter1 = new DVLD.Applications.LocalDrivingLicense.CtrlLicenseAppFelter();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.MyContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(294, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(589, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Local Driving license Application";
            // 
            // lblCountRecords
            // 
            this.lblCountRecords.AutoSize = true;
            this.lblCountRecords.Location = new System.Drawing.Point(40, 731);
            this.lblCountRecords.Name = "lblCountRecords";
            this.lblCountRecords.Size = new System.Drawing.Size(93, 22);
            this.lblCountRecords.TabIndex = 1;
            this.lblCountRecords.Text = "Records : ";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV.ColumnHeadersHeight = 35;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle7;
            this.DGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV.Location = new System.Drawing.Point(24, 334);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DGV.Size = new System.Drawing.Size(1116, 368);
            this.DGV.TabIndex = 8;
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
            // btnAddLocalDrivingLicenseApp
            // 
            this.btnAddLocalDrivingLicenseApp.BorderRadius = 15;
            this.btnAddLocalDrivingLicenseApp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddLocalDrivingLicenseApp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddLocalDrivingLicenseApp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddLocalDrivingLicenseApp.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddLocalDrivingLicenseApp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddLocalDrivingLicenseApp.FillColor = System.Drawing.Color.LightCyan;
            this.btnAddLocalDrivingLicenseApp.FillColor2 = System.Drawing.Color.Ivory;
            this.btnAddLocalDrivingLicenseApp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLocalDrivingLicenseApp.ForeColor = System.Drawing.Color.Black;
            this.btnAddLocalDrivingLicenseApp.Image = global::DVLD_Management_System.Properties.Resources.Add_File;
            this.btnAddLocalDrivingLicenseApp.ImageSize = new System.Drawing.Size(60, 60);
            this.btnAddLocalDrivingLicenseApp.Location = new System.Drawing.Point(1059, 255);
            this.btnAddLocalDrivingLicenseApp.Name = "btnAddLocalDrivingLicenseApp";
            this.btnAddLocalDrivingLicenseApp.Size = new System.Drawing.Size(81, 72);
            this.btnAddLocalDrivingLicenseApp.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnAddLocalDrivingLicenseApp, "Add New Driving License Application");
            this.btnAddLocalDrivingLicenseApp.Click += new System.EventHandler(this.btnAddLocalDrivingLicenseApp_Click);
            // 
            // MyContextMenuStrip
            // 
            this.MyContextMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Context_btnAddLocalDrivingLicenseApp,
            this.Context_btnEditLocalDrivingLicenseApp,
            this.Context_btnDeleteLocalDrivingLicenseApp,
            this.Context_btnCancleApplication,
            this.sechduleTestsToolStripMenuItem,
            this.lssueDrivingToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.lssueDrivingLicenseHistoryToolStripMenuItem});
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
            this.MyContextMenuStrip.Size = new System.Drawing.Size(283, 202);
            this.MyContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.MyContextMenuStrip_Opening);
            // 
            // Context_btnAddLocalDrivingLicenseApp
            // 
            this.Context_btnAddLocalDrivingLicenseApp.Image = global::DVLD_Management_System.Properties.Resources.Show_Application_Details;
            this.Context_btnAddLocalDrivingLicenseApp.Name = "Context_btnAddLocalDrivingLicenseApp";
            this.Context_btnAddLocalDrivingLicenseApp.Size = new System.Drawing.Size(282, 22);
            this.Context_btnAddLocalDrivingLicenseApp.Text = "Show Application Details";
            this.Context_btnAddLocalDrivingLicenseApp.Click += new System.EventHandler(this.btnAddLocalDrivingLicenseApp_Click);
            // 
            // Context_btnEditLocalDrivingLicenseApp
            // 
            this.Context_btnEditLocalDrivingLicenseApp.Image = ((System.Drawing.Image)(resources.GetObject("Context_btnEditLocalDrivingLicenseApp.Image")));
            this.Context_btnEditLocalDrivingLicenseApp.Name = "Context_btnEditLocalDrivingLicenseApp";
            this.Context_btnEditLocalDrivingLicenseApp.Size = new System.Drawing.Size(282, 22);
            this.Context_btnEditLocalDrivingLicenseApp.Text = "Edit Application";
            this.Context_btnEditLocalDrivingLicenseApp.Click += new System.EventHandler(this.Context_btnEditLocalDrivingLicenseApp_Click);
            // 
            // Context_btnDeleteLocalDrivingLicenseApp
            // 
            this.Context_btnDeleteLocalDrivingLicenseApp.Image = global::DVLD_Management_System.Properties.Resources.Remove;
            this.Context_btnDeleteLocalDrivingLicenseApp.Name = "Context_btnDeleteLocalDrivingLicenseApp";
            this.Context_btnDeleteLocalDrivingLicenseApp.Size = new System.Drawing.Size(282, 22);
            this.Context_btnDeleteLocalDrivingLicenseApp.Text = "Delete Application";
            this.Context_btnDeleteLocalDrivingLicenseApp.Click += new System.EventHandler(this.Context_btnDeleteLocalDrivingLicenseApp_Click);
            // 
            // Context_btnCancleApplication
            // 
            this.Context_btnCancleApplication.Image = global::DVLD_Management_System.Properties.Resources.Cancel_App;
            this.Context_btnCancleApplication.Name = "Context_btnCancleApplication";
            this.Context_btnCancleApplication.Size = new System.Drawing.Size(282, 22);
            this.Context_btnCancleApplication.Text = "Cancle Application";
            this.Context_btnCancleApplication.Click += new System.EventHandler(this.Context_btnCancleApplication_Click);
            // 
            // sechduleTestsToolStripMenuItem
            // 
            this.sechduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Context_btnSchedualeVisionTest,
            this.Context_btnSchedualeWnitteTest,
            this.Context_btnSchedualeStreetTest});
            this.sechduleTestsToolStripMenuItem.Image = global::DVLD_Management_System.Properties.Resources.TestsExam;
            this.sechduleTestsToolStripMenuItem.Name = "sechduleTestsToolStripMenuItem";
            this.sechduleTestsToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.sechduleTestsToolStripMenuItem.Text = "Sechdule Tests";
            // 
            // Context_btnSchedualeVisionTest
            // 
            this.Context_btnSchedualeVisionTest.Image = global::DVLD_Management_System.Properties.Resources.Eye;
            this.Context_btnSchedualeVisionTest.Name = "Context_btnSchedualeVisionTest";
            this.Context_btnSchedualeVisionTest.Size = new System.Drawing.Size(213, 22);
            this.Context_btnSchedualeVisionTest.Text = "Scheduale Vision Test";
            this.Context_btnSchedualeVisionTest.Click += new System.EventHandler(this.Context_btnSchedualeVisionTest_Click);
            // 
            // Context_btnSchedualeWnitteTest
            // 
            this.Context_btnSchedualeWnitteTest.Image = global::DVLD_Management_System.Properties.Resources.exam;
            this.Context_btnSchedualeWnitteTest.Name = "Context_btnSchedualeWnitteTest";
            this.Context_btnSchedualeWnitteTest.Size = new System.Drawing.Size(213, 22);
            this.Context_btnSchedualeWnitteTest.Text = "Scheduale Wnitte Test";
            this.Context_btnSchedualeWnitteTest.Click += new System.EventHandler(this.Context_btnSchedualeWnitteTest_Click);
            // 
            // Context_btnSchedualeStreetTest
            // 
            this.Context_btnSchedualeStreetTest.Image = global::DVLD_Management_System.Properties.Resources.car;
            this.Context_btnSchedualeStreetTest.Name = "Context_btnSchedualeStreetTest";
            this.Context_btnSchedualeStreetTest.Size = new System.Drawing.Size(213, 22);
            this.Context_btnSchedualeStreetTest.Text = "Scheduale Street Test";
            this.Context_btnSchedualeStreetTest.Click += new System.EventHandler(this.Context_btnSchedualeStreetTest_Click);
            // 
            // lssueDrivingToolStripMenuItem
            // 
            this.lssueDrivingToolStripMenuItem.Image = global::DVLD_Management_System.Properties.Resources.Driving_License;
            this.lssueDrivingToolStripMenuItem.Name = "lssueDrivingToolStripMenuItem";
            this.lssueDrivingToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.lssueDrivingToolStripMenuItem.Text = "lssue Driving License (First Time)";
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_Management_System.Properties.Resources.Documents1;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            // 
            // lssueDrivingLicenseHistoryToolStripMenuItem
            // 
            this.lssueDrivingLicenseHistoryToolStripMenuItem.Image = global::DVLD_Management_System.Properties.Resources.Date_To;
            this.lssueDrivingLicenseHistoryToolStripMenuItem.Name = "lssueDrivingLicenseHistoryToolStripMenuItem";
            this.lssueDrivingLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.lssueDrivingLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DVLD_Management_System.Properties.Resources.Documents;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(502, 78);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(130, 117);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 9;
            this.guna2PictureBox1.TabStop = false;
            // 
            // ctrlLicenseAppFelter1
            // 
            this.ctrlLicenseAppFelter1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLicenseAppFelter1.Location = new System.Drawing.Point(13, 273);
            this.ctrlLicenseAppFelter1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLicenseAppFelter1.Name = "ctrlLicenseAppFelter1";
            this.ctrlLicenseAppFelter1.Size = new System.Drawing.Size(681, 54);
            this.ctrlLicenseAppFelter1.TabIndex = 10;
            // 
            // FrmLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 771);
            this.Controls.Add(this.btnAddLocalDrivingLicenseApp);
            this.Controls.Add(this.ctrlLicenseAppFelter1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.lblCountRecords);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmLocalDrivingLicenseApplication";
            this.Text = "Local Driving license Application";
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.MyContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCountRecords;
        private Guna.UI2.WinForms.Guna2DataGridView DGV;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private DVLD.Applications.LocalDrivingLicense.CtrlLicenseAppFelter ctrlLicenseAppFelter1;
        private Guna.UI2.WinForms.Guna2GradientButton btnAddLocalDrivingLicenseApp;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip MyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem Context_btnAddLocalDrivingLicenseApp;
        private System.Windows.Forms.ToolStripMenuItem Context_btnEditLocalDrivingLicenseApp;
        private System.Windows.Forms.ToolStripMenuItem Context_btnDeleteLocalDrivingLicenseApp;
        private System.Windows.Forms.ToolStripMenuItem Context_btnCancleApplication;
        private System.Windows.Forms.ToolStripMenuItem sechduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lssueDrivingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lssueDrivingLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Context_btnSchedualeVisionTest;
        private System.Windows.Forms.ToolStripMenuItem Context_btnSchedualeWnitteTest;
        private System.Windows.Forms.ToolStripMenuItem Context_btnSchedualeStreetTest;
    }
}