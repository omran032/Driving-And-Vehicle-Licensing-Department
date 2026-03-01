using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول
{
    static class ClassUser
    {

        static int IDPreson_;

        public static int IDPerson // ID الشخص
        {
            get {  return IDPreson_; }
            set
            {
                if (value > 0)
                   IDPreson_ = value; 
            }
        }


        static int IDUser_;  // ID المستخدم

        public static int IDUser
        {
            get { return IDUser_; }
            set
            {
                if (value > 0)
                    IDUser_ = value;
            }
        }


        static string userName_;

        public static string UserName
        {
            get { return userName_; }
            set { userName_ = value; }
        }

        static string Authorities_; // دور المستخدم

        public static string Authorities
        {
            get { return Authorities_; }
            set { Authorities_ = value; }
        }

        static string role_; // دور المستخدم

        public static string Role
        {
            get { return role_; }
            set { role_ = value; }
        }

    }
}
