
namespace Payroll
{
    partial class frmCalculate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalculate));
            this.tosMain = new System.Windows.Forms.ToolStrip();
            this.tosbtnCalculate = new System.Windows.Forms.ToolStripButton();
            this.tosbtnExcel = new System.Windows.Forms.ToolStripButton();
            this.tosddbtnPDF = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblPayPeriod = new System.Windows.Forms.Label();
            this.lblQuarter = new System.Windows.Forms.Label();
            this.ddlEmployees = new System.Windows.Forms.ComboBox();
            this.ddlPayPeriod = new System.Windows.Forms.ComboBox();
            this.ddlQuarter = new System.Windows.Forms.ComboBox();
            this.radWeekly = new System.Windows.Forms.RadioButton();
            this.radBiWeekly = new System.Windows.Forms.RadioButton();
            this.radMonthly = new System.Windows.Forms.RadioButton();
            this.lblPayFreq = new System.Windows.Forms.Label();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.tosMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tosMain
            // 
            this.tosMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tosMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tosbtnCalculate,
            this.tosbtnExcel,
            this.tosddbtnPDF});
            this.tosMain.Location = new System.Drawing.Point(0, 0);
            this.tosMain.Name = "tosMain";
            this.tosMain.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tosMain.Size = new System.Drawing.Size(836, 33);
            this.tosMain.TabIndex = 0;
            this.tosMain.Text = "toolStrip1";
            // 
            // tosbtnCalculate
            // 
            this.tosbtnCalculate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnCalculate.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnCalculate.Image")));
            this.tosbtnCalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnCalculate.Name = "tosbtnCalculate";
            this.tosbtnCalculate.Size = new System.Drawing.Size(34, 28);
            this.tosbtnCalculate.Text = "Calculate";
            this.tosbtnCalculate.Click += new System.EventHandler(this.tosbtnCalculate_Click);
            // 
            // tosbtnExcel
            // 
            this.tosbtnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnExcel.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnExcel.Image")));
            this.tosbtnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnExcel.Name = "tosbtnExcel";
            this.tosbtnExcel.Size = new System.Drawing.Size(34, 33);
            this.tosbtnExcel.Text = "Export to Excel";
            this.tosbtnExcel.Click += new System.EventHandler(this.tosbtnExcel_Click);
            // 
            // tosddbtnPDF
            // 
            this.tosddbtnPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosddbtnPDF.Image = ((System.Drawing.Image)(resources.GetObject("tosddbtnPDF.Image")));
            this.tosddbtnPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosddbtnPDF.Name = "tosddbtnPDF";
            this.tosddbtnPDF.Size = new System.Drawing.Size(42, 33);
            this.tosddbtnPDF.Text = "toolStripDropDownButton1";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(45, 63);
            this.lblEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(105, 25);
            this.lblEmployee.TabIndex = 1;
            this.lblEmployee.Text = "Employee:";
            // 
            // lblPayPeriod
            // 
            this.lblPayPeriod.AutoSize = true;
            this.lblPayPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayPeriod.Location = new System.Drawing.Point(45, 122);
            this.lblPayPeriod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPayPeriod.Name = "lblPayPeriod";
            this.lblPayPeriod.Size = new System.Drawing.Size(113, 25);
            this.lblPayPeriod.TabIndex = 2;
            this.lblPayPeriod.Text = "Pay Period:";
            // 
            // lblQuarter
            // 
            this.lblQuarter.AutoSize = true;
            this.lblQuarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuarter.Location = new System.Drawing.Point(45, 180);
            this.lblQuarter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuarter.Name = "lblQuarter";
            this.lblQuarter.Size = new System.Drawing.Size(84, 25);
            this.lblQuarter.TabIndex = 3;
            this.lblQuarter.Text = "Quarter:";
            // 
            // ddlEmployees
            // 
            this.ddlEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlEmployees.FormattingEnabled = true;
            this.ddlEmployees.Location = new System.Drawing.Point(194, 58);
            this.ddlEmployees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlEmployees.Name = "ddlEmployees";
            this.ddlEmployees.Size = new System.Drawing.Size(222, 33);
            this.ddlEmployees.TabIndex = 4;
            // 
            // ddlPayPeriod
            // 
            this.ddlPayPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPayPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPayPeriod.FormattingEnabled = true;
            this.ddlPayPeriod.Location = new System.Drawing.Point(194, 117);
            this.ddlPayPeriod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlPayPeriod.Name = "ddlPayPeriod";
            this.ddlPayPeriod.Size = new System.Drawing.Size(58, 33);
            this.ddlPayPeriod.TabIndex = 5;
            // 
            // ddlQuarter
            // 
            this.ddlQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlQuarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlQuarter.FormattingEnabled = true;
            this.ddlQuarter.Location = new System.Drawing.Point(194, 175);
            this.ddlQuarter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlQuarter.Name = "ddlQuarter";
            this.ddlQuarter.Size = new System.Drawing.Size(58, 33);
            this.ddlQuarter.TabIndex = 6;
            // 
            // radWeekly
            // 
            this.radWeekly.AutoSize = true;
            this.radWeekly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWeekly.Location = new System.Drawing.Point(574, 115);
            this.radWeekly.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radWeekly.Name = "radWeekly";
            this.radWeekly.Size = new System.Drawing.Size(103, 29);
            this.radWeekly.TabIndex = 7;
            this.radWeekly.Text = "Weekly";
            this.radWeekly.UseVisualStyleBackColor = true;
            this.radWeekly.CheckedChanged += new System.EventHandler(this.radMonthly_CheckedChanged);
            // 
            // radBiWeekly
            // 
            this.radBiWeekly.AutoSize = true;
            this.radBiWeekly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBiWeekly.Location = new System.Drawing.Point(470, 183);
            this.radBiWeekly.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radBiWeekly.Name = "radBiWeekly";
            this.radBiWeekly.Size = new System.Drawing.Size(127, 29);
            this.radBiWeekly.TabIndex = 8;
            this.radBiWeekly.Text = "Bi-Weekly";
            this.radBiWeekly.UseVisualStyleBackColor = true;
            this.radBiWeekly.CheckedChanged += new System.EventHandler(this.radMonthly_CheckedChanged);
            // 
            // radMonthly
            // 
            this.radMonthly.AutoSize = true;
            this.radMonthly.Checked = true;
            this.radMonthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMonthly.Location = new System.Drawing.Point(681, 183);
            this.radMonthly.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radMonthly.Name = "radMonthly";
            this.radMonthly.Size = new System.Drawing.Size(106, 29);
            this.radMonthly.TabIndex = 9;
            this.radMonthly.TabStop = true;
            this.radMonthly.Text = "Monthly";
            this.radMonthly.UseVisualStyleBackColor = true;
            this.radMonthly.CheckedChanged += new System.EventHandler(this.radMonthly_CheckedChanged);
            // 
            // lblPayFreq
            // 
            this.lblPayFreq.AutoSize = true;
            this.lblPayFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayFreq.Location = new System.Drawing.Point(552, 58);
            this.lblPayFreq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPayFreq.Name = "lblPayFreq";
            this.lblPayFreq.Size = new System.Drawing.Size(164, 25);
            this.lblPayFreq.TabIndex = 10;
            this.lblPayFreq.Text = "Pay Frequency:";
            // 
            // lstResults
            // 
            this.lstResults.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 28;
            this.lstResults.Location = new System.Drawing.Point(50, 248);
            this.lstResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(738, 424);
            this.lstResults.TabIndex = 11;
            // 
            // frmCalculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 703);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.lblPayFreq);
            this.Controls.Add(this.radMonthly);
            this.Controls.Add(this.radBiWeekly);
            this.Controls.Add(this.radWeekly);
            this.Controls.Add(this.ddlQuarter);
            this.Controls.Add(this.ddlPayPeriod);
            this.Controls.Add(this.ddlEmployees);
            this.Controls.Add(this.lblQuarter);
            this.Controls.Add(this.lblPayPeriod);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.tosMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCalculate";
            this.Text = "frmCalculate";
            this.Load += new System.EventHandler(this.frmCalculate_Load);
            this.tosMain.ResumeLayout(false);
            this.tosMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tosMain;
        private System.Windows.Forms.ToolStripButton tosbtnCalculate;
        private System.Windows.Forms.ToolStripButton tosbtnExcel;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblPayPeriod;
        private System.Windows.Forms.Label lblQuarter;
        private System.Windows.Forms.ComboBox ddlEmployees;
        private System.Windows.Forms.ComboBox ddlPayPeriod;
        private System.Windows.Forms.ComboBox ddlQuarter;
        private System.Windows.Forms.RadioButton radWeekly;
        private System.Windows.Forms.RadioButton radBiWeekly;
        private System.Windows.Forms.RadioButton radMonthly;
        private System.Windows.Forms.Label lblPayFreq;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.ToolStripDropDownButton tosddbtnPDF;
    }
}