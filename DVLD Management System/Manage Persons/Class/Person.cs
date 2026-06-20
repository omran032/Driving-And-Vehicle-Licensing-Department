using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Class.Class
{
    public class Person
    {
        public int IDPerson { get; set; }                 // رقم الشخص (Identity)
        public string FullName { get; set; }              // الاسم الكامل
        public string Housing { get; set; }               // السكن
        public string NumPhone { get; set; }              // رقم الهاتف
        public string Email { get; set; }                 // البريد الإلكتروني
        public string Nationality { get; set; }           // الجنسية
        public string National_Number { get; set; }           // الرقم الوطني
        public string Gender { get; set; }                // الجنس
        public DateTime Birthdate { get; set; }           // تاريخ الميلاد
        public byte[] Picture { get; set; }               // الصورة (بايتات)


        /// <summary>
        ///  تفريغ القيم للوضع الافتراضي
        /// </summary>
        public void ValueNull()
        {
            IDPerson = 0;
            FullName = "???";
            Housing = "???";
            NumPhone = "???";
            Email = "???";
            Nationality = "???";
            National_Number = "???";
            Gender = "???";
            Birthdate = DateTime.MinValue;
            //تعيين الصورة الافتراضية
            Image img = Properties.Resources.Male;

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                Picture = ms.ToArray();
            }


        }


        /// <summary>
        /// تحويل صورة Image إلى مصفوفة بايت لتخزينها في قاعدة البيانات
        /// </summary>
        public static byte[] ImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }


        /// <summary>
        /// يرجع معلومات الشخص حسب PersonID ضمن كائن Person.
        /// إذا لم يتم العثور على الشخص → يرجع null.
        /// </summary>
        public static Person GetPersonByID(int personID)
        {
            string query = @"
        SELECT 
            IDPerson,
            FullName,
            Housing,
            NumPhone,
            Email,
            Nationality,
            [National Number],
            Gender,
            Birthdate,
            Picture
        FROM Persons
        WHERE IDPerson = @PersonID;
    ";

            var parameters = new Dictionary<string, object>()
    {
        { "@PersonID", personID }
    };

            try
            {
                using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.Text;

                    // إضافة الباراميترات
                    command.Parameters.AddWithValue("@PersonID", personID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null; // لا يوجد شخص بهذا الرقم

                        Person p = new Person()
                        {
                            IDPerson = reader.GetInt32(reader.GetOrdinal("IDPerson")),
                            FullName = reader["FullName"]?.ToString(),
                            Housing = reader["Housing"]?.ToString(),
                            NumPhone = reader["NumPhone"]?.ToString(),
                            Email = reader["Email"]?.ToString(),
                            Nationality = reader["Nationality"]?.ToString(),
                            National_Number = reader["National Number"]?.ToString(),
                            Gender = reader["Gender"]?.ToString(),
                            Birthdate = Convert.ToDateTime(reader["Birthdate"]),
                            Picture = reader["Picture"] == DBNull.Value ? null : (byte[])reader["Picture"]
                        };

                        return p;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء جلب بيانات الشخص: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}
