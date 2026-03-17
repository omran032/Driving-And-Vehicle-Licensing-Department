using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class_DB;
using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            MyTools.MoveControl(pnl_TopBar, this);

            //هل هناك معلومات عن مستخدم لعرضها؟
            LoadLoginFromRegistry( TxtUserName,  TxtPassword);

        }
        private void PicClose_Click(object sender, EventArgs e) // زر إغلاق النافذة
        {
            Close();
        }

        private void PicMinimize_Click(object sender, EventArgs e) // زر تصغير النافذة
        {
            WindowState = FormWindowState.Minimized;
        }



        string username;
        string password;
        string role; // موظف / مدير

           // زر تسجيل ادخول
        private void btnLogin_Click(object sender, EventArgs e) 
        {
              username = TxtUserName.Text.Trim().ToLower();
              password = TxtPassword.Text.Trim();
              role = ComboRole.SelectedItem?.ToString(); // اختيار الدور


            if ( IsNull(TxtUserName, "الرجاء إدخال اسم المستخدم") || IsNull(TxtPassword, "الرجاء إدخال كلمة المرور") || IsNull(ComboRole, "الرجاء اختيار الدور"))
            {
                return; // إذا كان هناك أي حقل فارغ، لا يتم متابعة عملية تسجيل الدخول
            }

            if (ClsCommandDB.IsExistUser(username , password , role ) )
            {
                // عرض الواجهة حسب الصلاحيات
                // فعلها بس تقسم الصلاحيات
                //  ClsPersonAuthorities personAuthorities = new ClsPersonAuthorities(Authorities); 

                // Windows Registry هل تم تفعيل حفظ المعلومات لحفظها في
                IsCheck_RememberMy();

                //   Close();
                FormMain formMain = new FormMain();
                MyTools.ShowForm(formMain);
                return;
            }
            else
            {
                lbl_ISError.Visible = true; // خطأ بالاسم او  كلمة السر
            }
        }





        // دالة للتحقق من الحقول الفارغة وعرض رسالة خطأ
        bool IsNull (Control control ,string TextError)
        {
            string value = control.Text.Trim();

            if (value == "")
            {
                ErrorProviderLogin.SetError(control, TextError);
                return true;
            }
            else
            {
                ErrorProviderLogin.Clear();
                return false;
            }
        }

        /// <summary>
        /// (Login Project DVLD)  داخل ملف   Windows Registry تخزين الاسم و كلمة السر في 
        /// </summary>
         void SaveLoginToRegistry(string username, string password)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Login Project DVLD");

            key.SetValue("Username", username);
            key.SetValue("Password", password);

            key.Close();
        }

        /// <summary>
        /// Windows Registry دالة القراءة من 
        /// </summary>
         void LoadLoginFromRegistry(Control txtUserName , Control txtPassword)
        {
            string username;
            string password;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Login Project DVLD");

            if (key != null)
            {
                username = key.GetValue("Username", "").ToString();
                password = key.GetValue("Password", "").ToString();

                txtUserName.Text = username;
                txtPassword.Text = password;
                key.Close();
            }
            else
            {
                username = "";
                password = "";
            }
        }

        /// <summary>
        /// التحقق من تفعيل حفظ المعلومات
        /// </summary>
        void IsCheck_RememberMy()
        {
            bool isCheck = Chk_RememberMy.Checked;
            if (isCheck)
            {
                SaveLoginToRegistry(username ,password);
            }
        }

        private void Chk_RememberMy_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
