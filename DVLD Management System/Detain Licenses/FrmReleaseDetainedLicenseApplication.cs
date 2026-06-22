using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class_Buisness;
using DVLD_Management_System.Detain_Licenses.Class;
using DVLD_Management_System.Drivers;
using DVLD_Management_System.Local_Licenses.Class;
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
using static DVLD_Management_System.Class.Class_DB.ClassAuditLogs;

namespace DVLD_Management_System.Detain_Licenses
{
    public partial class FrmReleaseDetainedLicenseApplication : Form
    {
        public FrmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }

        public Action EventRefreshData;

        ClassLicenseInfo Licenseinfo;
        ClassDetainInfo DetainInfo = new ClassDetainInfo();

        private void FrmReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
            //تسجيل الحدث لعرض البيانات
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += LoadData;

            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);

            lblCreatedByUser.Text = ClassUser.UserName;
        }

        void LoadData(ClassLicenseInfo info)
        {
            btnRelease.Enabled = true;

            if (info == null) return;

            Licenseinfo = info;

            llShowLicenseHistory.Enabled = true;

            bool IsActive = ClassDetainCMD.IsLicenseActive(Licenseinfo.LicenseID);
            if (!IsActive)
            {
                MessageBox.Show("الرخصة غير فعالة ", "لا يمكن الإكمال", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                btnRelease.Enabled = false;
                return;
            }

            bool IsLicenseDetained = ClassDetainCMD.IsLicenseDetained(Licenseinfo.LicenseID);
            if (!IsLicenseDetained)
            {
                MessageBox.Show("الرخصة غير محجوزة ", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                btnRelease.Enabled = false;
                return;
            }

            btnRelease.Enabled = true;

            LoadInfo();
        }

        void LoadInfo()
        {
            DetainInfo = ClassDetainCMD.GetActiveDetainInfo(Licenseinfo.LicenseID);

            if (DetainInfo == null) return;

            lblApplicationFees.Text = "150";
            lblFineFees.Text   = DetainInfo.Fees  + "";
            lblDetainDate.Text = DetainInfo.DeainDate.ToString();
            lblDetainID.Text   = DetainInfo.DetainID + "";
            lblLicenseID.Text  = DetainInfo.LicenseID + "";
            lblTotalFees.Text  = DetainInfo.Fees + 150 + " ";
            txtReason.Text     = DetainInfo.Reason;
        }

    

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)  // عرض جميع رخص الشخص
        {
            int PersonID = Licenseinfo.PersonID;
            if (PersonID <= 0) return;

            FrmShowPersonLicenseHistory personLicenseHistory = new FrmShowPersonLicenseHistory(PersonID);
            MyTools.ShowForm(personLicenseHistory);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRelease_Click_1(object sender, EventArgs e)// زر فك الحجز
        {
            if (DetainInfo == null) return;

            bool Result = ClassDetainCMD.ReleaseLicense(DetainInfo.LicenseID);

            if (Result)
            {
                AddLog(LogAction.ReleaseLicense, ClassUser.IDUser, "  فك حجز رخصة " + "\n + ID = " + DetainInfo.LicenseID);   // تسجيل عملية فك حجز رخصة في سجل الـ Logs
                MessageBox.Show("تم فك الحجز عن الرخصة", "تم", MessageBoxButtons.OK, MessageBoxIcon.Question);
                btnRelease.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.gbFilters.Visible = false;
                EventRefreshData?.Invoke();
                return;
            }
            else
            {
                MessageBox.Show("تم يتم فك الحجز عن الرخصة", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                btnRelease.Enabled = false;
                return;
            }
        }


    }
}
