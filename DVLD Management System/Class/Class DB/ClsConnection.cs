using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Class.Class_DB
{
    internal class ClsConnection      

    {
        ///////******  ///////******  ///////******  ///////******  ///////******  ///////******  ///////******  
        ///////******  ///////******  ///////******  ///////******  ///////******  ///////******  ///////******  
        //  مسار القاعدة   



        // تحديد مسار مجلد App
        // + مجلد Linky DB + اسم الملف

        //static private string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Linky Management");
        //static private string mdfPath = Path.Combine(documentsPath, "Linky_ExamDB.mdf");


        //// حيث تتم القراءه من النسخة الموجودة بالمستندات
        //// سلسلة الاتصال باستخدام LocalDB

        //static public string connection_Linky_ExamDB = $@"
        //      Data Source=(LocalDB)\MSSQLLocalDB;
        //      AttachDbFilename={mdfPath};
        //      Integrated Security=True;
        //      Connect Timeout=30; ";






        ///////******  ///////******  ///////******  ///////******  ///////******  ///////******  ///////******  
        ///////******  ///////******  ///////******  ///////******  ///////******  ///////******  ///////******  
        //  مسار القاعدة بجانب ملف exe

        // الغيها بس تنتهي من البرنامج وشغل يلي قبلها 

        static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DB_DVLD.mdf");

        public static string ConnectionString = $@"
            Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=""{dbPath}"";
            Integrated Security=True;
            Connect Timeout=30; ";
    }
}
