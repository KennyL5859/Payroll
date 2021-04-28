using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class WithholdTable
    {
        public double[,] rates { get; set; }  


        public WithholdTable(double[,] fedRates)
        {
            this.rates = fedRates;
        }
    }
}
