using DVLD_Management_System.Class.Class_Buisness;
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

namespace DVLD_Management_System.Local_Licenses
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }


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

        }



    }
}
