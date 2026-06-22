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
using System.Data.SqlClient;

namespace DVLD_Management_System.Tests.Ctrl
{
    public partial class ctrlScheduleTest : UserControl
    {
        public ctrlScheduleTest()
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
                            pbTestTypeImage.Image = Resources.Written_Test_512;
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

        // Creation mode: first time, retake, or street test
        private enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1, StreetTestSchedule = 2 }
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;



        private int _LocalDrivingLicenseApplicationID = -1;
        private int _TestAppointmentID = -1;
        private clsLDLApp _LocalDrivingLicenseApplication;
        private int _ApplicantPersonID = -1; // معرف الشخص صاحب الطلب

        // حدث ليقوم الفورم الأب بعمل Refresh عند الحفظ/التعديل
        public event EventHandler AppointmentSaved;

        // بديل بسيط لاستدعاء Refresh (يستخدم في بعض الأماكن)
        public Action OnAppointmentSaved;

        public void LoadInfo(int LocalDrivingLicenseApplicationID, int AppointmentID = -1)
        {
            // تنظيم الاستدعاءات: هذه الدالة مرتبة وواضحة — تستخدم الميثودات المساعدة أدناه
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            CheckIdDate();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = AppointmentID;

            // جلب بيانات الطلب من الدالة المخصصة
            var info = GetApplicationInfo(_LocalDrivingLicenseApplicationID);
            if (info == null)
            {
                MessageBox.Show("لا يوجد طلب برقم المعرف المحدد.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            // تعبئة الواجهة
            PopulateBasicInfo(info);

            // تحديد وضع الإنشاء (أول مرة / إعادة / شارع)
            DetermineCreationMode();

            // تحقق شروط الحجز (مثل اجتياز فحص الرؤية إن لزم)
            UpdateSchedulingConstraints(info);

            // إذا وضع التعديل: جلب بيانات الموعد
            if (_Mode == enMode.Update && _TestAppointmentID > 0)
            {
                var appt = GetTestAppointment(_TestAppointmentID);
                if (appt != null)
                    PopulateAppointmentInfo(appt);
            }

            // حفظ كائن الطلب البسيط للاستخدام اللاحق
            _LocalDrivingLicenseApplication = clsLDLApp.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
        }

        // =========================
        // Helper Methods - DB ops
        // =========================

        /// <summary>
        /// جلب معلومات الطلب (يغلف ClassInfoLicenseAplication.FindInfoRequest)
        /// </summary>
        private ClassInfoLicenseAplication GetApplicationInfo(int requestID)
        {
            // التعليق: نستعمل دالة موجودة في الكلاس المسؤول عن تجميع معلومات الطلب
            return ClassInfoLicenseAplication.FindInfoRequest(requestID);
        }

        /// <summary>
        /// يجلب صف الموعد من جدول Tests بحسب TestID
        /// </summary>
        private DataRow GetTestAppointment(int testID)
        {
            try
            {
                string q = "SELECT TestID, ExamDate, FeesExam, Result, TestTypeID FROM Tests WHERE TestID = @TestID";
                var p = new Dictionary<string, object>() { { "@TestID", testID } };
                var dt = ClsCommandDB.SelectCommand(q, p);
                if (dt != null && dt.Rows.Count > 0)
                    return dt.Rows[0];
            }
            catch
            {
                // تجاهل الأخطاء البسيطة
            }
            return null;
        }

        /// <summary>
        /// عدد المحاولات السابقة لنوع اختبار معين ولطلب معين
        /// </summary>
        private int CountPreviousAttempts(int requestID, int testTypeID)
        {
            try
            {
                string q = "SELECT COUNT(*) FROM Tests WHERE RequestID = @RequestID AND TestTypeID = @TestTypeID";
                var p = new Dictionary<string, object>() { { "@RequestID", requestID }, { "@TestTypeID", testTypeID } };
                var dt = ClsCommandDB.SelectCommand(q, p);
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch { }
            return 0;
        }



        // =========================
        // UI Population Helpers
        // =========================

        /// <summary>
        /// يعبئ المعلومات الأساسية (الاسم، الفئة، الرسوم)
        /// </summary>
        private void PopulateBasicInfo(ClassInfoLicenseAplication info)
        {
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = info.LicenseClass ?? "[غير معروفة]";
            lblFullName.Text = info.Person != null ? info.Person.FullName : "[غير معروف]";
            lblFees.Text = info.Fees.ToString();

            // حفظ معرف الشخص لعمليات التحقق لاحقاً
            _ApplicantPersonID = info.Person != null ? info.Person.IDPerson : -1;

            // عرض عدد المحاولات الناجحة
            try { lblTrial.Text = Cls_CMDCommandLocalDrivingLicenceApp.GetPassedTestsCount(_ApplicantPersonID).ToString(); }
            catch { lblTrial.Text = "0"; }
        }

        /// <summary>
        /// يعبئ بيانات الموعد عند وجوده
        /// </summary>
        private void PopulateAppointmentInfo(DataRow row)
        {
            dtpTestDate.Value = Convert.ToDateTime(row["ExamDate"]);
            lblRetakeTestAppID.Text = row["TestID"].ToString();

            // FeesExam في قاعدة البيانات هو المجموع المدفوع (Base + Retake إذا وُجد)
            int feesExam = 0;
            try { feesExam = Convert.ToInt32(row["FeesExam"]); } catch { feesExam = 0; }

            // الحصول على قيمة الرسوم الأساسية إذا لم تكن معروضة
            int baseFee = ParseFeesLabel(lblFees.Text);
            if (baseFee == 0)
            {
                try
                {
                    string qFeesTest = "SELECT TOP 1 Fees FROM TestTypes WHERE TestTypeID = @TestTypeID";
                    var pf = new Dictionary<string, object>() { { "@TestTypeID", (int)TestTypeID } };
                    var dtf2 = ClsCommandDB.SelectCommand(qFeesTest, pf);
                    if (dtf2 != null && dtf2.Rows.Count > 0)
                        baseFee = Convert.ToInt32(dtf2.Rows[0][0]);
                }
                catch { baseFee = 0; }
            }

            // حساب رسوم إعادة الاختبار كفرق بين الإجمالي والرسوم الأساسية
            int retakeFee = feesExam - baseFee;
            if (retakeFee < 0) retakeFee = 0;

            // تعبئة الحقول بدون تغيير قيمة الرسم الأساسي
            lblFees.Text = baseFee.ToString();
            lblRetakeAppFees.Text = retakeFee.ToString();
            lblTotalFees.Text = feesExam.ToString();
        }

        /// <summary>
        /// يحدد وضع الإنشاء (FirstTime/Retake/Street) اعتماداً على البيانات
        /// </summary>
        private void DetermineCreationMode()
        {
            if (TestTypeID == ClassInfoLicenseAplication.enTestType.StreetTest)
            {
                _CreationMode = enCreationMode.StreetTestSchedule;
            }
            else
            {
                int attempts = CountPreviousAttempts(_LocalDrivingLicenseApplicationID, (int)TestTypeID);
                _CreationMode = attempts > 0 ? enCreationMode.RetakeTestSchedule : enCreationMode.FirstTimeSchedule;
            }

            //      ApplyFeesRules(); // تحديد رسوم الدفع حسب الوضع

            // ضبط واجهة إعادة الاختبار
            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                // محاولة جلب رسوم إعادة الاختبار من RequestTypes (بحث بسيط)
                try
                {
                    string qFee = "SELECT TOP 1 Fees FROM RequestTypes WHERE TypeName LIKE '%Retake%' OR TypeName LIKE '%retake%'";
                    var dtf = ClsCommandDB.SelectCommand(qFee);
                    int retakeFees = (dtf != null && dtf.Rows.Count > 0) ? Convert.ToInt32(dtf.Rows[0][0]) : 0;
                    lblRetakeAppFees.Text = retakeFees.ToString();
                }
                catch { lblRetakeAppFees.Text = "0"; }

                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
            }
            else if (_CreationMode == enCreationMode.StreetTestSchedule)
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Street Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }

            // جلب رسوم الاختبار من TestTypes
            try
            {
                string qFeesTest = "SELECT TOP 1 Fees FROM TestTypes WHERE TestTypeID = @TestTypeID";
                var pf = new Dictionary<string, object>() { { "@TestTypeID", (int)TestTypeID } };
                var dtf2 = ClsCommandDB.SelectCommand(qFeesTest, pf);
                if (dtf2 != null && dtf2.Rows.Count > 0)
                    lblFees.Text = dtf2.Rows[0][0].ToString();
            }
            catch { }
        }

        /// <summary>
        /// يحدّث القيود المطبقة على إمكانية الحجز (مثلاً فحص الرؤية شرط للأنواع الأخرى)
        /// </summary>
        private void UpdateSchedulingConstraints(ClassInfoLicenseAplication info)
        {
            if (TestTypeID != ClassInfoLicenseAplication.enTestType.VisionTest)
            {
                bool canSchedule = true;
                try
                {
                    if (_ApplicantPersonID > 0)
                    {
                        int passed = Cls_CMDCommandLocalDrivingLicenceApp.GetPassedTestsCount(_ApplicantPersonID);
                        if (passed == 0) canSchedule = false; // يجب أن يجتاز فحص الرؤية أولاً
                    }
                    else canSchedule = false;
                }
                catch { canSchedule = false; }

                lblUserMessage.Visible = !canSchedule;
                btnSave.Enabled = canSchedule;
            }
            else
            {
                lblUserMessage.Visible = false;
                btnSave.Enabled = true;
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
                { "@ExamDate", new SqlParameter("@ExamDate", System.Data.SqlDbType.Date) { Value = examDate } },
                { "@FeesExam", new SqlParameter("@FeesExam", System.Data.SqlDbType.Int) { Value = fees } },
                { "@TestID", new SqlParameter("@TestID", System.Data.SqlDbType.Int) { Value = testID } }
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


        private int ParseFeesLabel(string text)
        {
            int value;
            if (int.TryParse(text, out value))
                return value;

            return 0;
        }

        /// <summary>
        /// تضبط وتعيد قيمة الرسوم حسب وضع الإنشاء (Street / FirstTime / Retake)
        /// يقوم باستخدام قيم الرسوم المعروضة في الواجهة (أو القيم الافتراضية)
        /// </summary>
        private int ApplyFeesRules()
        {
            // نحاول قراءة الرسوم من عناصر الواجهة إن كانت معروضة، وإلا نستخدم قيم افتراضية
            int baseFees = ParseFeesLabel(lblFees.Text);
            int retakeFees = ParseFeesLabel(lblRetakeAppFees.Text);

            // إذا لم تكن هناك قيمة في lblFees، حاول جلبها من قاعدة البيانات بحسب TestType
            if (baseFees == 0)
            {
                try
                {
                    string qFeesTest = "SELECT TOP 1 Fees FROM TestTypes WHERE TestTypeID = @TestTypeID";
                    var pf = new Dictionary<string, object>() { { "@TestTypeID", (int)TestTypeID } };
                    var dtf2 = ClsCommandDB.SelectCommand(qFeesTest, pf);
                    if (dtf2 != null && dtf2.Rows.Count > 0)
                        baseFees = Convert.ToInt32(dtf2.Rows[0][0]);
                }
                catch { }
            }

            // إذا وضع إعادة الاختبار وتحتوي lblRetakeAppFees على صفر، نحاول جلبها من RequestTypes
            if (_CreationMode == enCreationMode.RetakeTestSchedule && retakeFees == 0)
            {
                try
                {
                    string qFee = "SELECT TOP 1 Fees FROM RequestTypes WHERE TypeName LIKE '%Retake%' OR TypeName LIKE '%retake%'";
                    var dtf = ClsCommandDB.SelectCommand(qFee);
                    if (dtf != null && dtf.Rows.Count > 0)
                        retakeFees = Convert.ToInt32(dtf.Rows[0][0]);
                }
                catch { }
            }

            int total = baseFees + retakeFees;
            // تحديث واجهة المستخدم
            lblFees.Text = baseFees.ToString();
            lblRetakeAppFees.Text = retakeFees.ToString();
            lblTotalFees.Text = total.ToString();

            return total;
        }


        /// <summary>
        /// يتحقق إن كان للشخص نتيجة ناجحة لنوع الاختبار (يمنع جدولة جديدة)
        /// </summary>
        private bool HasPersonPassedTestTypeLocal(int personID, int testTypeID)
        {
            // التفاف على الدالة المشتركة في Cls_CMDCommandLocalDrivingLicenceApp
            return Cls_CMDCommandLocalDrivingLicenceApp.HasPersonPassedTestType(personID, testTypeID , _LocalDrivingLicenseApplication.LicenseClassID);
        }

        /// <summary>
        /// يتحقق إن كان هناك موعد مجدول نشط لنفس الطلب ونوع الاختبار
        /// </summary>
        public static bool IsThereActiveScheduledTestLocal(int requestID, int testTypeID)
        {
            return Cls_CMDCommandLocalDrivingLicenceApp.IsThereAnActiveScheduledTest(requestID, testTypeID);
        }

        /// <summary>
        /// يفحص إذا كانت نتيجة الموعد مُسجلة (Pass/Fail) — يستخدم قبل التعديل
        /// </summary>
        private bool IsAppointmentResultSet(int testID)
        {
            try
            {
                string q = "SELECT Result FROM Tests WHERE TestID = @TestID";
                var p = new Dictionary<string, object>() { { "@TestID", testID } };
                var dt = ClsCommandDB.SelectCommand(q, p);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var v = dt.Rows[0][0];
                    return (v != DBNull.Value && !string.IsNullOrWhiteSpace(v.ToString()));
                }
            }
            catch { }
            return false;
        }


        /// <summary>
        /// يمنع ادخال تاريخ قد فات في وضع الاضافة
        /// ويمكن تعديل تاريخ قد فات في وضع التعديل
        /// </summary>
        void CheckIdDate()
        {
            if (_Mode == enMode.Update && _TestAppointmentID > 0)
            {
                var appt = GetTestAppointment(_TestAppointmentID);

                if (appt != null)
                {
                    DateTime examDate = Convert.ToDateTime(appt["ExamDate"]);

                    // إذا التاريخ قد فات → امنع التعديل نهائياً
                    if (examDate < DateTime.Today)
                    {
                        MessageBox.Show("لا يمكن تعديل موعد اختبار قد مضى.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return;
                    }

                    // تعبئة البيانات
                    PopulateAppointmentInfo(appt);
                }
            }
            if (_Mode == enMode.AddNew)
            {
                dtpTestDate.MinDate = DateTime.Today;
            }

        }

        
        private void btnSave_Click_1(object sender, EventArgs e) // زر الحفظ
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
                // التحقق من وجود موعد فعّال مسبقاً لنفس الطلب ونوع الاختبار
                if (IsThereActiveScheduledTestLocal(_LocalDrivingLicenseApplicationID, (int)TestTypeID))
                {
                    MessageBox.Show("يوجد بالفعل موعد اختبار فعّال لهذا الطلب ولنفس نوع الاختبار.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // منع جدولة اختبار جديد إذا كان الشخص ناجحاً مسبقاً في نفس نوع الاختبار
                if (_ApplicantPersonID > 0 && HasPersonPassedTestTypeLocal(_ApplicantPersonID, (int)TestTypeID))
                {
                    MessageBox.Show("لا يمكن جدولة الاختبار لأن الشخص نجح مسبقاً في نفس نوع الاختبار.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // حساب الرسوم النهائية (رسوم الاختبار + رسوم إعادة الاختبار إن وُجدت)
                int totalFees = ApplyFeesRules();

                int IDUser = (ClassUser.IDUser <= 0) ? 3 : ClassUser.IDUser;

                // استدعاء ميثود الإدراج مع الرسوم النهائية
                int newID = AddTestAppointment(dtpTestDate.Value.Date, totalFees, _LocalDrivingLicenseApplicationID, (int)TestTypeID, IDUser);

                if (newID > 0)
                {
                    MessageBox.Show("تم حفظ موعد الاختبار بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // تحديث واجهة الرسوم بعد الحفظ
                    ApplyFeesRules();
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

                // منع التعديل إذا كانت نتيجة الاختبار قد ظهرت
                if (IsAppointmentResultSet(_TestAppointmentID))
                {
                    MessageBox.Show("لا يمكن تعديل الموعد لأن نتيجة الاختبار مسجلة بالفعل.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // حساب الرسوم النهائية بعد التعديل
                int totalFees = ApplyFeesRules();

                int result = UpdateTestAppointment(_TestAppointmentID, dtpTestDate.Value.Date, totalFees);

                if (result > 0)
                {
                    MessageBox.Show("تم تعديل موعد الاختبار بنجاح.", "تم التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // تحديث واجهة الرسوم بعد التعديل
                    ApplyFeesRules();
                    OnAppointmentSaved?.Invoke(); //   إطلاق الحدث 
                }
                else
                    MessageBox.Show("فشل في تعديل موعد الاختبار.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
