using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.Applications.Manage_Test_Type.Class
{
    internal class ClsCMD_TestTypeDB
    {
        /// <summary>
        /// TestType ارجاع بيانات جدول أنواع الإختبارات
        /// </summary>
        public static DataTable GetDataTestType()
        {
            string Query = $@"Select TestTypeID as ID , TypeName Title , Description , Fees   from TestTypes;";

           return ClsCommandDB.SelectCommand(Query);

        }

        /// <summary>
        /// تعديل نوع الاختبار 
        /// </summary>
        public static void UpdateTestType(InfoTestType infoTestType)
        {
            if (infoTestType == null) 
                MessageBox.Show("البيانات المرسلة فارغة", "" ,MessageBoxButtons.OK , MessageBoxIcon.Error);

            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                {"@ID"           , infoTestType.ID},
                {"@TestTypeName" , infoTestType.TestTypeName},
                {"@Fees"         , infoTestType.Fees},
                {"@Description"  , infoTestType.Description},
            };

            string Query = $@"";

            object result = ClsCommandDB.ExecuteNonQuery_Command(Query, Parameters, false);

            if(result == null )
                MessageBox.Show("لم يتم تعديل","مشكلة",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            else
                MessageBox.Show("تم تعديل نوع الإختبار", "تم");
        }



    }
}
