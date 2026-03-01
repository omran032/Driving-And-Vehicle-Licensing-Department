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

namespace DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            MyTools.MoveControl(pnl_TopBar, this); 

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

                //   Close();
                FormPerson formMain = new FormPerson();
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
       
    }
}
