using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Class.Class_DB;
using DVLD_Management_System.Manage_Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class
{
    public  class ClassInfoLicenseAplication
    {
        public int RequestID { get; set; }

        public string Status { get; set; }

        public int Fees { get; set; }

        public string DateRequest { get; set; }

        public Person Person { get; set; }

        public Users User { get; set; }

        public string LicenseClass { get; set; }

        public string RequestType { get; set; }






        // بيانات الطلب الرخصة
        // بيانات الشخص
        // بيانات الموظف المسؤول عن الطلب

        /// <summary>
        ///    جلب البيانات وتخزينها 
        /// </summary>
        /// <param name="requestID">معرف طلب الرخصة </param>
        /// <returns> ارجاع البيانات  </returns>
        public static ClassInfoLicenseAplication FindInfoRequest(int requestID)
        {
            string query = @"
        SELECT 
            R.RequestID,
            R.Status,
            R.Fees,
            R.DateRequest,
            
            -- Person
            P.IDPerson,
            P.FullName,
            P.Housing,
            P.NumPhone,
            P.Email,
            P.Nationality,
            P.Gender,
            P.Birthdate,
            P.[National number],

            -- User
            U.IDUser,
            U.UserName,
            U.Authorities,
            U.[Status Account],
            U.Role,

            -- License Class
            LC.ClassName,

            -- Request Type
            RT.TypeName

        FROM Requests R
        LEFT JOIN Persons P ON R.IDPerson = P.IDPerson
        LEFT JOIN Users U ON U.IDPerson = P.IDPerson
        LEFT JOIN LicenseClass LC ON R.LicenseClassID = LC.LicenseClassID
        LEFT JOIN RequestTypes RT ON R.RequestTypeID = RT.RequestTypeID

        WHERE R.RequestID = @RequestID";

            var parameters = new Dictionary<string, object>()
            {
                { "@RequestID", requestID }
            };

            DataTable dt = ClsCommandDB.SelectCommand(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            // تعبئة الكلاس
            ClassInfoLicenseAplication info = new ClassInfoLicenseAplication()
            {
                RequestID = Convert.ToInt32(row["RequestID"]),
                Status = row["Status"].ToString(),
                Fees = Convert.ToInt32(row["Fees"]),
                DateRequest = Convert.ToDateTime(row["DateRequest"]).ToString("yyyy-MM-dd"),

                // تعبئة الشخص
                Person = new Person()
                {
                    IDPerson = Convert.ToInt32(row["IDPerson"]),
                    FullName = row["FullName"].ToString(),
                    Housing = row["Housing"].ToString(),
                    NumPhone = row["NumPhone"].ToString(),
                    Email = row["Email"].ToString(),
                    Nationality = row["Nationality"].ToString(),
                    Gender = row["Gender"].ToString(),
                    Birthdate = Convert.ToDateTime(row["Birthdate"]),
                    National_Number = row["National number"].ToString()
                },

                // تعبئة المستخدم
                User = new Users()
                {
                    IDUser = row["IDUser"] == DBNull.Value ? 0 : Convert.ToInt32(row["IDUser"]),
                    UserName = row["UserName"].ToString(),
                    Authorities = row["Authorities"].ToString(),
                    Status_Account = row["Status Account"].ToString(),
                    Role = row["Role"].ToString()
                },

                LicenseClass = row["ClassName"].ToString(),
                RequestType = row["TypeName"].ToString()
            };

            return info;
        }


    }
}
