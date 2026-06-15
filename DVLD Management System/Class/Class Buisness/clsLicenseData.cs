using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Class.Class_Buisness
{
    public class clsLicenseData
    {

     

        /// <summary>
        ///
        ///  يقوم هذا الميثود بجلب معلومات رخصة القيادة من جدول Licenses
        ///  اعتماداً على رقم الرخصة (LicenseID).
        ///
        ///  في حال العثور على الرخصة:
        ///     - يرجع رقم الطلب المرتبط بها (RequestID)
        ///     - يرجع فئة الرخصة (LicenseClassID)
        ///     - يرجع فئة التصنيف (CategoryID)
        ///     - يرجع تاريخ الإصدار والانتهاء
        ///     - يرجع حالة الإصدار (StatusRelease)
        ///     - يرجع صورة الرخصة (ProfilePicture)
        ///
        ///  في حال عدم العثور على الرخصة:
        ///     - يرجع false
        ///
        ///  ملاحظة:
        ///  هذا الميثود متوافق 100% مع بنية قاعدة البيانات الخاصة بك.
        ///
        /// </summary>

        public static bool GetLicenseInfoByID(
    int LicenseID,
    ref int RequestID,
    ref int LicenseClassID,
    ref int CategoryID,
    ref DateTime IssueDate,
    ref DateTime ExpirationDate,
    ref string StatusRelease,
    ref byte[] ProfilePicture
)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = @"
            SELECT 
                LicenceID,
                RequestID,
                LicenseClassID,
                CategoryID,
                RelesaseDate,
                EndDate,
                StatusRelease,
                ProfilePicture
            FROM Licenses
            WHERE LicenceID = @LicenseID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;

                        RequestID = reader["RequestID"] != DBNull.Value ? Convert.ToInt32(reader["RequestID"]) : -1;
                        LicenseClassID = reader["LicenseClassID"] != DBNull.Value ? Convert.ToInt32(reader["LicenseClassID"]) : -1;
                        CategoryID = reader["CategoryID"] != DBNull.Value ? Convert.ToInt32(reader["CategoryID"]) : -1;

                        IssueDate = reader["RelesaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["RelesaseDate"]) : DateTime.MinValue;
                        ExpirationDate = reader["EndDate"] != DBNull.Value ? Convert.ToDateTime(reader["EndDate"]) : DateTime.MinValue;

                        StatusRelease = reader["StatusRelease"] != DBNull.Value ? reader["StatusRelease"].ToString() : "Unknown";

                        ProfilePicture = reader["ProfilePicture"] != DBNull.Value ? (byte[])reader["ProfilePicture"] : null;
                    }

                    reader.Close();
                }
                catch
                {
                    isFound = false;
                }
            }

            return isFound;
        }








        /// <summary>
        /// 
        /// </summary>
        /// <param name="RequestID"></param>
        /// <returns></returns>
        public static int GetLicenseIDByRequestID(int RequestID)
        {
            int LicenseID = -1;

            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = "SELECT LicenceID FROM Licenses WHERE RequestID = @RequestID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RequestID", RequestID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                        LicenseID = Convert.ToInt32(result);
                }
                catch
                {
                    LicenseID = -1;
                }
            }

            return LicenseID;
        }










        public static DataTable GetAllLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = "SELECT * FROM Licenses";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable GetDriverLicenses(int DriverID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
             DateTime IssueDate, DateTime ExpirationDate, string Notes,
             float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = @"
                              INSERT INTO Licenses
                               (ApplicationID,
                                DriverID,
                                LicenseClass,
                                IssueDate,
                                ExpirationDate,
                                Notes,
                                PaidFees,
                                IsActive,IssueReason,
                                CreatedByUserID)
                         VALUES
                               (
                               @ApplicationID,
                               @DriverID,
                               @LicenseClass,
                               @IssueDate,
                               @ExpirationDate,
                               @Notes,
                               @PaidFees,
                               @IsActive,@IssueReason, 
                               @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);

            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes == "")
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseID;

        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
             DateTime IssueDate, DateTime ExpirationDate, string Notes,
             float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = @"UPDATE Licenses
                           SET ApplicationID=@ApplicationID, DriverID = @DriverID,
                              LicenseClass = @LicenseClass,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              Notes = @Notes,
                              PaidFees = @PaidFees,
                              IsActive = @IsActive,IssueReason=@IssueReason,
                              CreatedByUserID = @CreatedByUserID
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes == "")
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseID;
        }

        public static bool DeactivateLicense(int LicenseID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = @"UPDATE Licenses
                           SET 
                              IsActive = 0
                             
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
