using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Drivers.Class
{
    public class ClassDriver_DB
    {



        public enum enDriverFilter
        {
            None = 0,
            DriverID = 1,
            PersonID = 2,
            NationalNo = 3,
            FullName = 4
        }


        /// <summary>
        /// جلب قائمة السائقين مع إمكانية الفلترة حسب:
        /// None, DriverID, PersonID, NationalNo, FullName.
        /// ترجع جدول يحتوي:
        /// DriverID, PersonID, Phone, NationalNum,
        /// ActiveLicenses (عدد الرخص الفعالة),
        /// Date (تاريخ آخر رخصة حصل عليها).
        /// </summary>
        public static DataTable GetDriversWithFilter(enDriverFilter filterType, string filterValue = "")
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ClsConnection.ConnectionString))
            {
                // الاستعلام 
                string query = @"
SELECT 
    D.DriverID,
    P.IDPerson AS PersonID,
    P.NumPhone as Phone ,
    P.[National number] AS NationalNum,

    -- عدد الرخص الفعّالة
    (SELECT COUNT(*) 
     FROM Licenses L 
     WHERE L.DriverID = D.DriverID AND L.StatusRelease = 1) AS ActiveLicenses,

    -- تاريخ آخر رخصة
    (SELECT MAX(L2.RelesaseDate)
     FROM Licenses L2
     WHERE L2.DriverID = D.DriverID) AS [Date]

FROM Drivers D
INNER JOIN Persons P ON D.PersonID = P.IDPerson ";

                // بناء شرط الفلترة
                string where = "";

                switch (filterType)
                {
                    case enDriverFilter.DriverID:
                        where = "WHERE D.DriverID = @Value";
                        break;

                    case enDriverFilter.PersonID:
                        where = "WHERE P.IDPerson = @Value";
                        break;

                    case enDriverFilter.NationalNo:
                        where = "WHERE P.[National number] LIKE '%' + @Value + '%'";
                        break;

                    case enDriverFilter.FullName:
                        where = "WHERE P.FullName LIKE '%' + @Value + '%'";
                        break;

                    case enDriverFilter.None:
                    default:
                        where = "";
                        break;
                }

                query += " " + where + " ORDER BY D.DriverID ASC";

                SqlCommand cmd = new SqlCommand(query, con);

                // إضافة قيمة الفلتر إذا كان هناك فلتر
                if (filterType != enDriverFilter.None)
                {
                    // إذا كان DriverID أو PersonID → لازم يتحول لرقم
                    if (filterType == enDriverFilter.DriverID || filterType == enDriverFilter.PersonID)
                        cmd.Parameters.AddWithValue("@Value", Convert.ToInt32(filterValue));
                    else
                        cmd.Parameters.AddWithValue("@Value", filterValue);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }



        /// <summary>
        /// ترجع جميع الرخص المحلية لشخص معيّن مع معلوماتها الأساسية
        /// وتعتمد على StatusRelease لتحديد فعالية الرخصة.
        /// </summary>
        public static DataTable GetAllLocalLicensesForPerson(int PersonID)
        {
            DataTable dt = new DataTable();

            string query = @"
    SELECT 
        L.LicenceID,
        L.RequestID AS ApplicationID,
        LC.ClassName,
        L.RelesaseDate AS IssueDate,
        L.EndDate AS [End Date],
        L.StatusRelease AS IsActive
    FROM Licenses L
    INNER JOIN LicenseClass LC 
        ON LC.LicenseClassID = L.LicenseClassID
    INNER JOIN Drivers D
        ON D.DriverID = L.DriverID
    WHERE D.PersonID = @PersonID
    ORDER BY L.RelesaseDate DESC;
";

            using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PersonID", PersonID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }

            return dt;
        }


        /// <summary>
        /// ترجع جميع الرخص الدولية لشخص معيّن مع معلوماتها الأساسية
        /// وتعتمد على عمود Status (BIT) لتحديد فعالية الرخصة.
        /// </summary>
        public static DataTable GetAllInternationalLicensesForPerson(int PersonID)
        {
            DataTable dt = new DataTable();

            string query = @"
    SELECT 
        IL.interLicenseID AS LicenseID,
        L.RequestID AS ApplicationID,
        IL.IssueDate,
        IL.ExpiryDate AS ExpirationDate,
        IL.Status AS IsActive
    FROM InternationalLicenses IL
    INNER JOIN Licenses L 
        ON L.LicenceID = IL.LicenceID
    INNER JOIN Drivers D
        ON D.DriverID = L.DriverID
    WHERE D.PersonID = @PersonID
    ORDER BY IL.IssueDate DESC;
    ";

            using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@PersonID", PersonID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }

            return dt;
        }





    }
}
