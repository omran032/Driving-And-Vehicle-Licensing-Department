using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Class.Class_DB
{
    public class ClassAuditLogs
    {


        public enum LogAction
        {
            // ============================
            // 1) الرخص المحلية Local Licenses
            // ============================
            AddLocalLicense,
            UpdateLocalLicense,
            DeleteLocalLicense,
            RenewLocalLicense,
            ReplaceLostLocalLicense,
            ReplaceDamagedLocalLicense,

            // ============================
            // 2) الرخص الدولية International Licenses
            // ============================
            AddInternationalLicense,
            UpdateInternationalLicense,
            DeleteInternationalLicense,
            RenewInternationalLicense,
            ActivateInternationalLicense,
            DeactivateInternationalLicense,

            // ============================
            // 3) الحجز وفك الحجز License Holds
            // ============================
            HoldLicense,
            ReleaseLicense,
            UpdateLicenseHold,
            DeleteLicenseHold,

            // ============================
            // 4) الاختبارات Tests
            // ============================
            AddTest,
            UpdateTest,
            DeleteTest,

            PassVisionTest,
            FailVisionTest,

            PassWrittenTest,
            FailWrittenTest,

            PassDrivingTest,
            FailDrivingTest,

            // ============================
            // 5) الطلبات Requests
            // ============================
            AddRequest,
            UpdateRequest,
            DeleteRequest,
            ApproveRequest,
            RejectRequest,

            // ============================
            // 6) أنواع الطلبات Request Types
            // ============================
            AddRequestType,
            UpdateRequestType,
            DeleteRequestType,

            // ============================
            // 7) أنواع الاختبارات Test Types
            // ============================
            AddTestType,
            UpdateTestType,
            DeleteTestType,
            SetTestResult,
            // ============================
            // 8) فئات الرخص License Classes
            // ============================
            AddLicenseClass,
            UpdateLicenseClass,
            DeleteLicenseClass,

            // ============================
            // 9) فئات الرخص Categories
            // ============================
            AddLicenseCategory,
            UpdateLicenseCategory,
            DeleteLicenseCategory,

            // ============================
            // 10) المستخدمين Users
            // ============================
            UserLogin,
            UserLogout,
            AddUser,
            UpdateUser,
            DeleteUser,
            ActivateUser,
            DeactivateUser,

            // ============================
            // 11) الأشخاص Persons
            // ============================
            AddPerson,
            UpdatePerson,
            DeletePerson,

            // ============================
            // 12) السائقين Drivers
            // ============================
            AddDriver,
            UpdateDriver,
            DeleteDriver,

            // ============================
            // 13) عمليات عامة
            // ============================
            DatabaseBackup,
            DatabaseRestore,
            SystemError,
            GeneralAction
        }


        /// <summary>
        /// تسجيل عملية في جدول AuditLogs
        /// </summary>
        public static void AddLog(LogAction action, int userID, string description = null)
        {

            string query = @"  INSERT INTO AuditLogs (Action, ActionDate, Description, IDUser)
                        VALUES                       (@Action, GETDATE(), @Description, @UserID);  ";

            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Action", action.ToString());
                    cmd.Parameters.AddWithValue("@Description", (object)description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء تسجيل العملية:\n" + ex.Message,
                    "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
