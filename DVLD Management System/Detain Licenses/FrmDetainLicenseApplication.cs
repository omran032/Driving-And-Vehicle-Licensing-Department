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
    public partial class FrmDetainLicenseApplication : Form
    {
        public FrmDetainLicenseApplication()
        {
            InitializeComponent();


        }

        public Action EventRefreshData;

        ClassLicenseInfo  Licenseinfo;

        private void FrmDetainLicenseApplication_Load(object sender, EventArgs e)
        {
            //تسجيل الحدث لعرض البيانات
            ctrlDriverLicenseInfoWithFilter1.OnLicenseSelected += LoadData;

            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);

            lblCreatedByUser.Text = ClassUser.UserName;

        }

        void LoadData(ClassLicenseInfo info)
        {
            btnDetain.Enabled = true;

            if (info == null) return;

            Licenseinfo = info;

            btnDetain.Enabled = true;
            llShowLicenseHistory.Enabled = true;

        }

        
        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // عرض جميع رخص الشخص
        {
            int PersonID = Licenseinfo.PersonID;
            if (PersonID <= 0) return;

            FrmShowPersonLicenseHistory personLicenseHistory = new FrmShowPersonLicenseHistory(PersonID);
            MyTools.ShowForm(personLicenseHistory);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e) // TextBox Fees
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnDetain_Click_1(object sender, EventArgs e) // زر حفظ الحجز
        {
            if (Licenseinfo == null) return;

            string Fees = txtFineFees.Text.Trim();

            if (string.IsNullOrEmpty(Fees))
            {
                errorProvider1.SetError(txtFineFees, "حدد الغرامة أولاً");
                return;
            }
            errorProvider1.SetError(txtFineFees, null);

            string Reason = TxtReason.Text.Trim();
            if (string.IsNullOrEmpty(Reason))
            {
                errorProvider1.SetError(TxtReason, "حدد سبب الغرامة أولاً ");
                return;
            }
            errorProvider1.SetError(TxtReason, null);


            bool IsLicenseDetained = ClassDetainCMD.IsLicenseDetained(Licenseinfo.LicenseID);
            if (IsLicenseDetained)
            {
                MessageBox.Show("الرخصة محجوزة حالياً", "لا يمكن حجز الرخصة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                btnDetain.Enabled = false;
                return;
            }

            bool IsActive = ClassDetainCMD.IsLicenseActive(Licenseinfo.LicenseID);
            if (!IsActive)
            {
                MessageBox.Show("الرخصة غير فعالة لذلك لا يمكن حجزها", "لا يمكن حجز الرخصة", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                btnDetain.Enabled = false;
                return;
            }

            int.TryParse(Fees, out int Amount);

            bool Result = ClassDetainCMD.DetainLicense(Licenseinfo.LicenseID, Reason, Amount);

            if (Result)
            {
                AddLog(LogAction.HoldLicense, ClassUser.IDUser, $" حجز الرخصة رقم  {Licenseinfo.LicenseID}  ");   // Log Entry
                 MessageBox.Show("تم حجز الرخصة ووضع الغرامة عليها", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
                MessageBox.Show("حدث مشكلة اثناء حجز الرخصة", "مشكلة", MessageBoxButtons.OK, MessageBoxIcon.Error);

            EventRefreshData?.Invoke();
            btnDetain.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.gbFilters.Enabled = false;

        }

      
    }
}
