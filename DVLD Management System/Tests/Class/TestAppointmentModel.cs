using System;

namespace DVLD_Management_System.Tests.Class
{
    // نموذج بيانات بسيط لحمل معلومات موعد الاختبار
    public class TestAppointmentModel
    {
        public int TestID { get; set; }
        public int RequestID { get; set; }
        public int TestTypeID { get; set; }
        public DateTime? ExamDate { get; set; }
        public int Fees { get; set; }
        public string Result { get; set; }
    }
}
