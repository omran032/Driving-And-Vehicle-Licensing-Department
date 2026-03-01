using DVLD_Management_System.AI;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Manage_Persons.Class;
using DVLD_Management_System.Manage_Persons.واجهات_فرعية;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD_Management_System.Manage_Persons.User_Control
{
    public partial class Ctrl_Add_UpdatePerson : UserControl
    {
        public Ctrl_Add_UpdatePerson()
        {
            person   = FrmAdd_UpdatePersone.person;
            IsUpdate = FrmAdd_UpdatePersone.IsUpdate;

            InitializeComponent();

            LoadData();

        }

        public Action OnRefreshData; // حدث لتحديث البيانات 


        public bool IsUpdate {  get; set; } // هل العنصر للتعديل ؟ ام لللاضافة

        public Person person; //تخزين المعلومات

        int ID  ;


        #region عناصر و ازرار

        private void btnSave_Click(object sender, EventArgs e) // زر الحفظ
        {
            if ( !checkData() )
                return;

            if(IsUpdate)
            {
                SaveInfoPerson();
                UpdatePerson();
                //تشغيل الاحداث
                OnRefreshData?.Invoke();
            }
            else
            {
                SaveInfoPerson();
                AddPerson();
                IsNotExistsNationaNumber();

                //تشغيل الاحداث
                OnRefreshData?.Invoke();
            }

        }

        // تعيين صورة
        private void AddPicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region لجلب وعرض الصورة
            // بتستخدمها بعدين بس  انا حطيتا هون
            //if (person.Picture != null)
            //{
            //    using (MemoryStream ms = new MemoryStream(person.Picture))
            //    {
            //        PicPerson.Image = Image.FromStream(ms);
            //    }
            //}
            //else
            //{
            //    PicPerson.Image = null; // أو صورة افتراضية
            //}
          #endregion

            //التحقق من الصورة اذا كانت تحوي على وجه

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.png;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;

                // استدعاء دالة كشف الوجه
                bool hasFace = cls_InspectImage.DetectFace(path);

                if (hasFace)
                {
                    MessageBox.Show("✔ تم التحقق من الصورة – يوجد وجه.");
                    Picture.Image = Image.FromFile(path);
                    Picture.Tag = "Selected";
                }
                else
                {
                    MessageBox.Show("❌ الصورة لا تحتوي على وجه. الرجاء اختيار صورة صحيحة.");
                }
            }

        }

        private void RdoMale_CheckedChanged(object sender, EventArgs e) // Male اختيار 
        {
            selectImageDefault("Male");
        }

        private void RdoFemale_CheckedChanged(object sender, EventArgs e) // Female اختيار 
        {
            selectImageDefault("Female");
        }






        #endregion


        // *********************************************
        // *********************************************


        #region <<<<<<<< اوامر ومثود  >>>>>>>>>


        void AddPerson()
        {
            lbl_IDPerson.Text = "ID : " + Cls_CMD_PresonsDB.AddPerson(person);
        }
        void UpdatePerson()
        {
            Cls_CMD_PresonsDB.UpdatePerson(person);
        }

        // تحميل البيانات
        void LoadData()
        {
            //التحكم بالتاريخ المسموح ادخاله
            DT_BirthDate.MaxDate = DateTime.Today.AddYears(-18);

            if (IsUpdate) // هل ارسلت بيانات للتعديل ؟
            {
                lbl_IDPerson.Text = "ID : " + person.IDPerson;

                txtFullName.Text       = person.FullName;
                txtNationalNumber.Text = person.National_Number;
                txtnumPhone.Text       = person.NumPhone;
                txtEmail.Text          = person.Email;

                ComboHousing.SelectedIndex = ComboHousing.FindStringExact(person.Housing);
                ComboCountry.SelectedIndex = ComboCountry.FindStringExact(person.Nationality);

                DT_BirthDate.Value = person.Birthdate;

                RdoFemale.Checked = person.Gender == "Female";

                // عرض الصورة
                if (person.Picture != null)
                {
                    using (MemoryStream ms = new MemoryStream(person.Picture))
                    {
                        Picture.Image = Image.FromStream(ms);
                        Picture.Tag = "Selected";
                    }
                }
                

            }


        }


        /// <summary>
        /// فحص البيانات قبل حفظها
        /// </summary>
        bool checkData()
        {
            if (
            IsNull(txtFullName) &&
            !NationalNum_IsNotExist &&
            IsNull(txtNationalNumber) &&
            IsNull(txtnumPhone) &&
            IsCorrentEmail() &&
            IsNull(txtnumPhone) &&
            IsNull(ComboHousing) &&
            IsNull(ComboCountry) &&
            IsSelectImage()
               ) 
            { return true; }

            else
            {
                MessageBox.Show("ادخل المعلومات بشكل صحيح أولاً" ,"التحقق من المعلومات" ,MessageBoxButtons.OK, MessageBoxIcon.Error );
                return false;
            }
        }

        /// <summary>
        /// هل العنصر فارغ ؟
        /// </summary>
        bool IsNull(Control ctrl)
        {
            string text = ctrl.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                MyErrorProvider.SetError(ctrl, "الحقل مطلوب");
                return false;
            }

            else
            {
                MyErrorProvider.Clear();
                return true;
            }
        }

      

        bool NationalNum_IsNotExist = false;

        // حدث بعد ادخال الرقم الوطني ...لفحص وجوده مسبقا
        private void txtNationalNumber_Leave(object sender, EventArgs e)
        {
            IsNotExistsNationaNumber();
        }

        /// <summary>
        /// التحقق من وجود نفس الرقم الوطني مسبقا
        /// </summary>
        void IsNotExistsNationaNumber()
        {
            string nationalNumber = txtNationalNumber.Text.Trim();
            if (nationalNumber.Length > 0)
                NationalNum_IsNotExist = Cls_CMD_PresonsDB.IsNotExist_NationalNum(nationalNumber);


            if (NationalNum_IsNotExist)
                MyErrorProvider.SetError(txtNationalNumber, "الرقم الوطني موجود مسبقاً");
            else
                MyErrorProvider.SetError(txtNationalNumber, "");
        }


        /// <summary>
        /// التحقق من صياغة الايميل
        /// </summary>
        bool IsCorrentEmail()
        {
            string Email = txtEmail.Text.Trim();
            if (Email.ToLower().EndsWith("@gmail.com") || string.IsNullOrEmpty(Email))
            {
               return  true;
                MyErrorProvider.SetError(txtEmail, "");
            }
            else
            {
                MyErrorProvider.SetError(txtEmail, "خطأ في كتابة كتابة البريد" + "\n اذا كنت تريد ادخال البريد ...قم كتابته بشكل صحيح");
                return  false;
            }
        }

        // حدث عند مغادرة التكست بوكس	
        private void txtEmail_Leave(object sender, EventArgs e) // التحقق من صيغة البريد
        {
            IsCorrentEmail();
        }

        // حفظ البيانات في الكلاس
        void SaveInfoPerson()
        {
            if (person == null)
            {
                person = new Person();
            }

            person.FullName = txtFullName.Text;
            person.National_Number = txtNationalNumber.Text;
            MessageBox.Show(person.National_Number);

            person.NumPhone = txtnumPhone.Text;
            person.Email = txtEmail.Text;

            person.Housing = ComboHousing.Text;
            person.Nationality = ComboCountry.Text;
            person.Birthdate = DT_BirthDate.Value;
 
            person.Gender = RdoFemale.Checked ? "Female" : "Male";

            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bmp = new Bitmap(Picture.Image))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    person.Picture = ms.ToArray();
                }
            }


        }
       

      

        
            
       

        bool IsSelectImage()
        {
            if(! selectImageDefault("Male"))
            {
                MyErrorProvider.SetError(AddPicture, "اختر الصورة الشخصية أولاً");
                return false;
            }
            else
                return true;
        }
     

        /// <summary>
        /// تعيين صورة افتراصية
        /// </summary>
        bool selectImageDefault(string typeImage)
        {
            if (Picture.Tag != "Default")
            return true;

            Picture.Image = typeImage=="Male" ? Properties.Resources.Male : Properties.Resources.Female;
            Picture.Tag = "Default";
            return false;
        }


        #endregion

       
    }
}
