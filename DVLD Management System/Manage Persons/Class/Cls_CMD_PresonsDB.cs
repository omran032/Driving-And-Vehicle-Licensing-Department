using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD_Management_System.Manage_Persons.Class
{
    internal class Cls_CMD_PresonsDB
    {



        //////////////////////////////////////////////////////////////////////////
        ///////////////////////////  [ Person اوامر جدول ]   ////////////////////////////////

        #region   Person اوامر جدول

        /// <summary>
        ///  عرض بيانات الاشخاص الموجودين
        /// </summary>
        /// <returns></returns>
        public static DataTable ShowPersons()
        {
            string Query = @"select  IDPerson as [ID] ,  FullName as [الاسم الكامل] , Housing as [السكن],[National Number] as [الرقم الوطني], NumPhone as [رقم الهاتف]" +
                ", Email as [الايميل], Nationality as [الجنسية], Gender as [الجنس], Birthdate as [الميلاد], Picture as [الصورة] from  Persons;";

            return ClsCommandDB.SelectCommand(Query);
        }





        /// <summary>
        /// Stored Prosedure إضافة شخص جديد باستخدام
        /// </summary>
        /// <param name="person">  لاضافته Person معلومات </param>
        /// <returns> ارجاع ID </returns>
        public static int AddPerson(Person person)
        {
            string Query = "AddPerson"; // اسم الـ SP

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@FullName", person.FullName },
                { "@National_Number", person.National_Number },
                { "@Housing", person.Housing },
                { "@NumPhone", person.NumPhone },
                { "@Email", person.Email },
                { "@Nationality", person.Nationality },
                { "@Gender", person.Gender },
                { "@Birthdate", person.Birthdate },
                { "@Picture", person.Picture }
            };

            object result = ClsCommandDB.ExecuteScalar_Command(Query, parameters, true);
            if(result != null)
                MessageBox.Show("تم الاضافة");
            else
                MessageBox.Show("لم تنجح الاضافة");


            return Convert.ToInt32(result);
        }




        /// <summary>
        ///  تعديل معلومات شخص معين
        /// </summary>
        public static void UpdatePerson(Person person)
        {
            string Query = "UpdatePerson";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@IDPerson", person.IDPerson },
                { "@FullName", person.FullName },
                { "@National_Number", person.National_Number },
                { "@Housing", person.Housing },
                { "@NumPhone", person.NumPhone },
                { "@Email", person.Email },
                { "@Nationality", person.Nationality },
                { "@Gender", person.Gender },
                { "@Birthdate", person.Birthdate },
                { "@Picture", person.Picture }
            };

            object result = ClsCommandDB.ExecuteNonQuery_Command(Query, parameters, true);

            if (result != null)
                MessageBox.Show("تم التعديل");
            else
                MessageBox.Show("لم تنجح التعديل");

        }





        /// <summary>
        /// حذف شخص معين
        /// </summary>
        public static void DeletePerson(int idPerson)
        {
            string Query = "DeletePerson";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@IDPerson", idPerson }
            };

          object result =  ClsCommandDB.ExecuteNonQuery_Command(Query, parameters, true);
            if (result != null)
                MessageBox.Show("تم الحذف");
            else
                MessageBox.Show("لم ينجح الحذف");

        }


        /// <summary>
        /// ارجاع عدد  الأشخاص الموجودين
        /// </summary>
        /// <returns>عدد الأشخاص</returns>
        public static int CountPersons()
        {
            string Query = "select count(*) from Persons;";         
        
            return ClsCommandDB.ExecuteScalar_Command(Query); ;
        }

         

        /// <summary>
        ///  عرض 50 شخص الجدد او السابقين
        /// </summary>
        /// <param name="IgnoreRow"> عدد الشفوف التي تريد تجاهلها </param>
        /// <returns> الصفوف بعد التجاهل </returns>
        public static DataTable Next50Person(int IgnoreRow)
        {
            string Query = $@"SELECT  
    IDPerson AS [ID],
    FullName AS [الاسم الكامل],
    [National Number] as [الرقم الوطني],
    Housing AS [السكن],
    NumPhone AS [رقم الهاتف],
    Email AS [الايميل],
    Nationality AS [الجنسية],
    Gender AS [الجنس],
    Birthdate AS [الميلاد],
    Picture AS [الصورة]
FROM Persons
ORDER BY IDPerson   
OFFSET {IgnoreRow} ROWS 
FETCH NEXT 50 ROWS ONLY;";

            return ClsCommandDB.SelectCommand(Query);
        }


        /// <summary>
        /// التحقق من وجود الرقم الوطني مسبقاً
        /// </summary>
        public static bool IsNotExist_NationalNum(string National_Number)
        {
            string Query = $@"SELECT  [National Number] as [الرقم الوطني] FROM Persons where [National Number] = @National_Number ";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@National_Number", National_Number }
            };

            object result = ClsCommandDB.ExecuteScalar_Command(Query , parameters);
           // MessageBox.Show("==== " + result.ToString()); // علمسح

            if (result == null)
                return false;

            else return true;


        }


        /// <summary>
        /// البحث عن شخص معين حسب الشرط
        /// </summary>
        /// <param name="value">شرط البحث</param>
        /// <param name="TypeSearch">نوع البحق</param>
        public static DataTable SearchPerson_ID(dynamic value , string TypeSearch)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@value", value }
            };

            string where;
            if (TypeSearch == "ID")
                where = "where IDPerson = @value";

            else if(TypeSearch == "FullName")
                where = "where FullName = @value";

            else if (TypeSearch == "National Number")
                where = "where [National Number] = @value";

            else
                where = "";


            string Query = $@"SELECT 
    IDPerson AS [ID],
    FullName AS [الاسم الكامل],
    [National Number] as [الرقم الوطني],
    Housing AS [السكن],
    NumPhone AS [رقم الهاتف],
    Email AS [الايميل],
    Nationality AS [الجنسية],
    Gender AS [الجنس],
    Birthdate AS [الميلاد],
    Picture AS [الصورة]
FROM Persons
{where}
";

            return ClsCommandDB.SelectCommand(Query , parameters);

        }


        #endregion




    }
}
