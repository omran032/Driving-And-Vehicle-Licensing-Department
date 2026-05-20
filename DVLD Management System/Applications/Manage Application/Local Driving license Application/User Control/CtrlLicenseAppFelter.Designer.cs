namespace DVLD.Applications.LocalDrivingLicense
{
    partial class CtrlLicenseAppFelter
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
            this.label1 = new System.Windows.Forms.Label();
            this.ComboxFelter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TxtFelter = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Felter";
            // 
            // ComboxFelter
            // 
            this.ComboxFelter.BackColor = System.Drawing.Color.Transparent;
            this.ComboxFelter.BorderRadius = 10;
            this.ComboxFelter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboxFelter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboxFelter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxFelter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboxFelter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboxFelter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.ComboxFelter.ItemHeight = 30;
            this.ComboxFelter.Items.AddRange(new object[] {
            "None",
            "Request ID",
            "National Number",
            "Full Name",
            "Status"});
            this.ComboxFelter.Location = new System.Drawing.Point(77, 10);
            this.ComboxFelter.Name = "ComboxFelter";
            this.ComboxFelter.Size = new System.Drawing.Size(245, 36);
            this.ComboxFelter.TabIndex = 1;
            // 
            // TxtFelter
            // 
            this.TxtFelter.BorderRadius = 10;
            this.TxtFelter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtFelter.DefaultText = "";
            this.TxtFelter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtFelter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtFelter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtFelter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtFelter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtFelter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TxtFelter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtFelter.Location = new System.Drawing.Point(355, 10);
            this.TxtFelter.Name = "TxtFelter";
            this.TxtFelter.PlaceholderText = "";
            this.TxtFelter.SelectedText = "";
            this.TxtFelter.Size = new System.Drawing.Size(286, 36);
            this.TxtFelter.TabIndex = 2;
            // 
            // CtrlFelter_LocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TxtFelter);
            this.Controls.Add(this.ComboxFelter);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CtrlFelter_LocalDrivingLicenseApplication";
            this.Size = new System.Drawing.Size(681, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox ComboxFelter;
        private Guna.UI2.WinForms.Guna2TextBox TxtFelter;
    }
}
