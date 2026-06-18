using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class_Buisness;
using DVLD_Management_System.Drivers;
using DVLD_Management_System.Local_Licenses.Class;
using DVLD_Management_System.Local_Licenses.Ctrl;
using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول;
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
     
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }

        //   نوع طلب الاستبدال
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        enApplicationType applicationType = enApplicationType.ReplaceDamagedDrivingLicense;


        ClassLicenseInfo Old_Licenseinfo; //الرخصة القديمة
        ClassLicenseInfo New_Licenseinfo; // الرخصة الجديدة


        // تحميل لفورم
        private void frmReplaceLostOrDamagedLicenseApplication_Load(object sender, EventArgs e)
        {
            llShowLicenseInfo.Enabled = false;
            btnIssueReplacement.Enabled = false;

            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            //تسجيل الحدث لعرض البيانات
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += LoadData;

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);

            lblCreatedByUser.Text = ClassUser.UserName;

            // lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
        }

       

        // يتم تنفيذه عند عمل بحث عن رخصة
        // فيتم تنفيذه في حدث البحث
        void LoadData(ClassLicenseInfo info)
        {
            if (info == null) return;

            llShowLicenseHistory.Enabled = true;
            btnIssueReplacement.Enabled = true;

            Old_Licenseinfo = info;

            if (!info.StatusRelease) // Inactive يعني هل هي 
            {
                // الرخصة غير فعالة اساساً
                MessageBox.Show("الرخصة المحددة غير فعالة", "لا يمكن تجديد الرخصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnIssueReplacement.Enabled = false;
                return;
            }

        }

        private void btnIssueReplacement_Click(object sender, EventArgs e) // زر استبدال الرخصة
        {
            DialogResult Result = MessageBox.Show("هل تريد تجديد الرخصة فعلا ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.No) return;

            int UserID = ClassUser.IDUser == 0 ? 3 : ClassUser.IDUser;

            bool isLost = applicationType == enApplicationType.ReplaceLostDrivingLicense;

              int newRequestID;
              int applicationFees;
              int licenseFees;

            // تقوم بارجاع معلومات   الرخصة الجديدة
            // تنفيذ امر تجديد الرخصة
            New_Licenseinfo = ClassLicenseInfo.CreateReplacementLicense(Old_Licenseinfo , UserID , isLost, out newRequestID , out applicationFees , out licenseFees);

            if (New_Licenseinfo == null) return;

            // عرض معلومات الرخصة الجديدة
            LoadInfoNewLicense(newRequestID, applicationFees, licenseFees);

            llShowLicenseInfo.Enabled = true;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false; //ايقاف البحث
            btnIssueReplacement.Enabled = false;

            MessageBox.Show("معرف الرخصة الجديدة هو " + New_Licenseinfo.LicenseID, "تم انشاء الرخصة و استبدالها", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        /// <summary>
        /// تحميل بيانات الرخصة المجددة
        /// </summary>
        void LoadInfoNewLicense(int NewRequestID_, int ApplicationFees_, int LicenseFees_)
        {
            lblApplicationID.Text = NewRequestID_ + " ";
            lblRreplacedLicenseID.Text = New_Licenseinfo.LicenseID + " ";

            lblApplicationFees.Text = ApplicationFees_ + " ";
            lblOldLicenseID.Text = Old_Licenseinfo.LicenseID + " ";

            ctrlDriverLicenseInfoWithFilter1.ctrlDriverLicenseInfo1.lblIsActive.Text = "No";

        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e) //اختيار بدل تالف
        {
            applicationType = enApplicationType.ReplaceDamagedDrivingLicense;
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e) // اختيار بدل فاقد
        {
            applicationType = enApplicationType.ReplaceLostDrivingLicense;
        }

        private void btnClose_Click(object sender, EventArgs e) // اغلاق
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // عرض معلومات الرخصة الجديدة
        {
            if (New_Licenseinfo != null)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(New_Licenseinfo);
                frm.ShowDialog();
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // عرض سجل الرخص
        {
            int PersonID = Old_Licenseinfo.PersonID;
            if (PersonID <= 0) return;

            FrmShowPersonLicenseHistory personLicenseHistory = new FrmShowPersonLicenseHistory(PersonID);
            MyTools.ShowForm(personLicenseHistory);
        }
    }
}
