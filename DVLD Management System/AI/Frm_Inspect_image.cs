using DVLD_Management_System.AI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System
{
    public partial class Frm_Inspect_image : Form
    {
        public Frm_Inspect_image()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;

                // استدعاء دالة كشف الوجه
                bool hasFace = cls_InspectImage.HasFace(path);

                if (hasFace)
                {
                    MessageBox.Show("✔ تم التحقق من الصورة – يوجد وجه.");
                    pictureBox1.Image = Image.FromFile(path);
                }
                else
                {
                    MessageBox.Show("❌ الصورة لا تحتوي على وجه. الرجاء اختيار صورة صحيحة.");
                }
            }
        }

      

    }
}
