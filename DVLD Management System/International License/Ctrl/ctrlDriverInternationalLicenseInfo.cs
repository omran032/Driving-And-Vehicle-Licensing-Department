using DVLD_Management_System.International_License.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Management_System.International_License.Class.Cls_InternationalLicenseCMD;

namespace DVLD_Management_System.Local_Licenses.Ctrl
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }


        public void LoadDataByObject(Cls_InternationalLicenseInfo Info)
        {
            if (Info == null) return;

            lblInternationalLicenseID.Text = Info.inernationalLicenseID.ToString();
            lblIssueDate.Text = Info.IssueDate.ToString("yyyy / MM / dd");
            lblIsActive.Text = Info.IsActive ? "Active" : "Inactive";
            lblExpirationDate.Text = Info.ExpirationDate.ToString("yyyy / MM / dd");

            lblLocalLicenseID.Text = Info.LoclLicenseID.ToString();
            lblApplicationID.Text = Info.RequestID.ToString();
            lblDriverID.Text = Info.DriverID.ToString();

            lblFullName.Text = Info.PersonInfo.FullName;
            lblNationalNo.Text = Info.PersonInfo.National_Number;
            lblGendor.Text = Info.PersonInfo.Gender;
            lblDateOfBirth.Text = Info.PersonInfo.Birthdate.ToString("yyyy / MM / dd");

            if (Info.PersonInfo.Picture != null)
            {
                using (MemoryStream ms = new MemoryStream(Info.PersonInfo.Picture))
                {
                    pbPersonImage.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pbPersonImage.Image = Info.PersonInfo.Gender == "Male" ? Properties.Resources.Male : Properties.Resources.Female; // صورة افتراضية
            }
        }

        /// <summary>
        /// تحميل معلومات الرخصة الدولية بواصة معرف الرخصة المحلية
        /// </summary>
        public void LoadDataByLicenseID(int LicenseID)
        {
            Cls_InternationalLicenseInfo InfoLicense =  Cls_InternationalLicenseCMD.GetInternationalLicenseInfo(enInterLicenseSearchBy.LicenseID, LicenseID);

            LoadDataByObject(InfoLicense);
        }

        /// <summary>
        /// تحميل معلومات الرخصة الدولية بواصة معرف السائق  
        /// </summary>
        public void LoadDataByDriverID(int DriverID)
        {
            Cls_InternationalLicenseInfo InfoLicense = Cls_InternationalLicenseCMD.GetInternationalLicenseInfo(enInterLicenseSearchBy.DriverID, DriverID);

            LoadDataByObject(InfoLicense);
        }

    }
}
