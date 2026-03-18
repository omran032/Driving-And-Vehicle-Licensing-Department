using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DVLD_Management_System.Class.Class
{
    public class Person
    {
        public int IDPerson { get; set; }                 // رقم الشخص (Identity)
        public string FullName { get; set; }              // الاسم الكامل
        public string Housing { get; set; }               // السكن
        public string NumPhone { get; set; }              // رقم الهاتف
        public string Email { get; set; }                 // البريد الإلكتروني
        public string Nationality { get; set; }           // الجنسية
        public string National_Number { get; set; }           // الرقم الوطني
        public string Gender { get; set; }                // الجنس
        public DateTime Birthdate { get; set; }           // تاريخ الميلاد
        public byte[] Picture { get; set; }               // الصورة (بايتات)


        /// <summary>
        ///  تفريغ القيم للوضع الافتراضي
        /// </summary>
        public void ValueNull()
        {
            IDPerson = 0;
            FullName = "???";
            Housing = "???";
            NumPhone = "???";
            Email = "???";
            Nationality = "???";
            National_Number = "???";
            Gender = "???";
            Birthdate = DateTime.MinValue;
            //تعيين الصورة الافتراضية
            Image img = Properties.Resources.Male;

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                Picture = ms.ToArray();
            }


        }
    }
}
