using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Persons.Class;
using DVLD_Management_System.Manage_Users.Class;
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

 

namespace DVLD_Management_System.Manage_Users.User_Control
{
    public partial class CtrlFeltterUser : UserControl
    {
        public CtrlFeltterUser()
        {
            InitializeComponent();
        }

        /// DataTable لعرض نتيجة الفلتر في      
        public delegate void ShowFelterPerson(DataTable DAtaUser);
        public event ShowFelterPerson EventShowFelterUser;
        public DataTable DataTableUser = new DataTable();


        bool NumberOnly;
        private void TxtFelter_KeyPress(object sender, KeyPressEventArgs e) // TextBox  منع ادخال احرف ب
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


        CancellationTokenSource cts;

        private async void TxtFelter_TextChanged(object sender, EventArgs e)// TextBox  عند تغيير النص في العنصر
        {
            cts?.Cancel(); // إلغاء أي عملية سابقة
            cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(600, cts.Token);

                string text = TxtFelter.Text;

                if (string.IsNullOrEmpty(TypeFelter) || string.IsNullOrEmpty(text))
                    return;

                switch (TypeFelter)
                {
                    case "البحث برقم الشخص":
                        DataTableUser = ClsCMD_UserDB.SearchUser(text, "ID");
                        break;

                    case "البحث عن اسم مستخدم":
                        DataTableUser = ClsCMD_UserDB.SearchUser(text, "UserName");
                        break;

                    default:
                        return;
                }

                EventShowFelterUser?.Invoke(DataTableUser);
            }
            catch (TaskCanceledException)
            {
                // تجاهل الإلغاء
            }
        }





        string TypeFelter;

        private void ComboFelter_SelectedIndexChanged(object sender, EventArgs e) // Combox Filter
        {
            TxtFelter.Text = null;
            TypeFelter = ComboFelter.Text.Trim();

            TxtFelter.Enabled = false; // القيمة الافتراضية

            switch (TypeFelter)
            {
                case "الكل":
                    DataTableUser = ClsCMD_UserDB.Next50Users(0);
                    break;

                case "الحساب الفعال":
                    DataTableUser = ClsCMD_UserDB.SearchUser("Active", "Active");
                    break;

                case "الحساب الغير فعال":
                    DataTableUser = ClsCMD_UserDB.SearchUser("Inactive", "Inactive");
                    break;

                case "البحث برقم الشخص":
                    NumberOnly = true;
                    TxtFelter.Enabled = true;
                    return;

                default:
                    NumberOnly = false;
                    TxtFelter.Enabled = true;
                    return;
            }

            NumberOnly = false;
            EventShowFelterUser?.Invoke(DataTableUser);
        }








    }
}
