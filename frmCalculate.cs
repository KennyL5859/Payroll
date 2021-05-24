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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using System.Collections;

namespace Payroll
{
    public partial class frmCalculate : Form
    {
        Dictionary<string, WithholdTable> WithHoldDic = new Dictionary<string, WithholdTable>();
        List<Employee> EmpList = new List<Employee>();
        static string filePath = AppDomain.CurrentDomain.BaseDirectory;
        string f941 = Path.GetFullPath(Path.Combine(filePath, @"..\..\Required\f941.pdf"));
        string f940 = Path.GetFullPath(Path.Combine(filePath, @"..\..\Required\f940.pdf"));
        string i941 = Path.GetFullPath(Path.Combine(filePath, @"..\..\Required\i941.pdf"));

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
            AddQuartersToDDL();
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

        private void tosbtnExcel_Click(object sender, EventArgs e)
        {
            // when user clicks Excel button, open a save file dialog and prompt
            // user to choose file path
            SaveFileDialog saveWindow = new SaveFileDialog();
            saveWindow.Title = "Export data to Excel";
            saveWindow.Filter = "Excel New (.xlsx)|*.xlsx|Excel Old (.xls)|*xls";
            saveWindow.ShowDialog();

            if (saveWindow.FileName == "")
                return;

            string fileName = saveWindow.FileName;

            // call write to excel method and pass in file name
            WriteToExcel(fileName);       
        }

        private void WriteToExcel(string file)
        {
            // open excel app, workwbook and call methods below
            object misValue = System.Reflection.Missing.Value;         
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);

            // write each of the pages below to excel workbook
            WriteStateSummary(xlWorkBook);
            WriteEachEmployee(xlWorkBook);     
            WriteSummaryPage(xlWorkBook);

            xlWorkBook.SaveAs(file, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            // show file path for 5 seconds
            string msg = "Excel file saved to " + file.ToString();
            ChangeStatusLabel(tosStatus, msg);
        }

        private void WriteStateSummary(Excel.Workbook xlWorkbook)
        {
            // writes the state umemployment taxes summary
            int numPeriods = GetNumPayPeriods();
            Employer newEmp = new Employer(WithHoldDic, EmpList, numPeriods);
            Excel.Worksheet xlSht = (Excel.Worksheet)xlWorkbook.Worksheets.Add();         
            xlSht.Name = "State Umemployment";
            xlSht.Cells[3, 1] = "Total Wages";
            xlSht.Cells[4, 1] = "Excess Wages";
            xlSht.Cells[5, 1] = "Taxable Wages";
            xlSht.Cells[6, 1] = "Tax Due";

            Employer emp = new Employer(WithHoldDic, EmpList, numPeriods);   

            for (int i = 1; i <= 4; i++)
            {
                Dictionary<string, List<double>> quarterDic = emp.CalcQuarterlyStateWages(i);
                double totalWages = quarterDic.Sum(x => x.Value[1]);
                double excessWages = quarterDic.Sum(x => x.Value[2]);
                double taxableWages = quarterDic.Sum(x => x.Value[3]);
                double taxDue = quarterDic.Sum(x => x.Value[4]);
                xlSht.Cells[2, i + 1] = "Q" + i;
                xlSht.Cells[3, i + 1] = totalWages;
                xlSht.Cells[4, i + 1] = excessWages;
                xlSht.Cells[5, i + 1] = taxableWages;
                xlSht.Cells[6, i + 1] = taxDue;
                xlSht.Cells[6, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);

            }

            for (int i = 0; i < EmpList.Count; i++)
            {
                string fName = EmpList[i].firstName + " " + EmpList[i].lastName;
                xlSht.Cells[9 + i, 1] = fName;                

                Dictionary<string, List<double>> quarterDic = emp.CalcQuarterlyStateWages(i + 1);
                
                for (int x = 0; x < EmpList.Count; x++)
                {
                    string name = EmpList[x].firstName + " " + EmpList[x].lastName;
                    List<double> payList = quarterDic[name];
                    double qSalary = payList[1];
                    xlSht.Cells[9 + x, i + 2] = qSalary;
                }               
            }
        }
        
