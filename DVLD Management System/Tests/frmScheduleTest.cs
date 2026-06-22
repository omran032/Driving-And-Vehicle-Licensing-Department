using DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.Class;
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

namespace DVLD_Management_System.Tests
{
    public partial class frmScheduleTest : Form
    {
        
        public frmScheduleTest(ClassInfoLicenseAplication.enTestType TestTypeID, int localAppID, int appointmentID = -1)
        {
            InitializeComponent();

            ctrlScheduleTest1.Dock = DockStyle.Fill;

            // تحديد نوع الاختبار
            ctrlScheduleTest1.TestTypeID = TestTypeID;

            // تمرير البيانات
            ctrlScheduleTest1.LoadInfo(localAppID, appointmentID);
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {

        }
    }
}
