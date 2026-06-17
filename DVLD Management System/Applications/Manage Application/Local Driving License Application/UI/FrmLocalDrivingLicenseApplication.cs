using Dev_Note_Assistant;
using DVLD_Management_System.Applications.Driver_Licenses_Services.New_Driving_License.Local_License.Class;
using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Class.Class_DB;
using DVLD_Management_System.Local_Licenses;
using DVLD_Management_System.Local_Licenses.Class;
using DVLD_Management_System.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class.ClassInfoLicenseAplication;

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

        // معلومات الطلب
        ClassInfoLicenseAplication infoLicenseAplication = new ClassInfoLicenseAplication();
        ClassInfoLicenseAplication.enTestType _TestType  = ClassInfoLicenseAplication.enTestType.VisionTest;

        DataTable Data ;
        void LoadData()
        {
            AllData();

            //  تشغيل الحدث بعد الفلترة
            ctrlLicenseAppFelter1.EventShowFelterUser += GetData;

        }

        /// <summary>
        /// Public method to refresh the main data grid from other forms
        /// </summary>
        public void RefreshData()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { AllData(); }));
            }
            else
            {
                AllData();
            }
        }

        // عرض بيانات طلبات رخص القادة المحلية
        public void AllData()
        {
            Data = clsLicenseClass.GetLocalLicenseRequests();
            DGV.DataSource = Data;
            lblCountRecords.Text = "Records : " + Data.Rows.Count.ToString();

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
                DataRowSelected(IndexRowSelected); // حفظ البيانات
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
            Status = DGV.Rows[IndexRow].Cells[6].Value.ToString().ToLower();
        }


        // عرض المعلومات Context  
        private void Context_btnAddLocalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            if (ID_Request == -1) return;

            LoadInfoAppointment(); if (ID_Request == -1) return;

            // استدعاء الفورم

            FrmLDLAppInfo ShowInfoApplication = new FrmLDLAppInfo(infoLicenseAplication);
            MyTools.ShowForm(ShowInfoApplication);
        }

        // زر عرض واجهة إضافة طلبات رخص محلية
        private void btnAddLocalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            FrmAddUpdateApplication frm = new FrmAddUpdateApplication();
            // subscribe to OnSaved to refresh parent data when child adds/updates
            frm.OnSaved += (all) =>
            {
                try
                {
                    if (all != null) all(); else AllData();
                }
                catch { }
            };
            MyTools.ShowForm(frm);
            // initial refresh after showing
            AllData();
        }
        // تحميل بيانات الطلب بالاوبجكت
        void LoadInfoAppointment()
        {
            infoLicenseAplication = ClassInfoLicenseAplication.FindInfoRequest(ID_Request); // تحميل البيانات بالاوبجكت
             
        }




        // زر عرض واجهة تعديل طلبات رخص محلية
        private void Context_btnEditLocalDrivingLicenseApp_Click(object sender, EventArgs e)
        {
            if (ID_Request == -1) return;

            LoadInfoAppointment(); if (ID_Request == -1) return;

            FrmAddUpdateApplication UpdateApplication = new FrmAddUpdateApplication(infoLicenseAplication);
            UpdateApplication.OnSaved += (all) =>
            {
                try
                {
                    if (all != null) all(); else AllData();
                }
                catch { }
            };
            MyTools.ShowForm(UpdateApplication);
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

            IsEncabledBtn_IssusDriverL();

            IsEnabledContext_btn_ShowLicense();

            IsEnabledContextDelete();
        }


        #region (VisionTest _ WnitteTest _ StreetTest)  خيارات عمل اختبارات القيادة 

        //  عرض واجهة انشاء اختبار من نوع محدد
        private void _ScheduleTest(ClassInfoLicenseAplication.enTestType _TestType)
        {
            LoadInfoAppointment();
            frmListTestApp frmListTestApp = new frmListTestApp(infoLicenseAplication , _TestType);
            frmListTestApp.ShowDialog();
         //   LoadData();
        }


        // VisionTest  // إختبار فحص النظر
        private void Context_btnSchedualeVisionTest_Click(object sender, EventArgs e)
        {
            _ScheduleTest(enTestType.VisionTest);
        }

        // WnitteTest  // اختبار كتابة
        private void Context_btnSchedualeWnitteTest_Click(object sender, EventArgs e)
        {
            _ScheduleTest(enTestType.WrittenTest);
        }

        // StreetTest  // اختبار القيادة
        private void Context_btnSchedualeStreetTest_Click(object sender, EventArgs e)
        {
            _ScheduleTest(enTestType.StreetTest);
        }

        #endregion



        #region  أوامر عند فتح القائمة

        /// <summary>
        ///  Cancel Application زر امكانية عمل
        /// </summary>
        void StatusRequest_isNew()
        {
            Context_btnCancleApplication.Enabled = Status == "new" || false;
        }

        /// <summary>
        /// أمكانية عمل اختبارات فحص القيادة
        /// </summary>
        void Status_btnSechdualeTests ()
        {
            Context_btnSechduleTests.Enabled = PassedTests != 3 && Status != "canceled";
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
            Context_btnEditLocalDrivingLicenseApp.Enabled = Status == "new" ;
        }

        /// <summary>
        /// تحديد متى يمكن الضغط على زر  ...اصدار رخصة لاول مرة
        /// </summary>
        void IsEncabledBtn_IssusDriverL()
        {
            // New عندما تكون حالة الطلب 
            // وعندما يكون الشخص قد نجح في الاختبارات كلها
            Context_btn_lssueDriving.Enabled = Status == "new" && PassedTests == 3;
        }

        /// <summary>
        /// تحديد متى يمكن عرض الرخصة 
        /// </summary>
        void IsEnabledContext_btn_ShowLicense()
        {
            Context_btn_ShowLicense.Enabled = Status == "completed" && PassedTests == 3;
        }

        /// <summary>
        /// متى يسمح بالحذف
        /// </summary>
        void IsEnabledContextDelete()
        {
            bool IsCompleted = Status == "completed";

            Context_btnDeleteLocalDrivingLicenseApp.Enabled = !IsCompleted;
        }


        #endregion

        private void Context_btn_ShowLicense_Click(object sender, EventArgs e)
        {
            int RequestID = (int)DGV.CurrentRow.Cells[0].Value;

            ClassLicenseInfo info = ClassLicenseInfo.GetLicenseInfoByRequestID(RequestID);

            if (info != null)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(info);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("الرخصة غير موجودة!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        
        private void Context_btn_lssueDriving_Click(object sender, EventArgs e)// زر انشاء رخصة لأول مرة
        {
            int LocalDrivingLicenseApplicationID = (int)DGV.CurrentRow.Cells[0].Value;
            if (ID_Request == -1) return;

            LoadInfoAppointment();  

            FrmIssueDriverLicenseFirstTime frm = new FrmIssueDriverLicenseFirstTime(LocalDrivingLicenseApplicationID , infoLicenseAplication);
            frm.ShowDialog();

            // Refrech
            AllData();  
        }
    }
}
