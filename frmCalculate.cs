using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
            lstResults.Items.Clear();
            int empSelect = ddlEmployees.SelectedIndex;
            int numPeriods = GetNumPayPeriods();
            int period = Convert.ToInt32(ddlPayPeriod.SelectedIndex) + 1;
            Employee emp = EmpList[empSelect];
            string fullName = emp.firstName + " " + emp.lastName;
            double fed = emp.CalcFedTax(numPeriods, WithHoldDic, period);
            double state = emp.CalcStateTax(numPeriods, period);
            double mediTax = emp.CalcMedTax(numPeriods, period);
            double ssnTax = emp.CalcSSNTax(numPeriods, period);
            double totalTax = fed + state + mediTax + ssnTax;
            double totalCulmulativeTax = emp.CalcTotalTax(numPeriods, WithHoldDic, period);
            double fedCul = emp.CalcFedTaxCulmulative(numPeriods, WithHoldDic, period);
            double stateCul = emp.CalcSSNTaxCulmulative(numPeriods, period);
            double ssnCul = emp.CalcSSNTaxCulmulative(numPeriods, period);
            double mediCul = emp.CalcMedTaxCulmulative(numPeriods, period);
            double netPay = emp.CalcNetPay(numPeriods, WithHoldDic, period);
            double netPayCul = emp.CalcNetPayCulmulative(numPeriods, WithHoldDic, period);

            lstResults.Items.Add(fullName);
            lstResults.Items.Add("Pay Period:  " + period);
            lstResults.Items.Add("");
            lstResults.Items.Add("Current".PadLeft(30) + "YTD".PadLeft(20));
            lstResults.Items.Add("-------".PadLeft(30) + "-------".PadLeft(20));

            lstResults.Items.Add("FICA" + ssnTax.ToString().PadLeft(26) + 
                ssnCul.ToString().PadLeft(20));
            lstResults.Items.Add("Medi" + mediTax.ToString().PadLeft(26) +
                mediCul.ToString().PadLeft(20));
            lstResults.Items.Add("Fed" + fed.ToString().PadLeft(27) +
                fedCul.ToString().PadLeft(20));
            lstResults.Items.Add("State" + state.ToString().PadLeft(25) +
                stateCul.ToString().PadLeft(20));
            lstResults.Items.Add("-------".PadLeft(30) + "-------".PadLeft(20));
            lstResults.Items.Add("Total" + totalTax.ToString().PadLeft(25) +
                totalCulmulativeTax.ToString().PadLeft(20));
            lstResults.Items.Add("-------".PadLeft(30) + "-------".PadLeft(20));
            lstResults.Items.Add("Net Pay" + netPay.ToString().PadLeft(23) +
                netPayCul.ToString().PadLeft(20));
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

            SaveFileDialog saveWindow = new SaveFileDialog();
            saveWindow.Title = "Export data to Excel";
            saveWindow.Filter = "Excel New (.xlsx)|*.xlsx|Excel Old (.xls)|*xls";
            saveWindow.ShowDialog();

            if (saveWindow.FileName == "")
                return;

            string fileName = saveWindow.FileName;
            WriteToExcel(fileName);

       
        }

        private void WriteToExcel(string file)
        {
            object misValue = System.Reflection.Missing.Value;         
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
            Excel.Worksheet xlWksheet;

            //for (int i = 0; i < 4; i++)
            //{
            //    xlWksheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
            //    xlWksheet.Name = i.ToString();
            //}

            WriteEachEmployee(xlWorkBook);
            WriteSummaryPage(xlWorkBook);

            xlWorkBook.SaveAs(file, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            tosStatus.Text = "Excel file saved to " + file.ToString();

        }

        private void WriteSummaryPage(Excel.Workbook xlWorkBook)
        {
            int numPeriods = GetNumPayPeriods();
            Employer newEmp = new Employer(WithHoldDic, EmpList, numPeriods);
            Excel.Borders sborders;
            Excel.Worksheet xlSht = (Excel.Worksheet)xlWorkBook.Worksheets["Sheet1"];
            xlSht.Name = "Summary";

            xlSht.Cells[3, 1] = "FICA (Employee)";
            xlSht.Cells[4, 1] = "Medicare (Employee)";
            xlSht.Cells[6, 1] = "FICA (Casco)";
            xlSht.Cells[7, 1] = "Medicare (Casco)";
            xlSht.Cells[9, 1] = "Fed Withholding";
            xlSht.Cells[10, 1] = "Fed-941";
            xlSht.Cells[13, 1] = "IL-501";

            for (int i = 1; i <= numPeriods; i++)
            {
                xlSht.Cells[2, i + 1] = i;

                double fica = newEmp.CalcSSNTax(i);
                double medTax = newEmp.CalcMediTax(i);
                double fedTax = newEmp.CalcFedTax(i);
                double stateTax = newEmp.CalcStateTax(i);
                double fedWithhold = newEmp.MonthlyFedWitholding(i);

                xlSht.Cells[3, i + 1] = fica;
                xlSht.Cells[4, i + 1] = medTax;
                xlSht.Cells[6, i + 1] = fica;
                xlSht.Cells[7, i + 1] = medTax;
                xlSht.Cells[9, i + 1] = fedTax;
                xlSht.Cells[10, i + 1] = fedWithhold;
                xlSht.Cells[10, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                sborders = xlSht.Cells[10, i + 1].Borders;
                sborders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                sborders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2d;
                sborders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;          
                xlSht.Cells[13, i + 1] = stateTax;
                xlSht.Cells[13, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
                sborders = xlSht.Cells[13, i + 1].Borders;
                sborders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;

               
            }




        }

        private void WriteEachEmployee(Excel.Workbook xlWorkbook)
        {
            int numPeriods = GetNumPayPeriods();

            for (int i = 0; i <= 3; i++)
            {
                Employee emp = EmpList[i];
                string name = emp.firstName + " " + emp.lastName;
                double pSalary = emp.salary / numPeriods;  

                Excel.Worksheet xlWkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add();
                xlWkSheet.Name = name;
                Excel.Borders borders;

                xlWkSheet.Cells[3, 1] = "Gross Wages";
                xlWkSheet.Cells[4, 1] = "FICA";
                xlWkSheet.Cells[5, 1] = "Med";
                xlWkSheet.Cells[6, 1] = "Fed";
                xlWkSheet.Cells[7, 1] = "State";
                xlWkSheet.Cells[9, 1] = "Net";

                for (int x = 1; x <= numPeriods; x++)
                {
                    
                    double payPerPeriod = emp.salaryPerPeriod(numPeriods, x);
                    double ssnTax = emp.CalcSSNTax(numPeriods, x);
                    double medTax = emp.CalcMedTax(numPeriods, x);
                    double fedTax = emp.CalcFedTax(numPeriods, WithHoldDic, x);
                    double stateTax = emp.CalcStateTax(numPeriods, x);
                    double netPay = emp.CalcNetPay(numPeriods, WithHoldDic, x);

                    xlWkSheet.Cells[2, x + 1] = x;
                    xlWkSheet.Cells[3, x + 1] = payPerPeriod.ToString();
                    xlWkSheet.Cells[4, x + 1] = ssnTax.ToString();
                    xlWkSheet.Cells[5, x + 1] = medTax.ToString();
                    xlWkSheet.Cells[6, x + 1] = fedTax.ToString();
                    xlWkSheet.Cells[7, x + 1] = stateTax.ToString();
                    borders = xlWkSheet.Cells[7, x + 1].Borders;
                    borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 3d;

                    xlWkSheet.Cells[9, x + 1] = netPay.ToString();
                    xlWkSheet.Cells[9, x + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);
                    borders = xlWkSheet.Cells[9, x + 1].Borders;
                    borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                    borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2d;
                    borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;
                    borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 3d;
                }
            }
        }

        private void tosTest_Click(object sender, EventArgs e)
        {
            Employer emp = new Employer(WithHoldDic, EmpList, 12);

            double x = emp.CalcStateTax(1);
            double y = emp.CalcStateTax(5);

            MessageBox.Show("HI");
        }
    }
}
