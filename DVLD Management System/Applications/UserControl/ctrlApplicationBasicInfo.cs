using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Class.Class_Buisness;
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
using static System.Net.Mime.MediaTypeNames;

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



        /// /////////////////////////////////








        private clsApplication _Application;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }


        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;

             lblStatus.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";

        }


        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.FindBaseApplication(ApplicationID);
            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
             lblStatus.Text = _Application.StatusText;
            lblType.Text = _Application.ApplicationTypeInfo.Title;
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicant.Text = _Application.ApplicantFullName;
            lblDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            if (_Application.CreatedByUserInfo == null) return;
             lblCreatedByUser.Text = _Application.CreatedByUserInfo.UserName;
        }

    }
}
