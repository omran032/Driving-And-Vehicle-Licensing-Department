using DVLD_Management_System.Applications.Manage_Application_Type.Class;
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
using static DVLD_Management_System.Class.Class.ControlHelper;

namespace DVLD_Management_System.Applications.Manage_Application_Type.واجهات
{
    public partial class FrmUpdateApplicatioType : Form
    {
        public FrmUpdateApplicatioType(InfoApplicationType infoApplication)
        {
            InitializeComponent();
            //  تحميل البيانات
            this.infoApplication = infoApplication;
            LoadData();
        }

        public Action Refesh ;

        InfoApplicationType infoApplication;

      void  LoadData ()
        {
            lblID.Text          = infoApplication.ID.ToString();
            txtTypeName.Text    = infoApplication.TypeName;
            txtFees.Text        = infoApplication.Fees.ToString();
            txtDescription.Text = infoApplication.Description;
        }

        private void btnSave_Click(object sender, EventArgs e) // زر حفظ التعديل
        {
            if (IsNullTextBox(txtTypeName, ErrorProvider) || IsNullTextBox(txtFees, ErrorProvider))
                return;

            infoApplication.TypeName    = txtTypeName.Text.Trim();
            infoApplication.Fees        = Convert.ToDouble( txtFees.Text.Trim() );
            infoApplication.Description = txtDescription.Text.Trim();

            //  نفيذ امر التعديل
            ClsCMD_ApplicationDB.UpdateApplicationType(infoApplication);
            Refesh?.Invoke();

        }
    }
}
