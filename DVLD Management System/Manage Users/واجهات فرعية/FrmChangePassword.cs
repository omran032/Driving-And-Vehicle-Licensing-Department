using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Class.Class_DB;
using DVLD_Management_System.Manage_Users.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Management_System.Manage_Users
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword(Users user_ , Person person_)
        {
            InitializeComponent();

            user = user_;

            // Person عرض بيانات  
            ctrl_InfoPerson1.LoadData(person_);
            // User عرض بيانات  
            ctrlInfoUser1.DesplaydInfoUser(user_);

        }
        Users user = new Users();

        string OldPassword; 
        string NewPassword;
        string ConfirmPassword;

        private void btnClose_Click(object sender, EventArgs e) // زر الاغلاق
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e) // زر الحفظ
        {
            bool check = isNullTexts(TxtOldPasswprd) || isNullTexts(TxtNewPasswprd) || isNullTexts(TxtConfirmPassword) ||
                         MatchesPassword()           || CheckOldPasswords();

            if (check) return;

            //تغيير كلمة المرور
            ClsCMD_UserDB.UpdatePassword(user.IDUser, NewPassword); 
        }

        #region ****  التحقق  ****

        // التحقق اذا تم تعبئة النصوص
        bool isNullTexts(Control control)
        {
            if(string.IsNullOrEmpty(control.Text)) //فارغة
            {
                ActiveErrorProvider(control, true);
                return true;
            }
            else
            {
                ActiveErrorProvider(control, false);
                return false;
            }
        }

        // التحقق من صحة كلمة المرور
        bool CheckOldPasswords()
        {
            OldPassword = TxtOldPasswprd.Text.Trim();

            if (ClsCommandDB.IsExistUser(user.UserName, OldPassword, user.Role)) // كلمة المرور صحيحة
            {
                ActiveErrorProvider(TxtOldPasswprd, false);
                return false;
            }

            else // خطأ
            {
                ActiveErrorProvider(TxtOldPasswprd, true, "كلمة المرور غير صحيحة");
                return true;
            }
        }

        // التحقق من تطابق كلمة السر الجديدة
        bool MatchesPassword()
        {
            NewPassword     = TxtNewPasswprd.Text.Trim();
            ConfirmPassword = TxtConfirmPassword.Text.Trim();

            if (NewPassword != ConfirmPassword)
            {
                ActiveErrorProvider(TxtConfirmPassword, true, "كلمة المرور غير متطابقة");
                return true; //  يعني مو متطابقة
            }
            else
            {
                ActiveErrorProvider(TxtConfirmPassword, false);
                return false; // متطابقة
            }
        }

    

        /// <summary>
        /// على العنصر Error وضع 
        /// </summary>
        void ActiveErrorProvider(Control control , bool IsActive ,  string MSG = "هذا الحقل مطلوب")
        {
            if(IsActive)
                errorProvider1.SetError(control, MSG);

            else errorProvider1.SetError(control, "");
        }

        #endregion

    }
}
