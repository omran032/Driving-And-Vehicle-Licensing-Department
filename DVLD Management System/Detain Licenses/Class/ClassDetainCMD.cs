using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Detain_Licenses.Class
{
    public class ClassDetainCMD
    {

        /// <summary>
        /// ترجع جدولاً يحتوي معلومات الرخص المحجوزة مع بيانات الشخص
        /// </summary>
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            string query = @"
    SELECT 
        LH.HoldID AS DetainID,
        LH.LicenceID AS LicenseID,
        LH.HoldDate AS DetainDate,

        CASE 
            WHEN LH.ReleasedDate IS NULL THEN CAST(0 AS BIT)
            ELSE CAST(1 AS BIT)
        END AS IsReleased,

        LH.PenaltyAmount AS FineFees,
        LH.ReleasedDate AS ReleaseDate,

        P.[National number] AS NationalNumber,
        P.FullName AS FullName,

        NULL AS ReleaseRequestID
    FROM LicenseHolds LH
    INNER JOIN Licenses L 
        ON L.LicenceID = LH.LicenceID
    INNER JOIN Drivers D
        ON D.DriverID = L.DriverID
    INNER JOIN Persons P
        ON P.IDPerson = D.PersonID
    ORDER BY LH.HoldDate DESC;
    ";

            using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }



        public enum enDetainFilter
        {
            None,
            DetainID,
            IsReleased,
            NationalNo,
            FullName,
            ReleaseApplicationID
        }

        public enum enIsReleasedFilter
        {
            All,        // عرض الكل
            Released,   // ReleasedDate NOT NULL
            NotReleased // ReleasedDate IS NULL
        }


        /// <summary>
        /// ترجع جدول الرخص المحجوزة مع الفلترة حسب عدة خيارات
        /// </summary>
        public static DataTable GetDetainedLicensesWithFilter(  enDetainFilter filterType,  string filterValue = "",  enIsReleasedFilter isReleasedFilter = enIsReleasedFilter.All)
        {
            DataTable dt = new DataTable();

            string query = @"
    SELECT 
        LH.HoldID AS DetainID,
        LH.LicenceID AS LicenseID,
        LH.HoldDate AS DetainDate,

        CASE 
            WHEN LH.ReleasedDate IS NULL THEN CAST(0 AS BIT)
            ELSE CAST(1 AS BIT)
        END AS IsReleased,

        LH.PenaltyAmount AS FineFees,
        LH.ReleasedDate AS ReleaseDate,

        P.[National number] AS NationalNumber,
        P.FullName AS FullName,
        p.IDPerson As [ID Person]

       -- NULL AS ReleaseRequestID
    FROM LicenseHolds LH
    INNER JOIN Licenses L 
        ON L.LicenceID = LH.LicenceID
    INNER JOIN Drivers D
        ON D.DriverID = L.DriverID
    INNER JOIN Persons P
        ON P.IDPerson = D.PersonID
    WHERE 1 = 1
    ";

            var parameters = new Dictionary<string, object>();

            // ---------------------------
            // فلترة IsReleased Enum
            // ---------------------------
            switch (isReleasedFilter)
            {
                case enIsReleasedFilter.Released:
                    query += " AND LH.ReleasedDate IS NOT NULL";
                    break;

                case enIsReleasedFilter.NotReleased:
                    query += " AND LH.ReleasedDate IS NULL";
                    break;

                case enIsReleasedFilter.All:
                default:
                    break;
            }
            try
            {
                // ---------------------------
                // فلترة حسب نوع البحث
                // ---------------------------
                switch (filterType)
                {
                    case enDetainFilter.DetainID:
                        query += " AND LH.HoldID = @HoldID";
                        parameters.Add("@HoldID", int.Parse(filterValue));
                        break;

                    case enDetainFilter.NationalNo:
                        query += " AND P.[National number] LIKE '%' + @NationalNo + '%'";
                        parameters.Add("@NationalNo", filterValue);
                        break;

                    case enDetainFilter.FullName:
                        query += " AND P.FullName LIKE '%' + @FullName + '%'";
                        parameters.Add("@FullName", filterValue);
                        break;

                    case enDetainFilter.ReleaseApplicationID:
                        query += " AND LH.ReleaseRequestID = @ReleaseRequestID";
                        parameters.Add("@ReleaseRequestID", int.Parse(filterValue));
                        break;

                    case enDetainFilter.IsReleased:
                        // تم التعامل معها عبر enum فوق
                        break;

                    case enDetainFilter.None:
                    default:
                        break;
                }

                query += " ORDER BY LH.HoldDate DESC";

                using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }

                return dt;
            }
            catch { return null; }


        }




        /// <summary>
        /// يتحقق ما إذا كانت الرخصة محجوزة حالياً (ReleasedDate = NULL)
        /// </summary>
        public static bool IsLicenseDetained(int licenseID)
        {
            string query = @"
        SELECT TOP 1 1
        FROM LicenseHolds
        WHERE LicenceID = @LicenseID
          AND ReleasedDate IS NULL";   // يعني ما زالت محجوزة

            var parameters = new Dictionary<string, object>()
            {
                { "@LicenseID", licenseID }
            };

            object result = ClsCommandDB.ExecuteScalar_Command(query, parameters, false);

            return (result != null && result != DBNull.Value);
        }


        /// <summary>
        /// يتحقق ما إذا كانت الرخصة فعّالة (Active) أم لا
        /// </summary>
        public static bool IsLicenseActive(int licenseID)
        {
            string query = @"
        SELECT StatusRelease
        FROM Licenses
        WHERE LicenceID = @LicenseID";

            var parameters = new Dictionary<string, object>()
            {
                { "@LicenseID", licenseID }
            };

            object result = ClsCommandDB.ExecuteScalar_Command(query, parameters, false);

            if (result == null || result == DBNull.Value)
                return false; // الرخصة غير موجودة

            return Convert.ToBoolean(result); // 1 = Active, 0 = Inactive
        }


        /// <summary>
        /// يحجز رخصة معينة إذا لم تكن محجوزة مسبقاً.
        ///
        /// حالات الإرجاع:
        /// - true  : تم حجز الرخصة بنجاح (تم إضافة سجل جديد في LicenseHolds).
        /// - false : لم يتم الحجز لأن الرخصة محجوزة مسبقاً (ReleasedDate IS NULL)
        ///           أو لم يتم إدراج أي سجل.
        /// </summary>
        public static bool DetainLicense(int licenseID, string reason, int penaltyAmount)
        {
            string query = @"
    INSERT INTO LicenseHolds (HoldDate, Reason, PenaltyAmount, ReleasedDate, LicenceID)
    SELECT @HoldDate, @Reason, @PenaltyAmount, NULL, @LicenseID
    WHERE NOT EXISTS (
        SELECT 1 
        FROM LicenseHolds 
        WHERE LicenceID = @LicenseID 
          AND ReleasedDate IS NULL
                    );";

            var parameters = new Dictionary<string, object>()
            {
                { "@HoldDate", DateTime.Now.Date },
                { "@Reason", reason },
                { "@PenaltyAmount", penaltyAmount },
                { "@LicenseID", licenseID }
            };

             object result = ClsCommandDB.ExecuteNonQuery_Command(query, parameters, false);

            // إذا رجعت null → يعني صار خطأ
            if (result == null || result == DBNull.Value)
                return false;

            // تحويل القيمة لعدد الصفوف المتأثرة
            int rowsAffected = Convert.ToInt32(result);

            return rowsAffected > 0;
        }


        /// <summary>
        /// يرجع معلومات الحجز الحالية لرخصة معيّنة ضمن كائن ClassDetainInfo.
        /// إذا لم تكن الرخصة محجوزة → يرجع null.
        /// </summary>
        public static ClassDetainInfo GetActiveDetainInfo(int licenseID)
        {
            string query = @"
        SELECT 
            LH.HoldID AS DetainID,
            LH.Reason,
            LH.PenaltyAmount AS Fees,
            LH.HoldDate AS DetainDate
        FROM LicenseHolds LH
        WHERE LH.LicenceID = @LicenseID
          AND LH.ReleasedDate IS NULL;";

            var parameters = new Dictionary<string, object>()
            {
                { "@LicenseID", licenseID }
            };

            DataTable dt = ClsCommandDB.SelectCommand(query, parameters);

            if (dt.Rows.Count == 0)
                return null; // لا يوجد حجز حالي

            DataRow row = dt.Rows[0];

            return new ClassDetainInfo
            {
                LicenseID = licenseID,
                DetainID = Convert.ToInt32(row["DetainID"]),
                Reason = row["Reason"].ToString(),
                Fees = Convert.ToInt32(row["Fees"]),
                DeainDate = Convert.ToDateTime(row["DetainDate"])
            };
        }


        /// <summary>
        /// يفك حجز رخصة معيّنة إذا كانت محجوزة حالياً.
        ///
        /// حالات الإرجاع:
        /// - true  : تم فك الحجز بنجاح (تم تحديث ReleasedDate).
        /// - false : لم يتم فك الحجز لأن الرخصة غير محجوزة حالياً
        ///           أو لم يتم تحديث أي سجل.
        ///
        /// ملاحظة:
        /// يتم التنفيذ بكويري واحد فقط باستخدام UPDATE مع شرط ReleasedDate IS NULL
        /// لضمان عدم فتح اتصالين مع قاعدة البيانات.
        /// </summary>
        public static bool ReleaseLicense(int licenseID)
        {
            string query = @"
        UPDATE LicenseHolds
        SET ReleasedDate = @ReleaseDate
        WHERE LicenceID = @LicenseID
          AND ReleasedDate IS NULL;   -- فقط الحجز الحالي";

            var parameters = new Dictionary<string, object>()
            {
                { "@ReleaseDate", DateTime.Now.Date },
                { "@LicenseID", licenseID }
            };

            object result = ClsCommandDB.ExecuteNonQuery_Command(query, parameters, false);

            if (result == null || result == DBNull.Value)
                return false;

            int rowsAffected = Convert.ToInt32(result);

            return rowsAffected > 0;
        }

    }
}
