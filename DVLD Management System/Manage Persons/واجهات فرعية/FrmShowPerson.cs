using DVLD_Management_System.Class.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Manage_Persons.واجهات_فرعية
{
    public partial class FrmShowPerson : Form
    {
        public FrmShowPerson(Person person_)
        {
            person = person_;
            InitializeComponent();
        }
        public static Person person;
    }
}
