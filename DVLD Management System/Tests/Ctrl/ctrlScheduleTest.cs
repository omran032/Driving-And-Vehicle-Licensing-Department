using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Properties;
using DVLD_Management_System.Tests.Class;
using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول;
using System.Data.SqlTypes;

namespace DVLD_Management_System.Tests.Ctrl
{
    public partial class ctrlScheduleTest : UserControl
    {
        public ctrlScheduleTest( )
        {
            InitializeComponent();
        }


        private ClassInfoLicenseAplication.enTestType _TestTypeID = ClassInfoLicenseAplication.enTestType.VisionTest;

        public ClassInfoLicenseAplication.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case ClassInfoLicenseAplication.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Eye;
                            break;
                        }

                    case ClassInfoLicenseAplication.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.exam;
                            break;
                        }
                    case ClassInfoLicenseAplication.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.car;
                            break;


                        }
                }
            }
        }





        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;



        private int _LocalDrivingLicenseApplicationID = -1;
        private int _TestAppointmentID = -1;
        private clsLDLApp _LocalDrivingLicenseApplication;
        private int _ApplicantPersonID = -1; // معرف الشخص صاحب الطلب

         public event EventHandler AppointmentSaved; // لا يتم استعماله حاليا

        // الحث يعمل عند الحفظ و التعديل ...وهو لتحديث البيانات التي تعرض في الجدول
        public Action OnAppointmentSaved;

        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            // تحديد وضع الشاشة: إضافة جديدة أو تعديل
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;


            if(_Mode == enMode.AddNew)
            {
                dtpTestDate.Value = DateTime.Today;
            }
            // حفظ المعرفات محلياً
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;

            // جلب معلومات الطلب (يتضمن معلومات الشخص وفئة الرخصة والرسوم)
            // هذه الدالة تستخدم الاستعلام الموجود في ClassInfoLicenseAplication.FindInfoRequest
            var info = ClassInfoLicenseAplication.FindInfoRequest(_LocalDrivingLicenseApplicationID);

            if (info == null)
            {
                // إذا لم توجد بيانات للطلب، تعطيل زر الحفظ وإظهار رسالة خطأ
                MessageBox.Show("لا يوجد طلب برقم المعرف المحدد.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            // تعبئة عناصر الواجهة بالمعلومات المستخرجة
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = info.LicenseClass ?? "[غير معروفة]";
            lblFullName.Text = info.Person != null ? info.Person.FullName : "[غير معروف]";
            lblFees.Text = info.Fees.ToString();

            // حساب عدد الاختبارات الناجحة للشخص (تجارب سابقة)
            try
            {
                if (info.Person != null)
                {
                    lblTrial.Text = Cls_CMDCommandLocalDrivingLicenceApp.GetPassedTestsCount(info.Person.IDPerson).ToString();
                    _ApplicantPersonID = info.Person.IDPerson; // حفظ معرف الشخص لاستخدامه لاحقاً
                }
                else
                    lblTrial.Text = "0";
            }
            catch
            {
                lblTrial.Text = "0";
            }

            // إذا كان نوع الاختبار ليس فحص الرؤية، فتأكد أن فحص الرؤية قد تم اجتيازه سابقاً
            if (TestTypeID != ClassInfoLicenseAplication.enTestType.VisionTest)
            {
                bool canSchedule = true;
                try
                {
                    if (info.Person != null)
                    {
                        int passed = Cls_CMDCommandLocalDrivingLicenceApp.GetPassedTestsCount(info.Person.IDPerson);
                        if (passed == 0)
                            canSchedule = false;
                    }
                    else
                    {
                        canSchedule = false;
                    }
                }
                catch
                {
                    canSchedule = false;
                }

                lblUserMessage.Visible = !canSchedule;
                btnSave.Enabled = canSchedule;
            }
            else
            {
                lblUserMessage.Visible = false;
                btnSave.Enabled = true;
            }

            // إذا الوضع تعديل، جلب معلومات الموعد من جدول Tests
            if (_Mode == enMode.Update && _TestAppointmentID > 0)
            {
                try
                {
                    string q = "SELECT TestID, ExamDate, FeesExam, Result FROM Tests WHERE TestID = @TestID";
                    var p = new Dictionary<string, object>() { { "@TestID", _TestAppointmentID } };
                    var dt = ClsCommandDB.SelectCommand(q, p);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        dtpTestDate.Value = Convert.ToDateTime(row["ExamDate"]);
                        lblRetakeTestAppID.Text = row["TestID"].ToString();
                        lblRetakeAppFees.Text = row["FeesExam"].ToString();
                        lblTotalFees.Text = row["FeesExam"].ToString();
                    }
                }
                catch
                {
                    // تجاهل أي خطأ أثناء تحميل بيانات الموعد لضمان عدم تعطل الواجهة
                }
            }

            // حفظ كائن الطلب البسيط للاستخدام اللاحق
            _LocalDrivingLicenseApplication = clsLDLApp.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
        }

        // زر الحفظ
        private void btnSave_Click(object sender, EventArgs e)
        {
            // التحقق من رقم الطلب
            if (_LocalDrivingLicenseApplicationID <= 0)
            {
                MessageBox.Show("رقم الطلب غير صالح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // إضافة موعد جديد
            if (_Mode == enMode.AddNew)
            {
                // التحقق من وجود موعد فعّال مسبقاً
                if (Cls_CMDCommandLocalDrivingLicenceApp.IsThereAnActiveScheduledTest(
                    _LocalDrivingLicenseApplicationID, (int)TestTypeID))
                {
                    MessageBox.Show("يوجد بالفعل موعد اختبار فعّال لهذا الطلب ولنفس نوع الاختبار.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int Fees = Convert.ToInt32(string.IsNullOrWhiteSpace(lblFees.Text) ? "0" : lblFees.Text.Replace("[$$$]", "").Trim());
                int IDUser = (ClassUser.IDUser <= 0) ? 3 : ClassUser.IDUser;


                // استدعاء ميثود الإدراج
                int newID = AddTestAppointment( dtpTestDate.Value.Date, Fees, _LocalDrivingLicenseApplicationID, (int)TestTypeID, IDUser);

                if (newID > 0)
                {
                    MessageBox.Show("تم حفظ موعد الاختبار بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnAppointmentSaved?.Invoke(); //   إطلاق الحدث 
                }
                else
                    MessageBox.Show("فشل في حفظ موعد الاختبار.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // تعديل موعد
            {
                if (_TestAppointmentID <= 0)
                {
                    MessageBox.Show("رقم الموعد غير صالح للتعديل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int fees = Convert.ToInt32( string.IsNullOrWhiteSpace(lblFees.Text) ? "0" : lblFees.Text.Replace("[$$$]", "").Trim() );

                int result = UpdateTestAppointment(_TestAppointmentID, dtpTestDate.Value.Date,  fees );

                if (result > 0)
                {
                    MessageBox.Show("تم تعديل موعد الاختبار بنجاح.", "تم التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnAppointmentSaved?.Invoke(); //   إطلاق الحدث 
                }
                else
                    MessageBox.Show("فشل في تعديل موعد الاختبار.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }







        /// <summary>
        /// إضافة موعد اختبار جديد إلى جدول Tests
        /// ترجع: 
        /// > 0  = رقم السجل الجديد
        /// = -1  خطأ أثناء التنفيذ
        /// </summary>
        public static int AddTestAppointment(DateTime examDate, int fees, int requestID, int testTypeID, int createdByUserID)
        {
            string query = @"
        INSERT INTO Tests (ExamDate, Mark, Result, FeesExam, RequestID, TestTypeID, CreateByUserID)
        VALUES (@ExamDate, @Mark, @Result, @FeesExam, @RequestID, @TestTypeID, @CreateByUserID);

        SELECT SCOPE_IDENTITY();  ";

            var parameters = new Dictionary<string, object>()
            {
                { "@ExamDate", examDate },
                { "@Mark", 0 },
                { "@Result", null },
                { "@FeesExam", fees },
                { "@RequestID", requestID },
                { "@TestTypeID", testTypeID },
                { "@CreateByUserID", createdByUserID }
            };

            object result = ClsCommandDB.ExecuteScalar_Command(query, parameters, false);

            if (result != null && int.TryParse(result.ToString(), out int newID))
                return newID;

            return -1;
        }



        /// <summary>
        /// تعديل موعد اختبار موجود في جدول Tests
        /// ترجع:
        /// > 0 = تم التعديل بنجاح
        /// = -1 فشل في التعديل
        /// </summary>
        public static int UpdateTestAppointment(int testID, DateTime examDate, int fees)
        {
            string query = @"
        UPDATE Tests 
        SET ExamDate = @ExamDate, 
            FeesExam = @FeesExam
        WHERE TestID = @TestID";

            var parameters = new Dictionary<string, object>()
            {
                { "@ExamDate", examDate },
                { "@FeesExam", fees },
                { "@TestID", testID }
            };

            object result = ClsCommandDB.ExecuteNonQuery_Command(query, parameters, false);

            if (result != null && int.TryParse(result.ToString(), out int rows))
                return rows;

            return -1;
        }

        // عنصر التاريخ
        private void dtpTestDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTestDate.Value.Date < DateTime.Today)
                dtpTestDate.Value = DateTime.Today;
        }

    }
}
