using Dev_Note_Assistant;
using DVLD_Management_System.Class.Class;
using DVLD_Management_System.Drivers.Class;
using DVLD_Management_System.Manage_Persons.Class;
using DVLD_Management_System.Manage_Persons.واجهات_فرعية;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Management_System.Drivers.Class.ClassDriver_DB;
using static DVLD_Management_System.Manage_Persons.واجهات_فرعية.FrmAdd_UpdatePersone;

namespace DVLD_Management_System.Drivers
{
    public partial class FrmListDrivers : Form
    {
        public FrmListDrivers()
        {
            InitializeComponent();
        }

        private void FrmListDrivers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        DataTable TableDataDrivers;

        enDriverFilter TypeFelter = enDriverFilter.None;

        void LoadData()
        {
            cbFilterBy.SelectedIndex = 0;

            TableDataDrivers = ClassDriver_DB.GetDriversWithFilter(enDriverFilter.None);
            dgvDrivers.DataSource = TableDataDrivers;

            lblRecordsCount.Text = TableDataDrivers.Rows.Count + " ";
        }



        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e) // ComboxFelter عنصر 
        {
            string Changes = cbFilterBy.Text.Trim();

            txtFilterValue.Text = null;
            txtFilterValue.Visible = true;
            btnSearch.Visible = true;

            switch (Changes)
            {
                case "None":
                    txtFilterValue.Visible = false;
                    btnSearch.Visible = false;
                    TableDataDrivers = ClassDriver_DB.GetDriversWithFilter(enDriverFilter.None);
                    dgvDrivers.DataSource = TableDataDrivers;
                    break;

                case "Driver ID":
                    TypeFelter = enDriverFilter.DriverID;
                    break;

                case "Person ID":
                    TypeFelter = enDriverFilter.PersonID;
                    break;

                case "National No":
                    TypeFelter = enDriverFilter.NationalNo;
                    break;

                case "Full Name":
                    TypeFelter = enDriverFilter.FullName;
                    break;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {


        }

        private void btnSearch_Click(object sender, EventArgs e) // زر البحث
        {
            switch (TypeFelter)
            {
                case enDriverFilter.DriverID:
                    TableDataDrivers = ClassDriver_DB.GetDriversWithFilter(enDriverFilter.DriverID);
                    dgvDrivers.DataSource = TableDataDrivers;
                    break;

                case enDriverFilter.PersonID:
                    TableDataDrivers = ClassDriver_DB.GetDriversWithFilter(enDriverFilter.PersonID);
                    dgvDrivers.DataSource = TableDataDrivers;
                    break;

                case enDriverFilter.NationalNo:
                    TableDataDrivers = ClassDriver_DB.GetDriversWithFilter(enDriverFilter.NationalNo);
                    dgvDrivers.DataSource = TableDataDrivers;
                    break;

                case enDriverFilter.FullName:
                    TableDataDrivers = ClassDriver_DB.GetDriversWithFilter(enDriverFilter.FullName);
                    dgvDrivers.DataSource = TableDataDrivers;
                    break;

                default:

                    break;
            }
            lblRecordsCount.Text = TableDataDrivers.Rows.Count + " ";
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e) // TextBox
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            if (e.KeyChar == (char)13) // 13 = Enter
            {
                btnSearch.PerformClick();
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e) // حيار عرض معلومات الشخص
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            if (PersonID <= 0) return;

            Person PersonInfo =  Cls_CMD_PresonsDB.GetPersonByID(PersonID);

            //واجهة الاضافة
            FrmShowPerson showPerson = new FrmShowPerson(PersonInfo);
            showPerson.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e) // عرض معلومات الشخص و رخصه
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            if (PersonID <= 0) return;

            FrmShowPersonLicenseHistory personLicenseHistory = new FrmShowPersonLicenseHistory(PersonID);
            MyTools.ShowForm(personLicenseHistory);

        }
    }
}
