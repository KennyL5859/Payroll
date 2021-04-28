using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Payroll
{
    public partial class frmMain : Form
    {
        static string filePath = AppDomain.CurrentDomain.BaseDirectory;
        string EMPDATAPATH = Path.GetFullPath(Path.Combine(filePath, @"..\..\Required\EmpInfo.txt"));
        string IRS_PERCENT = Path.GetFullPath(Path.Combine(filePath, @"..\..\Required\IRS_Percentage.xlsx"));
        List<Employee> EmpList = new List<Employee>();
        Dictionary<string, WithholdTable> WithHoldDic = new Dictionary<string, WithholdTable>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ReadFile();           
        }

        private void tosbtnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditEmp addForm = new frmAddEditEmp(false, EmpList);
            addForm.ShowDialog();
            UpdateFile();
        }

        private void tosbtnDelete_Click(object sender, EventArgs e)
        {
            int selectedRows = dgvEmployeeData.SelectedRows.Count;
            DialogResult result;
            int rowIndex = dgvEmployeeData.SelectedCells[0].RowIndex;

            // prompt user for delete confirmation
            if (selectedRows == 0)
            {
                MessageBox.Show("You must select an employee to delete.");
                return;
            }
            else if (selectedRows == 1)
            {
                result = MessageBox.Show("Are you sure you want to delete " +
                    dgvEmployeeData.Rows[rowIndex].Cells[0].Value.ToString() + " " + 
                    dgvEmployeeData.Rows[rowIndex].Cells[1].Value.ToString() +
                    "'s information", "Confirmation", MessageBoxButtons.OKCancel);
            }
            else
            {
                result = MessageBox.Show("Are you sure you want to delete " +
                    selectedRows + " employees data?", "Confirmation", MessageBoxButtons.OKCancel);

            }

            if (result == DialogResult.Cancel)
                return;            

            // Removes it from the list
            for (int i = 0; i < selectedRows; i++)
            {
                int rIndex = dgvEmployeeData.SelectedRows[i].Index;
                EmpList.RemoveAt(rIndex);
            }

            // update datagridview
            UpdateFile();
        }


        private void tosbtnEdit_Click(object sender, EventArgs e)
        {
            int empIndex = dgvEmployeeData.CurrentCell.RowIndex;
            frmAddEditEmp editForm = new frmAddEditEmp(true, EmpList, empIndex);
            editForm.ShowDialog();
            UpdateFile();
        }

        private void tosbtnSave_Click(object sender, EventArgs e)
        {
            WriteToFile();
            MessageBox.Show("Employee data have been saved");
        }

        private void dgvEmployeeData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // save to text file when after user edits cell
            WriteToFile();
        }

        private void dgvEmployeeData_DoubleClick(object sender, EventArgs e)
        {
            tosbtnEdit_Click(sender, e);
        }













        private void tosbtnCalculate_Click(object sender, EventArgs e)
        {

            List<string> fStatusList = new List<string> { "S", "S+", "MFJ", "MFJ+", "HOH", "HOH+" };

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWkbook = xlApp.Workbooks.Open(IRS_PERCENT, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


            for (int i = 0; i < fStatusList.Count; i++)
            {
                try
                {
                    Excel.Worksheet xlWkSheet = (Excel.Worksheet)xlWkbook.Worksheets[fStatusList[i]];
                    Excel.Range range = xlWkSheet.UsedRange;

                    double[,] table = new double[8, 5];

                    for (int r = 2; r <= 9; r++)
                    {
                        for (int c = 1; c <= 5; c++)
                        {
                            table[r - 2, c - 1] = Convert.ToDouble(range.Cells[r, c].Value2.ToString());
                        }
                    }

                    WithholdTable newTable = new WithholdTable(table);
                    WithHoldDic.Add(fStatusList[i], newTable);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred");
                    xlWkbook.Close(true, null, null);
                    xlApp.Quit();
                    return;
                }
            }


            xlWkbook.Close(true, null, null);
            xlApp.Quit();


            var x = WithHoldDic;

            MessageBox.Show(WithHoldDic.Count.ToString());

            
        }

















        private void ReadFile()
        {
            string empFile = "";

            // navigate and open up the employee data source
            if (File.Exists(EMPDATAPATH))
            {
                empFile = File.ReadAllText(EMPDATAPATH);       
            }

            string[] fileLines = empFile.Split('\n');
            
            // loop thru each line and split each line by comma
            for (int i = 0; i < fileLines.Length; i++)
            {
                if (fileLines[i].Length > 0)
                {
                    // if its not an empty line, convert each line into employee object
                    // and add to list
                    string[] empFields = fileLines[i].Split(',');
                    Employee tempEmp = SetEmpAttributes(empFields);
                    EmpList.Add(tempEmp);
                }
            }

            dgvEmployeeData.DataSource = EmpList;
            dgvEmployeeData.Refresh();
            ChangeDataColumnNames();
        }

        private void WriteToFile()
        {
            File.WriteAllText(EMPDATAPATH, string.Empty);

            using (StreamWriter wr = new StreamWriter(EMPDATAPATH))
            {
                for (int i = 0; i < EmpList.Count; i++)
                {
                    string[] attributes = EmpList[i].GetEmpStringAttributes();
                    StringBuilder sb = new StringBuilder();

                    for (int x = 0; x < attributes.Length - 1; x++)
                    {
                        sb.Append(attributes[x] + ",");
                    }
                    sb.Append(attributes[attributes.Length - 1]);

                    wr.WriteLine(sb.ToString());
                }
            }
        }

        private void UpdateFile()
        {
            dgvEmployeeData.DataSource = null;
            WriteToFile();
            EmpList.Clear();
            ReadFile();
        }

        private void ChangeDataColumnNames()
        {
            dgvEmployeeData.Columns[0].HeaderText = "First Name";
            dgvEmployeeData.Columns[1].HeaderText = "Last Name";
            dgvEmployeeData.Columns[2].HeaderText = "SSN";
            dgvEmployeeData.Columns[3].HeaderText = "DOB";
            dgvEmployeeData.Columns[4].HeaderText = "Status";
            dgvEmployeeData.Columns[5].HeaderText = "Withholding";
            dgvEmployeeData.Columns[6].HeaderText = "Child Dep.";
            dgvEmployeeData.Columns[7].HeaderText = "Other Dep.";
            dgvEmployeeData.Columns[8].HeaderText = "Extra Fed";
            dgvEmployeeData.Columns[9].HeaderText = "Extra State";
            dgvEmployeeData.Columns[10].HeaderText = "Multiple Jobs";
            dgvEmployeeData.Columns[11].HeaderText = "Street";
            dgvEmployeeData.Columns[12].HeaderText = "City";
            dgvEmployeeData.Columns[13].HeaderText = "State";
            dgvEmployeeData.Columns[14].HeaderText = "Zip Code";
            dgvEmployeeData.Columns[15].HeaderText = "Salary";
            dgvEmployeeData.Columns[16].HeaderText = "Start Date";
            dgvEmployeeData.Columns[17].HeaderText = "End Date";
        }

        private Employee SetEmpAttributes(string[] fields)
        {
            // convert everything in array to variables
            string fName = fields[0];
            string lName = fields[1];
            string ssn = fields[2];
            DateTime dob = Convert.ToDateTime(fields[3]);
            string status = fields[4];
            int withhold = Convert.ToInt32(fields[5]);
            int child = Convert.ToInt32(fields[6]);
            int other = Convert.ToInt32(fields[7]);
            double xFed = Convert.ToDouble(fields[8]);
            double xState = Convert.ToDouble(fields[9]);
            bool multiJob = Convert.ToBoolean(fields[10]);
            string street = fields[11];
            string city = fields[12];
            string state = fields[13];
            string zipCode = fields[14];
            double salary = Convert.ToDouble(fields[15]);
            DateTime start = Convert.ToDateTime(fields[16]);
            DateTime end = Convert.ToDateTime(fields[17]);

            Employee newEmp = new Employee(fName, lName, ssn, dob, status, withhold,
                child, other, xFed, xState, multiJob, street, city, state, zipCode,
                salary, start, end);

            return newEmp;
        }


    }
}
