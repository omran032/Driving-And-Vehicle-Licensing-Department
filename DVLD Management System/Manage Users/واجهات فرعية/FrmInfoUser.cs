using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Persons.User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Manage_Users.User_Control
{
    public partial class FrmInfoUser : Form
    {
        public FrmInfoUser(Users user, Person person)
        {
            InitializeComponent();

            // Person عرض بيانات  
            ctrl_InfoPerson1.LoadData(person);
            // User عرض بيانات  
            ctrlInfoUser1.DesplaydInfoUser(user);
          
        }

        private void btnClose_Click(object sender, EventArgs e) // زر الاغلاق
        {
            this.Close();
        }

     
    }
}
