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

namespace DVLD_Management_System.International_License.Class
{
    /// <summary>
    /// كلاس يحتوي على اوامر لقاعدة البيانات الخصة بالرخص الدولية
    /// </summary>
    public class Cls_InternationalLicenseCMD
    {

        public enum enInterLicenseFilter
        {
            All,
            InternationalLicenseID,
            ApplicationID,
            DriverID,
            LocalLicenseID,
            IsActive
        }

        public enum enIsActiveFilter
        {
            All,
            Yes,
            No
        }


        /// <summary>
        /// ترجع جدول الرخص الدولية مع خيارات فلترة متعددة:
        /// - International License ID
        /// - Application ID (RequestID)
        /// - DriverID
        /// - Local License ID
        /// - IsActive (Yes / No / All)
        /// </summary>
        public static DataTable GetInternationalLicensesWithFilter ( enInterLicenseFilter filterType,  string filterValue = "", enIsActiveFilter activeFilter = enIsActiveFilter.All )
        {
            DataTable dt = new DataTable();

            string query = @"
        SELECT 
            IL.interLicenseID AS InternationalLicenseID,
            IL.LicenceID AS LocalLicenseID,
            L.RequestID AS ApplicationID,
            L.DriverID AS DriverID,
            IL.IssueDate,
            IL.ExpiryDate,
            CAST(IL.IsActive AS BIT) AS IsActive
        FROM InternationalLicenses IL
        INNER JOIN Licenses L
            ON L.LicenceID = IL.LicenceID
        WHERE 1 = 1 ";

            var parameters = new Dictionary<string, object>();

            // ---------------------------
            // فلترة IsActive
            // ---------------------------
            switch (activeFilter)
            {
                case enIsActiveFilter.Yes:
                    query += " AND IL.IsActive = 1";
                    break;

                case enIsActiveFilter.No:
                    query += " AND IL.IsActive = 0";
                    break;

                case enIsActiveFilter.All:
                default:
                    break;
            }

            // ---------------------------
            // فلترة حسب نوع البحث
            // ---------------------------
            switch (filterType)
            {
                case enInterLicenseFilter.InternationalLicenseID:
                    query += " AND IL.interLicenseID = @InterID";
                    parameters.Add("@InterID", int.Parse(filterValue));
                    break;

                case enInterLicenseFilter.ApplicationID:
                    query += " AND L.RequestID = @AppID";
                    parameters.Add("@AppID", int.Parse(filterValue));
                    break;

                case enInterLicenseFilter.DriverID:
                    query += " AND L.DriverID = @DriverID";
                    parameters.Add("@DriverID", int.Parse(filterValue));
                    break;

                case enInterLicenseFilter.LocalLicenseID:
                    query += " AND IL.LicenceID = @LocalID";
                    parameters.Add("@LocalID", int.Parse(filterValue));
                    break;

                case enInterLicenseFilter.IsActive:
                    // تمت معالجتها فوق
                    break;

                case enInterLicenseFilter.All:
                default:
                    break;
            }

            query += " ORDER BY IL.IssueDate DESC";

            try
            {
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
            catch
            {
                return null;
            }
        }




        /// <summary>
        /// تتحقق إذا كانت الرخصة المحلية تمتلك رخصة دولية.
        /// ترجع:
        /// - true  : إذا كانت الرخصة لها سجل في InternationalLicenses
        /// - false : إذا لم يكن لها أي رخصة دولية
        /// </summary>
        public static bool IsInternationalLicenseExists(int licenseID)
        {
            string query = @"
        SELECT COUNT(*) 
        FROM InternationalLicenses
        WHERE LicenceID = @LicenseID;  ";

            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LicenseID", licenseID);

                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء التحقق من الرخصة الدولية: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }









        /// <summary>
        /// تنشئ رخصة دولية جديدة لشخص معيّن.
        /// الخطوات:
        /// 1) إنشاء طلب إصدار رخصة دولية (Request)
        /// 2) إصدار الرخصة الدولية وربطها بالرخصة المحلية
        /// ترجع رقم الرخصة الدولية الجديدة، أو -1 في حال حدوث خطأ.
        /// </summary>
        public static int CreateInternationalLicense(int localLicenseID, int personID, int createdByUserID)
        {
            try
            {
                int requestID = -1;

                using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
                {
                    conn.Open();

                    // -----------------------------
                    // 1) إنشاء طلب إصدار رخصة دولية
                    // -----------------------------
                    string insertRequestQuery = @"
                INSERT INTO Requests (Status, Fees, DateRequest, IDPerson, RequestTypeID, CreateByUserID)
                VALUES (1, 5000, GETDATE(), @PersonID, @RequestTypeID, @UserID);

                SELECT SCOPE_IDENTITY();   ";

                    using (SqlCommand cmd = new SqlCommand(insertRequestQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@PersonID", personID);
                        cmd.Parameters.AddWithValue("@UserID", createdByUserID);
                        cmd.Parameters.AddWithValue("@RequestTypeID", 1); // نوع طلب: رخصة دولية (عدّل الرقم حسب جدولك)

                        requestID = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    if (requestID <= 0)
                        return -1;

                    // -----------------------------
                    // 2) إصدار الرخصة الدولية
                    // -----------------------------
                    string insertInterLicenseQuery = @"
                INSERT INTO InternationalLicenses (IssueDate, ExpiryDate                 , Status  , LicenceID      , IsActive)
                VALUES                            (GETDATE(), DATEADD(YEAR, 5, GETDATE()), 'Active', @LocalLicenseID, 1);

                SELECT SCOPE_IDENTITY(); ";

                    using (SqlCommand cmd = new SqlCommand(insertInterLicenseQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@LocalLicenseID", localLicenseID);

                        int interLicenseID = Convert.ToInt32(cmd.ExecuteScalar());
                        return interLicenseID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تنفيذ الأمر في القاعدة أثناء إنشاء الرخصة الدولية: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }



        public enum enInterLicenseSearchBy
        {
            LicenseID,
            DriverID
        }

        /// <summary>
        /// تجلب معلومات الرخصة الدولية حسب LicenseID أو DriverID.
        /// ترجع كائن Cls_InternationalLicenseInfo جاهز.
        /// </summary>
        public static Cls_InternationalLicenseInfo GetInternationalLicenseInfo( enInterLicenseSearchBy searchBy, int value )
        {
            string query = @"
        SELECT 
            IL.interLicenseID,
            IL.IssueDate,
            IL.ExpiryDate,
            IL.IsActive,
            IL.LicenceID AS LocalLicenseID,

            L.RequestID,
            L.DriverID,

            P.IDPerson,
            P.FullName,
            P.Housing,
            P.NumPhone,
            P.Email,
            P.Nationality,
            P.[National number],
            P.Gender,
            P.Birthdate,
            P.Picture

        FROM InternationalLicenses IL
        INNER JOIN Licenses L
            ON L.LicenceID = IL.LicenceID
        INNER JOIN Drivers D
            ON D.DriverID = L.DriverID
        INNER JOIN Persons P
            ON P.IDPerson = D.PersonID
        WHERE 1 = 1
    ";

            // إضافة شرط البحث
            if (searchBy == enInterLicenseSearchBy.LicenseID)
                query += " AND IL.LicenceID = @Value";
            else
                query += " AND L.DriverID = @Value";

            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Value", value);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        // تعبئة معلومات الشخص
                        Person person = new Person()
                        {
                            IDPerson = reader.GetInt32(reader.GetOrdinal("IDPerson")),
                            FullName = reader["FullName"]?.ToString(),
                            Housing = reader["Housing"]?.ToString(),
                            NumPhone = reader["NumPhone"]?.ToString(),
                            Email = reader["Email"]?.ToString(),
                            Nationality = reader["Nationality"]?.ToString(),
                            National_Number = reader["National number"]?.ToString(),
                            Gender = reader["Gender"]?.ToString(),
                            Birthdate = Convert.ToDateTime(reader["Birthdate"]),
                            Picture = reader["Picture"] == DBNull.Value ? null : (byte[])reader["Picture"]
                        };

                        // تعبئة معلومات الرخصة الدولية
                        Cls_InternationalLicenseInfo info = new Cls_InternationalLicenseInfo()
                        {
                            PersonInfo = person,

                            inernationalLicenseID = reader.GetInt32(reader.GetOrdinal("interLicenseID")),
                            IssueDate = Convert.ToDateTime(reader["IssueDate"]),
                            ExpirationDate = Convert.ToDateTime(reader["ExpiryDate"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"]),

                            LoclLicenseID = reader.GetInt32(reader.GetOrdinal("LocalLicenseID")),
                            RequestID = reader.GetInt32(reader.GetOrdinal("RequestID")),
                            DriverID = reader.GetInt32(reader.GetOrdinal("DriverID"))
                        };

                        return info;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء جلب معلومات الرخصة الدولية: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



    }
}
