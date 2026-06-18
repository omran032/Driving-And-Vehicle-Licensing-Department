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

namespace DVLD_Management_System.Local_Licenses.Ctrl
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        // Define a custom event handler delegate with parameters
        public event Action<ClassLicenseInfo> OnLicenseSelected;
       


        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }


        private int LicenseID_;
        public int LicenseID // معرف الرخصة
        {
            get{ return LicenseID_; }
            set
            {
                LicenseID_ = value;

                if(LicenseID_ <= 0)
                {
                    return;
                }

                info = ClassLicenseInfo.GetLicenseInfoLicenseID(LicenseID);

            }
        }

        private ClassLicenseInfo info_;
        public ClassLicenseInfo info //معلومات ارخصة
        {
            get { return info_; }
            set
            {
                if (value != null)
                {
                    info_ = value;
                    ctrlDriverLicenseInfo1.LoadInfo(info);
                }
             
            }
        }


        // مربع النص
        private void guna2TextBox1_Validating(object sender, CancelEventArgs e)
        {
           
        }

        // مربع النص
        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                 errorProvider1.SetError(txtLicenseID, "هذا الحقل مطلوب ");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtLicenseID, null);
            }
        }

        // زر البحث
        private void btnFind_Click_1(object sender, EventArgs e)
        {
            int.TryParse(txtLicenseID.Text.Trim(), out int LicenseID);

             // تحميل البيانات في العنصر
            this.LicenseID = LicenseID;

            if(LicenseID <= 0)
            {
                errorProvider1.SetError(txtLicenseID, "ادخال خطأ ");
                return;
            }
            errorProvider1.SetError(txtLicenseID, null);


            if (info == null)
            {
                MessageBox.Show("الرخصة غير موجودة بعد أو لم يتم اصدارها!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (OnLicenseSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnLicenseSelected?.Invoke(info);
        }


        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }



    }
}
