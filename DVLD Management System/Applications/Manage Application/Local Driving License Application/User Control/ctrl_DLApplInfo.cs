using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
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
    public partial class ctrl_DLApplInfo : UserControl
    {
        public ctrl_DLApplInfo()
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

                // مرّر القيمة لليوزر كونترول الثاني
                ctrlApplicationBasicInfo1.InfoLicenseAplication = value;

                // عند تمرير القيمة حمل البيانات
                LoadData();
            }
        }


        void LoadData()
        {
            if (infoLicenseAplication == null)
                return;
            lblLocalDrivingLicenseApplicationID.Text = infoLicenseAplication.RequestID.ToString();
            lblAppliedFor.Text = infoLicenseAplication.LicenseClass;
            // عدد الفحوصات التي نجح بها الشخص
            int PassedTests = Cls_CMDCommandLocalDrivingLicenceApp.GetPassedTestsCount(infoLicenseAplication.Person.IDPerson);
            lblPassedTests.Text = $" 3/{PassedTests}";
        }

      
         
        // عرص معلومات الرخصة
        private void llShowLicenceInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("مو شغال زبطه ");

        }
    }
}
