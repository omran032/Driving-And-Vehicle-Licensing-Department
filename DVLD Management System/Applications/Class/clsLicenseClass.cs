using DVLD_Management_System.Class.Class_DB;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Applications.Driver_Licenses_Services.New_Driving_License.Local_License.Class
{
    public  class clsLicenseClass
    {
        public int LicenseClassID {  get; set; }

        public string NameClass { get; set; }

        public string DescriptionClass { get; set; }

        public byte MinAge { get; set; }            //  العمر الادنى للرخصة

        public byte ValidityLength { get; set; }    // مدة صلاحية الرخصة

        public int FeesClass { get; set; }

        public clsLicenseClass()
        {
            LicenseClassID   = 0;
            NameClass        = "";
            DescriptionClass = "";
            MinAge           = 18;
            ValidityLength   = 10;
            FeesClass        = 0;
        }

        public clsLicenseClass(int LicenseClassID , string NameClass , string DescriptionClass , int FeesClass)
        {
            this. LicenseClassID  = LicenseClassID;
            this.NameClass        = NameClass;
            this.DescriptionClass = DescriptionClass;
            this.MinAge           = 18;
            this.ValidityLength   = 10;
            this.FeesClass        = FeesClass ;
            ;
        }












        /// <summary>
        /// Combox عرض فئات الرخص في عنصر 
        /// </summary>
        public static void DisplayCLassNameInCombox(Guna2ComboBox Combox)
        {
            Combox.DataSource = AllClassName();
            Combox.DisplayMember = "ClassName";         // النص الظاهر
            Combox.ValueMember   = "LicenseClassID";    // القيمة المخفية (ID)
        }

        /// <summary>
        /// إرجاع معلومات كل فئات الرخص الموجودة
        /// Table :  LicenseClass 
        /// </summary>
        public static DataTable AllClassName()
        {
            string Query = $@"select LicenseClassID , ClassName , ClassDescription , MinAge , ValidatyLength , [Class fees]  from LicenseClass";

            return ClsCommandDB.SelectCommand(Query);
        }


        /// <summary>
        ///  يقوم بـ عرض ( كل طلبات ) الرخص المحلية مع معلومات الشخص والفئة وعدد الاختبارات الناجحة.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLocalLicenseRequests()
        {
            // View يجب تحويله ل 
            string Query = $@"SELECT * from GetLocalLicenseRequests_View";

            return ClsCommandDB.SelectCommand(Query);
        }



        /// <summary>
        /// الشخص National lNumber فلترة  طلبات الرخص المحلية بوساطة 
        /// </summary>
        public static DataTable FelterLocalLicenseRequestsByNationalNum(string NationalNum)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                {"@NationalNum" ,NationalNum }
            };

            string Query = $@"SELECT * from GetLocalLicenseRequests_View 
                            where [National Number] = @NationalNum ";

            return ClsCommandDB.SelectCommand(Query, Parameters);
        }

        /// <summary>
        /// ( رقم الطلب )  RequestID فلترة  طلبات الرخص المحلية بوساطة 
        /// </summary>
        public static DataTable FelterLocalLicenseRequestsByRequestID(int RequestID)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                {"@RequestID" ,RequestID }
            };

            string Query = $@"SELECT * from GetLocalLicenseRequests_View 
                            where [Request ID] = @RequestID ";

            return ClsCommandDB.SelectCommand(Query, Parameters);
        }

        /// <summary>
        /// (اسم الشخص الكامل) FullName فلترة طلبات الرخص المحلية بوساطة 
        /// (بحث يحتوي على وليس تطابق تام)
        /// </summary>
        public static DataTable FelterLocalLicenseRequestsByFullNamePerson(string FullNamePerson)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>()
    {
        {"@FullNamePerson" , FullNamePerson }
    };

            string Query = @"
        SELECT * 
        FROM GetLocalLicenseRequests_View
        WHERE FullName LIKE '%' + @FullNamePerson + '%' ";

            return ClsCommandDB.SelectCommand(Query, Parameters);
        }


        /// <summary>
        /// ( حالة الطلب ) StatusRequest فلترة  طلبات الرخص المحلية بوساطة 
        /// </summary>
        public static DataTable FelterLocalLicenseRequestsByStatusRequest(string StatusRequest)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                {"@Status" ,StatusRequest }
            };

            string Query = $@"SELECT * from GetLocalLicenseRequests_View 
                            where Status = @Status ";

            return ClsCommandDB.SelectCommand(Query, Parameters);
        }

    }
}
