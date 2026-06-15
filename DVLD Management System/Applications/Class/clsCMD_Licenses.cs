using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Applications.Class
{
    internal class clsCMD_Licenses
    {

        /// <summary>
        /// التحقق من وجود رخصة من نفس الفئة للشخص
        /// </summary>
        /// <param name="IDPerson">رمز الشخص</param>
        /// <param name="LicenseClassID">رمز الفئة </param>
        /// <returns>ID الرخصة</returns>
     

        public static int IsLicenseExistByPersonID(int IDPerson, int LicenseClassID)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>()
    {
        {"@IDPerson", IDPerson},
        {"@LicenseClassID", LicenseClassID}
    };

            string Query = @"
        SELECT L.LicenceID
        FROM Licenses L
        INNER JOIN Requests R ON L.RequestID = R.RequestID
        WHERE R.IDPerson = @IDPerson
          AND L.LicenseClassID = @LicenseClassID
          AND L.StatusRelease = 1;
    ";

            object result = ClsCommandDB.ExecuteScalar_Command(Query, Parameters);
            if (result == null) return -1;

            return Convert.ToInt32(result);
        }


       
    }
}
