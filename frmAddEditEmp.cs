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
            }
        }

        private void tosbtnSave_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                ClearBackgroundColors();
                DefensiveFeilds();
                UpdateEmployeeFields();
            }
            else
            {
                ClearBackgroundColors();
                DefensiveFeilds();
            }
        }


        private void DefensiveFeilds()
        {
            if (!CheckNull(mstFirstName, "First Name field must be filled out."))
                return;

            if (!CheckNull(mstLastName, "Last Name field must be filled out."))
                return;

            if (!CheckSSN(mstSSN, "SSN must be in XXX-XX-XXXX format"))
                return;

            if (!CheckDateTime(mstDob, "Date must be filled out"))
                return;

            if (!CheckNull(mstStreet, "Street must be filled out"))
                return;

            if (!CheckNull(mstCity, "City must be filled out"))
                return;

            if (!CheckNull(mstZipCode, "Zip Code must be filled out"))
                return;

            if (!CheckNull(mstStreet, "State must be filled out"))
                return;

            if (!CheckNull(mstSalary, "Salary must be fille out"))
                return;

            if (!CheckNull(mstXFed, "Extra Fed must be filled out"))
                return;

            if (!CheckNull(mstXState, "Extra State must be filled out"))
                return;

            if (!CheckDDLLists(ddlChildDep, "Must select # of child dependents"))
                return;

            if (!CheckDDLLists(ddlOtherDep, "Must select # of other dependents"))
                return;

            if (!CheckDDLLists(ddlWithholding, "Must select # of withholdings"))
                return;
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
            string pattern = @"\d{2}\\?\d{2}\\?\d{2}";
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
