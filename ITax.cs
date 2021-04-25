using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    interface ITax
    {
        double salaryPerPeriod(int periods);
    }
}
