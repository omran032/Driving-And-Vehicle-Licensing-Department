using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Class.Class_Buisness;
using DVLD_Management_System.Class.Class_DB;
using DVLD_Management_System.Local_Licenses.Class;
using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Management_System.Class.Class_DB.ClassAuditLogs;

namespace DVLD_Management_System.Local_Licenses
{
    /// <summary>
    /// واجهة اصدار رخصة لاول مرة
    /// </summary>
    public partial class FrmIssueDriverLicenseFirstTime : Form
    {

        private int _LocalDrivingLicenseApplicationID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClassInfoLicenseAplication InfoLicenseAplication;

        public FrmIssueDriverLicenseFirstTime(int LocalDrivingLicenseApplicationID, ClassInfoLicenseAplication InfoLicenseAplication_)
        {
            InitializeComponent();
            // Ensure Load event handler is attached so data is loaded when the form opens
            this.Load += new EventHandler(this.frmIssueDriverLicenseFirstTime_Load);
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            if (InfoLicenseAplication_ == null)
                return;
            InfoLicenseAplication = InfoLicenseAplication_;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {

            txtNotes.Focus();
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID_(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("لا يوجد طلب بالمعرّف=" + _LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // هل اجتاز الاختبارات ال 3
            //if (!_LocalDrivingLicenseApplication.PassedAllTests())
            //{

            //    MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //    return;
            //}

            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                MessageBox.Show("الشخص لديه رخصة بالفعل من قبل مع معرف الترخيص =" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrl_DLApplInfo1.InfoLicenseAplication = InfoLicenseAplication;



        }




        #region ***  التحقق ***

        /// <summary>
        /// يتحقق إذا كان الشخص يمتلك أي رخصة مسبقاً.
        /// يعيد true إذا كان لديه رخصة واحدة على الأقل.
        /// </summary>
        public static bool DoesPersonHaveLicense(int PersonID)
        {
            bool hasLicense = false;

            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = @"
            SELECT TOP 1 Lic.LicenceID
            FROM Licenses AS Lic
            INNER JOIN Requests AS Req
                ON Lic.RequestID = Req.RequestID
            WHERE Req.IDPerson = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                        hasLicense = true;
                }
                catch
                {
                    hasLicense = false;
                }
            }

            return hasLicense;
        }




        /// <summary>
        /// يتحقق إذا كان الشخص قد اجتاز جميع الاختبارات الثلاثة
        /// الخاصة بالفئة المطلوبة في طلب الرخصة.
        /// يعيد true إذا كان ناجحاً في Vision + Written + Street.
        /// </summary>
        public static bool HasPassedAllRequiredTests(int PersonID, int LicenseClassID)
        {
            bool isPassed = false;

            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = @"
            SELECT COUNT(DISTINCT T.TestTypeID) AS PassedCount
            FROM Tests T
            INNER JOIN Requests R ON T.RequestID = R.RequestID
            WHERE 
                R.IDPerson = @PersonID
                AND R.LicenseClassID = @LicenseClassID
                AND T.Result = 'Pass'";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int count))
                    {
                        // يجب أن يكون ناجحاً في 3 اختبارات مختلفة
                        isPassed = (count == 3);
                    }
                }
                catch
                {
                    isPassed = false;
                }
            }

            return isPassed;
        }




        /// <summary>
        /// يجلب رقم الفئة (LicenseClassID) اعتماداً على اسم الفئة.
        /// يعيد -1 إذا لم يتم العثور على الفئة.
        /// </summary>
        public static int GetLicenseClassIDByName(string className)
        {
            int classID = -1;

            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = @"
            SELECT LicenseClassID 
            FROM LicenseClass
            WHERE ClassName = @ClassName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClassName", className);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int id))
                        classID = id;
                }
                catch
                {
                    classID = -1;
                }
            }

