using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
