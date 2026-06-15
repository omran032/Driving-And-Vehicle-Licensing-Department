using DVLD_Management_System.Class.Class_Buisness;
using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Data;

namespace DVLD_Management_System.Tests.Class
{
    // بسيط لتعريف العمليات الأساسية للوصول لحالة الاختبار (Result) والحفظ
    public class clsTest
    {
        public int TestAppointmentID { get; set; }
        public int TestID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {

        }


        public static clsTest Find(int testID)
        {
            try
            {
                string q = "SELECT TestID, Result, Mark, FeesExam FROM Tests WHERE TestID = @TestID";
                var p = new Dictionary<string, object>() { { "@TestID", testID } };
                var dt = ClsCommandDB.SelectCommand(q, p);
                if (dt == null || dt.Rows.Count == 0) return null;

                var row = dt.Rows[0];
                var obj = new clsTest();
                obj.TestID = row["TestID"] != DBNull.Value ? Convert.ToInt32(row["TestID"]) : -1;
                obj.TestResult = row["Result"] != DBNull.Value && row["Result"].ToString().ToLower() == "pass";
                obj.Notes = row.Table.Columns.Contains("Notes") && row["Notes"] != DBNull.Value ? row["Notes"].ToString() : string.Empty;
                return obj;
            }
            catch { return null; }
        }

        public bool Save()
        {
            try
            {
                // Update Tests.Result. Use TestID if present, otherwise use TestAppointmentID
                int id = (this.TestID > 0) ? this.TestID : this.TestAppointmentID;
                if (id <= 0) return false;

                string q = "UPDATE Tests SET Result = @Result WHERE TestID = @TestID";
                var resultValue = TestResult ? "Pass" : "Fail";
                var p = new Dictionary<string, object>() { { "@Result", resultValue }, { "@TestID", id } };
                var r = ClsCommandDB.ExecuteNonQuery_Command(q, p, false);
                return (r != null && Convert.ToInt32(r) > 0);
            }
            catch { return false; }
        }















        public clsTestAppointment TestAppointmentInfo { set; get; }


        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsTest(int TestID, int TestAppointmentID,
          bool TestResult, string Notes, int CreatedByUserID)

        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
           this.TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNewTest()
        {
            //call DataAccess Layer 

            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);


            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            //call DataAccess Layer 

            return clsTestData.UpdateTest(this.TestID, this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);
        }

      

        public static clsTest FindLastTestPerPersonAndLicenseClass
            (int PersonID, int LicenseClassID, clsTestType.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass
                (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTest(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;

        }

        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllTests();

        }

      

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }













    }
}
