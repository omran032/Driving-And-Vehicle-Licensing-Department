using DVLD_Management_System.Applications.Manage_Application_Type.Class;
using DVLD_Management_System.Class.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD_Management_System.Applications.Manage_Test_Type.Class;


using System.Windows.Forms;
using Dev_Note_Assistant;

namespace DVLD_Management_System.Applications.Manage_Test_Type.واجهات
{
    public partial class FormManageTypeType : Form
    {
        public FormManageTypeType()
        {
            InitializeComponent();

            // عرض القائمة عند الضغط على الصف
            ControlHelper.EnableRightClickSelection(DGV, ContextMenuStrip, RowClicked);

            LoadData();
        }

        int CurrentRowIndex = -1 ;


        void LoadData()
        {
            DataTable TestTypeTable = ClsCMD_TestTypeDB.GetDataTestType();
            if (TestTypeTable == null) return;
            
            DGV.DataSource = TestTypeTable;

            lblCount.Text = "Records : " + TestTypeTable.Rows.Count;

           // DGV.Columns["Description"].Visible = false;

        }

        InfoTestType infoTestType = new InfoTestType()  ;

        /// <summary>
        /// تحميل البيانات للصف المختار
        /// </summary>
        void InformationRow()
        {
            if (CurrentRowIndex < 0) return;    

            var row = DGV.Rows[CurrentRowIndex];

            infoTestType.ID           = Convert.ToInt32(row.Cells["ID"].Value);
            infoTestType.TestTypeName = row.Cells["Title"].Value.ToString();
            infoTestType.Description  = row.Cells["Description"].Value.ToString();
            infoTestType.Fees         = Convert.ToDouble(row.Cells["Fees"].Value);
        }

        /// <summary>
        /// EnableRightClickSelection مثود لارجاع رقم الصف ..يستخدم مع حدث
        /// </summary>
        private void RowClicked(int row)
        {
            CurrentRowIndex = row;
        }

        private void ToolS_EditTestType_Click(object sender, EventArgs e) // تعديل 
        {    
            infoTestType =  new InfoTestType();
            // تحميل البيانات للصف المختار
            InformationRow();

            if (infoTestType == null) return;

            FrmUpdateTestType frmUpdateTest = new FrmUpdateTestType(infoTestType);
            frmUpdateTest.Refresh += LoadData; // حدث اعادة تحميل عند تعديل
            MyTools.ShowForm(frmUpdateTest);

        }

    }
}
