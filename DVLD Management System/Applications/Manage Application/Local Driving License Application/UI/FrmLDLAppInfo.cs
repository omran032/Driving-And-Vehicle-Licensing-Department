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

namespace DVLD_Management_System
{
    public partial class FrmLDLAppInfo : Form
    {
        public FrmLDLAppInfo(ClassInfoLicenseAplication InfoLicenseAplication)
        {
            InitializeComponent();
            if (InfoLicenseAplication == null)
                return;
            ctrl_DLApplInfo1.InfoLicenseAplication = InfoLicenseAplication;
        }




    }
}
