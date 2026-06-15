using DVLD_Management_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Management_System.Local_Licenses.Class;
using DVLD_Management_System.Class.Class_Buisness;

namespace DVLD_Management_System.Local_Licenses.Ctrl
{
    public partial class CtrlDriverLicenseInfo : UserControl
    {
        public CtrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private int _LicenseID;
        private clsLicense _License;


        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        { get { return _License; } }

        private void _LoadPersonImage()
        {
            try
            {
                // إذا ما في صورة مخزنة → اعرض صورة حسب الجنس
                if (_License.DriverInfo.PersonInfo.ImagePath == null ||
                    _License.DriverInfo.PersonInfo.ImagePath.Length == 0)
                {
                    pbPersonImage.Image = (_License.DriverInfo.PersonInfo.Gendor == 0)
                        ? Resources.Male
                        : Resources.Female;

                    return;
                }

                //// تحويل byte[] إلى Image
                //using (MemoryStream ms = new MemoryStream(_License.DriverInfo.PersonInfo.Picture))
                //{
                //    pbPersonImage.Image = Image.FromStream(ms);
                //}
            }
            catch
            {
                // في حال حدوث خطأ → اعرض صورة افتراضية حسب الجنس
                pbPersonImage.Image = (_License.DriverInfo.PersonInfo.Gendor == 0)
                    ? Resources.Male
                    : Resources.Female;
            }
        }


        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(_LicenseID);
            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            lblLicenseID.Text = _License.LicenseID.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblClass.Text = _License.LicenseClassIfo.ClassName;
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);

            lblDriverID.Text = _License.DriverID.ToString();
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            _LoadPersonImage();



        }


    }
}
