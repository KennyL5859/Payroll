using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    // Employee class that holds employee data
    public class Employee
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string SSN { get; set; }
        public DateTime DOB { get; set; }
        public string fStatus { get; set; }
        public int withHolding { get; set; }
        public int childDep { get; set; }
        public int otherDep { get; set; }
        public double xFedWithhold { get; set; }
        public double xStateWithold { get; set; }
        public bool multipleJobs { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public double salary { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        private const double SSNWageGap = 142800;
        private const double MedRegRate = 0.0145;
        private const double MedAddRate = 0.0235;
        private const double StateRate = 0.0495;

        // constructor for Employee class
        public Employee(string fName, string lName, string ssn, DateTime dob, string fStatus,
            int withhold, int child, int other, double xFed, double xState, bool multiple,
            string street, string city, string state, string zipCode, double salary, DateTime start,
            DateTime end)
        {
            this.firstName = fName;
            this.lastName = lName;
            this.SSN = ssn;
            this.DOB = dob;
            this.fStatus = fStatus;
            this.withHolding = withhold;
            this.childDep = child;
            this.otherDep = other;
            this.xFedWithhold = xFed;
            this.xStateWithold = xState;
            this.multipleJobs = multiple;
            this.street = street;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.salary = salary;
            this.startDate = start;
            this.endDate = end;
        }
        
        public double salaryPerPeriod(int periods, int selectedPeriod)
        {
            // calculates salary per period
            Dictionary<int, double> periodsRate = GetPeriodsWorked(periods);
            double salary = this.salary / periods * periodsRate[selectedPeriod];
            return Math.Round(salary, 2);
        }

        public double CalcQuarterlySalary(int periods, int beginP, int selectedPeriod)
        {
            // calculate salary from beginning period to end period
            double totalSalary = 0;

            for (int i = beginP; i <= selectedPeriod; i++)
                totalSalary += salaryPerPeriod(periods, i);

            return totalSalary;
        }

        public double CalcSSNTax(int periods, int selectedPeriod)
        {
            // calculate SSN tax withholding
            Dictionary<int, double> periodsRate = GetPeriodsWorked(periods);
            double wage = 0;
            double ssTax = 0;

            if (this.salary >= SSNWageGap)
                wage = SSNWageGap;
            else
                wage = this.salary;

            double tax = wage * 0.062 / periods * periodsRate[selectedPeriod];
            ssTax = Math.Round(tax, 2);
            return ssTax;           

        }

        public double CalcMedTax(int periods, int selectedPeriod)
        {
            // Calculate medicare withholding tax rates
            Dictionary<int, double> periodsRate = GetPeriodsWorked(periods);
            double regularRate = this.salary;
            double excessRate = 0;
            double medTax = 0;

            // this separates the regular rates and the additional medicare rates
            if ((this.fStatus == "S" || this.fStatus == "HOH") && this.salary > 200000)
            {
                regularRate = 200000;
                excessRate = this.salary - 200000;
            }
            else if (this.fStatus == "MFJ" && this.salary > 250000)
            {
                regularRate = 250000;
                excessRate = this.salary - 250000;
            }
            else if (this.fStatus == "MFS" && this.salary > 125000)
            {
                regularRate = 125000;
                excessRate = this.salary - 125000;
            }

            double tax = (((regularRate * MedRegRate) + (excessRate * MedAddRate)) / periods) * periodsRate[selectedPeriod];
            medTax = Math.Round(tax, 2);
            return medTax;       
        }

        public double CalcStateTax(int periods, int selectedPeriod)
        {
            // Calculates state withholding rates
            Dictionary<int, double> periodsRate = GetPeriodsWorked(periods);
            double stateTax = 0;
            double deductions = ((this.childDep * 2375) + (this.otherDep * 1000)) / periods;
            double perPeriodSalary = this.salary / periods * periodsRate[selectedPeriod];
            double tax = (perPeriodSalary - deductions) * 0.0495 + this.xStateWithold;

            if (tax < 0)
                stateTax = 0;
            else
                stateTax = Math.Round(tax, 2);

            return stateTax;            
        }

        public double CalcFedTax(int periods, Dictionary<string, WithholdTable> withDic, 
            int selectPeriod)
        {
            // Calculates the federal withholding
            Dictionary<int, double> periodsRate = GetPeriodsWorked(periods);
            double periodSalary = this.salary / periods;
            double salary = periodSalary * periodsRate[selectPeriod] * periods;
            double multipleJob;
            string status = "";

            if (this.multipleJobs)
            {
                multipleJob = 0;
                status = this.fStatus + "+";
            }                
            else
            {
                if (this.fStatus == "MFJ")
                    multipleJob = 12900;
                else
                    multipleJob = 8600;

                status = this.fStatus;
            }

            double adjAnnualWage = salary - multipleJob;
            WithholdTable WT = withDic[status];
            var table = WT.rates;
            int numRows = table.GetLength(0);
            int selectRows = 0;

            for (int i = 0; i < numRows; i++)
            {  
                if (adjAnnualWage >= table[i, 0] && adjAnnualWage <= table[i, 1])
                {
                    selectRows = i;
                }
            }

            double rowA = table[selectRows, 0];
            double tentative = table[selectRows, 2];
            double percentage = table[selectRows, 3];
            double adjAdj = adjAnnualWage - rowA;
            double tentative2 = adjAdj * percentage;
            double tax = (tentative + tentative2) / periods;
            double realTax = Math.Round(tax, 2) + this.xFedWithhold;
            return realTax;
        }

        public double CalcFedTaxCulmulative(int period, Dictionary<string, WithholdTable> withDic,
            int selectedPeriod)
        {
            // calculates culmulative federal withholding
            double culmuFedTax = 0;

            for (int i = 1; i <= selectedPeriod; i++)            
                culmuFedTax += CalcFedTax(period, withDic, i);            

            return culmuFedTax;
        }

        public double CalcStateTaxCulmulative(int periods, int selectedPeriod)
        {
            // calculate culmulative state withholding
            double stateTax = 0;

            for (int i = 1; i <= selectedPeriod; i++)
                stateTax += CalcStateTax(periods, i);

            return stateTax;
        }

        public double CalcSSNTaxCulmulative(int periods, int selectedPeriod)
        {
            // culmulative SSN tax
            double ssnTax = 0;

            for (int i = 1; i <= selectedPeriod; i++)
                ssnTax += CalcSSNTax(periods, i);

            return ssnTax;
        }

        public double CalcMedTaxCulmulative(int periods, int selectedPeriod)
        {
            // culmulative medicare tax
            double medTax = 0;

            for (int i = 1; i <= selectedPeriod; i++)
                medTax += CalcMedTax(periods, i);

            return medTax;
        }

        public double CalcNetPay(int periods, Dictionary<string, WithholdTable> withDic,
            int selectedPeriod)
        {
            // calculates the net pay after taxes are withheld
            double netPay = 0;

            Dictionary<int, double> periodsWorked = GetPeriodsWorked(periods);
            double salary = this.salary / periods * periodsWorked[selectedPeriod];
            double fed = CalcFedTax(periods, withDic, selectedPeriod);
            double state = CalcStateTax(periods, selectedPeriod);
            double ssn = CalcSSNTax(periods, selectedPeriod);
            double med = CalcMedTax(periods, selectedPeriod);
            double netSalary = salary - fed - state - ssn - med;
            netPay = Math.Round(netSalary, 2);
            return netPay;
        }

        public double CalcNetPayCulmulative(int periods, Dictionary<string, WithholdTable> withDic,
            int selectedPeriod)
        {
            // calculates the culmulative net pay
            double netPay = 0;

            for (int i = 1; i <= selectedPeriod; i++)
                netPay += CalcNetPay(periods, withDic, i);

            return netPay;
        }

        public double CalcTotalTax(int periods, Dictionary<string, WithholdTable> withDic, int selectPeriod)
        {            
            // calculates the total taxes (combine all withholdings)
            double fed = CalcFedTaxCulmulative(periods, withDic, selectPeriod);
            double state = CalcStateTaxCulmulative(periods, selectPeriod);
            double fica = CalcSSNTaxCulmulative(periods, selectPeriod);
            double mediTax = CalcMedTaxCulmulative(periods, selectPeriod);
            double totalTax = fed + state + fica + mediTax;
            return totalTax;
        }

        public Dictionary<int, double> GetPeriodsWorked(int periods)
        {
            // Dictionary that gets the number of periods worked 
            // based on start and end date
            Dictionary<int, double> periodsWorked = new Dictionary<int, double>();

            if (periods == 12)
                periodsWorked = GetMonthsWorked();
            else
                periodsWorked = GetWeeksWorked(periods);

            return periodsWorked;
        }

        public Dictionary<int, double> GetWeeksWorked(int periods)
        {
            // Get number of weeks worked based on start/end date
            int numDays = 365 / periods;
            Dictionary<int, double> weeksWorked = new Dictionary<int, double>();
            int curYear = DateTime.Now.Year;
            DateTime begin = new DateTime(curYear, 1, 1);
            DateTime end = new DateTime(curYear, 12, 31);
            int startMonth = this.startDate.Month;
            int startDate = this.startDate.Day;
            int endMonth = this.endDate.Month;
            int endDate = this.endDate.Day;

            if (this.startDate < begin && this.endDate > end)
            {
                for (int i = 1; i <= periods; i++)
                {
                    weeksWorked.Add(i, 1);
                }
            }
            else
            {
                int bDaysPassed = (this.startDate - begin).Days + 1;
                int beginPeriods = bDaysPassed / numDays + 1;
                int beginExcessDays = bDaysPassed % numDays;

                double beginPercentPeriod = 1;

                if (beginExcessDays != 0)
                    beginPercentPeriod = Math.Round((double)(numDays - beginExcessDays) / numDays, 2);

                int eDaysPassed = (end - this.endDate).Days;
                int periodsLeft = eDaysPassed / numDays;
                int lastPeriod = periods - periodsLeft;

                for (int i = 1; i <= periods; i++)
                {
                    if (i < beginPeriods)
                        weeksWorked.Add(i, 0);
                    else if (i == beginPeriods)
                        weeksWorked.Add(i, beginPercentPeriod);
                    else if (i > lastPeriod)
                        weeksWorked.Add(i, 0);
                    else
                        weeksWorked.Add(i, 1);
                }
            }
            return weeksWorked;
        }        

        public Dictionary<int, double> GetMonthsWorked()
        {
            // Get number of months worked based on start and end date
            Dictionary<int, double> monthsWorked = new Dictionary<int, double>();
            int curYear = DateTime.Now.Year;
            DateTime begin = new DateTime(curYear, 1, 1);
            DateTime end = new DateTime(curYear, 12, 31);
            int startMonth = this.startDate.Month;
            int startDate = this.startDate.Day;
            int endMonth = this.endDate.Month;
            int endDate = this.endDate.Day;  

            if (this.startDate < begin && this.endDate > end)
            {
                for (int i = 1; i <= 12; i++)
                {
                    monthsWorked.Add(i, 1);
                }
            }
            else
            {
                if (this.endDate > end)
                {
                    endMonth = 12;
                    endDate = 31;
                }

                int beginNumDays = DateTime.DaysInMonth(curYear, startMonth);
                double beginPercentWorked = Math.Round((double)(beginNumDays - startDate + 1) / beginNumDays, 2);

                int endNumDays = DateTime.DaysInMonth(curYear, endMonth);
                double endPercentWorked = Math.Round((double) endDate / endNumDays, 2);

                for (int i = 1; i <= 12; i++)
                {
                    if (i < startMonth)
                        monthsWorked.Add(i, 0);
                    else if (i == startMonth)
                        monthsWorked.Add(i, beginPercentWorked);
                    else if (i > endMonth)
                        monthsWorked.Add(i, 0);
                    else if (i == endMonth)
                        monthsWorked.Add(i, endPercentWorked);
                    else
                        monthsWorked.Add(i, 1);
                }
            }
            return monthsWorked;
        }

        public string[] GetEmpStringAttributes()
        {
            // gets employee attributes and put it into an array
            string[] EmpAttributes = new string[18];
            EmpAttributes[0] = this.firstName;
            EmpAttributes[1] = this.lastName;
            EmpAttributes[2] = this.SSN;
            string dob = this.DOB.ToString("MM/dd/yyyy");
            EmpAttributes[3] = dob;
            EmpAttributes[4] = this.fStatus;
            EmpAttributes[5] = this.withHolding.ToString();
            EmpAttributes[6] = this.childDep.ToString();
            EmpAttributes[7] = this.otherDep.ToString();
            EmpAttributes[8] = this.xFedWithhold.ToString();
            EmpAttributes[9] = this.xStateWithold.ToString();
            EmpAttributes[10] = this.multipleJobs.ToString();
            EmpAttributes[11] = this.street;
            EmpAttributes[12] = this.city;
            EmpAttributes[13] = this.state;
            EmpAttributes[14] = this.zipCode;
            EmpAttributes[15] = this.salary.ToString();
            string start = this.startDate.ToString("MM/dd/yyyy");
            string end = this.endDate.ToString("MM/dd/yyyy");
            EmpAttributes[16] = start;
            EmpAttributes[17] = end;
            return EmpAttributes;
        }
    }
}
