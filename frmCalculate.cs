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
    public partial class frmCalculate : Form
    {
        Dictionary<string, WithholdTable> WithHoldDic = new Dictionary<string, WithholdTable>();
        List<Employee> EmpList = new List<Employee>();

        public frmCalculate()
        {
            InitializeComponent();
        }

        public frmCalculate(List<Employee> eList, Dictionary<string, WithholdTable> wDic)
        {
            InitializeComponent();
            this.EmpList = eList;
            this.WithHoldDic = wDic;
        }

        private void frmCalculate_Load(object sender, EventArgs e)
        {
            AddNameToDDL();
            SetNumPayPeriods();                        
        }

        private void tosbtnCalculate_Click(object sender, EventArgs e)
        {
            ClearDDLColors();

            if (!CheckDDL(ddlEmployees, "You must select an employee"))
                return;

            if (!CheckDDL(ddlPayPeriod, "You must select a pay period"))
                return;           


            AddResultsToListbox();

        }


        private void AddResultsToListbox()
        {
            int empSelect = ddlEmployees.SelectedIndex;
            int numPeriods = GetNumPayPeriods();
            int period = Convert.ToInt32(ddlPayPeriod.SelectedIndex) + 1;
            Employee emp = EmpList[empSelect];
            string fullName = emp.firstName + " " + emp.lastName;
            double fica = emp.CalcFedTax(numPeriods, WithHoldDic);
            double state = emp.CalcStateTax(numPeriods);
            double mediTax = emp.CalcMedTax(numPeriods);
            double ssnTax = emp.CalcSSNTax(numPeriods);
            double total = emp.CalcTotalTax(numPeriods, WithHoldDic);
            double netPay = (emp.salary / numPeriods) - total;


            lstResults.Items.Add(fullName);
            lstResults.Items.Add("Pay Period:  " + period);
            lstResults.Items.Add("");
            lstResults.Items.Add("Current".PadLeft(30) + "YTD".PadLeft(20));
            lstResults.Items.Add("-------".PadLeft(30) + "-------".PadLeft(20));

            lstResults.Items.Add("FICA" + fica.ToString().PadLeft(26) + 
                fica.ToString().PadLeft(20));
            lstResults.Items.Add("Medi" + mediTax.ToString().PadLeft(26) +
                mediTax.ToString().PadLeft(20));
            lstResults.Items.Add("Fed" + fica.ToString().PadLeft(27) +
                fica.ToString().PadLeft(20));
            lstResults.Items.Add("State" + state.ToString().PadLeft(25) +
                state.ToString().PadLeft(20));
            lstResults.Items.Add("-------".PadLeft(30) + "-------".PadLeft(20));
            lstResults.Items.Add("Total" + total.ToString().PadLeft(25) +
                total.ToString().PadLeft(20));
            lstResults.Items.Add("-------".PadLeft(30) + "-------".PadLeft(20));
            lstResults.Items.Add("Net Pay" + netPay.ToString().PadLeft(23) +
                netPay.ToString().PadLeft(20));
        }
        

        private bool CheckDDL(ComboBox ddl, string msg)
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

        private int GetNumPayPeriods()
        {
            int numPeriods = 0;

            if (radWeekly.Checked)
                numPeriods = 52;
            else if (radBiWeekly.Checked)
                numPeriods = 26;
            else if (radMonthly.Checked)
                numPeriods = 12;

            return numPeriods;
        }

        private void SetNumPayPeriods()
        {
            ddlPayPeriod.Items.Clear();

            if (radWeekly.Checked)
            {
                for (int i = 1; i <= 52; i++)
                {
                    ddlPayPeriod.Items.Add(i);
                }
            }
            else if (radBiWeekly.Checked)
            {
                for (int i = 1; i <= 26; i++)
                {
                    ddlPayPeriod.Items.Add(i);
                }
            }
            else if (radMonthly.Checked)
            {
                for (int i = 1; i <= 12; i++)
                {
                    ddlPayPeriod.Items.Add(i);
                }
            }
        }

        private void AddNameToDDL()
        {
            for (int i = 0; i < EmpList.Count; i++)
            {
                string name = EmpList[i].firstName + " " + EmpList[i].lastName;
                ddlEmployees.Items.Add(name);
            }
        }

        private void radMonthly_CheckedChanged(object sender, EventArgs e)
        {
            SetNumPayPeriods();
        }

        private void ClearDDLColors()
        {
            ddlEmployees.BackColor = Color.White;
            ddlPayPeriod.BackColor = Color.White;
            ddlQuarter.BackColor = Color.White;
        }

        private void tosbtnExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(EmpList[0].CalcFedTax(12, WithHoldDic).ToString());
        }
    }
}
