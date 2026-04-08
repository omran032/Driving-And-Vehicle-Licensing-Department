using Dev_Note_Assistant;
using DVLD_Management_System.Applications.Manage_Application_Type.Class;
using DVLD_Management_System.Applications.Manage_Application_Type.واجهات;
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


namespace DVLD_Management_System.Applications.Manage_Application_Type
{
    public partial class FormManageApplicationType : Form
    {
        public FormManageApplicationType()
        {
            InitializeComponent();

            // عرض القائمة عند الضغط على الصف
            ControlHelper.EnableRightClickSelection(DGV, ContextMenuStrip, RowClicked);

            LoadData();
        }
        int CurrentRowIndex = -1 ;

        void LoadData() 
        {
            //  عرض البيانات بالجدول
            DataTable TableInfo = ClsCMD_ApplicationDB.GetAllApplicationType();
            DGV.DataSource = TableInfo;
            lblCount.Text = "Records : " + TableInfo.Rows.Count;

            // إخفاء عمود الوصف
            DGV.Columns["Description"].Visible = false;

        }

        /// <summary>
        /// EnableRightClickSelection مثود لارجاع رقم الصف ..يستخدم مع حدث
        /// </summary>
        private void RowClicked(int row)
        {
            CurrentRowIndex = row;
        }

        InfoApplicationType  infoApplicationType = new InfoApplicationType();

        void InformationRow()
        {
            if(CurrentRowIndex < 0) return;

            var row = DGV.Rows[CurrentRowIndex];

            infoApplicationType.ID          = Convert.ToInt32(row.Cells["ID"].Value);
            infoApplicationType.TypeName    = row.Cells["Title"].Value.ToString();
            infoApplicationType.Description = row.Cells["Description"].Value.ToString();
            infoApplicationType.Fees        = Convert.ToDouble( row.Cells["Fees"].Value);
        }


        private void ToolS_EditApplicationType_Click(object sender, EventArgs e) // خيار التعديل
        {
            InformationRow();
            if(infoApplicationType==null) return;

            FrmUpdateApplicatioType frmUpdate = new FrmUpdateApplicatioType(infoApplicationType);
            frmUpdate.Refesh += LoadData;
            MyTools.ShowForm(frmUpdate); //واجهة التعديل
        
        }


     

     
    }
}
