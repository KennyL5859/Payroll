using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class Employer
    {
        public Dictionary<string, WithholdTable> withHoldDic { get; set; }
        public List<Employee> EmpList { get; set; }
        public int numPeriods { get; set; }

        public Employer()
        {
        }

        public Employer(Dictionary<string, WithholdTable> wDic, List<Employee> eList, int periods)
        {
            this.withHoldDic = wDic;
            this.EmpList = eList;
            this.numPeriods = periods;
        }

        public double CalcSSNTax(int period)
        {
            double ssnTax = 0;

            for (int i = 0; i < EmpList.Count; i++)
                ssnTax += EmpList[i].CalcSSNTax(numPeriods, period);

            return Math.Round(ssnTax, 2);
        }

        public double CalcMediTax(int period)
        {
            double medTax = 0;

            for (int i = 0; i < EmpList.Count; i++)
                medTax += EmpList[i].CalcMedTax(numPeriods, period);

            return Math.Round(medTax, 2);
        }

        public double CalcFedTax(int period)
        {
            double fedTax = 0;

            for (int i = 0; i < EmpList.Count; i++)
                fedTax += EmpList[i].CalcFedTax(numPeriods, withHoldDic, period);

            return Math.Round(fedTax, 2);
        }

        public double CalcStateTax(int period)
        {
            double stateTax = 0;

            for (int i = 0; i < EmpList.Count; i++)
                stateTax += EmpList[i].CalcStateTax(numPeriods, period);

            return Math.Round(stateTax, 2);
        }

        public double MonthlyFedWitholding(int period)
        {
            double monthlyFedWithold = 0;
            double ssnTax = CalcSSNTax(period);
            double medTax = CalcMediTax(period);
            double fedTax = CalcFedTax(period);
            monthlyFedWithold = (2 * ssnTax) + (2 * medTax) + fedTax;
            return monthlyFedWithold;
        }


    }
}
