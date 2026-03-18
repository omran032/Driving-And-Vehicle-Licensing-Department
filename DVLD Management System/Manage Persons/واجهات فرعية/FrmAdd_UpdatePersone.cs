using DVLD_Management_System.Class.Class;
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

namespace DVLD_Management_System.Manage_Persons.واجهات_فرعية
{
    public partial class FrmAdd_UpdatePersone : Form
    {
        // حدث يقوم بحديث البيانات بالواجهة
        public delegate void RefreachData();
        public event RefreachData onEventRefreachData;


        /// <summary>
        /// واجهة تعديل بيانات  بيانات الاشخاص constractor 
        /// </summary>
        /// <param name="person_">بيانات الشخص</param>
        public FrmAdd_UpdatePersone(Person person_)
        {
            person = person_;
            IsUpdate = true;

            InitializeComponent();

            lblTitle.Text = "تعديل المعلومات";


            ctrl_Add_UpdatePerson1.OnRefreshData = RefrechData; //ارسال مثود للحدث
        }

        public int PersonID;
        public static Person person;
        public static bool   IsUpdate;

        /// <summary>
        /// واجهة لاضافة الاشخاص constractor 
        /// </summary>
        public FrmAdd_UpdatePersone()
        {
            IsUpdate = false;

            InitializeComponent();
            lblTitle.Text = "إضافة شخص";
            ctrl_Add_UpdatePerson1.IsUpdate = false;

            ctrl_Add_UpdatePerson1.OnRefreshData = RefrechData; //ارسال مثود للحدث
        }

        /// <summary>
        /// تحديث القائمة
        /// </summary>
        void RefrechData()
        {
            onEventRefreachData?.Invoke();
        }


     

      
    }
}
