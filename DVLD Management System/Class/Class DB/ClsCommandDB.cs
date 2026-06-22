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
        /// ترجع true إذا كانت المعلومات صحيحة،
        /// false إذا كانت خاطئة.
        /// كما تقوم بتحميل معلومات المستخدم داخل ClassUser.
        /// </summary>
        public static bool LoginUser(string username, string password)
        {
            password = ReturnEncrptionPassword(password);

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = @"
                SELECT 
                    IDUser,
                    IDPerson,
                    UserName,
                    Role,
                    Authorities,
                    [Status Account]
                FROM Users
                WHERE UserName = @Username
                AND Password = @Password
                AND [Status Account] = 'Active'; ";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return false; // المستخدم غير موجود أو الحساب غير فعال

                        // تعبئة بيانات المستخدم
                        ClassUser.IDUser = Convert.ToInt32(reader["IDUser"]);
                        ClassUser.IDPerson = Convert.ToInt32(reader["IDPerson"]);
                        ClassUser.UserName = reader["UserName"].ToString();
                        ClassUser.Role = reader["Role"].ToString();
                        ClassUser.Authorities = reader["Authorities"].ToString();
                        ClassUser.StatusAccount = reader["Status Account"].ToString();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء تسجيل الدخول:\n" + ex.Message,
                    "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        /// التحقق من اسم المستخدم وكلمة المرور فقط.
        /// ترجع دور المستخدم (Role) إذا كان موجوداً.
        /// إذا لم يتم العثور على المستخدم → ترجع null.
        /// </summary>
        public static string GetUserRole(string username, string password)
        {
            password = ReturnEncrptionPassword(password);

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    string query = @"
                SELECT Role
                FROM Users
                WHERE UserName = @Username
                AND Password = @Password
                AND [Status Account] = 'Active';
            ";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result == null)
                        return null; // المستخدم غير موجود

                    return result.ToString(); // رجّع الدور
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء التحقق من المستخدم:\n" + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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
