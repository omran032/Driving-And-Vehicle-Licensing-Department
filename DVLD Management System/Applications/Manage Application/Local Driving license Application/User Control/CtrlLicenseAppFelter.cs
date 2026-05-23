using DVLD_Management_System.Applications.Driver_Licenses_Services.New_Driving_License.Local_License.Class;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Users.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace DVLD_Management_System.Applications.Manage_Application.Local_Driving_license_Application.User_Control
namespace DVLD.Applications.LocalDrivingLicense
{
    public partial class CtrlLicenseAppFelter : UserControl
    {
        public CtrlLicenseAppFelter()
        {
            InitializeComponent();


        }

        /// DataTable لعرض نتيجة الفلتر في      
        public delegate void ShowFelterPerson(DataTable DataUser);
        public event ShowFelterPerson EventShowFelterUser;

        public DataTable DataTableUser = new DataTable();

        CancellationTokenSource cts;

        private async void TxtFelter_TextChanged_1(object sender, EventArgs e) // TextBox  عند تغيير النص في العنصر
        {
            cts?.Cancel(); // إلغاء أي عملية سابقة
            cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(600, cts.Token);

                string text = TxtFelter.Text.Trim();

                if (string.IsNullOrEmpty(TypeFelter) || string.IsNullOrEmpty(text))
                    return;

                switch (TypeFelter)
                {
                    case "request id":
                        int ID = text != "" ? int.Parse(text) : 0;
                        DataTableUser = clsLicenseClass.FelterLocalLicenseRequestsByRequestID(ID);
                        break;

                    case "national number":
                        string NationaNum = text != "" ? text : "0";
                        DataTableUser = clsLicenseClass.FelterLocalLicenseRequestsByNationalNum(NationaNum);
                        break;

                    case "full name":
                        DataTableUser = clsLicenseClass.FelterLocalLicenseRequestsByFullNamePerson(text);
                        break;

                    case "status":
                        // يمكن نستخدملها كومبوكس لحالها
                        break;
                }

                EventShowFelterUser?.Invoke(DataTableUser);
            }
            catch (TaskCanceledException)
            {
                // تجاهل الإلغاء
            }
        }



        string TypeFelter;
   
        private void ComboxFelter_SelectedIndexChanged(object sender, EventArgs e)  // Combox Filter
        {
            TxtFelter.Text = null;
            TypeFelter = ComboxFelter.Text.Trim().ToLower();

            TxtFelter.Enabled = true; // القيمة الافتراضية
            ControlHelper.EnableNumbersOnly(TxtFelter, false);
            switch (TypeFelter)
            {
                case "none":
                    DataTableUser = clsLicenseClass.GetLocalLicenseRequests();
                    EventShowFelterUser?.Invoke(DataTableUser);
                    break;

                case "request id":
              //  case "national number":
                    TxtFelter.Enabled = true;
                    ControlHelper.EnableNumbersOnly(TxtFelter, true);
                    break;
 
            }
        }
    }

}
