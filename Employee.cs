using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
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

        public double salaryPerPeriod(int periods)
        {
            double salary = this.salary / periods;
            return salary;
        }

        public double CalcSSNTax(int periods)
        {
            double wage = 0;
            double ssTax = 0;

            if (this.salary >= SSNWageGap)
                wage = SSNWageGap;
            else
                wage = this.salary;

            double tax = wage * 0.062 / periods;
            ssTax = Math.Round(tax, 2);
            return ssTax;           

        }

        public double CalcMedTax(int periods)
        {
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

            double tax = ((regularRate * MedRegRate) + (excessRate * MedAddRate)) / periods;
            medTax = Math.Round(tax, 2);

            return medTax;       
        }

        public double CalcStateTax(int periods)
        {
            double stateTax = 0;
            double deductions = ((this.childDep * 2375) + (this.otherDep * 1000)) / periods;
            double tax = ((this.salary - deductions) * 0.0495) / periods + this.xStateWithold;
            stateTax = Math.Round(tax, 2);
            return stateTax;
        }

        public double CalcFedTax(int periods, Dictionary<string, WithholdTable> withDic)
        {
            double salary = this.salary;
            double multipleJob;

            if (this.multipleJobs)
            {
                multipleJob = 0;
            }                
            else
            {
                if (this.fStatus == "MFJ")
                    multipleJob = 12900;
                else
                    multipleJob = 8600;
            }

            double adjAnnualWage = salary - multipleJob;
          
            //

            //

            
            return adjAnnualWage;

        }



        public string[] GetEmpStringAttributes()
        {
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
            string end = this.startDate.ToString("MM/dd/yyyy");
            EmpAttributes[16] = start;
            EmpAttributes[17] = end;
            return EmpAttributes;
        }
    }
}
