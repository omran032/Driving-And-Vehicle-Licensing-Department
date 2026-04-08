using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Applications.Class
{
    public class clsRequest
    {
        /// <summary>
        /// نوع الطلب
        /// </summary>
        public enum enApplicationType
        {
            NewDrivingLicense   = 1,            // رخصة جديدة
            RenewDrivingLicense = 2,            // تجديد رخصة
            ReplaceLostDrivingLicense      = 3, // استبدال رخصة مفقودة
            ReplaceDamagedDrivingLicense   = 4, // استبدال رخصة تالفة
            ReleaseDetainedDrivingLicsense = 5, // إطلاق سراح رخصة القيادة المحتجزة
            NewInternationalLicense = 6,        // رخصة دولية جديدة
            RetakeTest              = 7         // إعادة اختبار
        };



        public int RequestID { get; set; }

        public int Status { get; set; }

        public int Fees  {  get; set; }

        public DateTime DateRequest { get; set; }

        public int IDPerson { get; set; }

        public int LicenseClassID { get; set; }

        public int RequestTypeID { get; set; }

        /// <summary>
        /// إضافة طلب
        /// </summary>
        /// <returns> الطلب ID</returns>
        public static int AddRequest(clsRequest RequestInfo)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                {"@Status"         , RequestInfo.Status},
                {"@Fees"           , RequestInfo.Fees},
                {"@DateRequest"    , RequestInfo.DateRequest},
                {"@IDPerson"       , RequestInfo.IDPerson},
                {"@LicenseClassID" , RequestInfo.LicenseClassID},
                {"@RequestTypeID"  , RequestInfo.RequestTypeID}
            };

            string Query = $@"  INSERT INTO Requests (IDPerson, LicenseClassID, RequestTypeID, Fees, Status, DateRequest)
                                  VALUES (@IDPerson, @LicenseClassID, @RequestTypeID, @Fees, @Status, GETDATE());";

           object RequestID = ClsCommandDB.ExecuteNonQuery_Command(Query, Parameters, false);
            if (RequestID != null)
                 MessageBox.Show("تم إضافة الطلب", "تم");
            else MessageBox.Show("لم يتم إضافة الطلب", "لم تنجح العملية" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            
            return (int)RequestID;
        }


    }
}
