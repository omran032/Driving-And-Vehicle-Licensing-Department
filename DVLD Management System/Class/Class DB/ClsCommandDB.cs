using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Management_System.Class.Class_DB.ClsConnection;
 


namespace DVLD_Management_System.Class.Class_DB
{
    static class ClsCommandDB
    {


        /// <summary>
        /// تنفيذ كويري استعلام
        /// </summary>
        public static DataTable SelectCommand(string Query)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
               
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        /// <summary>
        /// تنفيذ كويري استعلام مع بارامترات
        /// </summary>
        public static DataTable SelectCommand(string Query, Dictionary<string, object> parameter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();

                foreach (var param in parameter)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        /// <summary>
        /// تنفيذ استعلام يقوم ب ارجاع قيمة واحدة
        /// </summary>
        /// <returns> ارجاع قيمة واحدة من الاستعلام</returns>
        public static object ExecuteScalar_Command(string Query, Dictionary<string, object> parameter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                foreach (var param in parameter)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
                return command.ExecuteScalar();
            }
        }

        /// <summary>
        ///  تنفيذ اومر التي ترجع قيمة واحدة
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public static dynamic ExecuteScalar_Command(string Query )
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
             
                return command.ExecuteScalar();
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="parameters"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        public static object ExecuteScalar_Command(string Query, Dictionary<string, object> parameters, bool isStoredProcedure = true)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(Query, connection);
                    command.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    connection.Open();
                    return command.ExecuteScalar();   //  يرجع قيمة
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء تنفيذ ExecuteScalar: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



        /// <summary>
        /// INSERT, UPDATE, DELETE  تنفيذ كويري غير استعلامي  مثل  
        /// </summary>
        /// <param name="Query">  الكويري </param>
        /// <param name="parameter"> بارامترات </param>
        public static object ExecuteNonQuery_Command(string Query, Dictionary<string, object> parameters, bool isStoredProcedure = true)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = new SqlCommand(Query, connection);

                    // تحديد نوع الأمر
                    command.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

                    // إضافة الباراميترات
                    foreach (var param in parameters)
                    {
                        if (param.Value is SqlParameter sqlParam)
                        {
                            command.Parameters.Add(sqlParam);
                        }
                        else
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    connection.Open();
                    int rowAffect = command.ExecuteNonQuery();

                    // إذا في OUTPUT → رجّع قيمته
                    var outputParam = command.Parameters.Cast<SqlParameter>()
                                        .FirstOrDefault(p => p.Direction == ParameterDirection.Output);

                    if (outputParam != null)
                        return outputParam.Value;

                    return rowAffect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء تنفيذ الأمر: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }







        /// <summary>
        /// التحقق من المستخدم عند تسجيل الدخول
        /// </summary>
        public static bool IsExistUser(string username, string password , string Role)
        {
            password = ReturnEncrptionPassword(password);

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = @"SELECT  Authorities, IDUser, IDPerson 
                     FROM Users 
                     WHERE Username = @Username 
                     AND Password = @Password 
                     AND Role = @Role  
                     AND [Status Account] = 'Active'";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", Role);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())   // يعني وجد صف واحد على الأقل
                        {
                            // حفظ القيم
                            ClassUser.Authorities = reader["Authorities"].ToString();
                            ClassUser.IDUser = Convert.ToInt32(reader["IDUser"]);
                            ClassUser.IDPerson = Convert.ToInt32(reader["IDPerson"]);
                            ClassUser.UserName = username;
                            ClassUser.Role = Role;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("مشكلة في ", "Error in IsExistUser DB " , MessageBoxButtons.OK , MessageBoxIcon.Hand);
                return false;
            }
        }


        /// <summary>
        /// دالة لتشفير كلمة المرور باستخدام SHA256
        /// </summary>
        public static string  ReturnEncrptionPassword(string password)
        {
            // استخدام SHA256 لتشفير كلمة المرور
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


    }
}
