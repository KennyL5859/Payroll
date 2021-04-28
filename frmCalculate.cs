using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
    }
}
