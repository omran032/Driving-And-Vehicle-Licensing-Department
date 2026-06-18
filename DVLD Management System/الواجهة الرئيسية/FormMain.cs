using Dev_Note_Assistant;
using DVLD_Management_System.Applications;
using DVLD_Management_System.Applications.Manage_Application_Type;
using DVLD_Management_System.Applications.Manage_Test_Type.واجهات;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Drivers;
using DVLD_Management_System.Local_Licenses;
using DVLD_Management_System.Manage_Persons.Class;
using DVLD_Management_System.Manage_Users;
using DVLD_Management_System.Manage_Users.Class;
using DVLD_Management_System.Manage_Users.User_Control;
using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Management_System.الواجهة_الرئيسية
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            LoadData();
        }
        Person Person;
        Users User;

        //تحميل بيانات المستخدم
        void LoadData()
        {
            Person = Cls_CMD_PresonsDB.GetPersonByID(ClassUser.IDPerson); // User ل Person إحضار معلومات
            User = new Users
            {
                IDUser = ClassUser.IDUser,
                IDPerson = ClassUser.IDPerson,
                UserName = ClassUser.UserName,
                Status_Account = ClassUser.StatusAccount,
                Authorities = ClassUser.Authorities,
                Role = ClassUser.Role
            }; //User  معلومات ال  
        }






        private void tsDdb_Users_Click(object sender, EventArgs e) // Users عرض  
        {
            FormShowUsers showUsers = new FormShowUsers();  
            MyTools.ShowForm(showUsers);
        }

        private void tsDdb_People_Click(object sender, EventArgs e) // Persons عرض ال
        {
            FormPerson formPerson = new FormPerson();
            MyTools.ShowForm(formPerson);
        }

        private void ToolSM_CurrentUserInfo_Click(object sender, EventArgs e) // User عرض كافة معلومات ال
        {
            FrmInfoUser infoUser = new FrmInfoUser(User, Person);
            MyTools.ShowForm(infoUser);
        }

        private void ToolSM_ChangePassword_Click(object sender, EventArgs e) // واجهة تعديل كلمة السر للمستخدم الحالي
        {
            FrmChangePassword changePassword = new FrmChangePassword(User, Person);
            MyTools.ShowForm(changePassword);
        }

        private void ToolS_ManageApplicationTypes_Click(object sender, EventArgs e) // إدارة أنواع الطلبات
        {
            FormManageApplicationType manageApplicationType = new FormManageApplicationType();
            MyTools.ShowForm(manageApplicationType);
        }

        private void ToolS_ManageTestTypes_Click(object sender, EventArgs e) // واجهة انواع الاختبارات
        {
            FormManageTypeType formManageType = new FormManageTypeType();
            MyTools.ShowForm(formManageType);
        }

        private void ToolS_LocalLicense_Click(object sender, EventArgs e) // إضافة طلبات رخص محلية 
        {
            FrmAddUpdateApplication updateApplication = new FrmAddUpdateApplication();
            MyTools.ShowForm(updateApplication);

        }

        private void ToolS_LocalDrivingLicenseApplication_Click(object sender, EventArgs e) // طلبات الرخص المحلية
        {
            FrmLocalDrivingLicenseApplication localDrivingLicenseApplication = new FrmLocalDrivingLicenseApplication();
            MyTools.ShowForm(localDrivingLicenseApplication);
        }

      
        private void ToolS_RetakeTest_Click(object sender, EventArgs e)   // طلب اعادة الاختبار 
        {
            // نفس واجهة طلبات عرض الرخص المحلية
            FrmLocalDrivingLicenseApplication localDrivingLicenseApplication = new FrmLocalDrivingLicenseApplication();
            MyTools.ShowForm(localDrivingLicenseApplication);
        }


        private void ToolS_RenewDrivingLicense_Click(object sender, EventArgs e) // طلب تجديد الرخصة العادية
        {
            frmRenewLocalDrivingLicenseApplication NewLicense = new frmRenewLocalDrivingLicenseApplication();
            MyTools.ShowForm(NewLicense);
        }

        private void ToolS_Replacement_Click(object sender, EventArgs e) // واجهة استبدال الرخصة   بدل فاقد _ تالف
        {
            frmReplaceLostOrDamagedLicenseApplication ReplaceLicense = new frmReplaceLostOrDamagedLicenseApplication();
            MyTools.ShowForm(ReplaceLicense);

        }

        private void toolStrip_Drivers_Click(object sender, EventArgs e) // عرض السائقين
        {
            FrmListDrivers frmListDrivers = new FrmListDrivers();
            MyTools.ShowForm(frmListDrivers);

        }
    }
}
