using DVLD_Management_System.Class.Class_DB;
using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Management_System.Class.Class_DB.ClassAuditLogs;

namespace DVLD_Management_System.Applications.Manage_Application_Type.Class
{
    internal class ClsCMD_ApplicationDB
    {

        /// <summary>
        /// GetAllApplicationType عرض بيانات جدول
        /// </summary>
        public static DataTable GetAllApplicationType()
        {
            string Query = $@"Select RequestTypeID [ID] , TypeName Title , Description , Fees   from RequestTypes";

            return ClsCommandDB.SelectCommand(Query);
        }

        /// <summary>
        /// تعديل نوع الطلب
        /// </summary>
        public static void UpdateApplicationType(InfoApplicationType infoApplication)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                {"@ID"          , infoApplication.ID},
                {"@TypeName"    , infoApplication.TypeName},
                {"@Description" , infoApplication.Description},
                {"@Fees"        , infoApplication.Fees}
            };

            string Query = $@"Update RequestTypes set
                                  TypeName    = '@TypeName' ,
                                  Description = '@Description',
                                  Fees        =  @Fees
                           Where RequestTypeID=  @ID;";

          var result =  ClsCommandDB.ExecuteNonQuery_Command(Query, Parameters , false);

            if (result == null)
                MessageBox.Show("لم يتم تعديل نوع الطلب  ... حاول مجدداً", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show(" تم تعديل نوع الطلب بنجاح ", "تم");
                AddLog(LogAction.UpdateRequestType, ClassUser.IDUser, $"تعديل نوع الطلب رقم {infoApplication.ID}"); // التسجيل في Logs

            }
        }


    }
}
