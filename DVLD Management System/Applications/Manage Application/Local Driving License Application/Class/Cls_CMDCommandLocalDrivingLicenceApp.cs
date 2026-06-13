using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class
{
    internal class Cls_CMDCommandLocalDrivingLicenceApp
    {
        /// <summary>
        ///  تغيير حالة طلب الرخصة
        /// -1  = Cansle  // 0 = New  // 1 = Completed
        /// </summary>
        public static bool UpdateRequestStatus(int requestID, int newStatus)
        {
            string query = @"UPDATE Requests 
                     SET Status = @Status 
                     WHERE RequestID = @RequestID";

            var parameters = new Dictionary<string, object>()
            {
               { "@Status", newStatus },
               { "@RequestID", requestID }
            };

            // تنفيذ الأمر
            var result = ClsCommandDB.ExecuteNonQuery_Command(query, parameters, false);

            //    يرجع عدد الصفوف المتأثرة  
            return (result != null && Convert.ToInt32(result) > 0);
        }


        /// <summary>
        /// حذف طلب رخصة قيادة
        /// </summary>
        /// <param name="requestID">معرف الرخصة</param>
        public static bool DeleteRequestByID(int requestID)
        {
            // 1) التحقق من وجود اختبارات مرتبطة بالطلب
            string checkTests = @"SELECT COUNT(*) FROM Tests WHERE RequestID = @RequestID";
            var p1 = new Dictionary<string, object>() { { "@RequestID", requestID } };
            int testCount = Convert.ToInt32(ClsCommandDB.ExecuteScalar_Command(checkTests, p1, false));

            if (testCount > 0)
            {
                MessageBox.Show("لا يمكن حذف الطلب لأنه مرتبط باختبارات.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2) التحقق من وجود رخصة مرتبطة بالطلب
            string checkLicense = @"SELECT COUNT(*) FROM Licenses WHERE RequestID = @RequestID";
            int licenseCount = Convert.ToInt32(ClsCommandDB.ExecuteScalar_Command(checkLicense, p1, false));

            if (licenseCount > 0)
            {
                MessageBox.Show("لا يمكن حذف الطلب لأنه تم إصدار رخصة بناءً عليه.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 3) إذا ما في أي ارتباط → نحذف الطلب
            string deleteQuery = @"DELETE FROM Requests WHERE RequestID = @RequestID";

            var result = ClsCommandDB.ExecuteNonQuery_Command(deleteQuery, p1, false);

            if (result != null && Convert.ToInt32(result) > 0)
            {
                MessageBox.Show("تم حذف الطلب بنجاح.",
                    "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("لم يتم العثور على الطلب أو لم يتم الحذف.",
                    "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        /// <summary>
        /// يرجع عدد الفحوصات التي نجح فيها الشخص.
        /// إذا لم ينجح بأي فحص يرجع 0.
        /// </summary>
        public static int GetPassedTestsCount(int personID)
        {
            string query = @"
        SELECT COUNT(*) 
        FROM Tests T
        INNER JOIN Requests R ON T.RequestID = R.RequestID
        WHERE R.IDPerson = @PersonID
        AND T.Result = 'Pass'";

            var parameters = new Dictionary<string, object>()
            {
                { "@PersonID", personID }
            };

            object result = ClsCommandDB.ExecuteScalar_Command(query, parameters, false);

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }


        /// <summary>
        /// يتحقق ما إذا كان الشخص قد نجح سابقاً في اختبار من نوع محدد
        /// </summary>
        public static bool HasPersonPassedTestType(int personID, int testTypeID)
        {
            string query = @"
        SELECT TOP 1 1
        FROM Tests T
        INNER JOIN Requests R ON T.RequestID = R.RequestID
        WHERE R.IDPerson = @PersonID
        AND T.TestTypeID = @TestTypeID
        AND T.Result = 'Pass'";

            var parameters = new Dictionary<string, object>()
            {
                { "@PersonID", personID },
                { "@TestTypeID", testTypeID }
            };

            object result = ClsCommandDB.ExecuteScalar_Command(query, parameters, false);

            return (result != null && result != DBNull.Value);
        }




        /// <summary>
        ///   تجلب هذه الدالة جميع الاختبارات المرتبطة بطلب معيّن ونوع اختبار محدد
        /// اعتماداً على مخطط DVLD (من جدول Tests فقط)
        /// وتعيد TestID و ExamDate و FeesExam و Result مرتّبة من الأحدث إلى الأقدم.
        /// </summary>
        /// <param name="RequestID"></param>
        /// <param name="TestTypeID"></param>
        /// <returns></returns>
        public static DataTable GetTestsPerType(int RequestID, int TestTypeID)
        {
                string query = @"
            SELECT 
                TestID,
                ExamDate,
                FeesExam,
                Result
            FROM Tests
            WHERE 
                TestTypeID = @TestTypeID
                AND RequestID = @RequestID
            ORDER BY TestID DESC;";

                var parameters = new Dictionary<string, object>()
            {
                { "@RequestID", RequestID },
                { "@TestTypeID", TestTypeID }
            };

            return ClsCommandDB.SelectCommand(query , parameters);
        }











        /// <summary>
        /// تتحقق هذه الدالة من وجود اختبار مجدول لنفس الطلب ولنفس نوع الاختبار
        ///    اعتماداً على أن نتيجة الاختبار (Result) نصية وتكون NULL عندما لا يتم تحديد النتيجة بعد
        /// أي أن Result IS NULL يعني أن الاختبار مجدول ولم يُنفّذ بعد.
        /// </summary>
        /// <param name="RequestID"></param>
        /// <param name="TestTypeID"></param>
        /// <returns></returns>
        public static bool IsThereAnActiveScheduledTest(int RequestID, int TestTypeID)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = @"
            SELECT TOP 1 1
            FROM Tests
            WHERE 
                RequestID = @RequestID
                AND TestTypeID = @TestTypeID
                AND Result IS NULL
            ORDER BY TestID DESC;
        ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@RequestID", RequestID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();
                    object scalar = command.ExecuteScalar();

                    if (scalar != null)
                        result = true;
                }
                catch
                {
                }
            }

            return result;
        }


    }
}
