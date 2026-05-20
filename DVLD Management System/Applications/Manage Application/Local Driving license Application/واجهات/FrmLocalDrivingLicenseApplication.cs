using DVLD_Management_System.Applications.Driver_Licenses_Services.New_Driving_License.Local_License.Class;
using DVLD_Management_System.Class.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Applications
{
    public partial class FrmLocalDrivingLicenseApplication : Form
    {
        public FrmLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            LoadData();

        }

        DataTable Data ;
        void LoadData()
        {
            Data = clsLicenseClass.GetLocalLicenseRequests();
            DGV.DataSource = Data;
            lblCountRecords.Text = "Records : " + Data.Rows.Count.ToString();

            //  تشغيل الحدث بعد الفلترة
            ctrlLicenseAppFelter1.EventShowFelterUser += GetData;

        }

        /// <summary>
        /// إحضار البيانات بعد الفلترة
        /// </summary>
        void GetData(DataTable Data)
        {
            DGV.DataSource = Data;
        }


    }
}