            return classID;
        }



     


        #endregion


        /// <summary>
        /// ينشئ رخصة جديدة للشخص اعتماداً على بيانات ClassInfoLicenseAplication
        /// ويعيد رقم الرخصة الجديدة أو -1 عند الفشل.
        /// </summary>
        public static int CreateLicenseFromApplicationInfo(ClassInfoLicenseAplication info, int CreatedByUserID)
        {
            int licenseID = -1;

            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // ============================================================
                    // 1) الحصول على DriverID أو إنشاؤه إذا لم يكن موجوداً
                    // ============================================================

                    int driverID = -1;

                    string findDriverQuery = @"SELECT DriverID FROM Drivers WHERE PersonID = @PersonID";

                    SqlCommand findDriverCmd = new SqlCommand(findDriverQuery, connection, transaction);
                    findDriverCmd.Parameters.AddWithValue("@PersonID", info.Person.IDPerson);

                    object result = findDriverCmd.ExecuteScalar();

                    if (result != null)
                    {
                        driverID = Convert.ToInt32(result);
                    }
                    else
                    {
                        // إنشاء Driver جديد
                        string insertDriverQuery = @"
                    INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                    VALUES (@PersonID, @CreatedByUserID, GETDATE());
                    SELECT SCOPE_IDENTITY();";

                        SqlCommand insertDriverCmd = new SqlCommand(insertDriverQuery, connection, transaction);
                        insertDriverCmd.Parameters.AddWithValue("@PersonID", info.Person.IDPerson);
                        insertDriverCmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        object newDriver = insertDriverCmd.ExecuteScalar();

                        if (newDriver == null)
                        {
                            transaction.Rollback();
                            return -1;
                        }

                        driverID = Convert.ToInt32(newDriver);
                    }

                    // ============================================================
                    // 2) جلب LicenseClassID من اسم الفئة
                    // ============================================================

                    int licenseClassID = GetLicenseClassIDByName(info.LicenseClass);

                 

                    // ============================================================
                    // 3) جلب مدة الصلاحية ValidatyLength
                    // ============================================================

                    int validityYears = 0;

                    string getValidityQuery = @"SELECT ValidatyLength FROM LicenseClass WHERE LicenseClassID = @ID";

                    SqlCommand getValidityCmd = new SqlCommand(getValidityQuery, connection, transaction);
                    getValidityCmd.Parameters.AddWithValue("@ID", licenseClassID);

                    object validityResult = getValidityCmd.ExecuteScalar();

                    if (validityResult == null)
                    {
                        transaction.Rollback();
                        return -1;
                    }

                    validityYears = Convert.ToInt32(validityResult);

                    // ============================================================
                    // 4) إنشاء الرخصة الجديدة
                    // ============================================================

                    string insertLicenseQuery = @"
                INSERT INTO Licenses
                (RequestID, DriverID, LicenseClassID, CategoryID,
                 StatusRelease, RelesaseDate, EndDate, ProfilePicture)
                VALUES
                (@RequestID, @DriverID, @LicenseClassID, @CategoryID,    @StatusRelease, @RelesaseDate, @EndDate, @ProfilePicture);

                SELECT SCOPE_IDENTITY();";

                    SqlCommand insertLicenseCmd = new SqlCommand(insertLicenseQuery, connection, transaction);
                    // إضافة البارامترات
                    insertLicenseCmd.Parameters.AddWithValue("@RequestID", info.RequestID);
                    insertLicenseCmd.Parameters.AddWithValue("@DriverID", driverID);
                    insertLicenseCmd.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    insertLicenseCmd.Parameters.AddWithValue("@CategoryID", 1);

                    // لا تكرر هذا السطر مرتين
                    insertLicenseCmd.Parameters.AddWithValue("@StatusRelease", 1);

                    insertLicenseCmd.Parameters.AddWithValue("@RelesaseDate", DateTime.Now);
                    insertLicenseCmd.Parameters.AddWithValue("@EndDate", DateTime.Now.AddYears(validityYears));

                    byte[] pictureBytes;

                    if (info.Person.Picture == null)
                    {
                        // صورة افتراضية من Resources
                        pictureBytes = ImageToBytes(Properties.Resources.Male);
                    }
                    else
                    {
                        pictureBytes = info.Person.Picture;
                    }

                    insertLicenseCmd.Parameters.Add("@ProfilePicture", SqlDbType.VarBinary).Value = pictureBytes;





                    object newLicense = insertLicenseCmd.ExecuteScalar();

                    if (newLicense == null)
                    {
                        transaction.Rollback();
                        return -1;
                    }

                    licenseID = Convert.ToInt32(newLicense);

                    // ============================================================
                    // 5) إنهاء العملية
                    // ============================================================

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    return -1;
                }
            }
          

            return licenseID;
        }


        /// <summary>
        /// تقوم بتغيير حالة الطلب ل Completed
        /// وذلك بعد انشاء الرخصة لاول مرة
        /// </summary>
        /// <param name="requestId">معرف الرخصة</param>
        public static void StatusRequest_Completed(int requestId)
        {
            ///////////////////////////////////////    هاد لازم تحطه بس لما يطلع الرخصة لاول مرة ////////////////////////////////////////
            // بعد التعديل، تحقق إذا وصل العداد إلى 3 → حدّث الحالة إلى Completed
            int passed = Cls_CMDCommandLocalDrivingLicenceApp.GetRequestPassedTests(requestId);
            if (passed >= 3)
                Cls_CMDCommandLocalDrivingLicenceApp.UpdateRequestStatus(requestId, 1);
            else
                Cls_CMDCommandLocalDrivingLicenceApp.UpdateRequestStatus(requestId, 0);

            // إذا كانت واجهة FrmLocalDrivingLicenseApplication مفتوحة فحدّثها فورياً
            foreach (Form f in Application.OpenForms)
            {
                if (f is DVLD_Management_System.Applications.FrmLocalDrivingLicenseApplication frm)
                {
                    try
                    {
                        frm.RefreshData();
                    }
                    catch { }
                }
            }
        }



        /// <summary>
        /// تحويل الصورة لبايت
        /// </summary>
        private static byte[] ImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        private void btnIssueLicense_Click(object sender, EventArgs e) // زر انشاء الرخصة
        {
            // 1) التحقق إذا الشخص لديه رخصة مسبقاً
            if (DoesPersonHaveLicense(InfoLicenseAplication.Person.IDPerson))
            {
                MessageBox.Show("هذا الشخص يمتلك رخصة مسبقاً ولا يمكن إصدار رخصة جديدة.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2) متابعة الإصدار إذا لم يكن لديه رخصة
            bool ExistUserID = clsGlobal.CurrentUser == null;
            int UserID = !ExistUserID ? clsGlobal.CurrentUser.UserID : 3;



            if (!HasPassedAllRequiredTests(InfoLicenseAplication.Person.IDPerson, GetLicenseClassIDByName(InfoLicenseAplication.LicenseClass)))
            {
                MessageBox.Show("لا يمكن إصدار الرخصة لأن الشخص لم يجتز جميع الاختبارات المطلوبة.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int newLicenseID = CreateLicenseFromApplicationInfo(InfoLicenseAplication, UserID);

            if (newLicenseID != -1)
            {
                StatusRequest_Completed(InfoLicenseAplication.RequestID);
                btnIssueLicense.Enabled = false; // تعطيل الزر

                AddLog(LogAction.AddLocalLicense, ClassUser.IDUser, "إضافة رخصة محلية");   // Log: إضافة رخصة محلية
                MessageBox.Show("تم إنشاء الترخيص بنجاح. المعرف = " + newLicenseID, "تم انشاء رخصة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("فشل في إنشاء الترخيص!", "فشل انشاء رخصة", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }

}