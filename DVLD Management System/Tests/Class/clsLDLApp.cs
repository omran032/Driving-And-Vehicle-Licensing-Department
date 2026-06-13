using DVLD_Management_System.Applications.Driver_Licenses_Services.New_Driving_License.Local_License.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Tests.Class
{
    internal class clsLDLApp
    {
        public clsLDLApp()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;


            Mode = enMode.AddNew;
        }

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { set; get; }
        public int LicenseClassID { set; get; }
        public clsLicenseClass LicenseClassInfo;

        public static clsLDLApp FindByLocalDrivingAppLicenseID(int requestID)
        {
            // Simple test stub: try to get basic info from Requests table
            try
            {
                var dt = DVLD_Management_System.Class.Class_DB.ClsCommandDB.SelectCommand("SELECT RequestID, LicenseClassID, Fees FROM Requests WHERE RequestID = " + requestID);
                if (dt.Rows.Count == 0) return null;

                var row = dt.Rows[0];
                clsLDLApp app = new clsLDLApp();
                app.LocalDrivingLicenseApplicationID = Convert.ToInt32(row["RequestID"]);
                app.LicenseClassID = row["LicenseClassID"] == DBNull.Value ? -1 : Convert.ToInt32(row["LicenseClassID"]);
                return app;
            }
            catch
            {
                return null;
            }
        }

        //public string PersonFullName { set; get; }
        //{
        //    get
        //    {
        //        return clsPerson.Find(ApplicantPersonID).FullName;
        //    }

        //}




    }
}
