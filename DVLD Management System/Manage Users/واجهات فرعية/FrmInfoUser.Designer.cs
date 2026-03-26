namespace DVLD_Management_System.Manage_Users.User_Control
{
    partial class FrmInfoUser
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrl_InfoPerson1 = new DVLD_Management_System.Manage_Persons.User_Control.ctrl_InfoPerson();
            this.ctrlInfoUser1 = new DVLD_Management_System.Manage_Users.User_Control.CtrlInfoUser();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrl_InfoPerson1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 459);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Person Information";
            // 
            // ctrl_InfoPerson1
            // 
            this.ctrl_InfoPerson1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrl_InfoPerson1.Location = new System.Drawing.Point(11, 16);
            this.ctrl_InfoPerson1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ctrl_InfoPerson1.Name = "ctrl_InfoPerson1";
            this.ctrl_InfoPerson1.person = null;
            this.ctrl_InfoPerson1.Size = new System.Drawing.Size(692, 435);
            this.ctrl_InfoPerson1.TabIndex = 0;
            // 
            // ctrlInfoUser1
            // 
            this.ctrlInfoUser1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlInfoUser1.Location = new System.Drawing.Point(19, 476);
            this.ctrlInfoUser1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlInfoUser1.Name = "ctrlInfoUser1";
            this.ctrlInfoUser1.Size = new System.Drawing.Size(736, 135);
            this.ctrlInfoUser1.TabIndex = 4;
            // 
            // FrmInfoUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 631);
            this.Controls.Add(this.ctrlInfoUser1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FrmInfoUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInfoUser";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Manage_Persons.User_Control.ctrl_InfoPerson ctrl_InfoPerson1;
        private CtrlInfoUser ctrlInfoUser1;
    }
}