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

            MessageBox.Show(EmpList[0].CalcStateTax(12).ToString());
  
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

        }
    }
}
