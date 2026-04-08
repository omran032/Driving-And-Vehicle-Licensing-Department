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
        public static int IsLicenseExistByPersonID(int IDPerson , int LicenseClassID )
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                {"@IDPerson"       , IDPerson},
                {"@LicenseClassID" ,LicenseClassID }
            };

            string Query = $@"SELECT LicenceID
                                FROM Licenses
                                    WHERE LicenseClassID = @LicenseClassID
                                        AND PersonID = @IDPerson
                                        AND StatusRelease = 1;";
          object result =   ClsCommandDB.ExecuteScalar_Command(Query, Parameters);
             if (result == null) result = -1;

            return (int)result;
        }


      

    }
}
