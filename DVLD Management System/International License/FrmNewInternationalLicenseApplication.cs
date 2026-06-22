using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class_Buisness;
using DVLD_Management_System.Drivers;
using DVLD_Management_System.International_License.Class;
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

namespace DVLD_Management_System.International_License
{
    public partial class FrmNewInternationalLicenseApplication : Form
    {
        public FrmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        public Action EventRefreshData;

        ClassLicenseInfo Licenseinfo;

        private void FrmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            llShowLicenseInfo.Enabled = false;

            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            //تسجيل الحدث لعرض البيانات
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += CheckingLicense;

            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = lblApplicationDate.Text;
            lblFees.Text = "5000";

            lblCreatedByUser.Text = ClassUser.UserName;
        }

        void CheckingLicense(ClassLicenseInfo info)
        {
            if (info == null) return;

            Licenseinfo = info;

            llShowLicenseHistory.Enabled = true;

            if (!info.StatusRelease) // Inactive يعني هل هي 
            {
                // الرخصة غير فعالة اساساً
                MessageBox.Show("الرخصة المحددة غير فعالة", "لا يمكن اصدار رخصة دولية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnIssueLicense.Enabled = false;
                return;
            }


            if( info.ClassName != "Class 3 - Ordinary Driving License")
            {
                // لانها مو من الفئة المطلوبة
                MessageBox.Show("يجب ان تكون فئة الرخصة من نوع \n Class 3 - Ordinary Driving License \n رخصة قيادة عادية حصراً", "لا يمكن اصدار رخصة دولية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnIssueLicense.Enabled = false;
                return;
            }

            if(Cls_InternationalLicenseCMD.IsInternationalLicenseExists(info.LicenseID))
            {
                MessageBox.Show("الرخصة المحدد هي موجودة كرخصة دولية", "لا يمكن اصدار رخصة دولية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnIssueLicense.Enabled = false;
                return;
            }
           
            btnIssueLicense.Enabled = true;

        }


    

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // عرض معلومات الرخصة الدولية
        {
            if (Licenseinfo == null) return;

            int LicenseID = Licenseinfo.LicenseID;
            FrmShowInfo_InternationL info_InternationL = new FrmShowInfo_InternationL(Cls_InternationalLicenseCMD.enInterLicenseSearchBy.LicenseID ,  LicenseID);
            MyTools.ShowForm(info_InternationL);
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // عرض الرخص التي يحملها الشخص
        {
            int PersonID = Licenseinfo.PersonID;

            if (PersonID <= 0) return;

            FrmShowPersonLicenseHistory personLicenseHistory = new FrmShowPersonLicenseHistory(PersonID);
            MyTools.ShowForm(personLicenseHistory);
        }


        private void btnIssueLicense_Click(object sender, EventArgs e) // زر انشاء الرخصة الدولية
        {
            if (Licenseinfo == null) return;

            int UserID = ClassUser.IDUser == 0 ? 3 : ClassUser.IDUser;

            int Result_intLicenseID =  Cls_InternationalLicenseCMD.CreateInternationalLicense(Licenseinfo.LicenseID, Licenseinfo.PersonID, UserID);

            if(Result_intLicenseID > 0)
            {
                AddLog(LogAction.AddInternationalLicense, ClassUser.IDUser, $" إضافة رخصة دولية للرخصة المحلية رقم {Licenseinfo.LicenseID}");   // تسجيل عملية إضافة رخصة دولية في سجل الـ Logs
                MessageBox.Show($"تم إضافة رخصة دولية جديد \n ID = {Result_intLicenseID} ", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssueLicense.Enabled = false;
                llShowLicenseInfo.Enabled = true;
                return;
            }
            else
            {
                MessageBox.Show($"لم تنجح عملية الإضافة ", "لم يتم انشاء الرخصة الدولية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnIssueLicense.Enabled = false;
                return;
            }
        }

  





    }
}
