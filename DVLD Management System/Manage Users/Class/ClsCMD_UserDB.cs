using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Class.Class_DB;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Manage_Users.Class
{
    internal class ClsCMD_UserDB
    {


        /// <summary>
        ///  عرض 50 مستخدم الجدد او السابقين
        /// </summary>
        /// <param name="IgnoreRow"> عدد الصفوف التي تريد تجاهلها </param>
        /// <returns> الصفوف بعد التجاهل </returns>
        public static DataTable Next50Users(int IgnoreRow)
        {
            string Query = $@"SELECT  
    IDUser as[ID],
    IDPerson as [معرف الشخص],
    UserName as [أسم المستخدم],
    [Status Account] as [حالة الحساب],
    Authorities as [الصلاحيات],
    Role as [الدور]
FROM Users
ORDER BY IDUser   
OFFSET  0 ROWS 
FETCH NEXT 50 ROWS ONLY;";

            return ClsCommandDB.SelectCommand(Query);
        }

        /// <summary>
        /// ارجاع عدد  الأشخاص الموجودين
        /// </summary>
        /// <returns>عدد الأشخاص</returns>
        public static int CountUsers()
        {
            string Query = "select count(*) from Users;";

            return ClsCommandDB.ExecuteScalar_Command(Query); ;
        }

        /// <summary>
        /// User مرتبط ب Person  يقوم بالتحق اذا كان  ال 
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        public static bool IsNotPersonLinkedToUser(int personID)
        {
            string Query = "SELECT COUNT(*) FROM Users WHERE IDPerson = @IDPerson";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@IDPerson", personID }
            };

           int count = (int) ClsCommandDB.ExecuteScalar_Command(Query, parameters);
           
            return !(count > 0);
        }

        /// <summary>
        ///  ID وارجاع  User إضافة 
        /// </summary>
        /// <returns> بعد الإضافة  ID User </returns>
        public static int AddUser(string UserName ,  string Password , string Status_Account , int PersonID)
        {
            Password = ClsCommandDB.ReturnEncrptionPassword(Password); // تشغير كلمة المرور 

            string Query = @"
        INSERT INTO Users (Username, Password, IDPerson, [Status Account] ,Authorities , Role)
        VALUES (@UserName, @Password, @PersonID, @Status_Account , @Authorities ,@Role );

        SELECT SCOPE_IDENTITY();";


            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@UserName"      , UserName },
                { "@Password"      , Password },
                { "@Status_Account", Status_Account },
                { "@Authorities"   , "Admin" }, //التعديل عند تقسم الصلاحيات
                { "@Role"          , "Admin" },        //
                { "@PersonID"      , PersonID },
            };

            int ID = Convert.ToInt32(ClsCommandDB.ExecuteScalar_Command(Query, parameters));
            if (ID > 0) 
            MessageBox.Show("تم إضافة المستخدم بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("لم يتم إضافة المستخدم ", "فشل العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return ID;
        }



        /// <summary>
        /// عرض المستخدمين حسب فلتر البحث
        /// </summary>
        /// <param name="Value">القيمة التي تبحث عنها</param>
        /// <param name="TypeFeltter">نواع البحث</param>
        public static DataTable  SearchUser( dynamic Value ,  string TypeFeltter)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@value", Value }
            };

            string Where = ""; //الشرط

            if (TypeFeltter == "ID")
                Where = @"where IDuser = @value";

            else if (TypeFeltter == "UserName")
                Where = @"where UserName = @value";

            else if (TypeFeltter == "Active" || TypeFeltter == "Inactive")
                Where = @"where [Status Account] = @value";


            string Query = $@"SELECT  
    IDUser as[ID],
    IDPerson as [معرف الشخص],
    UserName as [أسم المستخدم],
    [Status Account] as [حالة الحساب],
    Authorities as [الصلاحيات],
    Role as [الدور]
FROM Users {Where}";

            return ClsCommandDB.SelectCommand(Query, parameters);
        }



        /// <summary>
        ///  User تعديل معلومات ال
        /// </summary>
        /// <param name="IDUser"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="Status_Account"></param>
        /// <param name="PersonID"></param>
        public static void UpdateUser(int IDUser , string UserName, string Password, string Status_Account, int PersonID)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@IDUser"        , IDUser },
                { "@UserName"      , UserName },
                { "@Password"      , Password },
                { "@Status_Account", Status_Account },
                { "@Authorities"   , "Admin" }, //التعديل عند تقسم الصلاحيات
                { "@Role"          , "Admin" },        //
                { "@PersonID"      , PersonID },
            };

            string Query = $@"UPDATE Users
SET 
    UserName       = @UserName,
    Password       = @Password,
    Authorities    = @Authorities,
    [Status Account] = @Status_Account,
    IDPerson       = @PersonID,
    Role           = @Role
WHERE 
    IDUser = @IDUser;
";

          object result =   ClsCommandDB.ExecuteNonQuery_Command(Query, parameters , false);
            if (result != null)
                MessageBox.Show("تم تعديل المستخدم بنجاح", "نجاح العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("لم يتم تعديل المستخدم ", "فشل العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// تغيير كلمة المرور
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Password"></param>
        public static void UpdatePassword(int ID, string Password)
        {
            // تشفير الكلمة قبل تخزينها
            Password = ClsCommandDB.ReturnEncrptionPassword(Password);

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@Password", Password } ,
                {  "@IDUser" , ID       }
            };

            string Query = $@"UPDATE Users
                              SET Password = @Password
                              WHERE IDUser = @IDUser;";

            object result = ClsCommandDB.ExecuteNonQuery_Command(Query, parameters , false);

            if (result != null)
                MessageBox.Show("تم تعديل كلمة السر الخاصة بك", "نجاح العملية", MessageBoxButtons.OK,  MessageBoxIcon.Information);

            else
                MessageBox.Show("لم يتم تعديل كلمة المرور", " لم تكتمل العملية", MessageBoxButtons.OK,  MessageBoxIcon.Warning);
        }

        /// <summary>
        /// User حذف 
        /// </summary>
        /// <param name="ID"></param>
        public static int DeleteUser(int ID)
        {
            string Query = "DeleteUser";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
               { "@ID", ID }
            };

            object result = ClsCommandDB.ExecuteScalar_Command(Query, parameters, true);

            if (result == null)
            {
                MessageBox.Show("حدث خطأ غير متوقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            int value = Convert.ToInt32(result);

            switch (value)
            {
                case 1:
                    MessageBox.Show("تم حذف المستخدم", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 0:
                    MessageBox.Show("المستخدم غير موجود", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case -1:
                    MessageBox.Show("لا يمكن حذف هذا المستخدم لأنه مرتبط ببيانات أخرى",
                                    "عملية غير مسموحة",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    break;

            }
            return value;

        }




    }
}
