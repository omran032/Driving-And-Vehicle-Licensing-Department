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


        private void FrmShowLicenses_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        /*
        Local Licnse
International License

        This Month
This Year

        New License
Expired License
         */




        void LoadData()
        {


            DataTableLicenses = ;
            DGV.DataSource = DataTableLicenses;

            CombxTypeLicense.Text = "Local Licnse";
            CombxDateRange.Text = "This Month";
            CombxLicenseStatus.Text = "New License";


            DisplayCountRows();
        }

        void DisplayCountRows()
        {
            lblCountRecords.Text = "Records : " + DataTableLicenses.Rows.Count;
        }

        private void CombxTypeLicense_SelectedIndexChanged(object sender, EventArgs e) // Combx Type License
        {

        }

        private void CombxDateRange_SelectedIndexChanged(object sender, EventArgs e) // Combx Date Range
        {

        }

        private void CombxLicenseStatus_SelectedIndexChanged(object sender, EventArgs e) //  Combx License Status
        {

        }

      
    }
}
