using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Manage_Users
{
     public class Users
    {
        public int IDUser { get; set; } //

        public int IDPerson { get; set; }

        public string UserName { get; set; }

        public string Authorities { get; set; } // الصلاحيات

        public string Status_Account { get; set; } //حالة الحساب  

        public string Role { get; set; } //الدور


    }
}
