namespace DVLD_Management_System.Manage_Persons.واجهات_فرعية
{
    partial class FrmAdd_UpdatePersone
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ctrl_Add_UpdatePerson1 = new DVLD_Management_System.Manage_Persons.User_Control.Ctrl_Add_UpdatePerson();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(315, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(265, 42);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Update Persons";
            // 
            // ctrl_Add_UpdatePerson1
            // 
            this.ctrl_Add_UpdatePerson1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_Add_UpdatePerson1.IsUpdate = true;
            this.ctrl_Add_UpdatePerson1.Location = new System.Drawing.Point(13, 66);
            this.ctrl_Add_UpdatePerson1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrl_Add_UpdatePerson1.Name = "ctrl_Add_UpdatePerson1";
            this.ctrl_Add_UpdatePerson1.Size = new System.Drawing.Size(845, 513);
            this.ctrl_Add_UpdatePerson1.TabIndex = 7;
            // 
            // FrmAdd_UpdatePersone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 575);
            this.Controls.Add(this.ctrl_Add_UpdatePerson1);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmAdd_UpdatePersone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add && Update Person";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        public User_Control.Ctrl_Add_UpdatePerson ctrl_Add_UpdatePerson1;
    }
}