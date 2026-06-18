using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Drivers.Class;
using DVLD_Management_System.Local_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Drivers.Ctrl
{
    public partial class CtrlDriverLicenses : UserControl
    {
        public CtrlDriverLicenses()
        {
            InitializeComponent();
        }


        public int PersonID { get; set; }

        DataTable DataLocalLicenses;
        DataTable DataNationalLicenses;

        public void LoadLicenses(int PersonID_)
        {
            PersonID = PersonID_;

            // الرخص المحلية
            DataLocalLicenses = ClassDriver_DB.GetAllLocalLicensesForPerson(PersonID_);
            dgvLocalLicensesHistory.DataSource = DataLocalLicenses;
            lblLocalLicensesRecords.Text = DataLocalLicenses.Rows.Count + " ";

            // الرخص الدولية
            DataNationalLicenses = ClassDriver_DB.GetAllInternationalLicensesForPerson(PersonID_);
            dgvInternationalLicensesHistory.DataSource = DataNationalLicenses;
            lblInternationalLicensesRecords.Text = DataNationalLicenses.Rows.Count + " ";


        }

        private void ToolStrip_ShowLocalLicenseInfo_Click(object sender, EventArgs e) // عرض معلومات الرخصة المحلية
        {
            int LicenseID = (int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value;
            if (LicenseID <= 0) return;

            frmShowLicenseInfo frmShowLicense = new frmShowLicenseInfo(LicenseID);
            frmShowLicense.ShowDialog();

        }

        private void ToolStrip_InternationalLicense_Click(object sender, EventArgs e) // عرض معلومات الرخصة الدولية
        {
            int LicenseID = (int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value;
            if (LicenseID <= 0) return;




        }



    }
}
