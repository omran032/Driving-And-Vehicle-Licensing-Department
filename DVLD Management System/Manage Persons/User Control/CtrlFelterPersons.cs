using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Persons.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DVLD_Management_System.Manage_Persons.User_Control
{
    public partial class CtrlFelterPersons : UserControl
    {
        public CtrlFelterPersons()
        {
            InitializeComponent();
        }

        /// ctrl_InfoPerson لعرض نتيجة الفلتر في عنصر معلومات الشخص
        public delegate void ShowFelterPerson( Person per  ); 
        public event ShowFelterPerson EventShowFelterPersons ;

        /// DGV  في  FromPerson  في واجهة   Persons لعرض النتيجة في واجهة ال
        public delegate void FelterPersons();
        public event FelterPersons EventFelterPersons;

        public   DataTable dataTablePerson = new DataTable();
        public   Person person = new Person();


        CancellationTokenSource cts;
        private async void TxtFelter_TextChanged(object sender, EventArgs e) // حدث عند تغيير النص بالعنصر
        {
            cts?.Cancel(); // إلغاء أي عملية سابقة
            cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(600, cts.Token); // ينتظر فقط إذا ما تم الإلغاء

                // فلترة البحث عن شخص
                string textFelter = TxtFelter.Text;

                if (string.IsNullOrEmpty(TypeFelter) && string.IsNullOrEmpty(textFelter))
                    return;

                if (TypeFelter == "البحث برقم الشخص")
                    dataTablePerson = Cls_CMD_PresonsDB.SearchPerson_ID(textFelter, "ID");

                else if (TypeFelter == "البحث بالاسم")
                    dataTablePerson = Cls_CMD_PresonsDB.SearchPerson_ID(textFelter, "FullName");

                else if (TypeFelter == "البحث بالرقم الوطني")
                    dataTablePerson = Cls_CMD_PresonsDB.SearchPerson_ID(textFelter, "National Number");

                SavaInfoPerson();

                EventFelterPersons?.Invoke();
                EventShowFelterPersons?.Invoke(person);
            }
            catch (TaskCanceledException)
            {
                // تجاهل الإلغاء
            }
        }



        bool NumberOnly = false;

        string TypeFelter;
        private void ComboFelter_SelectedIndexChanged(object sender, EventArgs e) // Combox
        {
            TxtFelter.Text = null;
           TypeFelter = ComboFelter.Text.Trim();

            if (TypeFelter == "الكل")
            {
                dataTablePerson = Cls_CMD_PresonsDB.Next50Person(0); //عرض اول 50 شخص بدون تجاهل
                EventFelterPersons?.Invoke();
            }
            else if (TypeFelter == "البحث برقم الشخص") NumberOnly = true;

            else NumberOnly = false;
        }



        /// <summary>
        /// Class Person حفظ البيانات في 
        /// </summary>
        void SavaInfoPerson()
        {
            if (dataTablePerson.Rows.Count == 0)
            {
                person.ValueNull(); //تفريغ القيم
                return;
            }

            DataRow row = dataTablePerson.Rows[0];

            person.IDPerson        = Convert.ToInt32(row["ID"]);
            person.FullName        = row["الاسم الكامل"].ToString();
            person.National_Number = row["الرقم الوطني"].ToString();
            person.Housing     = row["السكن"].ToString();
            person.NumPhone    = row["رقم الهاتف"].ToString();
            person.Email       = row["الايميل"].ToString();
            person.Nationality = row["الجنسية"].ToString();
            person.Gender      = row["الجنس"].ToString();
            person.Birthdate   = Convert.ToDateTime(row["الميلاد"]);
            person.Picture     = row["الصورة"] as byte[];
        }

        /// <summary>
        ///  (الكلل) Combox  إخفاء خيار في   
        /// </summary>
        public void HighFelterAll()
        {
            ComboFelter.Items.Remove("الكل");

        }

        private void TxtFelter_KeyPress(object sender, KeyPressEventArgs e) //منع ادخال احرف
        {
            //  رجّع كل شيء لطبيعته
            if (!NumberOnly)
                return;

            //   امنع الأحرف
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                System.Media.SystemSounds.Hand.Play(); // صوت خطأ
                e.Handled = true;
            }
        }

      


    }
}
