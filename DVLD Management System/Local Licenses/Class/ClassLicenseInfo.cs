using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Class.Class_DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Management_System.Local_Licenses.Class
{
    public class ClassLicenseInfo
    {
        public int LicenseID { get; set; }
        public int RequestID { get; set; }
        public bool StatusRelease { get; set; }
        public bool IsDetained { get; set; }
        public string ClassName { get; set; }
        public string FullName { get; set; }
        public string NationalNo { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }

        public int PersonID { get; set; }

        private int DriverID_;

        public int DriverID
        { get { return DriverID_; }
            set
            {
                DriverID_ = value;
                //استخراج معرف الشخص
                PersonID = GetPersonIDByDriverID(DriverID_);
            }
        }


        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string IssueReason { get; set; }
        public string Notes { get; set; }

        

    public byte[] PersonPicture { get; set; }   // ← الصورة الجديدة





        /// <summary>
        /// جلب معلومات الرخصة كاملة اعتماداً على معرف الطلب (RequestID)
        /// تقوم الميثود بإيجاد الرخصة المرتبطة بالطلب ثم تعيد جميع بياناتها
        /// </summary>
        /// <summary>
        /// جلب معلومات الرخصة كاملة اعتماداً على معرف الطلب (RequestID)
        /// تقوم الميثود بجلب بيانات الرخصة + بيانات السائق + بيانات الشخص
        /// بما في ذلك صورة الشخص المخزنة في قاعدة البيانات
        /// </summary>
        public static ClassLicenseInfo GetLicenseInfoByRequestID(int requestID)
        {
            ClassLicenseInfo info = null;

            using (SqlConnection con = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = @"
        SELECT 
            L.LicenceID,
            L.StatusRelease,
            L.RelesaseDate,
            L.EndDate,
            L.DriverID,
            LC.ClassName,
            P.FullName,
            P.[National number],
            P.Gender,
            P.Birthdate,
            P.Picture   -- ← جلب صورة الشخص
        FROM Licenses L
        INNER JOIN Drivers D ON L.DriverID = D.DriverID
        INNER JOIN Persons P ON D.PersonID = P.IDPerson
        INNER JOIN LicenseClass LC ON L.LicenseClassID = LC.LicenseClassID
        WHERE L.RequestID = @RequestID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RequestID", requestID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    info = new ClassLicenseInfo
                    {
                        RequestID = requestID,
                        LicenseID = reader.GetInt32(0),
                        StatusRelease = reader.GetBoolean(1),
                        IssueDate = reader.GetDateTime(2),
                        ExpirationDate = reader.GetDateTime(3),
                        DriverID = reader.GetInt32(4),
                        ClassName = reader.GetString(5),
                        FullName = reader.GetString(6),
                        NationalNo = reader.GetString(7),
                        Gender = reader.GetString(8),
                        Birthdate = reader.GetDateTime(9),

                        // الصورة (قد تكون NULL)
                        PersonPicture = reader["Picture"] != DBNull.Value
                                        ? (byte[])reader["Picture"]
                                        : null,

                        // قيم ثابتة حالياً
                        IssueReason = "First Time",
                        Notes = ""
                    };
                }
            }

            return info;
        }



        public static ClassLicenseInfo GetLicenseInfoLicenseID(int LicenseID)
        {
            ClassLicenseInfo info = null;

            using (SqlConnection con = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = @"
        SELECT 
            L.RequestID,
            L.StatusRelease,
            L.RelesaseDate,
            L.EndDate,
            L.DriverID,
            LC.ClassName,
            P.FullName,
            P.[National number],
            P.Gender,
            P.Birthdate,
            P.Picture   -- ← جلب صورة الشخص
        FROM Licenses L
        INNER JOIN Drivers D ON L.DriverID = D.DriverID
        INNER JOIN Persons P ON D.PersonID = P.IDPerson
        INNER JOIN LicenseClass LC ON L.LicenseClassID = LC.LicenseClassID
        WHERE L.LicenceID = @LicenseID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    info = new ClassLicenseInfo
                    {
                        LicenseID = LicenseID,
                        RequestID = reader.GetInt32(0),
                        StatusRelease = reader.GetBoolean(1),
                        IssueDate = reader.GetDateTime(2),
                        ExpirationDate = reader.GetDateTime(3),
                        DriverID = reader.GetInt32(4),
                        ClassName = reader.GetString(5),
                        FullName = reader.GetString(6),
                        NationalNo = reader.GetString(7),
                        Gender = reader.GetString(8),
                        Birthdate = reader.GetDateTime(9),

                        // الصورة (قد تكون NULL)
                        PersonPicture = reader["Picture"] != DBNull.Value
                                        ? (byte[])reader["Picture"]
                                        : null,

                        // قيم ثابتة حالياً
                        IssueReason = "First Time",
                        Notes = ""
                    };
                }
            }

            return info;
        }









        /// <summary>
        /// تجديد رخصة منتهية لشخص معيّن:
        /// 1) إنشاء طلب تجديد جديد (Requests)
        /// 2) إنشاء رخصة جديدة (Licenses) مرتبطة بالطلب الجديد
        /// 3) تغيير حالة الرخصة القديمة إلى Inactive
        /// 4) إعادة معلومات الرخصة الجديدة في ClassLicenseInfo
        /// مع إرجاع معرف الطلب الجديد + رسوم الطلب + رسوم الرخصة
        /// </summary>
        public static ClassLicenseInfo RenewLicense(  ClassLicenseInfo oldLicenseInfo, int createdByUserID, out int newRequestID, out int applicationFees, out int licenseFees )
        {
            newRequestID = -1;
            applicationFees = 0;
            licenseFees = 0;

            ClassLicenseInfo newLicenseInfo = null;

            using (SqlConnection con = new SqlConnection(ClsConnection.ConnectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // 1) جلب معلومات الفئة من جدول LicenseClass (مدة الصلاحية + رسوم الفئة)
                    int licenseClassID = -1;
                    int validityYears = 0;
                    int classFees = 0;

                    string getClassQuery = @"
                SELECT LicenseClassID, ValidatyLength, [Class fees]
                FROM LicenseClass
                WHERE ClassName = @ClassName";

                    SqlCommand getClassCmd = new SqlCommand(getClassQuery, con, transaction);
                    getClassCmd.Parameters.AddWithValue("@ClassName", oldLicenseInfo.ClassName);

                    using (SqlDataReader reader = getClassCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            licenseClassID = reader.GetInt32(0);
                            validityYears = reader.GetInt32(1);
                            classFees = reader.GetInt32(2);
                        }
                        else
                        {
                            transaction.Rollback();
                            return null;
                        }
                    }

                    // 2) تحديد الرسوم (يمكنك تعديل القيم حسب نظامك)
                    applicationFees = 7;   // مثال: رسوم طلب التجديد
                    licenseFees = classFees; // رسوم الرخصة من جدول الفئات



                    // 3) إنشاء طلب تجديد جديد في جدول Requests
                    string insertRequestQuery = @"
                INSERT INTO Requests
                (Status, Fees, DateRequest, IDPerson, LicenseClassID, RequestTypeID, CreateByUserID, PassedTests)
                VALUES
                (@Status, @Fees, @DateRequest, @IDPerson, @LicenseClassID, @RequestTypeID, @CreateByUserID, @PassedTests);
                SELECT SCOPE_IDENTITY();";

                    SqlCommand insertRequestCmd = new SqlCommand(insertRequestQuery, con, transaction);

                    insertRequestCmd.Parameters.AddWithValue("@Status", 1);
                    insertRequestCmd.Parameters.AddWithValue("@Fees", applicationFees);
                    insertRequestCmd.Parameters.AddWithValue("@DateRequest", DateTime.Now);
                    insertRequestCmd.Parameters.AddWithValue("@IDPerson", oldLicenseInfo.PersonID  );
                    // ملاحظة: هنا يفضّل أن تستخدم IDPerson الحقيقي من كلاس آخر أو تمرّره للميثود
                    insertRequestCmd.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    insertRequestCmd.Parameters.AddWithValue("@RequestTypeID", 2); // مثال: 2 = تجديد
                    insertRequestCmd.Parameters.AddWithValue("@CreateByUserID", createdByUserID);
                    insertRequestCmd.Parameters.AddWithValue("@PassedTests", 0); // في التجديد عادة لا يوجد اختبارات جديدة

                    object requestResult = insertRequestCmd.ExecuteScalar();
                    if (requestResult == null)
                    {
                        transaction.Rollback();
                        return null;
                    }

                    newRequestID = Convert.ToInt32(requestResult);

                    // 4) جلب CategoryID و DriverID
                    // من الرخصة القديمة (لضمان نفس الفئة/السائق)
                    int categoryID = 1;
                    int driverID = oldLicenseInfo.DriverID;

                    string getOldLicenseQuery = @"
                SELECT CategoryID, DriverID
                FROM Licenses
                WHERE LicenceID = @OldLicenseID";

                    SqlCommand getOldLicenseCmd = new SqlCommand(getOldLicenseQuery, con, transaction);
                    getOldLicenseCmd.Parameters.AddWithValue("@OldLicenseID", oldLicenseInfo.LicenseID);

                    using (SqlDataReader reader = getOldLicenseCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                                categoryID = reader.GetInt32(0);

                            if (!reader.IsDBNull(1))
                                driverID = reader.GetInt32(1);
                        }
                    }

                    // 5) تجهيز صورة الشخص (يمكنك تمريرها من خارج الميثود أو جلبها من Persons)
                    byte[] pictureBytes = oldLicenseInfo.PersonPicture ?? Person.ImageToBytes(Properties.Resources.Male);

                    // 6) إنشاء الرخصة الجديدة في جدول Licenses
                    string insertLicenseQuery = @"
                INSERT INTO Licenses
                    (RequestID, DriverID, LicenseClassID, CategoryID,
                     StatusRelease, RelesaseDate, EndDate, ProfilePicture, IssueReason)
                    VALUES
                        (@RequestID, @DriverID, @LicenseClassID, @CategoryID,
                                     @StatusRelease, @RelesaseDate, @EndDate, @ProfilePicture, @IssueReason);
                    SELECT SCOPE_IDENTITY();";

                    SqlCommand insertLicenseCmd = new SqlCommand(insertLicenseQuery, con, transaction);

                    insertLicenseCmd.Parameters.AddWithValue("@RequestID", newRequestID);
                    insertLicenseCmd.Parameters.AddWithValue("@DriverID", driverID);
                    insertLicenseCmd.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
                    insertLicenseCmd.Parameters.AddWithValue("@CategoryID", categoryID);
                    insertLicenseCmd.Parameters.AddWithValue("@StatusRelease", 1); // Active
                    insertLicenseCmd.Parameters.AddWithValue("@RelesaseDate", DateTime.Now);
                    insertLicenseCmd.Parameters.AddWithValue("@EndDate", DateTime.Now.AddYears(validityYears));
                    insertLicenseCmd.Parameters.Add("@ProfilePicture", SqlDbType.VarBinary).Value = pictureBytes;
                    insertLicenseCmd.Parameters.AddWithValue("@IssueReason", "Renew");


                    object newLicenseResult = insertLicenseCmd.ExecuteScalar();
                    if (newLicenseResult == null)
                    {
                        transaction.Rollback();
                        return null;
                    }

                    int newLicenseID = Convert.ToInt32(newLicenseResult);

                    // 7) تغيير حالة الرخصة القديمة إلى Inactive
                    string updateOldLicenseQuery = @"
                UPDATE Licenses
                SET StatusRelease = 0
                WHERE LicenceID = @OldLicenseID";

                    SqlCommand updateOldLicenseCmd = new SqlCommand(updateOldLicenseQuery, con, transaction);
                    updateOldLicenseCmd.Parameters.AddWithValue("@OldLicenseID", oldLicenseInfo.LicenseID);
                    updateOldLicenseCmd.ExecuteNonQuery();

                    // 8) ClassLicenseInfo جلب معلومات الرخصة الجديدة كاملة لإرجاعها في 
                    string getNewLicenseInfoQuery = @"
                SELECT 
                    L.LicenceID,
                    L.StatusRelease,
                    L.RelesaseDate,
                    L.EndDate,
                    L.DriverID,
                    LC.ClassName,
                    P.FullName,
                    P.[National number],
                    P.Gender,
                    P.Birthdate,
                    P.Picture
                FROM Licenses L
                INNER JOIN Drivers D ON L.DriverID = D.DriverID
                INNER JOIN Persons P ON D.PersonID = P.IDPerson
                INNER JOIN LicenseClass LC ON L.LicenseClassID = LC.LicenseClassID
                WHERE L.LicenceID = @NewLicenseID";

                    SqlCommand getNewLicenseInfoCmd = new SqlCommand(getNewLicenseInfoQuery, con, transaction);
                    getNewLicenseInfoCmd.Parameters.AddWithValue("@NewLicenseID", newLicenseID);

                    using (SqlDataReader reader = getNewLicenseInfoCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            newLicenseInfo = new ClassLicenseInfo
                            {
                                LicenseID = reader.GetInt32(0),
                                StatusRelease = reader.GetBoolean(1),
                                IssueDate = reader.GetDateTime(2),
                                ExpirationDate = reader.GetDateTime(3),
                                DriverID = reader.GetInt32(4),
                                ClassName = reader.GetString(5),
                                FullName = reader.GetString(6),
                                NationalNo = reader.GetString(7),
                                Gender = reader.GetString(8),
                                Birthdate = reader.GetDateTime(9),
                                PersonPicture = reader["Picture"] != DBNull.Value ? (byte[])reader["Picture"] : null,
                                IssueReason = "Renew",
                                Notes = oldLicenseInfo.Notes
                            };
                        }
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    return null;
                }
            }

            return newLicenseInfo;
        }



        /// <summary>
        /// جلب رقم الشخص (PersonID) اعتماداً على DriverID
        /// تستخدم عند إنشاء طلب جديد لمعرفة صاحب الرخصة
        /// </summary>
        public static int GetPersonIDByDriverID(int driverID)
        {
            int personID = -1;

            using (SqlConnection con = new SqlConnection(ClsConnection.ConnectionString))
            {
                string query = @"SELECT PersonID 
                         FROM Drivers 
                         WHERE DriverID = @DriverID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DriverID", driverID);

                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    personID = Convert.ToInt32(result);
            }

            return personID; // يرجع -1 إذا لم يتم العثور على السائق
        }



    }

}
