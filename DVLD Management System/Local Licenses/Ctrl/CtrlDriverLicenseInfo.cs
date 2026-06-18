using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Class.Class_Buisness;
using DVLD_Management_System.Local_Licenses.Class;
using DVLD_Management_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Local_Licenses.Ctrl
{
    public partial class CtrlDriverLicenseInfo : UserControl
    {
        public CtrlDriverLicenseInfo()
        {
            InitializeComponent();
        }


        /// <summary>
        /// تحميل معلومات الرخصة عن المعلومات المرسلة
        /// </summary>
        public void LoadInfo(ClassLicenseInfo info)
        {
            lblLicenseID.Text = info.LicenseID.ToString();
            lblIsActive.Text = info.StatusRelease ? "Active" : "Inactive";
            lblIsDetained.Text = info.IsDetained ? "Yes" : "No";
            lblClass.Text = info.ClassName;
            lblFullName.Text = info.FullName;
            lblNationalNo.Text = info.NationalNo;
            lblGendor.Text = info.Gender;
            lblDateOfBirth.Text = info.Birthdate.ToShortDateString();

            lblDriverID.Text = info.DriverID.ToString();
            lblIssueDate.Text = info.IssueDate.ToShortDateString();
            lblExpirationDate.Text = info.ExpirationDate.ToShortDateString();
            lblIssueReason.Text = info.IssueReason;
            lblNotes.Text = info.Notes;

            ShowPicture(info);
        }

        /// <summary>
        /// تحميل معلومات الرخصة عن طريق معرف الطلب
        /// </summary>
        /// <param name="RequstID"></param>
        public void LoadInfo(int RequstID)
        {
            ClassLicenseInfo info = ClassLicenseInfo.GetLicenseInfoByRequestID(RequstID);

            if (info != null)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(info);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("الرخصة غير موجودة بعد أو لم يتم اصدارها!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblLicenseID.Text = info.LicenseID.ToString();
            lblIsActive.Text = info.StatusRelease ? "Active" : "Inactive";
            lblIsDetained.Text = info.IsDetained ? "Yes" : "No";
            lblClass.Text = info.ClassName;
            lblFullName.Text = info.FullName;
            lblNationalNo.Text = info.NationalNo;
            lblGendor.Text = info.Gender;
            lblDateOfBirth.Text = info.Birthdate.ToShortDateString();

            lblDriverID.Text = info.DriverID.ToString();
            lblIssueDate.Text = info.IssueDate.ToShortDateString();
            lblExpirationDate.Text = info.ExpirationDate.ToShortDateString();
            lblIssueReason.Text = info.IssueReason;
            lblNotes.Text = info.Notes;

            ShowPicture(info);
        }

        /// <summary>
        /// تحميل معلومات الرخصة عن طريق معرف الطلب
        /// </summary>
        /// <param name="RequstID"></param>
        public void LoadInfoByLicenseID(int LicenseID)
        {
            ClassLicenseInfo info = ClassLicenseInfo.GetLicenseInfoLicenseID(LicenseID);

            if (info == null)
            {
                MessageBox.Show("الرخصة غير موجودة بعد أو لم يتم اصدارها!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            lblLicenseID.Text = info.LicenseID.ToString();
            lblIsActive.Text = info.StatusRelease ? "Active" : "Inactive";
            lblIsDetained.Text = info.IsDetained ? "Yes" : "No";
            lblClass.Text = info.ClassName;
            lblFullName.Text = info.FullName;
            lblNationalNo.Text = info.NationalNo;
            lblGendor.Text = info.Gender;
            lblDateOfBirth.Text = info.Birthdate.ToShortDateString();

            lblDriverID.Text = info.DriverID.ToString();
            lblIssueDate.Text = info.IssueDate.ToShortDateString();
            lblExpirationDate.Text = info.ExpirationDate.ToShortDateString();
            lblIssueReason.Text = info.IssueReason;
            lblNotes.Text = info.Notes;

            ShowPicture(info);
        }


        void ShowPicture(ClassLicenseInfo info)
        {
            if (info.PersonPicture != null)
            {
                using (MemoryStream ms = new MemoryStream(info.PersonPicture))
                {
                    pbPersonImage.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pbPersonImage.Image = info.Gender =="Male" ? Resources.Male : Resources.Female; // صورة افتراضية
            }
        }




    }
}
