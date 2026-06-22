using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Detain_Licenses.Class;
using DVLD_Management_System.Drivers;
using DVLD_Management_System.Local_Licenses;
using DVLD_Management_System.Manage_Persons.واجهات_فرعية;
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
using static DVLD_Management_System.Detain_Licenses.Class.ClassDetainCMD;

namespace DVLD_Management_System.Detain_Licenses
{
    public partial class FrmListDetainedLicenses : Form
    {
        public FrmListDetainedLicenses()
        {
            InitializeComponent();


        }


        DataTable DataInfoTable = new DataTable();
        enDetainFilter enDetainFilter_ = enDetainFilter.None;
        private void FrmListDetainedLicenses_Load(object sender, EventArgs e) // تحميل الفورم
        {
            LoadData();
        }


        void LoadData()
        {
            CombxFilterBy.Text = "None";

            DataInfoTable = ClassDetainCMD.GetDetainedLicensesWithFilter(enDetainFilter_);
            LoadDataFromDGV(DataInfoTable);
        }

        void LoadDataFromDGV(DataTable DT)
        {
            DGV.DataSource = DT;
            showCountRecords();
        }

        void showCountRecords()
        {
            if (DataInfoTable == null) return;
                    
            lblTotalRecords.Text = DataInfoTable.Rows.Count + " ";
        }




        string Choice  = "None"; 
        private void CombxFilterBy_SelectedIndexChanged(object sender, EventArgs e) // Combox Felter
        {
            Choice = CombxFilterBy.Text.Trim();

            CombxIsReleased.Visible = false;
            txtFilterValue.Visible = false;

            switch (Choice)
            {
                case "None":
                    enDetainFilter_ = enDetainFilter.None;
                    LoadData();
                    break;

                case "Detain ID":
                    enDetainFilter_ = enDetainFilter.DetainID;
                    txtFilterValue.Visible = true;

                    break;

                case "Is Released":
                    enDetainFilter_ = enDetainFilter.IsReleased;
                    CombxIsReleased.Visible = true;

                    break;

                case "National No":
                    enDetainFilter_ = enDetainFilter.NationalNo;
                    txtFilterValue.Visible = true;

                    break;

                case "Full Name":
                    enDetainFilter_ = enDetainFilter.FullName;
                    txtFilterValue.Visible = true;

                    break;

                case "Release Application ID":
                    enDetainFilter_ = enDetainFilter.ReleaseApplicationID;
                    txtFilterValue.Visible = true;

                    break;

            }

        }

       // اختيار عرض الرخص المحجوزة أو الغير محجوزة
        private void CombxIsReleased_SelectedIndexChanged(object sender, EventArgs e) // Combox Options
        {
            if (enDetainFilter_ != enDetainFilter.IsReleased) return;
            string ChoiceInCombx = CombxIsReleased.Text.Trim();

            if(ChoiceInCombx == "All")
            {
                DataInfoTable = ClassDetainCMD.GetDetainedLicensesWithFilter(enDetainFilter_, "", enIsReleasedFilter.All);
                LoadDataFromDGV(DataInfoTable);
            }
            else if (ChoiceInCombx == "Yes")
            {
                DataInfoTable = ClassDetainCMD.GetDetainedLicensesWithFilter(enDetainFilter_, "", enIsReleasedFilter.Released);
                LoadDataFromDGV(DataInfoTable);
            }
            else if (ChoiceInCombx == "No")
            {
                DataInfoTable = ClassDetainCMD.GetDetainedLicensesWithFilter(enDetainFilter_, "", enIsReleasedFilter.NotReleased);
                LoadDataFromDGV(DataInfoTable);
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e) // TextBox
        {
            //we allow number incase person id or user id is selected.
            if (Choice == "Detain ID" || Choice == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string TextSearch = txtFilterValue.Text.Trim();

            DataInfoTable = ClassDetainCMD.GetDetainedLicensesWithFilter(enDetainFilter_, TextSearch);
            LoadDataFromDGV(DataInfoTable);
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e) // زر عرض واجهة فك الحجز
        {
            FrmReleaseDetainedLicenseApplication frmReleaseDetained = new FrmReleaseDetainedLicenseApplication();
            frmReleaseDetained.EventRefreshData += LoadData;
            MyTools.ShowForm(frmReleaseDetained);
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)  // زر عرض واجهة حجز الرخص
        {
            FrmDetainLicenseApplication detainLicenseApplication = new FrmDetainLicenseApplication();
            detainLicenseApplication.EventRefreshData += LoadData;
            MyTools.ShowForm(detainLicenseApplication);
        }

       


        private void cmsApplications_Opening(object sender, CancelEventArgs e)    // حدث عند فتح  القائمة 
        {
            IsRelease();
        }

        // فحص هل الرخصة محجوزة ام لا ؟
        void IsRelease()
        {
            bool IsRelease = (bool)DGV.CurrentRow.Cells[3].Value;

            if(IsRelease)
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            else  
                releaseDetainedLicenseToolStripMenuItem.Enabled = true;
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e) // زر فك حجز الرخصة
        {
            DialogResult Result = MessageBox.Show("هل انت متاكد من فك حجز الرخصة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.No) return;

            int LicenseID = (int)DGV.CurrentRow.Cells[1].Value;
            if (LicenseID != 0)
            {
             bool IsSecsesfule =    ClassDetainCMD.ReleaseLicense(LicenseID);
                if(IsSecsesfule)
                {
                    AddLog(LogAction.ReleaseLicense, ClassUser.IDUser, "  فك حجز رخصة " + "\n + ID = " +LicenseID);   // تسجيل عملية فك حجز رخصة في سجل الـ Logs
                    MessageBox.Show("تم فك الحجز عن الرخصة", "تم", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    LoadData();
                }
                else
                    MessageBox.Show("تم يتم فك الحجز عن الرخصة", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e) // عرض معلومات الشخص
        {
            int PersonID = (int)DGV.CurrentRow.Cells[8].Value;

            FrmShowPerson showPerson = new FrmShowPerson(PersonID);
            showPerson.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e) // عرض معلومات الرخصة
        {
            int LicenseID = (int)DGV.CurrentRow.Cells[1].Value;
            if (LicenseID != 0)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e) // واجهة عرض الرخص التي يملكها الشخص
        {
            int PersonID = (int)DGV.CurrentRow.Cells[8].Value;
            if (PersonID <= 0) return;

            FrmShowPersonLicenseHistory personLicenseHistory = new FrmShowPersonLicenseHistory(PersonID);
            MyTools.ShowForm(personLicenseHistory);
        }
        
        private void btnClose_Click_1(object sender, EventArgs e)// اغلاق الواجهة
        {
            this.Close();
        }


    }
}
