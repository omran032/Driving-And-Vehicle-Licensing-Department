using Dev_Note_Assistant;
using DVLD_Management_System.Applications.Driver_Licenses_Services.New_Driving_License.Local_License.Class;
using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
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

namespace DVLD_Management_System.Applications
{
    public partial class FrmLocalDrivingLicenseApplication : Form
    {
        public FrmLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            // تحميل البيانات
            LoadData();
            // ضبط الأوامر للعناصر
            ShowNumberIndexRowSelectedInTable();
        }



        DataTable Data ;
        void LoadData()
        {
            AllData();
            lblCountRecords.Text = "Records : " + Data.Rows.Count.ToString();

            //  تشغيل الحدث بعد الفلترة
            ctrlLicenseAppFelter1.EventShowFelterUser += GetData;

        }

        // عرض بيانات طلبات رخص القادة المحلية
        void AllData()
        {
            Data = clsLicenseClass.GetLocalLicenseRequests();
            DGV.DataSource = Data;
        }

        /// <summary>
        /// إحضار البيانات بعد الفلترة
        /// </summary>
        void GetData(DataTable Data)
        {
            DGV.DataSource = Data;
        }

        int IndexRowSelected = -1;
        Action<int> OnRowRightClick;

        // Index عرض القائمة عند الضغط على صف ... ومعرفة 
        void ShowNumberIndexRowSelectedInTable()
        {
            OnRowRightClick = (d) =>
            {
                IndexRowSelected = d;
                DataRowSelected(IndexRowSelected); // ← هون لازم تنفّذ
            };

            ControlHelper.EnableRightClickSelection(DGV, MyContextMenuStrip, OnRowRightClick);
        }


        int ID_Request = -1 ; string ClassName; string NationalNum; string FullName;
        DateTime ApllicationDate; int PassedTests ;string Status;

        /// <summary>
        /// معرفة بيانات الصف المحدد
        /// </summary>
        void DataRowSelected(int IndexRow)
        {
            ID_Request = Convert.ToInt32(DGV.Rows[IndexRow].Cells[0].Value);
            ClassName = DGV.Rows[IndexRow].Cells[1].Value.ToString();
            NationalNum = DGV.Rows[IndexRow].Cells[2].Value.ToString();
            FullName = DGV.Rows[IndexRow].Cells[3].Value.ToString();
            ApllicationDate = Convert.ToDateTime(DGV.Rows[IndexRow].Cells[4].Value);
            PassedTests = Convert.ToInt32(DGV.Rows[IndexRow].Cells[5].Value);
            Status = DGV.Rows[IndexRow].Cells[6].Value.ToString();
        }


        // زر عرض واجهة إضافة طلبات رخص محلية
        private void btnAddLocalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            if(ID_Request == -1) return;

            ClassInfoLicenseAplication infoLicenseAplication = new ClassInfoLicenseAplication();
            infoLicenseAplication = ClassInfoLicenseAplication.FindInfoRequest(ID_Request); // تحميل البيانات بالاوبجكت
            // استدعاء الفورم
            FrmLDLAppInfo frmLDLApp = new FrmLDLAppInfo(infoLicenseAplication);
            MyTools.ShowForm(frmLDLApp);
        }

        // زر عرض واجهة تعديل طلبات رخص محلية
        private void Context_btnEditLocalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            FrmAddUpdateApplication addUpdateApplication = new FrmAddUpdateApplication(1);
            MyTools.ShowForm(addUpdateApplication);
            // Refrech
            AllData();
        }

        // زر حذف   طلب رخصة محلية
        private void Context_btnDeleteLocalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (ID_Request == 0) return;
            // امر حذف طلب الرخصة
            Cls_CMDCommandLocalDrivingLicenceApp.DeleteRequestByID(ID_Request);
            AllData(); // Refresh
        }

        // Cancle جعل حالة طلب الرخصة
        private void Context_btnCancleApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // -1  = Cansle  // 0 = New  // 1 = Completed
           bool request =  Cls_CMDCommandLocalDrivingLicenceApp.UpdateRequestStatus(ID_Request, -1);

            if(request)
            {
                MessageBox.Show("The license application status has been updated", "Canceled", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                AllData(); // Refresh
            }
        }

        // حدث عند فتح  القائمة 
        private void MyContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            StatusRequest_isNew();

            Status_btnSechdualeTests();

            CanEditRequest();
        }






        #region  أوامر عند فتح القائمة

        /// <summary>
        ///  Cancel Application زر امكانية عمل
        /// </summary>
        void StatusRequest_isNew()
        {
            Context_btnCancleApplication.Enabled = Status == "New" || Status == "Completed";
        }

        /// <summary>
        /// أمكانية عمل اختبارات فحص القيادة
        /// </summary>
        void Status_btnSechdualeTests ()
        {
            sechduleTestsToolStripMenuItem.Enabled = PassedTests != 3 && Status != "Cancelled";
            Context_btnSchedualeVisionTest.Enabled = PassedTests == 0;
            Context_btnSchedualeWnitteTest.Enabled = PassedTests == 1;
            Context_btnSchedualeStreetTest.Enabled = PassedTests == 2; 
        }

        /// <summary>
        ///  هل يمكن تعديل الطلب ؟
        /// </summary>
        void CanEditRequest()
        {
            // New لا يمكن تعديل الطلب الا اذا كانت حالته 
            Context_btnEditLocalDrivingLicenseApp.Enabled = Status == "New" ;
        }



        #endregion

       
    }
}
