using System;
using System.Collections.Generic;
using System.Data;
using DVLD_Management_System.Class.Class_DB;

namespace DVLD_Management_System.Tests.Class
{
    // Helper class to keep DB-related logic outside UI controls
    public static class TestDataHelper
    {
        public static int CountPreviousAttempts(int requestID, int testTypeID)
        {
            if (requestID <= 0) return 0;

            try
            {
                string q = "SELECT COUNT(*) FROM Tests WHERE RequestID = @RequestID AND TestTypeID = @TestTypeID";
                var p = new Dictionary<string, object>() { { "@RequestID", requestID }, { "@TestTypeID", testTypeID } };
                DataTable dt = ClsCommandDB.SelectCommand(q, p);
                if (dt != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch { }

            return 0;
        }
    }
}
