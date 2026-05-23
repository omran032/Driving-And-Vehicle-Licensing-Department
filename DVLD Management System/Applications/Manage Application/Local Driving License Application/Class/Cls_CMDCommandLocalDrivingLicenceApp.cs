using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
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


    }
}
