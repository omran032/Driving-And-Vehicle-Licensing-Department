using Dev_Note_Assistant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.الواجهة_الرئيسية
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void tsDdb_Users_Click(object sender, EventArgs e) //عرض المستخدمين
        {
            FormShowUsers showUsers = new FormShowUsers();  
            MyTools.ShowForm(showUsers);
        }


    }
}
