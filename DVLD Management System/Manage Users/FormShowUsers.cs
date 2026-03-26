using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Persons.Class;
using DVLD_Management_System.Manage_Users;
using DVLD_Management_System.Manage_Users.Class;
using DVLD_Management_System.Manage_Users.User_Control;
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
    public partial class FormShowUsers : Form
    {
        public FormShowUsers()
        {
            InitializeComponent();

            LoadData();
            Events();
        }

        int IgnoreRow = 0;
        int CountPerson = 0;

        // الذي يعمل عند الفلنرة CtrlFeltterUser تسجيل الحدث في عنصر 
        void Events()
        {
               // العنصر
            ctrlFeltterUser1.EventShowFelterUser += ShowFeltter;
        }

        void LoadData()
        {    
            // عرض اول 50 شخص
            DGV.DataSource = ClsCMD_UserDB.Next50Users(IgnoreRow);

            // عرض عدد الاشخاص
            CountPerson = ClsCMD_UserDB.CountUsers(); // العدد الحقيقي
            lblNumberUsers.Text = CountPerson.ToString();

            // هل يمكن عرض المزيد من الاشخاص
            if (IgnoreRow + 50 >= CountPerson)
            {
                PicNext.Visible = false; //الغاء الانتقال
                lblNumberInfo.Visible = false;
            }
            else
                PicNext.Visible = true;

            PicPrevious.Visible = false; // الغاء الرجوع

            // اخفاء الاعمدة
            DGV.Columns["الصلاحيات"].Visible = false;
            DGV.Columns["الدور"].Visible = false;

        }



        void ShowFeltter(DataTable data)
        {
            DGV.DataSource = data;
        }


        int currentRow = -1; //رقم الصف المختار
        private void DGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) // حدث تحديد الصف بالماوس
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGV.ClearSelection();
                DGV.Rows[e.RowIndex].Selected = true;

                currentRow = e.RowIndex; // تخزين رقم الصف

                DGV.ClearSelection();
                DGV.Rows[e.RowIndex].Selected = true;
                DGV.CurrentCell = DGV.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // إظهار القائمة
                DGV.ContextMenuStrip = MyContextMenuStrip;
            }
            else
                DGV.ContextMenuStrip = null;
        }

        Users users = new Users();
        Person person = new Person();


        /// <summary>
        /// تخزين المعلومات
        /// </summary>
        void InformationRow()
        {
            var row = DGV.Rows[currentRow];

            users.IDUser   = Convert.ToInt32(row.Cells["ID"].Value.ToString());
            users.IDPerson = Convert.ToInt32(row.Cells["معرف الشخص"].Value);
            users.UserName       = row.Cells["أسم المستخدم"].Value.ToString();
            users.Status_Account = row.Cells["حالة الحساب"].Value.ToString();
            users.Authorities    = row.Cells["الصلاحيات"].Value.ToString();
            users.Role           = row.Cells["الدور"].Value.ToString();
        }

        /// <summary>
        /// Person إحضار معلومات ال
        /// </summary>
        void InfoPerson()
        {
            person =  Cls_CMD_PresonsDB.GetPersonByID(users.IDPerson);
        }

        private void PicNext_Click(object sender, EventArgs e) // زر عرض 50 الصف الجدد
        {
            if (IgnoreRow + 50 < CountPerson)
            {
                IgnoreRow += 50;
                DGV.DataSource = Cls_CMD_PresonsDB.Next50Person(IgnoreRow);
                PicPrevious.Visible = true; // تفعيل الرجوع
            }

            if (IgnoreRow + 50 >= CountPerson)
                PicNext.Visible = false; //الغاء الانتقال           

            lblNumberInfo.Text = IgnoreRow.ToString();
        }


        private void PicPrevious_Click(object sender, EventArgs e)// زر عرض 50 صف السابقين
        {
            if (IgnoreRow >= 50)
            {
                IgnoreRow -= 50;
                DGV.DataSource = Cls_CMD_PresonsDB.Next50Person(IgnoreRow);
                PicNext.Visible = true; // تفعيل الانتقال
            }
            if (IgnoreRow == 0)
            {
                PicPrevious.Visible = false; // الغاء الرجوع
            }

            lblNumberInfo.Text = IgnoreRow.ToString();
        }




        private void CTMS_btnShowInfo_Click(object sender, EventArgs e) //عرض المعلومات
        {
            InformationRow();
            InfoPerson();

            FrmInfoUser infoUser = new FrmInfoUser(users, person);
            MyTools.ShowForm(infoUser);
        }

        private void CTMS_btnUpdate_Click(object sender, EventArgs e) // تعديل بيانات المستخدم
        {
            InformationRow();
            FrmAdd_UpdateUser frmAdd_Update = new FrmAdd_UpdateUser(users);
            //تنفيذه عند الإضافة او التعديل
            frmAdd_Update.Add_UpdateUser += LoadData; 
            MyTools.ShowForm(frmAdd_Update);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) // تعديل كلمة السر
        {
            InformationRow();
            InfoPerson();

            FrmChangePassword changePassword = new FrmChangePassword(users, person);
            MyTools.ShowForm(changePassword);
        }

        private void CTMS_btnDelete_Click(object sender, EventArgs e) // حذف المستخدم
        {
            InformationRow();
            DialogResult = MessageBox.Show("هل انت متأكد من حذف المستخدم ؟", "تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            int result = 0;

            if(DialogResult == DialogResult.OK)
                result = ClsCMD_UserDB.DeleteUser(users.IDUser);

            //إذا نحذف ...حدث القائمة
            if (result == 1)
                LoadData();

        }

        private void btnAdd_Click(object sender, EventArgs e) // User  إضافة   
        {
            FrmAdd_UpdateUser frmAdd_Update = new FrmAdd_UpdateUser();
            frmAdd_Update.Add_UpdateUser += LoadData; //تنفيذه عند الإضافة او التعديل
            MyTools.ShowForm(frmAdd_Update);

        }

      
    }
}
