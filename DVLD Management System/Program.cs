using DVLD_Management_System.الواجهة_الرئيسية.تسجيل_الدخول;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.Run(new FormPerson());


           // Application.Run(new Form1()); // Test
           // 
        }
    }
}