        private void WriteSummaryPage(Excel.Workbook xlWorkBook)
        {
            // writes the total federal withholding and state withholding summary
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
            // write each employee withholding on each separate sheet
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

        private void tosmnuBtnIL941_Click(object sender, EventArgs e)
        {
            // Write to form I941 (ILLINOIS WITHHOLDING INCOME TAX RETURN)
            ClearDDLColors();

            if (!CheckDDL(ddlQuarter, "You must select a quarter to continue."))
                return;

            int quarter = ddlQuarter.SelectedIndex + 1;

            SaveFileDialog saveWindow = new SaveFileDialog();
            saveWindow.Title = "Export data to PDF";
            saveWindow.Filter = "PDF (.pdf)|*.pdf";
            saveWindow.ShowDialog();

            if (saveWindow.FileName == "")
                return;

            string fileName = saveWindow.FileName;

            // call WriteIL941 method
            WriteIL941(fileName, quarter);           

            string msg = "Form I941 have been exported to " + fileName;
            ChangeStatusLabel(tosStatus, msg);
        }

        private void WriteIL941(string fileName, int quarter)
        {
            // method that calculates and writes to IL-941 form
            int periods = GetNumPayPeriods();
            Employer emp = new Employer(WithHoldDic, EmpList, periods);
            double line1 = emp.CalcTotalQuarterlyWages(quarter);
            int[] periodsRange = emp.GetPeriodDateRange(quarter);
            int beginP = periodsRange[0];
            int endP = periodsRange[1];
            List<double> monthlyTax = new List<double>();

            for (int i = beginP; i <= endP; i++)
                monthlyTax.Add(emp.CalcStateTax(i));

            double totalWithhold = monthlyTax.Sum();

            string[] firstMonth = SplitDollarAmounts(monthlyTax[0]);
            string[] secondMonth = SplitDollarAmounts(monthlyTax[1]);
            string[] thirdMonth = SplitDollarAmounts(monthlyTax[2]);


            // read the pdf file and find the textfield values
            PdfReader pdr = new PdfReader(i941);

            //StringBuilder sb = new StringBuilder();
            //foreach (var de in pdr.AcroFields.Fields)
            //{
            //    lstResults.Items.Add(de.ToString());
            //}

            //string[] checkboxStates = pdFF.GetAppearanceStates("DiscussWithPreparer");
            //for (int i = 0; i < checkboxStates.Length; i++)
            //{
            //    lstResults.Items.Add(checkboxStates[i]);
            //}

            PdfStamper pds = new PdfStamper(pdr, new FileStream(fileName, FileMode.Create));
            AcroFields pdFF = pds.AcroFields;

            pdFF.SetField("fein", "36");
            pdFF.SetField("fein1", "4084647");
            pdFF.SetField("name", "CASCO USA INC");
            pdFF.SetField("address", "1300 IROQUOIS AVE, SUITE 245");
            pdFF.SetField("city", "NAPERVILLE");
            pdFF.SetField("state", "IL");
            pdFF.SetField("zip", "60563");
            pdFF.SetField("checkbox4", quarter.ToString());
            pdFF.SetField("w2", "0");
            pdFF.SetField("Form1099", "0");
            pdFF.SetField("line1", line1.ToString());
            pdFF.SetField("Month1Day28", firstMonth[0]);
            pdFF.SetField("Month1Day28Cents", firstMonth[1]);
            pdFF.SetField("Month2Day28", secondMonth[0]);
            pdFF.SetField("Month2Day28Cents", secondMonth[1]);
            pdFF.SetField("Month3Day28", thirdMonth[0]);
            pdFF.SetField("Month3Day28Cents", thirdMonth[1]);
            pdFF.SetField("Month1Total", firstMonth[0]);
            pdFF.SetField("Month1TotalCents", firstMonth[1]);
            pdFF.SetField("Month2Total", secondMonth[0]);
            pdFF.SetField("Month2TotalCents", secondMonth[1]);
            pdFF.SetField("Month3Total", thirdMonth[0]);
            pdFF.SetField("Month3TotalCents", thirdMonth[1]);
            pdFF.SetField("line3", "0.00");
            pdFF.SetField("line4", totalWithhold.ToString());
            pdFF.SetField("line5", totalWithhold.ToString());
            pdFF.SetField("line6", "0.00");
            pdFF.SetField("Title", "President");
            pdFF.SetField("areacode1", "630");
            pdFF.SetField("phonenumber1", "802-5498");
            pdFF.SetField("DiscussWithPreparer", "a");
            pdFF.SetField("PreparerName", "Kenneth Lin");
            pdFF.SetField("SelfEmployed", "a");
            pdFF.SetField("PTIN", "P02226123");
            pdFF.SetField("FirmName", "Kenneth Lin, CPA");
            pdFF.SetField("FirmAddress", "4227 Colton Cir. Naperville IL 60564");
            pdFF.SetField("areacode2", "630");
            pdFF.SetField("phonenumber2", "802-5485");
            pds.FormFlattening = false;
            pds.Close();

        }

        private void tosmnubtnFed941_Click(object sender, EventArgs e)
        {
            ClearDDLColors();

            if (!CheckDDL(ddlQuarter, "You must select a quarter to continue."))
                return;

            int quarter = ddlQuarter.SelectedIndex + 1;

            // opne a save file dialog and prompt user to enter file path
            SaveFileDialog saveWindow = new SaveFileDialog();
            saveWindow.Title = "Export data to PDF";
            saveWindow.Filter = "PDF (.pdf)|*.pdf";
            saveWindow.ShowDialog();

            if (saveWindow.FileName == "")
                return;

            string fileName = saveWindow.FileName;
            CreateFed941(fileName, quarter);
            string msg = "Form F941 have been exported to " + fileName;
            ChangeStatusLabel(tosStatus, msg);
        }

        private void CreateFed941(string fileName, int quarter)
        {
            int periods = GetNumPayPeriods();
            Employer emp = new Employer(WithHoldDic, EmpList, periods);
            Dictionary<string, List<double>> payDic = emp.CalcQuarterlyStateWages(quarter);
            Dictionary<int, List<double>> withDic = emp.CalcFedQuarterlyWitholding(quarter);
            int[] periodsRange = emp.GetPeriodDateRange(quarter);
            int beginP = periodsRange[0];
            int endP = periodsRange[1];
            List<double> monthlyWithholdList = new List<double>();

            for (int i = beginP; i <= endP; i++)
            {
                double monthlyWithhold = withDic[i].Sum();
                monthlyWithholdList.Add(monthlyWithhold);
            }

            double wages = payDic.Sum(x => x.Value[1]);
            double totalFed = withDic.Sum(f => f.Value[0]);
            double totalSSNTax = withDic.Sum(s => s.Value[1]);
            double totalMedTax = withDic.Sum(m => m.Value[2]);
            double totalMedAndSSN = withDic.Sum(x => x.Value[1] + x.Value[2]);
            double totalTaxesBeforeAdj = withDic.Sum(x => x.Value[0] + x.Value[1] + x.Value[2]);

            // format the $55.89 to [55, 89]
            string[] wagesSplit = SplitDollarAmounts(wages);
            string[] totalFedSplit = SplitDollarAmounts(totalFed);
            string[] totalSSNSplit = SplitDollarAmounts(totalSSNTax);
            string[] totalMedSplit = SplitDollarAmounts(totalMedTax);
            string[] totalMedAndSSNSplit = SplitDollarAmounts(totalMedAndSSN);
            string[] totalTaxesAdjSplit = SplitDollarAmounts(totalTaxesBeforeAdj);
            string[] firstMonth = SplitDollarAmounts(monthlyWithholdList[0]);
            string[] secondMonth = SplitDollarAmounts(monthlyWithholdList[1]);
            string[] thirdMonth = SplitDollarAmounts(monthlyWithholdList[2]);

            // read the pdf file and find the textfield values
            PdfReader pdr = new PdfReader(f941);
            //StringBuilder sb = new StringBuilder();

            //foreach (var de in pdr.AcroFields.Fields)
            //{      
            //    lstResults.Items.Add(de.ToString());
            //}

            // open a PdfStamper and write to the pdf and save it to file path
            PdfStamper pds = new PdfStamper(pdr, new FileStream(fileName, FileMode.Create));
            AcroFields pdFF = pds.AcroFields;

            pdFF.SetField("f1_1[0]", "36");
            pdFF.SetField("f1_2[0]", "4084647");
            pdFF.SetField("f1_3[0]", "CASCO (USA) INC");
            pdFF.SetField("f1_5[0]", "1300 IROQUOIS, UNIT 245");
            pdFF.SetField("f1_6[0]", "NAPERVILLE");
            pdFF.SetField("f1_7[0]", "IL");
            pdFF.SetField("f1_8[0]", "60653");

            if (ddlQuarter.SelectedIndex == 0)
                pdFF.SetField("c1_1[0]", "1");
            else if (ddlQuarter.SelectedIndex == 1)
                pdFF.SetField("c1_1[1]", "2");
            else if (ddlQuarter.SelectedIndex == 2)
                pdFF.SetField("c1_1[2]", "3");
            else if (ddlQuarter.SelectedIndex == 3)
                pdFF.SetField("c1_1[3]", "4");

            pdFF.SetField("f1_12[0]", EmpList.Count.ToString());

            pdFF.SetField("f1_13[0]", wagesSplit[0]);
            pdFF.SetField("f1_14[0]", wagesSplit[1]);
            pdFF.SetField("f1_15[0]", totalFedSplit[0]);
            pdFF.SetField("f1_16[0]", totalFedSplit[1]);
            pdFF.SetField("f1_17[0]", wagesSplit[0]);
            pdFF.SetField("f1_18[0]", wagesSplit[1]);
            pdFF.SetField("f1_19[0]", totalSSNSplit[0]);
            pdFF.SetField("f1_20[0]", totalSSNSplit[1]);
            pdFF.SetField("f1_33[0]", wagesSplit[0]);
            pdFF.SetField("f1_34[0]", wagesSplit[1]);
            pdFF.SetField("f1_35[0]", totalMedSplit[0]);
            pdFF.SetField("f1_36[0]", totalMedSplit[1]);
            pdFF.SetField("f1_41[0]", totalMedAndSSNSplit[0]);
            pdFF.SetField("f1_42[0]", totalMedAndSSNSplit[1]);
            pdFF.SetField("f1_45[0]", totalTaxesAdjSplit[0]);
            pdFF.SetField("f1_46[0]", totalTaxesAdjSplit[1]);
            pdFF.SetField("f1_53[0]", totalTaxesAdjSplit[0]);
            pdFF.SetField("f1_54[0]", totalTaxesAdjSplit[1]);
            pdFF.SetField("f2_1[0]", "CASCO (USA) INC");
            pdFF.SetField("f2_2[0]", "36-4084647");
            pdFF.SetField("f2_5[0]", totalTaxesAdjSplit[0]);
            pdFF.SetField("f2_6[0]", totalTaxesAdjSplit[1]);
            pdFF.SetField("f2_7[0]", totalTaxesAdjSplit[0]);
            pdFF.SetField("f2_8[0]", totalTaxesAdjSplit[1]);
            pdFF.SetField("c2_2[1]", "2");
            pdFF.SetField("f2_25[0]", firstMonth[0]);
            pdFF.SetField("f2_26[0]", firstMonth[1]);
            pdFF.SetField("f2_27[0]", secondMonth[0]);
            pdFF.SetField("f2_28[0]", secondMonth[1]);
            pdFF.SetField("f2_29[0]", thirdMonth[0]);
            pdFF.SetField("f2_30[0]", thirdMonth[1]);
            pdFF.SetField("f2_31[0]", totalTaxesAdjSplit[0]);
            pdFF.SetField("f2_32[0]", totalTaxesAdjSplit[1]);
            pdFF.SetField("f3_1[0]", "CASCO (USA) INC");
            pdFF.SetField("f3_2[0]", "36-4084647");
            pdFF.SetField("c3_3[0]", "1");
            pdFF.SetField("f3_18[0]", "KENNETH LIN");
            pdFF.SetField("f3_19[0]", "(630) 802-5485");
            pdFF.SetField("f3_23[0]", "(630) 802-5498");
            pdFF.SetField("c3_4[0]", "1");
            pdFF.SetField("f3_24[0]", "KENNETH LIN");
            pdFF.SetField("f3_25[0]", "P02226123");
            pdFF.SetField("f3_26[0]", "KENNETH LIN");
            pdFF.SetField("f3_28[0]", "4227 Colton Cir.");
            pdFF.SetField("f3_29[0]", "(630) 802-5485");
            pdFF.SetField("f3_30[0]", "Naperville");
            pdFF.SetField("f3_31[0]", "IL");
            pdFF.SetField("f3_32[0]", "60564");
            pds.FormFlattening = false;
            pds.Close();
        }      

        private void tosbtnF940_Click(object sender, EventArgs e)
        {
            // open a save file dialog and prompt user to enter file path
            SaveFileDialog saveWindow = new SaveFileDialog();
            saveWindow.Title = "Export data to PDF";
            saveWindow.Filter = "PDF (.pdf)|*.pdf";
            saveWindow.ShowDialog();

            if (saveWindow.FileName == "")
                return;

            string fileName = saveWindow.FileName;

            CreateFed940(fileName);           

            string msg = "Form Fed-940 has been exported to " + fileName;
            ChangeStatusLabel(tosStatus, msg);
        }

        private void CreateFed940(string fileName)
        {
            int periods = GetNumPayPeriods();
            Employer emp = new Employer(WithHoldDic, EmpList, periods);
            List<double> FutaList = emp.CalcFUTA();
            double totalWages = FutaList[0];
            double excessWages = FutaList[1];
            double taxableWages = FutaList[2];
            double futaTax = Math.Round(taxableWages * 0.006, 2);
            string[] totalWagesSplit = SplitDollarAmounts(totalWages);
            string[] excessWagesSplit = SplitDollarAmounts(excessWages);
            string[] taxableWagesSplit = SplitDollarAmounts(taxableWages);
            string[] futaTaxSplit = SplitDollarAmounts(futaTax);


            // read the pdf file and find the textfield values
            PdfReader pdr = new PdfReader(f940);

            //StringBuilder sb = new StringBuilder();
            //foreach (var de in pdr.AcroFields.Fields)
            //{
            //    lstResults.Items.Add(de.ToString());
            //}

            // open a PdfStamper and write to the pdf and save it to file path
            PdfStamper pds = new PdfStamper(pdr, new FileStream(fileName, FileMode.Create));
            AcroFields pdFF = pds.AcroFields;

            pdFF.SetField("f1_1[0]", "3");
            pdFF.SetField("f1_2[0]", "6");
            pdFF.SetField("f1_3[0]", "4");
            pdFF.SetField("f1_4[0]", "0");
            pdFF.SetField("f1_5[0]", "8");
            pdFF.SetField("f1_6[0]", "4");
            pdFF.SetField("f1_7[0]", "6");
            pdFF.SetField("f1_8[0]", "4");
            pdFF.SetField("f1_9[0]", "7");
            pdFF.SetField("f1_10[0]", "CASCO (USA) INC");
            pdFF.SetField("f1_12[0]", "1300 IROQUOIS, UNIT 245");
            pdFF.SetField("f1_13[0]", "NAPERVILLE");
            pdFF.SetField("f1_14[0]", "IL");
            pdFF.SetField("f1_15[0]", "60563");
            pdFF.SetField("f1_19[0]", "I");
            pdFF.SetField("f1_20[0]", "L");
            pdFF.SetField("f1_21[0]", totalWagesSplit[0]);
            pdFF.SetField("f1_22[0]", totalWagesSplit[1]);
            pdFF.SetField("f1_25[0]", excessWagesSplit[0]);
            pdFF.SetField("f1_26[0]", excessWagesSplit[1]);
            pdFF.SetField("f1_27[0]", excessWagesSplit[0]);
            pdFF.SetField("f1_28[0]", excessWagesSplit[1]);
            pdFF.SetField("f1_29[0]", taxableWagesSplit[0]);
            pdFF.SetField("f1_30[0]", taxableWagesSplit[1]);
            pdFF.SetField("f1_31[0]", futaTaxSplit[0]);
            pdFF.SetField("f1_32[0]", futaTaxSplit[1]);
            pdFF.SetField("f1_39[0]", futaTaxSplit[0]);
            pdFF.SetField("f1_40[0]", futaTaxSplit[1]);
            pdFF.SetField("f1_41[0]", futaTaxSplit[0]);
            pdFF.SetField("f1_42[0]", futaTaxSplit[1]);
            pdFF.SetField("f2_1[0]", "CASCO (USA) INC");
            pdFF.SetField("f2_2[0]", "36-4084647");
            pdFF.SetField("c2_1[0]", "Yes");
            pdFF.SetField("f2_13[0]", "KENNETH LIN");
            pdFF.SetField("f2_14[0]", "(630) 802-5485");
            pdFF.SetField("f2_16[0]", "LU LIN");
            pdFF.SetField("f2_17[0]", "PRESIDENT");
            pdFF.SetField("f2_18[0]", "(630) 802-5498");
            pdFF.SetField("c2_2[0]", "1");
            pdFF.SetField("f2_19[0]", "KENNETH LIN");
            pdFF.SetField("f2_20[0]", "P02226123");
            pdFF.SetField("f2_21[0]", "KENNETH LIN");
            pdFF.SetField("f2_23[0]", "4227 COLTON CIR");
            pdFF.SetField("f2_24[0]", "(630) 802-5485");
            pdFF.SetField("f2_25[0]", "NAPERVILLE");
            pdFF.SetField("f2_26[0]", "IL");
            pdFF.SetField("f2_27[0]", "60564");
            pds.FormFlattening = false;
            pds.Close();
        }


        private void tosbtnCreateAll_Click(object sender, EventArgs e)
        {            

            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;

            DialogResult result = folder.ShowDialog();  
            string path = "";

            if (result == DialogResult.OK)
            {         
                path = folder.SelectedPath;
            }

            string test = Path.Combine(path, "test");

            MessageBox.Show(test);

            if (!Directory.Exists(test))
                Directory.CreateDirectory(test);



        }

        private bool CheckDDL(ComboBox ddl, string msg)
        {
            // check if drop down list has been selected
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
            // get number of periods based on user selection
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
            // set correct number of months in drop down list as user picks pay frequency
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
            // add employee names to drop down list
            for (int i = 0; i < EmpList.Count; i++)
            {
                string name = EmpList[i].firstName + " " + EmpList[i].lastName;
                ddlEmployees.Items.Add(name);
            }
        }

        private void AddQuartersToDDL()
        {
            // Add quarters 1-4 to drop down list
            for (int i = 1; i <= 4; i++)
                ddlQuarter.Items.Add(i);
        }

        private void radMonthly_CheckedChanged(object sender, EventArgs e)
        {
            // if pay frequency changes, update the period drop down list
            SetNumPayPeriods();
        }

        private void ClearDDLColors()
        {
            // change the drop down lists colors back to white
            ddlEmployees.BackColor = Color.White;
            ddlPayPeriod.BackColor = Color.White;
            ddlQuarter.BackColor = Color.White;
        }

        private void ChangeStatusLabel(ToolStripLabel status, string msg)
        {
            // displays the message, then erase it after 5 seconds
            status.Text = msg;

            var timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += (s, e) =>
            {
                status.Text = "";
                timer.Stop();
            };
            timer.Start();
        }

        private string[] SplitDollarAmounts(double dollar)
        {
            // convert $12.33 to [12, 33]
            string[] parts = new string[2];
            string sDollar = Math.Round(dollar, 2).ToString();

            if (!sDollar.Contains('.'))
            {
                parts[0] = sDollar;
                parts[1] = "00";
            }
            else
            {
                parts = sDollar.Split('.');
            }

            return parts;
        }

    }
}
