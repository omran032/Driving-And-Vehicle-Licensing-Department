using Dev_Note_Assistant;
using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Class.Class_DB;
using DVLD_Management_System.Properties;
using DVLD_Management_System.Tests.Ctrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class.ClassInfoLicenseAplication;

namespace DVLD_Management_System.Tests
{
    public partial class frmListTestApp : Form
    {
        public frmListTestApp(ClassInfoLicenseAplication infoLicenseApplication_, ClassInfoLicenseAplication.enTestType TestType_)
        {
            InitializeComponent();
            infoLicenseApplication = infoLicenseApplication_;
            TestType = TestType_; // نوغ الاختبار

            // Index عرض القائمة عند الضغط على صف ... ومعرفة 
            ShowNumberIndexRowSelectedInTable();
        }

        ClassInfoLicenseAplication infoLicenseApplication = new ClassInfoLicenseAplication();
        ClassInfoLicenseAplication.enTestType TestType    =     ClassInfoLicenseAplication.enTestType.VisionTest;


        int ID_Test = -1;
        int IndexRowSelected = -1;
        Action<int> OnRowRightClick;

        // Index عرض القائمة عند الضغط على صف ... ومعرفة 
        void ShowNumberIndexRowSelectedInTable()
        {
            OnRowRightClick = (d) =>
            {
                IndexRowSelected = d;
                DataRowSelected(IndexRowSelected);  // حفظ البيانات
            };

            ControlHelper.EnableRightClickSelection(DGV, MyContextMenuStrip, OnRowRightClick);
        }

        /// <summary>
        /// للصف المختار TestID معرفة 
        /// </summary>
        void DataRowSelected(int IndexRow)
        {
            ID_Test = Convert.ToInt32(DGV.Rows[IndexRow].Cells[0].Value);
        }

