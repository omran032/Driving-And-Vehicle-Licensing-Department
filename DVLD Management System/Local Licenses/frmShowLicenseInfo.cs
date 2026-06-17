using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Local_Licenses.Class;
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
    public partial class frmShowLicenseInfo : Form
    {
        private int _LicenseID;
        ClassInfoLicenseAplication infoLicenseAplication;
        public frmShowLicenseInfo(ClassInfoLicenseAplication infoLicenseAplication_)
        {
            InitializeComponent();
            

            infoLicenseAplication = infoLicenseAplication_;
        }

        ClassLicenseInfo info;
        public frmShowLicenseInfo(ClassLicenseInfo info_)
        {
            InitializeComponent();

            
            info = info_;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void frmShowLicenseInfo_Load_1(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadInfo(info);

        }
    }
}
