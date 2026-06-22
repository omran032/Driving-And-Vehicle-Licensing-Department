using DVLD_Management_System.International_License.Class;
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
    public partial class FrmShowInfo_InternationL : Form
    {
        public FrmShowInfo_InternationL(enInterLicenseSearchBy SearchBy_ , int ValueID_)
        {
            InitializeComponent();

            SearchBy = SearchBy_;
            ValueID = ValueID_;
        }

        public FrmShowInfo_InternationL(Cls_InternationalLicenseInfo InfoInternationLicense_) // الباني الثاني
        {
            InitializeComponent();

            InfoInternationLicense = InfoInternationLicense_;
        }

        Cls_InternationalLicenseInfo InfoInternationLicense;
        int ValueID;
        enInterLicenseSearchBy SearchBy;

        private void FrmShowInfo_InternationL_Load(object sender, EventArgs e) // تحميل الفورم
        {
            if(SearchBy == enInterLicenseSearchBy.LicenseID)
            {
                ctrlDriverInternationalLicenseInfo1.LoadDataByLicenseID(ValueID);
            }
            else if (SearchBy == enInterLicenseSearchBy.DriverID)
            {
                ctrlDriverInternationalLicenseInfo1.LoadDataByDriverID(ValueID);
            }
            else // هون في حال ستدعى الباني الثاني
            {
                if (InfoInternationLicense == null) return;
                ctrlDriverInternationalLicenseInfo1.LoadDataByObject(InfoInternationLicense);
            }


        }

        private void btnClose_Click(object sender, EventArgs e) // إغلاق
        {
            this.Close();
        }
    }
}
