using DVLD_Management_System.Applications.Class;
using DVLD_Management_System.Applications.Driver_Licenses_Services.New_Driving_License.Local_License.Class;
using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
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
        // حدث يُشغّل بعد إضافة أو تعديل الطلب
        public event Action<Action> OnSaved; // المرسل يطلب Action (مثل AllData) ليتم تنفيذها من المستدعي
                 ////////// Constractor Add /////////////
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



        ////////// Constractor New /////////////

        public FrmAddUpdateApplication(ClassInfoLicenseAplication infoLicenseAplication)
        {
            InitializeComponent();

            LoadModeUpdate();
            LoadData();


            if (infoLicenseAplication != null)
            {
                // تعبئة بيانات الشخص
                person = infoLicenseAplication.Person;

                // تعبئة الواجهة
                ctrlFelterPersons1.person =  person ;


                // تعبئة فئة الرخصة
                try
                {
                    // LicenseClass in ClassInfoLicenseAplication may be the class name (e.g. "Class 2 - Heavy Motorcycle")
                    // while the combobox expects an integer ID. Resolve the ID safely.
                    if (!string.IsNullOrEmpty(infoLicenseAplication.LicenseClass))
                    {
                        int resolvedId = 0;

                        // 1) If the stored value is actually numeric text, use it directly
                        if (int.TryParse(infoLicenseAplication.LicenseClass, out resolvedId))
                        {
                            ComboxLicenseClass.SelectedValue = resolvedId;
                        }
                        else
                        {
                            // 2) Try to resolve from the combobox DataSource (DataTable provided by LoadData)
                            var ds = ComboxLicenseClass.DataSource as System.Data.DataTable;
                            string safeName = infoLicenseAplication.LicenseClass.Replace("'", "''");
                            bool set = false;

                            if (ds != null)
                            {
                                try
                                {
                                    var rows = ds.Select($"ClassName = '{safeName}'");
                                    if (rows.Length > 0)
                                    {
                                        resolvedId = rows[0]["LicenseClassID"] != System.DBNull.Value ? Convert.ToInt32(rows[0]["LicenseClassID"]) : 0;
                                        if (resolvedId > 0)
                                        {
                                            ComboxLicenseClass.SelectedValue = resolvedId;
                                            set = true;
                                        }
                                    }
                                }
                                catch { }
                            }

                            // 3) Fallback: query DB for matching class name
                            if (!set)
                            {
                                try
                                {
                                    var table = clsLicenseClass.AllClassName();
                                    if (table != null)
                                    {
                                        var r = table.Select($"ClassName = '{safeName}'");
                                        if (r.Length > 0)
                                        {
                                            resolvedId = r[0]["LicenseClassID"] != System.DBNull.Value ? Convert.ToInt32(r[0]["LicenseClassID"]) : 0;
                                            if (resolvedId > 0)
                                            {
                                                ComboxLicenseClass.SelectedValue = resolvedId;
                                                set = true;
                                            }
                                        }
                                        else
                                        {
                                            // try contains match as last resort
                                            var r2 = table.Select($"ClassName LIKE '%{safeName}%'");
                                            if (r2.Length > 0)
                                            {
                                                resolvedId = r2[0]["LicenseClassID"] != System.DBNull.Value ? Convert.ToInt32(r2[0]["LicenseClassID"]) : 0;
                                                if (resolvedId > 0)
                                                {
                                                    ComboxLicenseClass.SelectedValue = resolvedId;
                                                    set = true;
                                                }
                                            }
                                        }
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
                catch
                {
                    // leave combobox default selection on any error
                }

                // عرض رقم الطلب
                lblLocalDrivingLicebseApplicationID.Text = infoLicenseAplication.RequestID.ToString();
            }

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
        /// طريقة عامة لتحديث بيانات واجهة المستخدم بدون إعادة إرفاق معالجات الأحداث.
        /// يمكن للأشكال الأخرى (مثل FrmTakeTest) استدعاء هذا بعد التغييرات لكي يتم تحديث الجدول الرئيسي / عناصر التحكم.
        /// سيعيد هذا تحميل بيانات القوائم المنسدلة ويحدث عرض معلومات الشخص، ولكنه لن يستدعي EventFilter()
        /// لتجنب تكرار الاشتراكات في الأحداث.
        /// </summary>
        public void RefreshData()
        {
            if (DesignMode)
                return;

            // إعادة تحميل مصادر البيانات المشتركة (مثل القوائم المنسدلة)
            LoadData();

            // حاول تحديث عرض معلومات الشخص إذا كان متاحًا.
            // تم استخدام ctrl_InfoPerson.LoadData كمعالج حدث سابقًا، واستدعاؤه مباشرة يجدد واجهة المستخدم.
            try
            {
                // ctrl_InfoPerson.LoadData expects a Person parameter — pass the current person if available
                ctrl_InfoPerson?.LoadData(person);
            }
            catch
            {
                 // تجاهل أي أخطاء أثناء التحديث لتجنب تعطيل المستدعين.
            }
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
                    this.Close();
                    return;
                }

                // التحقق من وجود رخصة من نفس الفئة للشخص
                if (clsCMD_Licenses.IsLicenseExistByPersonID(IDPerson, ClassLisenseID) != -1)
                {
                    MessageBox.Show("هذا الشخص حاصل على هذه الفئة من الرخصة", "لا يمكن إضافة الطلب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                clsRequest Request = new clsRequest()
                {
                    Status = 0, // New 
                    Fees = 15,
                    DateRequest = DateTime.Now,
                    IDPerson = IDPerson,
                    LicenseClassID = ClassLisenseID,
                    RequestTypeID = (int)clsRequest.enApplicationType.NewDrivingLicense
                };

                // ID الطلب
                lblLocalDrivingLicebseApplicationID.Text = clsRequest.AddRequest(Request).ToString();
                LoadModeUpdate();

                // تشغيل الحدث إن وُجد: نمرّر مرجعاً لدالة التحديث العامة إذا كانت مفتوحة في الـ Forms
                try
                {
                    Action allDataDelegate = null;
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is DVLD_Management_System.Applications.FrmLocalDrivingLicenseApplication main)
                        {
                            allDataDelegate = new Action(main.AllData);
                            break;
                        }
                    }

                    OnSaved?.Invoke(allDataDelegate);
                }
                catch { }

            }

            else if (ModeForm == Mode.Update)
            {
                // تنفيذ التعديل عبر clsRequest.UpdateRequest
                int reqId = 0;
                try { reqId = Convert.ToInt32(lblLocalDrivingLicebseApplicationID.Text); } catch { reqId = 0; }
                if (reqId <= 0) return;

                clsRequest r = new clsRequest()
                {
                    RequestID = reqId,
                    LicenseClassID = Convert.ToInt32(ComboxLicenseClass.SelectedValue)
                };

                bool updated = clsRequest.UpdateRequest(r);
                if (updated)
                {
                    MessageBox.Show("تم تحديث الطلب بنجاح", "تم التحديث", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // تشغيل الحدث لإبلاغ الأب بتحديث البيانات
                    try
                    {
                        Action allDataDelegate = null;
                        foreach (Form f in Application.OpenForms)
                        {
                            if (f is DVLD_Management_System.Applications.FrmLocalDrivingLicenseApplication main)
                            {
                                allDataDelegate = new Action(main.AllData);
                                break;
                            }
                        }

                        OnSaved?.Invoke(allDataDelegate);
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("فشل تحديث الطلب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                 
        }


    }
}
