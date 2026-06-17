using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Class.Class_Buisness;
using DVLD_Management_System.Local_Licenses;
using DVLD_Management_System.Local_Licenses.Class;
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
            int RequestID = infoLicenseAplication.RequestID;

            ClassLicenseInfo info = ClassLicenseInfo.GetLicenseInfoByRequestID(RequestID);

            if (info != null)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(info);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("الرخصة غير موجودة بعد أو لم يتم اصدارها!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }









        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;


        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }


        private int _LicenseID;
        private int _LocalDrivingLicenseApplicationID = -1;

        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            //incase there is license enable the show link.
            llShowLicenceInfo.Enabled = (_LicenseID != -1);


            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);

        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = -1;
            ctrlApplicationBasicInfo1.ResetApplicationInfo();
            lblLocalDrivingLicenseApplicationID.Text = "[????]";
            lblAppliedFor.Text = "[????]";


        }
      

    }
}
