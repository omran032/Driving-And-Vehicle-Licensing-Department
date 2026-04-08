using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Management_System.Applications.Manage_Test_Type.Class;
using static DVLD_Management_System.Class.Class.ControlHelper;

namespace DVLD_Management_System.Applications.Manage_Test_Type.واجهات
{
    public partial class FrmUpdateTestType : Form
    {
        public FrmUpdateTestType(InfoTestType infoTestType)
        {
            InitializeComponent();
            this.infoTestType = infoTestType;

            LoadData();
        }

         public  Action Refresh;

          InfoTestType infoTestType ;

        void LoadData()
        {
            if (infoTestType == null) return;

            lblID.Text            = infoTestType.ID.ToString();
            txtTypeName.Text      = infoTestType.TestTypeName;
            txtFees.Text          = infoTestType.Fees.ToString();
            txtDescription.Text   = infoTestType.Description;

        }

        private void btnSave_Click(object sender, EventArgs e) // زر حفظ التعديل
        {
            if (IsNullTextBox(txtTypeName, ErrorProvider) || IsNullTextBox(txtFees, ErrorProvider) || IsNullTextBox(txtDescription, ErrorProvider)) 
                return;

            infoTestType.TestTypeName = txtTypeName.Text.Trim();
            infoTestType.Fees         = Convert.ToDouble(txtFees.Text.Trim());
            infoTestType.Description  = txtDescription.Text.Trim();

            //  نفيذ امر التعديل
            ClsCMD_TestTypeDB.UpdateTestType(infoTestType);
            Refresh?.Invoke();

        }
    }
}
