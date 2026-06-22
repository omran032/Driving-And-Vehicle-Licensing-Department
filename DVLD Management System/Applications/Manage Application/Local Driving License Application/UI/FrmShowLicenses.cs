using Dev_Note_Assistant;
using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Applications.Manage_Application.Local_Driving_License_Application.UI
{
    public partial class FrmShowLicenses : Form
    {
        public FrmShowLicenses()
        {
            InitializeComponent();


        }

        DataTable DataTableLicenses = new DataTable();

        public string TypeLicense = "Local Licnse";
        public string DateRange = "This Month";
        public  string LicenseStatus = "New License";


        private void FrmShowLicenses_Load(object sender, EventArgs e)
        {
            CombxTypeLicense.Text = TypeLicense;
            CombxDateRange.Text = DateRange;
            CombxLicenseStatus.Text = LicenseStatus;

            LoadData();
        }



        void LoadData()
        {
            DataTableLicenses = Cls_CMDCommandLocalDrivingLicenceApp.FelterLicenses(TypeLicense , DateRange , LicenseStatus);
            DGV.DataSource = DataTableLicenses;

            DisplayCountRows();
        }

        void DisplayCountRows()
        {
            if (DataTableLicenses == null) return;

            lblCountRecords.Text = "Records : " + DataTableLicenses.Rows.Count;
        }


        void TitleMode()
        {
            if(TypeLicense == "Local Licnse")
            {
                lblTitle.Text = "Show Local Licenses";
                MyTools.LocationIn_Center_X(lblTitle, this);  // توسيط
                PicTitle.Image = Properties.Resources.Local_32;

            }
            else if (TypeLicense == "International License")
            {
                lblTitle.Text = "Show International Licenses";
                MyTools.LocationIn_Center_X(lblTitle, this);  // توسيط
                PicTitle.Image = Properties.Resources.International_32;
            }
        }

        private void CombxTypeLicense_SelectedIndexChanged(object sender, EventArgs e) // Combx Type License
        {
            TypeLicense = CombxTypeLicense.Text.Trim();

            TitleMode();

            LoadData();
        }

        private void CombxDateRange_SelectedIndexChanged(object sender, EventArgs e) // Combx Date Range
        {
            DateRange = CombxDateRange.Text.Trim();

            LoadData();

        }

        private void CombxLicenseStatus_SelectedIndexChanged(object sender, EventArgs e) //  Combx License Status
        {
            LicenseStatus = CombxLicenseStatus.Text.Trim();

            LoadData();

        }


    }
}
