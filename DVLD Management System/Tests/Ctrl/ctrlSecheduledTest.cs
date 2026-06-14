using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Properties;
using DVLD_Management_System.Class.Class_DB;
using DVLD_Management_System.Tests.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Tests.Ctrl
{
    public partial class ctrlSecheduledTest : UserControl
    {
        // نوع الاختبار (رؤية/كتابي/شارع)
        private ClassInfoLicenseAplication.enTestType _TestTypeID = ClassInfoLicenseAplication.enTestType.VisionTest;
        private int _TestID = -1;
        private int _TestAppointmentID = -1;
        private int _RequestID = -1; // معرف الطلب المرتبط بهذا الموعد

        public ctrlSecheduledTest()
        {
            InitializeComponent();
        }

        // خاصية لتعيين نوع الاختبار وتحديث الواجهة بصرياً
        public ClassInfoLicenseAplication.enTestType TestTypeID
        {
            get => _TestTypeID;
            set
            {
                _TestTypeID = value;
                UpdateTestTypeUI();
            }
        }

        public int TestAppointmentID => _TestAppointmentID;
        public int TestID => _TestID;
        // معرف الطلب العام المرتبط بالموعد (RequestID)
        public int RequestID => _RequestID;

        /// <summary>
        /// تحميل بيانات الموعد من قاعدة البيانات وعرضها في العنصر
        /// يمكن استدعاء هذه الدالة من أي فورم مع معرف الموعد TestID
        /// </summary>
        /// <param name="TestAppointmentID">معرف سجل الاختبار في جدول Tests</param>
        public void LoadInfo(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;
            if (_TestAppointmentID <= 0) return;

            // 1) Get model from DB
            var model = GetAppointmentData(_TestAppointmentID);
            if (model == null)
            {
                MessageBox.Show("No appointment found with ID=" + _TestAppointmentID, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _TestID = model.TestID;
            _RequestID = model.RequestID; // خزّن معرف الطلب ليتم الوصول إليه من الفورم الحاوي

            // 2) Fill UI elements
            FillUI(model);
        }

        // جلب بيانات الموعد كـ Model (تفصل منطق DB عن UI)
        private Tests.Class.TestAppointmentModel GetAppointmentData(int testAppointmentID)
        {
            try
            {
                string q = "SELECT TestID, ExamDate, FeesExam, Result, RequestID, TestTypeID FROM Tests WHERE TestID = @TestID";
                var p = new Dictionary<string, object>() { { "@TestID", testAppointmentID } };
                var dt = ClsCommandDB.SelectCommand(q, p);
                if (dt == null || dt.Rows.Count == 0) return null;

                var row = dt.Rows[0];
                var model = new Tests.Class.TestAppointmentModel();

                model.TestID = row["TestID"] != DBNull.Value ? Convert.ToInt32(row["TestID"]) : -1;
                model.RequestID = row["RequestID"] != DBNull.Value ? Convert.ToInt32(row["RequestID"]) : -1;
                model.TestTypeID = row.Table.Columns.Contains("TestTypeID") && row["TestTypeID"] != DBNull.Value ? Convert.ToInt32(row["TestTypeID"]) : (int)_TestTypeID;
                model.ExamDate = row["ExamDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["ExamDate"]) : null;
                model.Fees = row["FeesExam"] != DBNull.Value ? Convert.ToInt32(row["FeesExam"]) : 0;
                model.Result = row["Result"] != DBNull.Value ? row["Result"].ToString() : null;

                return model;
            }
            catch
            {
                return null;
            }
        }

        // تعبئة واجهة المستخدم بالقيم من النموذج
        private void FillUI(Tests.Class.TestAppointmentModel model)
        {
            // request-level info using ClassInfoLicenseAplication
            ClassInfoLicenseAplication info = null;
            if (model.RequestID > 0)
                info = ClassInfoLicenseAplication.FindInfoRequest(model.RequestID);

            lblLocalDrivingLicenseAppID.Text = info != null ? info.RequestID.ToString() : (model.RequestID > 0 ? model.RequestID.ToString() : "[N/A]");
            lblDrivingClass.Text = info != null ? info.LicenseClass ?? "[N/A]" : "[N/A]";
            lblFullName.Text = info != null && info.Person != null ? info.Person.FullName : "[N/A]";

            // Count attempts using helper (moved out of UI)
            lblTrial.Text = TestDataHelper.CountPreviousAttempts(model.RequestID, model.TestTypeID).ToString();

            lblDate.Text = model.ExamDate.HasValue ? model.ExamDate.Value.ToString("yyyy-MM-dd") : "[N/A]";
            lblFees.Text = model.Fees.ToString();
            lblTestID.Text = model.TestID <= 0 ? "Not Taken Yet" : model.TestID.ToString();

            // تحديث الواجهة حسب نوع الاختبار
            TestTypeID = (ClassInfoLicenseAplication.enTestType)model.TestTypeID;
        }

        // يفصل تحديث الواجهة الخاصة بنوع الاختبار إلى ميثود مستقل
        private void UpdateTestTypeUI()
        {
            switch (_TestTypeID)
            {
                case ClassInfoLicenseAplication.enTestType.VisionTest:
                    gbTestType.Text = "Vision Test";
                    pbTestTypeImage.Image = Resources.Eye;
                    break;
                case ClassInfoLicenseAplication.enTestType.WrittenTest:
                    gbTestType.Text = "Written Test";
                    pbTestTypeImage.Image = Resources.exam;
                    break;
                case ClassInfoLicenseAplication.enTestType.StreetTest:
                    gbTestType.Text = "Street Test";
                    pbTestTypeImage.Image = Resources.car;
                    break;
            }
        }

        // CountPreviousAttempts moved to TestDataHelper to keep DB logic outside UI control.
    }
}
