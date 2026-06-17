namespace DVLD_Management_System.Local_Licenses.Ctrl
{
    partial class ctrlDriverLicenseInfoWithFilter
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
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.txtLicenseID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfo1 = new DVLD_Management_System.Local_Licenses.Ctrl.CtrlDriverLicenseInfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilters
            // 
            this.gbFilters.BackColor = System.Drawing.Color.Transparent;
            this.gbFilters.Controls.Add(this.btnFind);
            this.gbFilters.Controls.Add(this.txtLicenseID);
            this.gbFilters.Controls.Add(this.label1);
            this.gbFilters.Location = new System.Drawing.Point(33, 25);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(436, 67);
            this.gbFilters.TabIndex = 18;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filter";
            // 
            // btnFind
            // 
            this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFind.BorderRadius = 15;
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFind.FillColor = System.Drawing.Color.SeaShell;
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Image = global::DVLD_Management_System.Properties.Resources.SearchDrivigLicense;
            this.btnFind.ImageSize = new System.Drawing.Size(50, 50);
            this.btnFind.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFind.Location = new System.Drawing.Point(374, 18);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(56, 43);
            this.btnFind.TabIndex = 21;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click_1);
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.BorderRadius = 15;
            this.txtLicenseID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLicenseID.DefaultText = "";
            this.txtLicenseID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLicenseID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLicenseID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLicenseID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLicenseID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicenseID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLicenseID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicenseID.Location = new System.Drawing.Point(130, 21);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.PlaceholderText = "";
            this.txtLicenseID.SelectedText = "";
            this.txtLicenseID.Size = new System.Drawing.Size(212, 36);
            this.txtLicenseID.TabIndex = 20;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
            this.txtLicenseID.Validating += new System.ComponentModel.CancelEventHandler(this.guna2TextBox1_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "LicenseID:";
            this.toolTip1.SetToolTip(this.label1, "الرخصة ID");
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDriverLicenseInfo1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(19, 91);
            this.ctrlDriverLicenseInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(927, 338);
            this.ctrlDriverLicenseInfo1.TabIndex = 19;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlDriverLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Controls.Add(this.gbFilters);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlDriverLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(958, 429);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnFind;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        public Guna.UI2.WinForms.Guna2TextBox txtLicenseID;
        public System.Windows.Forms.GroupBox gbFilters;
        public CtrlDriverLicenseInfo ctrlDriverLicenseInfo1;
    }
}
