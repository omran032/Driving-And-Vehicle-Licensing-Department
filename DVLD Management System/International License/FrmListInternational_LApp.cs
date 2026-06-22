using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Drivers;
using DVLD_Management_System.International_License.Class;
using DVLD_Management_System.Local_Licenses.Class;
using DVLD_Management_System.Manage_Persons.Class;
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
using static DVLD_Management_System.International_License.Class.Cls_InternationalLicenseCMD;

namespace DVLD_Management_System.International_License
{
    public partial class FrmListInternational_LApp : Form
    {
        public FrmListInternational_LApp()
        {
            InitializeComponent();

        }

        DataTable DataTableInfo = new DataTable();
        Cls_InternationalLicenseCMD.enInterLicenseFilter TypeFilter = enInterLicenseFilter.All;


        private void FrmListInternational_LApp_Load(object sender, EventArgs e)
        {
            
            CombxFilterBy.Text = "All";
            LoadData();
        }

 

        void LoadData()
        {
            DataTableInfo = Cls_InternationalLicenseCMD.GetInternationalLicensesWithFilter(TypeFilter);
            DGV.DataSource = DataTableInfo;

            CalculateCountRecords();
        }

        // حساب عدد الصفوف
        void CalculateCountRecords()
        {
            if (DataTableInfo == null) return;

            lblInternationalLicensesRecords.Text = DataTableInfo.Rows.Count.ToString();
        }


        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e) // Combox Type Filter
        {
            string change = CombxFilterBy.Text.Trim();

            txtFilterValue.Text = null;
            CombxIsReleased.Text = null;

            CombxIsReleased.Visible = false;
            txtFilterValue.Visible = false;

            switch (change)
            {
                case "All":
                    TypeFilter = enInterLicenseFilter.All;
                    LoadData();
                    break;

                case "International License ID":
                    TypeFilter = enInterLicenseFilter.InternationalLicenseID;
                    txtFilterValue.Visible = true;

                    break;

                case "Application ID":
                    TypeFilter = enInterLicenseFilter.ApplicationID;
                    txtFilterValue.Visible = true;

                    break;

                case "Driver ID":
                    TypeFilter = enInterLicenseFilter.DriverID;
                    txtFilterValue.Visible = true;

                    break;

                case "Local License ID":
                    TypeFilter = enInterLicenseFilter.LocalLicenseID;
                    txtFilterValue.Visible = true;

                    break;

                case "Is Active":
                    TypeFilter = enInterLicenseFilter.IsActive;
                    CombxIsReleased.Visible = true;

                    break;
            }
        }
         
 


        private void CombxIsReleased_SelectedIndexChanged(object sender, EventArgs e) // Combox Filter Is Active
        {
            TypeFilter = enInterLicenseFilter.IsActive;
            if (TypeFilter != enInterLicenseFilter.IsActive) return;

            string chnage = CombxIsReleased.Text.Trim();

            switch(chnage)
            {
                case "All":
                    DataTableInfo = Cls_InternationalLicenseCMD.GetInternationalLicensesWithFilter(TypeFilter, "", enIsActiveFilter.All);
                    DGV.DataSource = DataTableInfo;
                    CalculateCountRecords();
                    break;

                case "Yes":
                    DataTableInfo = Cls_InternationalLicenseCMD.GetInternationalLicensesWithFilter(TypeFilter, "", enIsActiveFilter.Yes);
                    DGV.DataSource = DataTableInfo;
                    CalculateCountRecords();
                    break;

                case "No":
                    DataTableInfo = Cls_InternationalLicenseCMD.GetInternationalLicensesWithFilter(TypeFilter, "", enIsActiveFilter.No);
                    DGV.DataSource = DataTableInfo;
                    CalculateCountRecords();
                    break;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtFilterValue.Text.Trim(), out int ID);

            DataTableInfo = Cls_InternationalLicenseCMD.GetInternationalLicensesWithFilter( TypeFilter, ID.ToString() );
            DGV.DataSource = DataTableInfo;
            CalculateCountRecords();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e) // TextBox Search
        {
            // عدم السماح بادخال احرف
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnNewApplication_Click(object sender, EventArgs e) // عرض واجهة إضافة رخصة دولية
        {
            FrmNewInternationalLicenseApplication newInternationalLicenseApplication = new FrmNewInternationalLicenseApplication();
            newInternationalLicenseApplication.EventRefreshData += LoadData; // Event Refresh
            MyTools.ShowForm(newInternationalLicenseApplication);
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e) // عرض معلومات الشخص
        {
            ClassLicenseInfo licenseInfo = new ClassLicenseInfo();
            licenseInfo.DriverID = (int)DGV.CurrentRow.Cells[3].Value;

            if (licenseInfo.PersonID <= 0) return;

            Person PersonInfo = Cls_CMD_PresonsDB.GetPersonByID(licenseInfo.PersonID);

            //واجهة معلومات الشخص
            FrmShowPerson showPerson = new FrmShowPerson(PersonInfo);
            showPerson.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e) // عرض معلومات الرخصة الدولية
        {
            int DriverID = (int)DGV.CurrentRow.Cells[3].Value;

            FrmShowInfo_InternationL info_InternationL = new FrmShowInfo_InternationL(Cls_InternationalLicenseCMD.enInterLicenseSearchBy.DriverID, DriverID);
            MyTools.ShowForm(info_InternationL);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e) // واجهة عرض الرخص التي يملكها الشخص
        {
            ClassLicenseInfo licenseInfo = new ClassLicenseInfo();
            licenseInfo.DriverID = (int)DGV.CurrentRow.Cells[3].Value;

            if (licenseInfo.PersonID <= 0) return;

            FrmShowPersonLicenseHistory personLicenseHistory = new FrmShowPersonLicenseHistory(licenseInfo.PersonID);
            MyTools.ShowForm(personLicenseHistory);
        }
    }
}
