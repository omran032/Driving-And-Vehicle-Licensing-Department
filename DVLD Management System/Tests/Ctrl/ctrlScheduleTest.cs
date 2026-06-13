using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Properties;
using DVLD_Management_System.Tests.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Tests.Ctrl
{
    public partial class ctrlScheduleTest : UserControl
    {
        public ctrlScheduleTest( )
        {
            InitializeComponent();
        }


        private ClassInfoLicenseAplication.enTestType _TestTypeID = ClassInfoLicenseAplication.enTestType.VisionTest;

        public ClassInfoLicenseAplication.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case ClassInfoLicenseAplication.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Eye;
                            break;
                        }

                    case ClassInfoLicenseAplication.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.exam;
                            break;
                        }
                    case ClassInfoLicenseAplication.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.car;
                            break;


                        }
                }
            }
        }





        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;



        private int _LocalDrivingLicenseApplicationID = -1;
        private int _TestAppointmentID = -1;
        private clsLDLApp _LocalDrivingLicenseApplication;

        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            // تحديد وضع الشاشة  >>> إضافة جديدة أو تعديل 
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            //تحميل بيانات الطلب الأساسي
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;
            _LocalDrivingLicenseApplication = clsLDLApp.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);



        }

        // زر الحفظ
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
