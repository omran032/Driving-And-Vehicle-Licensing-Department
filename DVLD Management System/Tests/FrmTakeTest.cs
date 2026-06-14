using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;

namespace DVLD_Management_System.Tests
{
    using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول;
    using DVLD_Management_System.Tests.Class;

    public partial class FrmTakeTest : Form
    {
        private int _AppointmentID;
        private ClassInfoLicenseAplication.enTestType _TestType;

        private int _TestID = -1;
        private clsTest _Test;


        public FrmTakeTest(int AppointmentID, ClassInfoLicenseAplication.enTestType TestType)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _TestType = TestType;

        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSecheduledTest1.TestTypeID = _TestType;

            ctrlSecheduledTest1.LoadInfo(_AppointmentID);

            btnSave.Enabled = ctrlSecheduledTest1.TestAppointmentID != -1;

            _TestID = ctrlSecheduledTest1.TestID;
            if (_TestID != -1)
            {
                // حاول جلب كائن clsTest، وإن لم يوجد نهيئ كائناً جديداً لتجنّب NullReferenceException
                _Test = clsTest.Find(_TestID);
                if (_Test == null)
                {
                    _Test = new clsTest();
                }

                // إذا وجدنا نتيجة محفوظة اعرضها
                if (!string.IsNullOrEmpty(_Test.Notes) || _Test.TestResult)
                {
                    if (_Test.TestResult)
                        rbPass.Checked = true;
                    else
                        rbFail.Checked = true;

                    txtNotes.Text = _Test.Notes ?? string.Empty;

                    lblUserMessage.Visible = true;
                    // اسمح بتعديل النتيجة إذا لزم الأمر (لا نقوم بتعطيل الأزرار)
                    rbFail.Enabled = true;
                    rbPass.Enabled = true;
                }
            }
            else
            {
                // لم يكن هناك معرف اختبار → نهيئ كائن جديد دائماً
                _Test = new clsTest();
            }

        }

        

       
        // زر الحفظ
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
             )
            {
                return;
            }

            // تأكد أن _Test مهيأ
            if (_Test == null) _Test = new clsTest();

            _Test.TestAppointmentID = _AppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = ClassUser.IDUser <= 0 ? 3 : ClassUser.IDUser;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                try
                {
                    int requestId = ctrlSecheduledTest1.RequestID;
                    if (requestId > 0)
                    {
                        // Adjust request-level PassedTests depending on transition
                        // إذا انتقلنا من غير ناجح إلى ناجح → زِد
                        // إذا انتقلنا من ناجح إلى غير ناجح → أنقص
                        bool currentIsPass = _Test.TestResult;
                        // محاولة جلب الحالة السابقة من قاعدة البيانات عبر TestID (إذا وُجد)
                        bool previousIsPass = false;
                        if (_Test.TestID > 0)
                        {
                            var old = clsTest.Find(_Test.TestID);
                            if (old != null) previousIsPass = old.TestResult;
                        }

                        if (!previousIsPass && currentIsPass)
                        {
                            Cls_CMDCommandLocalDrivingLicenceApp.IncrementRequestPassedTests(requestId);
                        }
                        else if (previousIsPass && !currentIsPass)
                        {
                            Cls_CMDCommandLocalDrivingLicenceApp.DecrementRequestPassedTests(requestId);
                        }

                        // بعد التعديل، تحقق إذا وصل العداد إلى 3 → حدّث الحالة إلى Completed
                        int passed = Cls_CMDCommandLocalDrivingLicenceApp.GetRequestPassedTests(requestId);
                        if (passed >= 3)
                            Cls_CMDCommandLocalDrivingLicenceApp.UpdateRequestStatus(requestId, 1);
                        else
                            Cls_CMDCommandLocalDrivingLicenceApp.UpdateRequestStatus(requestId, 0);

                        // إذا كانت واجهة FrmLocalDrivingLicenseApplication مفتوحة فحدّثها فورياً
                        foreach (Form f in Application.OpenForms)
                        {
                            if (f is DVLD_Management_System.Applications.FrmLocalDrivingLicenseApplication frm)
                            {
                                try { frm.RefreshData(); } catch { }
                            }
                        }
                    }
                }
                catch { }
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // زر الاغلاق
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
