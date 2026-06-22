using DVLD_Management_System.Class.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.International_License.Class
{
    /// <summary>
    /// كلاس لتخزين البيانات المهمة الخاصة بالرخصة الدولية
    /// </summary>
    public class Cls_InternationalLicenseInfo
    {


        public Person PersonInfo { get; set; }

        public int inernationalLicenseID { get; set; }

        public bool IsActive { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime IssueDate { get; set; }

        public int LoclLicenseID { get; set; }

        public int RequestID { get; set; }

        public int DriverID { get; set; }





    }
}
