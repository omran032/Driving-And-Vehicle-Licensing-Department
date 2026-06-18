using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Persons.Class;
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

namespace DVLD_Management_System.Drivers
{
    public partial class FrmShowPersonLicenseHistory : Form
    {
        public FrmShowPersonLicenseHistory(int PersonID_)
        {
            InitializeComponent();

            PersonID = PersonID_;


        }

        int PersonID { get; set; }

        private void FrmShowPersonLicenseHistory_Load(object sender, EventArgs e) // تحميل الفورم
        {
            Loaddata();
        }

        DataTable dataTablePerson = new DataTable();
        Person person = new Person();

        /// <summary>
        /// تحميل البيانات في العناصر
        /// </summary>
        void Loaddata()
        {
            ctrlFelterPersons1.Enabled = false;
            ctrlFelterPersons1.ComboFelter.Text = "البحث برقم الشخص";
            ctrlFelterPersons1.TxtFelter.Text = PersonID.ToString();

            dataTablePerson = Cls_CMD_PresonsDB.SearchPerson_ID(PersonID.ToString(), "ID");
            SavaInfoPerson();
            ctrl_InfoPerson1.LoadData(person);

            ctrlDriverLicenses1.LoadLicenses(PersonID);

        }


        /// <summary>
        /// Class Person حفظ البيانات في 
        /// </summary>
        void SavaInfoPerson()
        {
            if (dataTablePerson.Rows.Count == 0)
            {
                person.ValueNull(); //تفريغ القيم
                return;
            }

            DataRow row = dataTablePerson.Rows[0];

            person.IDPerson = Convert.ToInt32(row["ID"]);
            person.FullName = row["الاسم الكامل"].ToString();
            person.National_Number = row["الرقم الوطني"].ToString();
            person.Housing = row["السكن"].ToString();
            person.NumPhone = row["رقم الهاتف"].ToString();
            person.Email = row["الايميل"].ToString();
            person.Nationality = row["الجنسية"].ToString();
            person.Gender = row["الجنس"].ToString();
            person.Birthdate = Convert.ToDateTime(row["الميلاد"]);
            person.Picture = row["الصورة"] as byte[];
        }

    }
}
