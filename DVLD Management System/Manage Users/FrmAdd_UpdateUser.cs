using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Persons.User_Control;
using DVLD_Management_System.Manage_Persons.واجهات_فرعية;
using DVLD_Management_System.Manage_Users.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Management_System.Manage_Persons.واجهات_فرعية.FrmAdd_UpdatePersone;

namespace DVLD_Management_System.Manage_Users
{
    public partial class FrmAdd_UpdateUser : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Process">العملية</param>
        public FrmAdd_UpdateUser(string Process = "Add New User") 
        {
            InitializeComponent();

            lblTitle.Text = Process;
            this.Text = Process;

            EventFelter();
        }
        private void btnClose_Click(object sender, EventArgs e) // إغلاق 
        {
            this.Close();
        }

        Person person;

        void EventFelter()
        {
            // تسجيل الدالة التي تقوم بعرض المعلومات.. في الحدث عند الفلترة
            ctrlFelterPersons.EventShowFelterPersons += ctrl_InfoPerson.LoadData;
            // Person  إحضار معلومات ال
            ctrlFelterPersons.EventFelterPersons +=  GetPerson;

            //  (الكل) Combox  إخفاء خيار في   
            ctrlFelterPersons.HighFelterAll();
        }

        // حدث يعمل بعد الاضافة أو التعديل
        public delegate void Add_UpdateUserEventHandler();
        public event Add_UpdateUserEventHandler Add_UpdateUser; 


     
      

        /// <summary>
        /// Person  إحضار معلومات ال
        /// </summary>
        void GetPerson() 
        {
            person = ctrlFelterPersons.person;
        }

        bool IsPersonLinked()
        {
            if (person == null)
            {
                MessageBox.Show("حدد الشخص أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true; // يعني مرتبط أو غير صالح
            }

            int IDPerson = person.IDPerson;

            bool linked = ClsCMD_UserDB.IsNotPersonLinkedToUser(IDPerson) == false;

            if (linked)
            {
                MessageBox.Show("هذا الشخص مرتبط بمستخدم", "لا يمكنك الإكمال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // يعني لا تكمل
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
            if (Passwors2 != Passwors2) //عدم تشابه
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




        private void btnSave_Click(object sender, EventArgs e) //حفظ المستخدم
        {
            string UserName = TxtUserName.Text.Trim().ToLower();
            string Password = TxtPassword.Text.Trim();
            string ConfirmPassword = TxtConfirmPassword.Text.Trim() ;
          
            if (IsPersonLinked() || IsNull(TxtUserName) || IsNull(TxtPassword) || IsNull(TxtConfirmPassword) || PasswordMatch())
                return;

            else
            {
                ClsCMD_UserDB.AddUser(UserName, Password , IsActivo ,person.IDPerson);
                //هون بتنفذ امر إضافة اليوزر
                //بس تنجح العملية سواء اضافة او تعديل ..بقوم بتنفيذ الحدث
                Add_UpdateUser?.Invoke();
            }



        }

        FrmAdd_UpdatePersone frmAdd_Update;
        private void btnAddPerson_Click(object sender, EventArgs e) // Person  زر إضافة 
        {
            frmAdd_Update = new FrmAdd_UpdatePersone();
            frmAdd_Update.onEventRefreachData += ShowIDPerson;
            //تسجيل المثود بالحدث
            MyTools.ShowForm(frmAdd_Update);
            
        }

        void ShowIDPerson()
        {
            frmAdd_Update.ctrl_Add_UpdatePerson1.OnProcessCompleted += (id) =>
            {
                frmAdd_Update.ctrl_Add_UpdatePerson1.PersonID = id;
                lbl_IDUser.Text = id.ToString();
            };

        }
    }
}
                            