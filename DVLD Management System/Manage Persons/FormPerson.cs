using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Class.Class_DB;
using DVLD_Management_System.Manage_Persons.Class;
using DVLD_Management_System.Manage_Persons.واجهات_فرعية;
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
    public partial class FormPerson : Form
    {
        public FormPerson()
        {
            InitializeComponent();

            LoadData();
        }


        #region [[[[ ازرار وعناصر ]]]]

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

        private void PicPrevious_Click(object sender, EventArgs e) // زر عرض 50 صف السابقين
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

        int currentRow = -1;

     

        private void CTMS_btnShowInfo_Click(object sender, EventArgs e) // زر عرض المعلومات
        {
            InformationRow();
            FrmShowPerson showPerson = new FrmShowPerson(person);
            showPerson.Show();
        }


        private void CTMS_btnUpdate_Click(object sender, EventArgs e) // زر تعديل معلومات الشخص
        {
            InformationRow();
            //واجهة الاضافة
            FrmAdd_UpdatePersone frmAdd_Update = new FrmAdd_UpdatePersone(person);
            //تسجيل المثود بالحدث
            frmAdd_Update.onEventRefreachData += RefrechData;
            MyTools.ShowForm(frmAdd_Update);

        }

        private void CTMS_btnDelete_Click(object sender, EventArgs e) // حذف الشخص
        {
            InformationRow();
            Cls_CMD_PresonsDB.DeletePerson(person.IDPerson); //امر حذف الشخص
            RefrechData();
        }


        private void btnAdd_Click(object sender, EventArgs e) //زر الاضافة
        {
            FrmAdd_UpdatePersone frmAdd_Update = new FrmAdd_UpdatePersone();
            //تسجيل المثود بالحدث
            frmAdd_Update.onEventRefreachData += RefrechData;
            MyTools.ShowForm(frmAdd_Update);
        }

        #endregion

        string TypeFelter;
        private void TxtFelter_Leave(object sender, EventArgs e) // حدث عند الخروج من العنصر
        {
            string textFelter = TxtFelter.Text;

            if (string.IsNullOrEmpty(TypeFelter) && string.IsNullOrEmpty(textFelter))
                return;

            if (TypeFelter == "البحث برقم الشخص")
                DGV.DataSource = Cls_CMD_PresonsDB.SearchPerson_ID(textFelter, "ID");

            if (TypeFelter =="البحث بالاسم")
                DGV.DataSource = Cls_CMD_PresonsDB.SearchPerson_ID(textFelter, "FullName");

            if (TypeFelter =="البحث بالرقم الوطني")
                DGV.DataSource = Cls_CMD_PresonsDB.SearchPerson_ID(textFelter, "National Number");

        }


        private void ComboFelter_SelectedIndexChanged(object sender, EventArgs e) // ComboBox  عند الاختيار في
        {
            TypeFelter = ComboFelter.Text.Trim();
        }


        // *********************************************

        #region [[[[ اوامر التعامل مع الواجهة وبياناتها  ]]]]

        int CountPerson;
        int IgnoreRow = 0;

        void LoadData()
        {
            // عرض اول 50 شخص
            DGV.DataSource = Cls_CMD_PresonsDB.Next50Person(IgnoreRow);

            // عرض عدد الاشخاص
            CountPerson = Cls_CMD_PresonsDB.CountPersons(); // العدد الحقيقي
            lblNumberPersun.Text = CountPerson.ToString();

            // هل يمكن عرض المزيد من الاشخاص
            if (IgnoreRow + 50 >= CountPerson)
            {
                PicNext.Visible = false; //الغاء الانتقال
                lblNumberInfo.Visible =false;
            }
            else
                PicNext.Visible = true;

            PicPrevious.Visible = false; // الغاء الرجوع

            // اخفاء الاعمدة
           // DGV.Columns["ID"].Visible = false;
            DGV.Columns["الايميل"].Visible = false;
            DGV.Columns["الجنس"].Visible = false;
            DGV.Columns["الميلاد"].Visible = false;
            DGV.Columns["الصورة"].Visible = false;
        }

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


        Person person = new Person(); // معلومات الشخص

        /// <summary>
        /// تخزين المعلومات
        /// </summary>
        void InformationRow()
        {
            var row = DGV.Rows[currentRow];

            person.IDPerson = Convert.ToInt32(row.Cells["ID"].Value);
            person.FullName =        row.Cells["الاسم الكامل"].Value.ToString();
            person.National_Number = row.Cells["الرقم الوطني"].Value.ToString();
            person.Housing =         row.Cells["السكن"].Value.ToString();
            person.NumPhone =        row.Cells["رقم الهاتف"].Value.ToString();
            person.Email  =          row.Cells["الايميل"].Value.ToString();
            person.Nationality  =    row.Cells["الجنسية"].Value.ToString();
            person.Gender  =         row.Cells["الجنس"].Value.ToString();
            person.Birthdate  = Convert.ToDateTime(row.Cells["الميلاد"].Value);
            person.Picture  =        row.Cells["الصورة"].Value as byte[];


           // MessageBox.Show(person.IDPerson + "");
        }
  
      
        /// <summary>
        /// تحديث البيانات بعد الاضافة او تعديل
        /// </summary>
        void RefrechData()
        {
            // عرض اول 50 شخص
            DGV.DataSource = Cls_CMD_PresonsDB.Next50Person(IgnoreRow);

            // عرض عدد الاشخاص
            CountPerson = Cls_CMD_PresonsDB.CountPersons(); // العدد الحقيقي
            lblNumberPersun.Text = CountPerson.ToString();
        }



        #endregion

      
    }
}
