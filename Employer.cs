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

        private double stateTaxableLimit = 12960;
        private double stateTaxableRate = 0.00675;


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

        public Dictionary<string, List<double>> CalcQuarterlyStateWages(int quarter)
        {
            Dictionary<string, List<double>> quarterDic = new Dictionary<string, List<double>>();

            Dictionary<int, int[]> monthlyDic = new Dictionary<int, int[]>();
            monthlyDic.Add(1, new int[] { 1, 3 });
            monthlyDic.Add(2, new int[] { 4, 6 });
            monthlyDic.Add(3, new int[] { 7, 9 });
            monthlyDic.Add(4, new int[] { 10, 12 });

            Dictionary<int, int[]> semiMonthlyDic = new Dictionary<int, int[]>();
            semiMonthlyDic.Add(1, new int[] { 1, 6 });
            semiMonthlyDic.Add(2, new int[] { 7, 13 });
            semiMonthlyDic.Add(3, new int[] { 14, 20 });
            semiMonthlyDic.Add(4, new int[] { 21, 26 });

            Dictionary<int, int[]> weeklyDic = new Dictionary<int, int[]>();
            weeklyDic.Add(1, new int[] { 1, 13 });
            weeklyDic.Add(2, new int[] { 14, 26 });
            weeklyDic.Add(3, new int[] { 27, 39 });
            weeklyDic.Add(4, new int[] { 40, 52 });

            int[] periodRange = new int[2];

            if (numPeriods == 12)            
                periodRange = monthlyDic[quarter];            
            else if (numPeriods == 26)            
                periodRange = semiMonthlyDic[quarter];            
            else if (numPeriods == 52)            
                periodRange = weeklyDic[quarter];

            int beginP = periodRange[0];
            int endP = periodRange[1];
            
            for (int i = 0; i < EmpList.Count; i++)
            {
                string name = EmpList[i].firstName + " " + EmpList[i].lastName;
                double quarterSal = EmpList[i].CalcQuarterlySalary(numPeriods, beginP, endP);
                double totalSal = EmpList[i].CalcQuarterlySalary(numPeriods, 1, endP);

                double excessSal = 0;
                double taxableSal = 0;

                if (totalSal > this.stateTaxableLimit)
                    excessSal = totalSal - this.stateTaxableLimit;

                if (excessSal < quarterSal)
                    taxableSal = quarterSal - excessSal;
                else
                    excessSal = quarterSal;

                double taxDue = taxableSal * this.stateTaxableRate;

                List<double> salList = new List<double>();
                salList.AddRange(new List<double> {Math.Round(totalSal, 2), 
                    Math.Round(quarterSal, 2), Math.Round(excessSal, 2), Math.Round(taxableSal, 2), 
                    Math.Round(taxDue, 2)});
                quarterDic.Add(name, salList);
            }

            return quarterDic;
        }

    }
}
