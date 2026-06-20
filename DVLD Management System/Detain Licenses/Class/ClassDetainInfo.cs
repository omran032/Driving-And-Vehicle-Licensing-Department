using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Detain_Licenses.Class
{
    public class ClassDetainInfo
    {
        public int DetainID { get; set; }

        public int LicenseID { get; set; }

        public string Reason { get; set; }

        public int Fees { get; set; }

        public DateTime DeainDate { get; set; }


    }
}
