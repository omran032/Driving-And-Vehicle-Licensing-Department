using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Management_System.الواجهة_الرئيسية;
using DVLD_Management_System.Manage_Users;
using DVLD_Management_System.Local_Licenses;
using DVLD_Management_System.Applications.Manage_Application.Local_Driving_License_Application.UI;



namespace DVLD_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


             Application.Run(new FormLogin()); // Log (Main)
            //   Application.Run(new FormMain()); //Main

           //  Application.Run(new FrmShowLicenses()); 
            //Application.Run(new FormPerson());
            //Application.Run(new FormShowUsers());
            //Application.Run(new FrmAdd_UpdateUser());


            // Application.Run(new Form1()); // Test
            // 
        }
    }
}
