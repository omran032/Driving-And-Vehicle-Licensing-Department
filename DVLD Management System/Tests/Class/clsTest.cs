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
    }
}
