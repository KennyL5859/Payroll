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


    }
}
