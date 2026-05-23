using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Persons.واجهات_فرعية;
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
    public partial class ctrlApplicationBasicInfo : UserControl
    {
   
        public ctrlApplicationBasicInfo ( )
        {
            InitializeComponent();
         }

               ClassInfoLicenseAplication infoLicenseAplication;
        // يحتوي على بينات طلب الرخصة والشخص
        public ClassInfoLicenseAplication InfoLicenseAplication
        {
            get => infoLicenseAplication;
            set
            {
                infoLicenseAplication = value;

                // عند تمرير القيمة حمل البيانات
                LoadData();
            }
        }

        void LoadData()
        {
            if (infoLicenseAplication == null) return;

            // عرض المعلومات
            lblStatus.Text = infoLicenseAplication.Status;
            lblFees.Text = infoLicenseAplication.Fees.ToString();
            lblType.Text = infoLicenseAplication.RequestType;
            lblApplicant.Text = infoLicenseAplication.Person.FullName;
            lblCreatedByUser.Text = infoLicenseAplication.User.UserName;
            lblDate.Text = infoLicenseAplication.DateRequest.ToString();
        }

        

        // زر عرض معلومات الشخص
        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowPerson showPerson = new FrmShowPerson(infoLicenseAplication.Person);
            showPerson.Show();
        }

    }
}
