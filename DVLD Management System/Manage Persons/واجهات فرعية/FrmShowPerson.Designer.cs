namespace DVLD_Management_System.Manage_Persons.واجهات_فرعية
{
    partial class FrmShowPerson
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
            this.ctrl_InfoPerson1 = new DVLD_Management_System.Manage_Persons.User_Control.ctrl_InfoPerson();
            this.SuspendLayout();
            // 
            // ctrl_InfoPerson1
            // 
            this.ctrl_InfoPerson1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_InfoPerson1.Location = new System.Drawing.Point(15, 4);
            this.ctrl_InfoPerson1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrl_InfoPerson1.Name = "ctrl_InfoPerson1";
            this.ctrl_InfoPerson1.Size = new System.Drawing.Size(701, 451);
            this.ctrl_InfoPerson1.TabIndex = 0;
            // 
            // FrmShowPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 458);
            this.Controls.Add(this.ctrl_InfoPerson1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmShowPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "معلومات الشخص";
            this.ResumeLayout(false);

        }

        #endregion

        private User_Control.ctrl_InfoPerson ctrl_InfoPerson1;
    }
}