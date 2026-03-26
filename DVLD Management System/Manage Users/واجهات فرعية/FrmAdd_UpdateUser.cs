using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Persons.Class;
using DVLD_Management_System.Manage_Persons.User_Control;
using DVLD_Management_System.Manage_Persons.واجهات_فرعية;
using DVLD_Management_System.Manage_Users.Class;
using System;
using System.Windows.Forms;

namespace DVLD_Management_System.Manage_Users
{

    /// <summary>
    ///  User واجهة إضافة وتعديل ال
    /// </summary>
    public partial class FrmAdd_UpdateUser : Form
    {
        /// <summary>
        ///    اذا كنت تريد الإضافة لا تدخل شيء 
        ///  ...... Update User اذا كنت تريد التعديل أدخل
        /// </summary>
        /// <param name="Process"></param>
        public FrmAdd_UpdateUser(Users users_ = null)
        {
            InitializeComponent();

            if (users_ == null)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                Mode = "Add";
            }
            else
            {
                user = users_;
                LoadUserData();
            }

            EventFilter();
        }


        // حدث يعمل بعد الاضافة أو التعديل
        public delegate void Add_UpdateUserEventHandler();
        public event Add_UpdateUserEventHandler Add_UpdateUser;

        Users user =new Users();
        Person person;

        string Mode = "Add";

        private void btnClose_Click(object sender, EventArgs e) // إغلاق 
        {
            this.Close();
        }


        void EventFilter()
        {
            if (DesignMode)
                return;
            // تسجيل الدالة التي تقوم بعرض المعلومات.. في الحدث عند الفلترة
            ctrlFelterPersons1.EventShowFelterPersons += ctrl_InfoPerson.LoadData;
                // Person  إحضار معلومات ال
                ctrlFelterPersons1.EventFelterPersons += GetPerson;

                //  (الكل) Combox  إخفاء خيار في   
                ctrlFelterPersons1.HighFelterAll();
            
        }

        /// <summary>
        /// تحميل بيانات المستخدم عند التعديل
        /// </summary>
        void LoadUserData()
        {
            lblTitle.Text = "Update User";
            this.Text = "Update User";
            Mode = "Update";

            if (user == null)
                return;
            lbl_IDUser.Text = user.IDUser.ToString();

            TxtUserName.Text = user.UserName;
            Chck_IsActive.Checked = user.Status_Account == "active";

            // تحميل الشخص المرتبط
            person = Cls_CMD_PresonsDB.GetPersonByID(user.IDPerson);
            ctrl_InfoPerson.LoadData(person);
        }



    

        /// <summary>
        /// Person  إحضار معلومات ال
        /// </summary>
        void GetPerson() 
        {
            person = ctrlFelterPersons1.person;
        }

        /// <summary>
        /// User التحقق من وجود الشخص مسبقاً ك 
        /// </summary>
        /// <returns></returns>
        bool IsPersonLinked()
        {
            if (person == null || person.IDPerson == 0)
            {
                MessageBox.Show("حدد الشخص أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            // إذا تعديل >>> اسمح له يبقى مرتبط ( بنفس ) الشخص أو شخص غير مرتبط مسبقاً
            if (Mode == "Update" && person.IDPerson == user.IDPerson)
                return false;

            bool linked = ClsCMD_UserDB.IsNotPersonLinkedToUser(person.IDPerson) == false;

            if (linked)
            {
                MessageBox.Show("هذا الشخص مرتبط بمستخدم آخر", "لا يمكنك الإكمال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;// يعني لا تكمل
            }

            return false; // الشخص غير مرتبط → يمكنك الإكمال
        }


        private void btnNext_Click(object sender, EventArgs e) // زر الانتقال للتاب الثاني
        {
            if (!IsPersonLinked()) // إذا الشخص غير مرتبط
            {
                TabCtrl.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// التحقق من الادخال
        /// </summary>
        bool IsValidUserInput()
        {
            if (IsPersonLinked()) return false;
            if (IsNull(TxtUserName)) return false;
            if (IsNull(TxtPassword)) return false;
            if (IsNull(TxtConfirmPassword)) return false;
            if (PasswordMatch()) return false;

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e) // زر الحفظ
        {
            if (!IsValidUserInput())
                return;

            string userName = TxtUserName.Text.Trim().ToLower();
            string password = TxtPassword.Text.Trim();

            if (Mode == "Add")
            {
                // 1) إضافة المستخدم
                int newID = ClsCMD_UserDB.AddUser(userName, password, IsActivo, person.IDPerson);
                lbl_IDUser.Text = newID.ToString();

                // 2) تحديث كائن user
                user.IDPerson = person.IDPerson;
                user.UserName = userName;
                user.Status_Account = IsActivo;
                user.IDUser = newID;

                // 3) تحويل الواجهة إلى تعديل
                Mode = "Update";

                // 4) تحميل البيانات
                LoadUserData();
            }
            else // Update
            {
                ClsCMD_UserDB.UpdateUser(user.IDUser, userName, password, IsActivo, person.IDPerson);
            }

            Add_UpdateUser?.Invoke();
           // this.Close();
        }


        #region  ****  التبويب الثاني  ****


        string IsActivo  = "Inactive";
        private void Chck_IsActive_CheckedChanged(object sender, EventArgs e) // Check Is Active
        {
            //تحديد اذا كان الحساب نشط 
            IsActivo = (Chck_IsActive.Checked ? "Active" : "Inactive").ToLower();
        }

        /// <summary>
        /// التحقق اذا كان العنصر فارغ
        /// </summary>
        bool IsNull(Control ctrl)
        {
            string Text = ctrl.Text;
            if(string.IsNullOrEmpty(Text))
            {
                errorProvider1.SetError(ctrl, "هذا الحقل مطلوب");
                return true;
            }

            else
            {
                errorProvider1.SetError(ctrl, "");
                return false;
            }
        }

        /// <summary>
        /// التحقق اذا كانت كلمتي المرور متطابقة
        /// </summary>
         bool PasswordMatch()
        {
            string Passwors1 = TxtPassword.Text;
            string Passwors2 = TxtConfirmPassword.Text;
            if (Passwors2 != Passwors1) //عدم تشابه
            {
                errorProvider1.SetError(TxtConfirmPassword, "هذا الحقل مطلوب");
                return true;
            }
            else
            {
                errorProvider1.SetError(TxtConfirmPassword, "");
                return false;
            }


        }
        #endregion





        FrmAdd_UpdatePersone frmAdd_Update;
        private void btnAddPerson_Click(object sender, EventArgs e) // Person  زر إضافة 
        {
            var frm = new FrmAdd_UpdatePersone();
            MyTools.ShowForm(frm);
        }


    }
}
                            