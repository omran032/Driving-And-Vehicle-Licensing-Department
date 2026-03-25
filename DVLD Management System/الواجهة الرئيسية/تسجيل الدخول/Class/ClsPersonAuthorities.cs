using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول.Class
{
    /// <summary>
    ///  كلاس يقوم بعرض الواجهة حسب صلاحيات الشخص
    /// </summary>
    internal class ClsPersonAuthorities
    {
        public ClsPersonAuthorities (string Authorities_)
        {
            Authorities = Authorities_;
            DispalyForm();
        }

        string Authorities; // User الصلاحية لل 

        /// <summary>
        ///  يقوم بفتح الواجهة حسب نوع الصلاحية
        /// </summary>
        void DispalyForm()
        {
            if (Authorities == "")
            {

            }
            else if (Authorities == "")
            {

            }
        }




    }
}
