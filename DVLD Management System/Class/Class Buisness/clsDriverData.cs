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
    public class clsDriverData
    {

        public static bool GetDriverInfoByDriverID(int DriverID,
            ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        /// <summary>
        /// يجلب معلومات السائق من جدول Drivers اعتماداً على PersonID.
        /// يعيد DriverID و CreatedByUserID و CreatedDate.
        /// </summary>
        public static bool GetDriverInfoByPersonID(
            int PersonID,
            ref int DriverID,
            ref int CreatedByUserID,
            ref DateTime CreatedDate)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = "SELECT DriverID, CreatedByUserID, CreatedDate FROM Drivers WHERE PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;

                        DriverID = reader["DriverID"] != DBNull.Value ? Convert.ToInt32(reader["DriverID"]) : -1;
                        CreatedByUserID = reader["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(reader["CreatedByUserID"]) : -1;
                        CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : DateTime.MinValue;
                    }
                }
                catch
                {
                    isFound = false;
                }
            }

            return isFound;
        }


        public static DataTable GetAllDrivers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = "SELECT * FROM Drivers_View order by FullName";

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

        /// <summary>
        /// ينشئ سائقاً جديداً في جدول Drivers ويعيد رقم DriverID.
        /// يعتمد على PersonID و CreatedByUserID،
        /// ويقوم بتوليد CreatedDate تلقائياً.
        /// </summary>
        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            int DriverID = -1;

            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = @"Insert Into Drivers (PersonID,CreatedByUserID,CreatedDate)
                         Values (@PersonID,@CreatedByUserID,@CreatedDate);
                         SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        DriverID = insertedID;
                }
                catch
                {
                    DriverID = -1;
                }
            }

            return DriverID;
        }


        /// <summary>
        /// يقوم بتحديث بيانات السائق في جدول Drivers.
        /// لا يتم تعديل CreatedDate لأنه يمثل تاريخ إنشاء السائق.
        /// يعيد true إذا تم تحديث سجل واحد على الأقل.
        /// </summary>
        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = @"
            UPDATE Drivers
            SET PersonID = @PersonID,
                CreatedByUserID = @CreatedByUserID
            WHERE DriverID = @DriverID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
            }

            return (rowsAffected > 0);
        }

    }

}
