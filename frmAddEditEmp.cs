using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Payroll
{
    public partial class frmAddEditEmp : Form
    {
        bool isEdit;
        List<Employee> EmpList = new List<Employee>();
        int empIndex;

        public frmAddEditEmp()
        {
            InitializeComponent();
        }

        public frmAddEditEmp(bool edit, List<Employee> eList)
        {
            InitializeComponent();
            isEdit = edit;
            EmpList = eList;
        }

        public frmAddEditEmp(bool edit, List<Employee> eList, int index)
        {
            InitializeComponent();
            isEdit = edit;
            EmpList = eList;
            empIndex = index;
        }

        private void frmAddEditEmp_Load(object sender, EventArgs e)
        {
            // if its in edit mode
            if (isEdit)
            {
                this.Text = "Edit Employee Data";
                tosbtnSave.ToolTipText = "Save Employee Changes";

                FillInFields();
            }
            else
            {
                this.Text = "Add New Employee";
                tosbtnSave.ToolTipText = "Save New Employee";
                radSingle.Checked = true;
            }
        }

        private void tosbtnSave_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                ClearBackgroundColors();

                if (!CheckFields())
                    return;

                UpdateEmployeeFields();
            }
            else
            {
                ClearBackgroundColors();

                if (!CheckFields())
                    return;

                AddNewEmployee();           
            }

            this.Close();
        }

        private bool CheckFields()
        {
            if (!CheckNull(mstFirstName, "First Name field must be filled out."))
                return false;
            
            if (!CheckNull(mstLastName, "Last Name field must be filled out."))
                return false;

            if (!CheckSSN(mstSSN, "SSN must be in XXX-XX-XXXX format"))
                return false;

            if (!CheckDateTime(mstDob, "DOB must be filled out"))
                return false;

            if (!CheckNull(mstStreet, "Street must be filled out"))
                return false;

            if (!CheckNull(mstCity, "City must be filled out"))
                return false;

            if (!CheckNull(mstZipCode, "Zip Code must be filled out"))
                return false;

            if (!CheckNull(mstStreet, "State must be filled out"))
                return false;

            if (!CheckNull(mstSalary, "Salary must be fille out"))
                return false;

            if (!CheckNull(mstXFed, "Extra Fed must be filled out"))
                return false;

            if (!CheckNull(mstXState, "Extra State must be filled out"))
                return false;

            if (!CheckDDLLists(ddlChildDep, "Must select # of child dependents"))
                return false;

            if (!CheckDDLLists(ddlOtherDep, "Must select # of other dependents"))
                return false;

            if (!CheckDDLLists(ddlWithholding, "Must select # of withholdings"))
                return false;

            return true;
        }

        private void AddNewEmployee()
        {
            string fName = mstFirstName.Text;
            string lName = mstLastName.Text;
            string ssn = mstSSN.Text;
            DateTime dob = DateTime.ParseExact(mstDob.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            string street = mstStreet.Text;
            string city = mstCity.Text;
            string zipCode = mstZipCode.Text;
            string state = mstState.Text;
            double salary = Convert.ToDouble(mstSalary.Text);
            double xFed = Convert.ToDouble(mstXFed.Text);
            double xState = Convert.ToDouble(mstXState.Text);
            int child = ddlChildDep.SelectedIndex;
            int other = ddlOtherDep.SelectedIndex;
            int withhold = ddlWithholding.SelectedIndex;
            string status = "";

            if (radSingle.Checked)
                status = "S";
            else if (radHOH.Checked)
                status = "HOH";
            else if (radMFS.Checked)
                status = "MFS";
            else if (radMFJ.Checked)
                status = "MFJ";

            bool multiple = chkMultiple.Checked;
            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date;

            Employee newEmp = new Employee(fName, lName, ssn, dob, status, withhold,
                child, other, xFed, xState, multiple, street, city, state, zipCode,
                salary, start, end);

            EmpList.Add(newEmp);
        }    

        private void ClearBackgroundColors()
        {
            mstFirstName.BackColor = Color.White;
            mstLastName.BackColor = Color.White;
            mstSSN.BackColor = Color.White;
            mstDob.BackColor = Color.White;
            mstStreet.BackColor = Color.White;
            mstCity.BackColor = Color.White;
            mstZipCode.BackColor = Color.White;
            mstState.BackColor = Color.White;
            mstSalary.BackColor = Color.White;
            mstXFed.BackColor = Color.White;
            mstXState.BackColor = Color.White;
            ddlChildDep.BackColor = Color.White;
            ddlOtherDep.BackColor = Color.White;
            ddlWithholding.BackColor = Color.White;
        }

        private bool CheckDDLLists(ComboBox ddl, string msg)
        {
            if (ddl.SelectedIndex == -1)
            {
                MessageBox.Show(msg);
                ddl.BackColor = Color.LightYellow;
                return false;
            }
            else
            {
                return true;
            }
        }


        private bool CheckDateTime(MaskedTextBox mst, string msg)
        {
            string pattern = @"\d{2}\/\d{2}\/\d{4}";
            Match m = Regex.Match(mst.Text, pattern);

            if (m.Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show(msg);
                mst.BackColor = Color.LightYellow;
                return false;
            }
        }


        private bool CheckSSN(MaskedTextBox mst, string msg)
        {
            string pattern = @"\d{3}-?\d{2}-?\d{4}";
            Match m = Regex.Match(mstSSN.Text, pattern);

            if (m.Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show(msg);
                mst.BackColor = Color.LightYellow;
                return false;
            }
        }



        private bool CheckNull(MaskedTextBox mst, string msg)
        {
            if (mst.Text == "")
            {
                MessageBox.Show(msg);
                mst.BackColor = Color.LightYellow;
                return false;
            }
            else
            {
                return true;
            }
        }


        private void UpdateEmployeeFields()
        {

            EmpList[empIndex].firstName = mstFirstName.Text;
            EmpList[empIndex].lastName = mstLastName.Text;
            EmpList[empIndex].SSN = mstSSN.Text;
            DateTime dob = DateTime.ParseExact(mstDob.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            EmpList[empIndex].DOB = dob;
            EmpList[empIndex].street = mstStreet.Text;
            EmpList[empIndex].city = mstCity.Text;
            EmpList[empIndex].zipCode = mstZipCode.Text;
            EmpList[empIndex].state = mstState.Text;
            EmpList[empIndex].salary = Convert.ToDouble(mstSalary.Text);
            EmpList[empIndex].xFedWithhold = Convert.ToDouble(mstXFed.Text);
            EmpList[empIndex].xStateWithold = Convert.ToDouble(mstXState.Text);
            EmpList[empIndex].childDep = ddlChildDep.SelectedIndex;
            EmpList[empIndex].otherDep = ddlOtherDep.SelectedIndex;
            EmpList[empIndex].withHolding = ddlWithholding.SelectedIndex;

            if (radSingle.Checked)
                EmpList[empIndex].fStatus = "S";
            else if (radHOH.Checked)
                EmpList[empIndex].fStatus = "HOH";
            else if (radMFS.Checked)
                EmpList[empIndex].fStatus = "MFS";
            else if (radMFJ.Checked)
                EmpList[empIndex].fStatus = "MFJ";

            EmpList[empIndex].multipleJobs = chkMultiple.Checked;
            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date;
            EmpList[empIndex].startDate = start;
            EmpList[empIndex].endDate = end;

            this.Close();

        }

        private void FillInFields()
        {
            Employee sEmp = EmpList[empIndex];
            mstFirstName.Text = sEmp.firstName;
            mstLastName.Text = sEmp.lastName;
            mstSSN.Text = sEmp.SSN;
            mstDob.Text = sEmp.DOB.ToString("MM/dd/yyyy");
            mstStreet.Text = sEmp.street;
            mstCity.Text = sEmp.city;
            mstZipCode.Text = sEmp.zipCode;
            mstState.Text = sEmp.state;
            mstSalary.Text = sEmp.salary.ToString();
            mstXFed.Text = sEmp.xFedWithhold.ToString();
            mstXState.Text = sEmp.xStateWithold.ToString();
            ddlChildDep.SelectedIndex = sEmp.childDep;
            ddlOtherDep.SelectedIndex = sEmp.otherDep;
            ddlWithholding.SelectedIndex = sEmp.withHolding;

            if (sEmp.fStatus == "S")
                radSingle.Checked = true;
            else if (sEmp.fStatus == "HOH")
                radHOH.Checked = true;
            else if (sEmp.fStatus == "MFJ")
                radMFJ.Checked = true;
            else if (sEmp.fStatus == "MFS")
                radMFS.Checked = true;

            chkMultiple.Checked = sEmp.multipleJobs;
            dtpStart.Value = sEmp.startDate;
            dtpEnd.Value = sEmp.endDate;            

        }


    }
}
