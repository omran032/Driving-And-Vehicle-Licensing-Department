using DVLD_Management_System.Class.Class_Buisness;
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
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {
        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        ClassLicenseInfo Old_Licenseinfo; //الرخصة القديمة
        ClassLicenseInfo New_Licenseinfo; // الرخصة الجديدة


        // تحميل لفورم
        private void ctrlDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {
            llShowLicenseInfo.Enabled = false; 

            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            //تسجيل الحدث لعرض البيانات
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += LoadData;

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            
            lblExpirationDate.Text = "???";
            lblCreatedByUser.Text = ClassUser.UserName;

           // lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();

        }

        // يتم تنفيذه عند عمل بحث عن رخصة
        // فيتم تنفيذه في حدث البحث
      void LoadData(ClassLicenseInfo info )
        {
            btnRenewLicense.Enabled = true;

            if (info == null) return;

            Old_Licenseinfo = info;
            llShowLicenseHistory.Enabled = true;

            if (info.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show("الرخصة ما زالت سارية ولم تنتهي بعد", "لا يمكن تجديد الرخصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnRenewLicense.Enabled = false;
                return;
            }

            if ( ! info.StatusRelease ) // Inactive يعني هل هي 
            {
                // الرخصة غير فعالة اساساً
                MessageBox.Show("الرخصة المحددة غير فعالة", "لا يمكن تجديد الرخصة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnRenewLicense.Enabled = false;
                return;
            }

        }




        private void btnRenewLicense_Click(object sender, EventArgs e) // زر تجديد الرخصة
        {
            DialogResult Result = MessageBox.Show("هل تريد تجديد الرخصة فعلا ؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.No) return;

            int UserID = ClassUser.IDUser == 0 ? 3 : ClassUser.IDUser;

            int NewRequestID;   // معرف الطلب
            int ApplicationFees;
            int LicenseFees;

            // تقوم بارجاع معلومات   الرخصة الجديدة
            // تنفيذ امر تجديد الرخصة
            New_Licenseinfo = ClassLicenseInfo.RenewLicense(Old_Licenseinfo, UserID, out NewRequestID, out ApplicationFees, out LicenseFees );

            if (New_Licenseinfo == null) return;

            // عرض معلومات الرخصة الجديدة
            LoadInfoNewLicense(NewRequestID , ApplicationFees , LicenseFees);

            llShowLicenseInfo.Enabled = true;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false; //ايقاف البحث
            btnRenewLicense.Enabled = false;

            MessageBox.Show("معرف الرخصة الجديدة هو " + New_Licenseinfo.LicenseID, "تم انشاء الرخصة", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// تحميل بيانات الرخصة المجددة
        /// </summary>
        void LoadInfoNewLicense(  int NewRequestID_ , int ApplicationFees_ , int LicenseFees_)
        {
            //تاريخ انتهاء الصلاحية
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(10)); // +10 Years
            lblApplicationID.Text = NewRequestID_ + " ";
            lblRenewedLicenseID.Text = New_Licenseinfo.LicenseID + " ";
            lblLicenseFees.Text = LicenseFees_ + " ";
            lblApplicationFees.Text = ApplicationFees_ + " ";
            lblTotalFees.Text = (LicenseFees_ + ApplicationFees_) + " ";
            lblOldLicenseID.Text = Old_Licenseinfo.LicenseID + " ";

            ctrlDriverLicenseInfoWithFilter1.ctrlDriverLicenseInfo1.lblIsActive.Text = "No";

        }


        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // عرض معلومات الرخصة الجديدة
        {
            if (New_Licenseinfo != null)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(New_Licenseinfo);
                frm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
