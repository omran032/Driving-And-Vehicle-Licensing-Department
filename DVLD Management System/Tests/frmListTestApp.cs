using Dev_Note_Assistant;
using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class.ClassInfoLicenseAplication;

namespace DVLD_Management_System.Tests
{
    public partial class frmListTestApp : Form
    {
        public frmListTestApp(ClassInfoLicenseAplication infoLicenseApplication_, ClassInfoLicenseAplication.enTestType TestType_)
        {
            InitializeComponent();
            infoLicenseApplication = infoLicenseApplication_;
            TestType = TestType_; // نوغ الاختبار

            // Index عرض القائمة عند الضغط على صف ... ومعرفة 
            ShowNumberIndexRowSelectedInTable();
        }

        ClassInfoLicenseAplication infoLicenseApplication = new ClassInfoLicenseAplication();
        ClassInfoLicenseAplication.enTestType TestType    =     ClassInfoLicenseAplication.enTestType.VisionTest;


        int ID_Test = -1;
        int IndexRowSelected = -1;
        Action<int> OnRowRightClick;

        // Index عرض القائمة عند الضغط على صف ... ومعرفة 
        void ShowNumberIndexRowSelectedInTable()
        {
            OnRowRightClick = (d) =>
            {
                IndexRowSelected = d;
                DataRowSelected(IndexRowSelected);  // حفظ البيانات
            };

            ControlHelper.EnableRightClickSelection(DGV, MyContextMenuStrip, OnRowRightClick);
        }

        /// <summary>
        /// للصف المختار TestID معرفة 
        /// </summary>
        void DataRowSelected(int IndexRow)
        {
            ID_Test = Convert.ToInt32(DGV.Rows[IndexRow].Cells[0].Value);
        }

        DataTable DT;
      void LoadData_()
        {
            ///   تجلب  جميع الاختبارات المرتبطة بطلب معيّن ونوع اختبار محدد
            DT = Cls_CMDCommandLocalDrivingLicenceApp.GetTestsPerType(infoLicenseApplication.RequestID, (int)TestType);
            DGV.DataSource = DT;
        }


        // تحميل الفورم
        private void frmListTestApp_Load(object sender, EventArgs e)
        {
            if (infoLicenseApplication == null) return;
            // تحميل بيانات الطلب و المعلومات كاملة
            ctrl_DLApplInfo1.InfoLicenseAplication = infoLicenseApplication;

            Load_();

            LoadData_();

            if (DGV.Rows.Count > 0)
            {
                DGV.Columns[0].HeaderText = "Appointment ID";

                DGV.Columns[1].HeaderText = "Appointment Date";

                DGV.Columns[2].HeaderText = "Paid Fees";

                DGV.Columns[3].HeaderText = "Is Locked";
            }

            lblRecordsCount.Text = DT.Rows.Count.ToString();
        }


        void Load_()
        {
            switch (TestType)
            {
                case ClassInfoLicenseAplication.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Eye;
                        break;
                    }

                case ClassInfoLicenseAplication.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.exam;
                        break;
                    }
                case ClassInfoLicenseAplication.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.car;
                        break;
                    }
            }
        }

        //زر إضافة موعد جديد 
        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = infoLicenseApplication.RequestID;

            frmScheduleTest frm = new frmScheduleTest(TestType , LocalDrivingLicenseApplicationID);
            frm.ctrlScheduleTest1.OnAppointmentSaved += LoadData_;
            frm.ShowDialog();

        }

        // زر تعديل موعد
        private void Context_Edit_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = ID_Test;
            int LocalDrivingLicenseApplicationID = infoLicenseApplication.RequestID;

            frmScheduleTest frm = new frmScheduleTest(TestType , LocalDrivingLicenseApplicationID, TestAppointmentID);
            frm.ctrlScheduleTest1.OnAppointmentSaved += LoadData_;
            frm.ShowDialog();

        }

        private void Context_TakeTest_Click(object sender, EventArgs e)
        {

        }

     
    }
}
