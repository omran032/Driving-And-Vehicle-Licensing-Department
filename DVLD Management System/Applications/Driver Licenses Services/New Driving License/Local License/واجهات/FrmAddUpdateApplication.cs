using DVLD_Management_System.Applications.Class;
using DVLD_Management_System.Applications.Driver_Licenses_Services.New_Driving_License.Local_License.Class;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Persons.User_Control;
using DVLD_Management_System.Manage_Users;
using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;

namespace DVLD_Management_System.Applications
{
    public partial class FrmAddUpdateApplication : Form
    {
                 ////////// Constractor New /////////////
        public FrmAddUpdateApplication()
        {
            InitializeComponent();

            ModeForm = Mode.New;
            EventFilter();
            LoadData();

            // المستخدم مسجل الطلب
            lblCreatedByUser.Text   = ClassUser.UserName;
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblTitle.Text = "Local Driving License Application";
        }

        ////////// Constractor Update /////////////
        public FrmAddUpdateApplication(int info)
        {
            InitializeComponent();

            LoadModeUpdate();
            LoadData();

            // المستخدم مسجل الطلب
            lblCreatedByUser.Text = ClassUser.UserName;
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }


        enum Mode { New = 1 , Update = 2 };
              Mode ModeForm;

        private void FrmAddUpdateApplication_Load(object sender, EventArgs e) // Load Form
        {
            
        }
        void LoadData()
        {
            // Combox  عرض فئات الرخص في 
            clsLicenseClass.DisplayCLassNameInCombox(ComboxLicenseClass);

        }
        /// <summary>
        /// تفعيل وضع التعديل
        /// </summary>
        void LoadModeUpdate()
        {
            ModeForm = Mode.Update;
            ctrlFelterPersons1.Enabled = false;
            lblTitle.Text = "Update Local Driving License Application";


        }

        Person person;

        void EventFilter()
        {
            if (DesignMode)
                return;
            // تسجيل الدالة التي تقوم بعرض المعلومات.. في الحدث عند الفلترة
            ctrlFelterPersons1.EventShowFelterPersons += ctrl_InfoPerson.LoadData;
            // Person  إحضار معلومات ال
            ctrlFelterPersons1.EventFelterPersons += GetPerson;

            //   Combox  إخفاء خيار (الكل) في   
            ctrlFelterPersons1.HighFelterAll();

        }
       
        /// <summary>
        /// Person  إحضار معلومات ال
        /// </summary>
        void GetPerson()
        {    
            person = ctrlFelterPersons1.person;
        }

        private void btnNext_Click(object sender, EventArgs e) // Next زر 
        {
                MyTabControl.SelectedIndex = 1;
        }

         
        private void btnSave_Click(object sender, EventArgs e) // زر الحفظ
        {
            if(person == null || person.IDPerson == 0)
            {
                MessageBox.Show("لا يمكن الإكمال حدد الشخص أولاً", "خطأ" ,MessageBoxButtons.OK, MessageBoxIcon.Error) ;
                return;
            }
            int IDPerson = person.IDPerson;

            // فئة الرخصة المختارة ID 
            int ClassLisenseID = Convert.ToInt32(ComboxLicenseClass.SelectedValue);
            if(ClassLisenseID == 0)
            {
                MessageBox.Show("لا يمكن الإكمال حدد فئة الرخصة أولاً", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ModeForm == Mode.New)
            {

                // التحقق من وجود طلب مشابه قبل
                int APPlicationID = ClsCMD_LocalLicense.GetActiveApplicationIDForLicenseClass(IDPerson, clsRequest.enApplicationType.NewDrivingLicense, ClassLisenseID); // DB بدك تاخذه من 

                // اذا كان موجود ...رفض
                if (APPlicationID != -1)
                {
                    MessageBox.Show("هذا الشخص لديه طلب بالفعل في نفس الفئة", "لا يمكن إضافة الطلب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // التحقق من وجود رخصة من نفس الفئة للشخص
                if (clsCMD_Licenses.IsLicenseExistByPersonID(IDPerson, ClassLisenseID) != -1)
                {
                    MessageBox.Show("هذا الشخص حاصل على هذه الفئة من الرخصة", "لا يمكن إضافة الطلب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                clsRequest Request = new clsRequest()
                {
                    Status = 1,
                    Fees = 15,
                    DateRequest = DateTime.Now,
                    IDPerson = IDPerson,
                    LicenseClassID = ClassLisenseID,
                    RequestTypeID = (int)clsRequest.enApplicationType.NewDrivingLicense
                };

                // ID الطلب
                lblLocalDrivingLicebseApplicationID.Text = clsRequest.AddRequest(Request).ToString();
                LoadModeUpdate();

            }

            else if(ModeForm == Mode.Update)
            {
                
                // وضع امر التعديل 
            }
                 
        }


    }
}
