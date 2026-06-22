using Dev_Note_Assistant;
using DVLD_Management_System.Applications;
using DVLD_Management_System.Applications.Manage_Application.Local_Driving_License_Application.UI;
using DVLD_Management_System.Applications.Manage_Application_Type;
using DVLD_Management_System.Applications.Manage_Test_Type.واجهات;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Class.Class_DB;
using DVLD_Management_System.Detain_Licenses;
using DVLD_Management_System.Drivers;
using DVLD_Management_System.International_License;
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
using System.Data.SqlClient;
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

            LoadDataUser();
        }
        Person Person;
        Users User;

        //تحميل بيانات المستخدم
        void LoadDataUser()
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

            lblNamePerson_User.Text = "Name : " + Person.FullName; // FullName هون يفضل تبدلها باسم الشخص  
            lblRole.Text = "Role : " + ClassUser.Role;
            lblDate.Text = "Date : " +  DateTime.Now.ToString("yyyy / MM / dd");
        }

                        //---------------------------------------------------------------------------
                        //---------------------------------------------------------------------------

        #region *****///****  تحميل معلومات وبيانات الواجهة   *****///****


        #region ||||||  أزرار وعناصر    |||||||

        private void btnRefrech_Click(object sender, EventArgs e) // زر تحديث البيانات في الفورم
        {
            LoadDataForm();
        }

     
        private void PnlAddNewLocalLicense_Click(object sender, EventArgs e) // زر _ بانل .. إضافة رخصة محلية
        {
            FrmAddUpdateApplication updateApplication = new FrmAddUpdateApplication();
            MyTools.ShowForm(updateApplication);
        }

        private void PnlAddNewInternationalLicense_Click(object sender, EventArgs e)// زر _ بانل .. إضافة رخصة دولية
        {
            FrmNewInternationalLicenseApplication newInternationalLicenseApplication = new FrmNewInternationalLicenseApplication();
            MyTools.ShowForm(newInternationalLicenseApplication);
        }

        private void TxtLogID_KeyPress(object sender, KeyPressEventArgs e)  // TextBox Search LogID
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            if (e.KeyChar == (char)13) // 13 = Enter
            {
                btnSearch.PerformClick();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) // Button Search Logs By LogID
        {
            int.TryParse(TxtLogID.Text.Trim(), out int LogID);

            if (LogID == 0) return;

            // تحميل في جدول السجلات
            DataTable DataLogs = GetAuditLogs(LogID);
            DGV.DataSource = DataLogs;
        }

     

        private void PnlLicenseExpiring_Click(object sender, EventArgs e) // بنل عرض الرخص المنتهية هذا الشهر
        {
            FrmShowLicenses showLicenses = new FrmShowLicenses();
            showLicenses.LicenseStatus = "Expired License";
            MyTools.ShowForm(showLicenses);
        }
        
        private void PnlUnpaidViolation_Click(object sender, EventArgs e)// بنل عرض المخالفات الغير مدفوعة
        {
            FrmListDetainedLicenses listDetainedLicenses = new FrmListDetainedLicenses();
            listDetainedLicenses.ShowLocenseUnpaidViolations = true;
            MyTools.ShowForm(listDetainedLicenses);
        }
        private void PnlNewLicense_Click(object sender, EventArgs e) // بنل عرض الرخص الجديدة هذا الشهر
        {
            FrmShowLicenses showLicenses = new FrmShowLicenses();
            MyTools.ShowForm(showLicenses);
        }

        #endregion

        // ///////////////////////////////////////////// ///////////////////////////////////////////
        // ///////////////////////////////////////////// ///////////////////////////////////////////

        #region |||||| مثود وأوامر    |||||||
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadDataForm();
        }


        void LoadDataForm()
        {
            TxtLogID.Text = null;

            // عدد السائقين الذين ستنتهي رخصهم هذا الشهر
            lblCountLicenseExpiring.Text  = GetDriversWithLicensesExpiringThisMonth().ToString();
            //عدد المخالفات الغير مدفوعة
            lblCountUnpaidViolations.Text = GetUnpaidViolationsCount().ToString();
            // عدد الرخص المحلية الجديدة هذا الشهر
            lblCountNewLicense.Text       = GetNewLocalLicensesThisMonth().ToString();
            // تحميل جدول السجلات
            DataTable DataLogs = GetAuditLogs();
            DGV.DataSource = DataLogs;

        }

        #endregion


        // ///////////////////////////////////////////// ///////////////////////////////////////////
        // ///////////////////////////////////////////// ///////////////////////////////////////////

        #region ||||||  أوامر لقاعدة البيانات    |||||||

        /// <summary>
        /// ترجع عدد السائقين الذين ستنتهي رخصهم خلال هذا الشهر.
        /// تعتمد على EndDate في جدول Licenses.
        /// </summary>
        public static int GetDriversWithLicensesExpiringThisMonth()
        {
            string query = @"
        SELECT COUNT(DISTINCT DriverID)
        FROM Licenses
        WHERE 
            EndDate IS NOT NULL
            AND MONTH(EndDate) = MONTH(GETDATE())
            AND YEAR(EndDate) = YEAR(GETDATE()); ";

            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء حساب عدد الرخص المنتهية هذا الشهر:\n" + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


        /// <summary>
        /// ترجع عدد المخالفات غير المدفوعة.
        /// المخالفة تعتبر غير مدفوعة إذا:
        /// PenaltyAmount > 0 AND ReleasedDate IS NULL
        /// </summary>
        public static int GetUnpaidViolationsCount()
        {
            string query = @"
        SELECT COUNT(*)
        FROM LicenseHolds
        WHERE PenaltyAmount > 0
        AND ReleasedDate IS NULL; ";

            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء حساب عدد المخالفات غير المدفوعة:\n" + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


        /// <summary>
        /// ترجع عدد الرخص المحلية الجديدة التي تم إصدارها خلال هذا الشهر.
        /// تعتمد على RelesaseDate في جدول Licenses.
        /// </summary>
        public static int GetNewLocalLicensesThisMonth()
        {
            string query = @"
        SELECT COUNT(*)
        FROM Licenses
        WHERE 
            RelesaseDate IS NOT NULL
            AND MONTH(RelesaseDate) = MONTH(GETDATE())
            AND YEAR(RelesaseDate) = YEAR(GETDATE()); ";

            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء حساب عدد الرخص المحلية الجديدة هذا الشهر:\n" + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }




        /// <summary>
        /// ترجع جدول سجلات العمليات.
        /// إذا كان logID = -1 → ترجع كل السجلات.
        /// إذا كان logID رقم صحيح → ترجع السجل المطلوب فقط.
        /// </summary>
        public static DataTable GetAuditLogs(int logID = -1)
        {
            string query = @"
        SELECT 
            A.LogID,
            A.IDUser,
            P.FullName AS PersonName,
            A.Action,
            A.ActionDate
        FROM AuditLogs A
        INNER JOIN Users U ON A.IDUser = U.IDUser
        INNER JOIN Persons P ON U.IDPerson = P.IDPerson
        WHERE 1 = 1 ";

            // إذا بدنا سجل واحد فقط
            if (logID != -1)
                query += " AND A.LogID = @LogID";

            query += " ORDER BY A.LogID DESC"; // ترتيب من الأحدث للأقدم

            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConnection.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (logID != -1)
                        cmd.Parameters.AddWithValue("@LogID", logID);

                    conn.Open();

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء جلب سجلات العمليات:\n" + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        #endregion


        #endregion

                        //---------------------------------------------------------------------------
                        //---------------------------------------------------------------------------

        #region  ******  أزرار القائمة العلوية   ******
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

        private void ToolS_ManageDetainedLicenses_Click(object sender, EventArgs e) // واجهة عرض الرخص المخالفة
        {
            FrmListDetainedLicenses listDetainedLicenses = new FrmListDetainedLicenses();
            MyTools.ShowForm(listDetainedLicenses);
        }

        private void ToolS_DetaunLicense_Click(object sender, EventArgs e) // واجهة حجز رخصة
        {
            FrmDetainLicenseApplication detainLicenseApplication = new FrmDetainLicenseApplication();
            MyTools.ShowForm(detainLicenseApplication);
        }

        private void ToolS_ReleaseDetainedLicense_Click(object sender, EventArgs e) //واجهة فك حجز الرخصة
        {
            FrmReleaseDetainedLicenseApplication frmReleaseDetained = new FrmReleaseDetainedLicenseApplication();
            MyTools.ShowForm(frmReleaseDetained);
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)//واجهة فك حجز الرخصة
        {
            FrmReleaseDetainedLicenseApplication frmReleaseDetained = new FrmReleaseDetainedLicenseApplication();
            MyTools.ShowForm(frmReleaseDetained);
        }

        private void ToolS_internationalLicenseApplications_Click(object sender, EventArgs e) // واجهة عرض الرخص الدولية
        {
            FrmListInternational_LApp listInternational_LApp = new FrmListInternational_LApp();
            MyTools.ShowForm(listInternational_LApp);

        }

        private void ToolS_InternationalLicense_Click(object sender, EventArgs e) // واجهة إضافة رخصة دولية
        {
            FrmNewInternationalLicenseApplication newInternationalLicenseApplication = new FrmNewInternationalLicenseApplication();
            MyTools.ShowForm(newInternationalLicenseApplication);
        }
















        #endregion

        
    }
}
