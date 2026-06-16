using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Class.Class_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Local_Licenses
{
    /// <summary>
    /// واجهة اصدار رخصة لاول مرة
    /// </summary>
    public partial class FrmIssueDriverLicenseFirstTime : Form
    {

        private int _LocalDrivingLicenseApplicationID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClassInfoLicenseAplication InfoLicenseAplication;

        public FrmIssueDriverLicenseFirstTime(int LocalDrivingLicenseApplicationID , ClassInfoLicenseAplication InfoLicenseAplication_)
        {
            InitializeComponent();
            // Ensure Load event handler is attached so data is loaded when the form opens
            this.Load += new EventHandler(this.frmIssueDriverLicenseFirstTime_Load);
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            if (InfoLicenseAplication_ == null)
                return;
            InfoLicenseAplication = InfoLicenseAplication_;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {

            txtNotes.Focus();
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID_(_LocalDrivingLicenseApplicationID); 

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("لا يوجد طلب بالمعرّف=" + _LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // هل اجتاز الاختبارات ال 3
            //if (!_LocalDrivingLicenseApplication.PassedAllTests())
            //{

            //    MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //    return;
            //}

            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                MessageBox.Show("الشخص لديه رخصة بالفعل من قبل مع معرف الترخيص =" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrl_DLApplInfo1.InfoLicenseAplication = InfoLicenseAplication;



        }



        private void btnIssueLicense_Click_1(object sender, EventArgs e) // زر انشاء الرخصة
        {
            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirtTime(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }



















}

