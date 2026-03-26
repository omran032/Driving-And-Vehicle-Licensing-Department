using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Persons.واجهات_فرعية;
using Emgu.CV.XFeatures2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Manage_Persons.User_Control
{
    public partial class ctrl_InfoPerson : UserControl
    {
        public ctrl_InfoPerson()
        {
            InitializeComponent();
           
            LoadData(FrmShowPerson.person);
        }
        public ctrl_InfoPerson(Person person_)
        {
            InitializeComponent();

            person = person_;

            LoadData(person_);
        }
        public int PersonID
        {
            get
            {
                int id;
                if (int.TryParse(lbl_IDPerson.Text, out id))
                    return id;

                return 0; // قيمة افتراضية
            }
            set
            {
                lbl_IDPerson.Text = value.ToString();
            }
        }


        public Person person { set; get; }

       public void LoadData(Person person)
        {
            if (DesignMode || person == null)
                return;
      

            lbl_IDPerson.Text      = "ID : " +person.IDPerson.ToString();
            lblFullName.Text       = person.FullName;
            lblNationalNumber.Text = person.National_Number;
            lblNumberPhone.Text    = person.NumPhone;
            if(person.Email != null) 
               lblEmail.Text   = person.Email;
            lblGender.Text     = person.Gender;
            lblBirthDate.Text  = person.Birthdate.ToString("yyyy-MM-dd");
            lblHousing.Text    = person.Housing;
            lblNationalty.Text = person.Nationality;

            // عرض الصورة
            if (person.Picture != null)
            {
                using (MemoryStream ms = new MemoryStream(person.Picture))
                {
                    Picture.Image = Image.FromStream(ms);
                    Picture.Tag = "Selected";
                }
            }
        }

    }
}
