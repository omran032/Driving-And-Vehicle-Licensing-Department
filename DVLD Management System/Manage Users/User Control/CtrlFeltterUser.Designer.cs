namespace DVLD_Management_System.Manage_Users.User_Control
{
    partial class CtrlFeltterUser
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
            this.TxtFelter = new Guna.UI2.WinForms.Guna2TextBox();
            this.ComboFelter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
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
            this.TxtFelter.Location = new System.Drawing.Point(237, 4);
            this.TxtFelter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtFelter.Name = "TxtFelter";
            this.TxtFelter.PlaceholderText = "";
            this.TxtFelter.SelectedText = "";
            this.TxtFelter.Size = new System.Drawing.Size(239, 36);
            this.TxtFelter.TabIndex = 24;
            this.TxtFelter.TextChanged += new System.EventHandler(this.TxtFelter_TextChanged);
            this.TxtFelter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFelter_KeyPress);
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
            "الكل",
            "البحث برقم الشخص",
            "البحث عن اسم مستخدم",
            "الحساب الفعال",
            "الحساب الغير فعال"});
            this.ComboFelter.Location = new System.Drawing.Point(3, 6);
            this.ComboFelter.Name = "ComboFelter";
            this.ComboFelter.Size = new System.Drawing.Size(227, 36);
            this.ComboFelter.TabIndex = 23;
            this.ComboFelter.SelectedIndexChanged += new System.EventHandler(this.ComboFelter_SelectedIndexChanged);
            // 
            // CtrlFeltterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TxtFelter);
            this.Controls.Add(this.ComboFelter);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CtrlFeltterUser";
            this.Size = new System.Drawing.Size(485, 49);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox TxtFelter;
        private Guna.UI2.WinForms.Guna2ComboBox ComboFelter;
    }
}