        DataTable DT;
  void LoadData_()
        {
            ///   تجلب  جميع الاختبارات المرتبطة بطلب معيّن ونوع اختبار محدد
            DT = Cls_CMDCommandLocalDrivingLicenceApp.GetTestsPerType(infoLicenseApplication.RequestID, (int)TestType);

          //  if (DGV.Columns.Contains("Result"))
               // DGV.Columns["Result"].Visible = false;

            if (DT == null)
            {
                DGV.DataSource = null;
                return;
            }

            // فحص الأعمدة الرقمية: إذا وُجدت فيها قيم نصية مثل "No" أو "N/A" نضيف عمود نصي بديل لعرضها
            // هذا يمنع DataGridView من محاولة تحويل نص غير رقمي إلى Int32 وإظهار استثناء،
            // وفي الوقت نفسه نحافظ على العمود الرقمي الأصلي للعمليات الحسابية.
            var cols = DT.Columns.Cast<System.Data.DataColumn>().ToList();
            foreach (var col in cols)
            {
                // نطبق على أنواع الأعداد الشائعة (صحيحة وعشرية)
                if (col.DataType == typeof(int) || col.DataType == typeof(long) || col.DataType == typeof(short) ||
                    col.DataType == typeof(decimal) || col.DataType == typeof(double) || col.DataType == typeof(float))
                {
                    bool hasNonNumeric = false;
                    foreach (System.Data.DataRow dr in DT.Rows)
                    {
                        var v = dr[col.ColumnName];
                        if (v == null || v == System.DBNull.Value) continue;
                        // إذا كانت القيمة ليست قابلة للتحويل لعدد نعتبرها نصية
                        long tmpLong;
                        decimal tmpDec;
                        if (!long.TryParse(v.ToString(), out tmpLong) && !decimal.TryParse(v.ToString(), out tmpDec))
                        {
                            hasNonNumeric = true;
                            break;
                        }
                    }

                    if (hasNonNumeric)
                    {
                        string textColName = col.ColumnName + "Text";
                        if (!DT.Columns.Contains(textColName))
                        {
                            DT.Columns.Add(textColName, typeof(string));
                            foreach (System.Data.DataRow dr in DT.Rows)
                            {
                                var v = dr[col.ColumnName];
                                if (v == null || v == System.DBNull.Value)
                                    dr[textColName] = string.Empty;
                                else
                                {
                                    // حافظ على العلامات النصية كما هي، وحول القيم الرقمية الشائعة إلى تمثيل نصي مقروء
                                    var s = v.ToString();
                                    if (s == "0") dr[textColName] = "No";
                                    else if (s == "1") dr[textColName] = "Yes";
                                    else dr[textColName] = s;
                                }
                            }
                        }
                    }
                }
            }

            // اربط DataGridView بالجدول بعد إضافة أعمدة النص حتى يتم استخدام أعمدة العرض النصية عندما وُجدت
            DGV.DataSource = DT;

            AddColumnIsLockedCheck();

            // ربط معالج أخطاء البيانات لمنع ظهور مربع خطأ عند تحويل القيم
            DGV.DataError -= DGV_DataError;
            DGV.DataError += DGV_DataError;

            // إذا أضفنا أعمدة نصية بديلة مثل ColNameText نخفي العمود الرقمي الأصلي حتى لا يحدث تحويل
            foreach (DataColumn c in DT.Columns)
            {
                if (c.ColumnName.EndsWith("Text"))
                {
                    string original = c.ColumnName.Substring(0, c.ColumnName.Length - 4);
                    if (DGV.Columns.Contains(c.ColumnName))
                    {
                        DGV.Columns[c.ColumnName].HeaderText = original;
                        DGV.Columns[c.ColumnName].ReadOnly = true;
                    }
                    if (DGV.Columns.Contains(original))
                    {
                        DGV.Columns[original].Visible = false;
                    }
                }
            }

            // تأكد من أن رؤوس الأعمدة والبيانات متوافقة مع أسماء الأعمدة الفعلية
            if (DT != null && DT.Columns.Count > 0)
            {
                if (DGV.Columns.Contains("TestID"))
                    DGV.Columns["TestID"].HeaderText = "Appointment ID";

                if (DGV.Columns.Contains("ExamDate"))
                    DGV.Columns["ExamDate"].HeaderText = "Appointment Date";

                if (DGV.Columns.Contains("FeesExam"))
                {
                    DGV.Columns["FeesExam"].HeaderText = "Paid Fees";
                    // حاول تنسيق الرسوم كقيمة رقمية
                    DGV.Columns["FeesExam"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (DGV.Columns.Contains("Result"))
                    DGV.Columns["Result"].HeaderText = "Result";

                // إذا أضفنا عمود IsLockedText فاعرضه وأخفي العمود الرقمي الأصلي لتجنب مشاكل التحويل
                if (DT.Columns.Contains("IsLockedText"))
                {
                    if (DGV.Columns.Contains("IsLockedText"))
                        DGV.Columns["IsLockedText"].HeaderText = "Is Locked";
                    if (DGV.Columns.Contains("IsLocked"))
                        DGV.Columns["IsLocked"].Visible = false;
                }
                else if (DGV.Columns.Contains("IsLocked"))
                {
                    DGV.Columns["IsLocked"].HeaderText = "Is Locked";

                    // عرض IsLocked بشكل مقروء (Yes/No) إن لم يكن هناك عمود نصي مخصص
                    foreach (DataGridViewRow r in DGV.Rows)
                    {
                        try
                        {
                            var cell = r.Cells["IsLocked"];
                            if (cell.Value == null || cell.Value == DBNull.Value)
                                cell.Value = "No";
                            else
                            {
                                int v;
                                if (int.TryParse(cell.Value.ToString(), out v))
                                    cell.Value = (v == 1) ? "Yes" : "No";
                                else
                                    cell.Value = (cell.Value.ToString().Trim() == "1") ? "Yes" : "No";
                            }
                        }
                        catch { }
                    }
                }
            }
        }


        /// <summary>
        /// الذي يعرض حالة الاختبار Check إضافة عمود 
        /// </summary>
        void AddColumnIsLockedCheck()
        {
            // إزالة أي عمود CheckBox سابق
            if (DGV.Columns.Contains("IsLockedCheck"))
                DGV.Columns.Remove("IsLockedCheck");

            // إنشاء عمود CheckBox جديد
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.Name = "IsLockedCheck";
            chk.HeaderText = "Is Locked";
            chk.DataPropertyName = "IsLocked";   // ربطه بالقيمة الأصلية 0/1
            chk.ReadOnly = true;                 // لأنه حالة فقط، مو للتعديل
            chk.ThreeState = false;

            // إضافة العمود
            DGV.Columns.Add(chk);

            // إخفاء العمود الرقمي الأصلي
            if (DGV.Columns.Contains("IsLocked"))
                DGV.Columns["IsLocked"].Visible = false;

            // إخفاء العمود النصي إذا كان موجود
            if (DGV.Columns.Contains("IsLockedText"))
                DGV.Columns["IsLockedText"].Visible = false;
        }


        // تحميل الفورم
        private void frmListTestApp_Load(object sender, EventArgs e)
        {
            if (infoLicenseApplication == null) return;
            // تحميل بيانات الطلب و المعلومات كاملة
            ctrl_DLApplInfo1.InfoLicenseAplication = infoLicenseApplication;

            Load_();

            LoadData_();

            if (DGV.Columns.Contains("TestID"))
                DGV.Columns["TestID"].HeaderText = "Appointment ID";

            if (DGV.Columns.Contains("ExamDate"))
                DGV.Columns["ExamDate"].HeaderText = "Appointment Date";

            if (DGV.Columns.Contains("FeesExam"))
            {
                DGV.Columns["FeesExam"].HeaderText = "Paid Fees";
                DGV.Columns["FeesExam"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (DGV.Columns.Contains("IsLocked"))
                DGV.Columns["IsLocked"].HeaderText = "Is Locked";

            if (DGV.Columns.Contains("IsLockedText"))
                DGV.Columns["IsLockedText"].HeaderText = "Is Locked";


            lblRecordsCount.Text = DT.Rows.Count.ToString();
        }


        void Load_()
        {
            switch (TestType)
            {
                case ClassInfoLicenseAplication.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Eye;
                        break;
                    }

                case ClassInfoLicenseAplication.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.exam;
                        break;
                    }
                case ClassInfoLicenseAplication.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.car;
                        break;
                    }
            }
        }

        //زر إضافة موعد جديد 
        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = infoLicenseApplication.RequestID;

            // التحقق من وجود موعد فعّال مسبقاً لنفس الطلب ونوع الاختبار
            if (ctrlScheduleTest.IsThereActiveScheduledTestLocal(LocalDrivingLicenseApplicationID, (int)TestType))
            {
                MessageBox.Show("يوجد بالفعل موعد اختبار فعّال لهذا الطلب ولنفس نوع الاختبار.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // منع جدولة اختبار جديد إذا كان الشخص قد نجح مسبقاً في نفس نوع الاختبار
            try
            {
                if (infoLicenseApplication.Person != null && infoLicenseApplication.Person.IDPerson > 0)
                {
                    bool passed = Cls_CMDCommandLocalDrivingLicenceApp.HasPersonPassedTestType(infoLicenseApplication.Person.IDPerson, (int)TestType);
                    if (passed)
                    {
                        MessageBox.Show("لا يمكن جدولة اختبار جديد لأن الشخص ناجح مسبقاً في نفس نوع الاختبار.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch { }

            frmScheduleTest frm = new frmScheduleTest(TestType , LocalDrivingLicenseApplicationID);
            frm.ctrlScheduleTest1.OnAppointmentSaved += LoadData_;
            frm.ShowDialog();

        }

        // زر تعديل موعد
        private void Context_Edit_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = ID_Test;
            int LocalDrivingLicenseApplicationID = infoLicenseApplication.RequestID;

            if (TestAppointmentID <= 0)
                return;

            // ❗ منع تعديل اختبار ظهرت نتيجته
            if (IsResultSet(TestAppointmentID))
            {
                MessageBox.Show("لا يمكن تعديل موعد اختبار ظهرت نتيجته (Pass/Fail).",
                                "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // إذا ما في نتيجة → اسمح بالتعديل
            frmScheduleTest frm = new frmScheduleTest(TestType, LocalDrivingLicenseApplicationID, TestAppointmentID);
            frm.ctrlScheduleTest1.OnAppointmentSaved += LoadData_;
            frm.ShowDialog();
        }


        // تنفيذ الاختبار
        private void Context_TakeTest_Click(object sender, EventArgs e)
        {
            // تأكد من وجود صف محدد
            int appointmentID = ID_Test;
            if (appointmentID <= 0)
            {
                MessageBox.Show("الرجاء تحديد موعد أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // افتح نافذة تسجيل نتيجة الاختبار ومرر المعرف ونوع الاختبار
            FrmTakeTest frm = new FrmTakeTest(appointmentID, TestType);
            frm.ShowDialog();

            // بعد إغلاق نافذة تسجيل النتيجة نعيد تحميل البيانات
            LoadData_();
        }

        // منع استثناءات تحويل البيانات في DataGridView
        private void DGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // إلغاء الخطأ حتى لا يظهر للمستخدم
            e.Cancel = true;
        }

        bool IsResultSet(int testID)
        {
            try
            {
                string q = "SELECT Result FROM Tests WHERE TestID = @TestID";
                var p = new Dictionary<string, object>() { { "@TestID", testID } };
                var dt = ClsCommandDB.SelectCommand(q, p);

                if (dt != null && dt.Rows.Count > 0)
                {
                    var v = dt.Rows[0][0];
                    return (v != DBNull.Value && !string.IsNullOrWhiteSpace(v.ToString()));
                }
            }
            catch { }

            return false;
        }

    }
}
