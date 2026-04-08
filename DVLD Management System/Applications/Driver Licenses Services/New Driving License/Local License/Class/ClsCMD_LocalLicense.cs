using DVLD_Management_System.Applications.Class;
using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Applications.Driver_Licenses_Services.New_Driving_License.Local_License.Class
{
    public class ClsCMD_LocalLicense
    {
        /// <summary>
        /// التحقق من وجود طلب مشابه لفئة رخصة معينة
        /// </summary>
        /// <param name="PersonID">رمز الشخص</param>
        /// <param name="RquestTypeID">نوع الطلب .... جديد _تجديد _بدل تالف _الخ</param>
        /// <param name="ClassLicenseID">فئة الرخصة</param>
        /// <returns>ارجاع رمز الطلب اذا موجود مسبقاً</returns>
        public static int GetActiveApplicationIDForLicenseClass(int PersonID , clsRequest.enApplicationType RquestTypeID , int ClassLicenseID  )
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                {"@PersonID"     , PersonID },
                {"@RquestTypeID" , (int)RquestTypeID },
                {"@ClassLicenseID" , ClassLicenseID }
            };

            string Query = $@"select Req.RequestID 
                    from Requests Req
                        where IDPerson = @PersonID 
                            and   LicenseClassID = @ClassLicenseID 
                            and  RequestTypeID  = @RquestTypeID 
                            and Status = 1; ";                // يعني فعّال  

            object result =  ClsCommandDB.ExecuteScalar_Command(Query, Parameters);

            if (result == null) result = -1;
            return (int)result;
        }










    }
}
