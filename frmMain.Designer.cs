
namespace Payroll
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tosMain = new System.Windows.Forms.ToolStrip();
            this.tosbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tosbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tosbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tosbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tosbtnCalculate = new System.Windows.Forms.ToolStripButton();
            this.dgvEmployeeData = new System.Windows.Forms.DataGridView();
            this.sstripMain = new System.Windows.Forms.StatusStrip();
            this.toslblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tosStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tosMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeData)).BeginInit();
            this.sstripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tosMain
            // 
            this.tosMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tosMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tosbtnAdd,
            this.tosbtnDelete,
            this.tosbtnEdit,
            this.tosbtnSave,
            this.tosbtnCalculate});
            this.tosMain.Location = new System.Drawing.Point(0, 0);
            this.tosMain.Name = "tosMain";
            this.tosMain.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tosMain.Size = new System.Drawing.Size(898, 33);
            this.tosMain.TabIndex = 0;
            this.tosMain.Text = "toolStrip1";
            // 
            // tosbtnAdd
            // 
            this.tosbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnAdd.Image")));
            this.tosbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnAdd.Name = "tosbtnAdd";
            this.tosbtnAdd.Size = new System.Drawing.Size(34, 28);
            this.tosbtnAdd.Text = "toolStripButton1";
            this.tosbtnAdd.Click += new System.EventHandler(this.tosbtnAdd_Click);
            // 
            // tosbtnDelete
            // 
            this.tosbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnDelete.Image")));
            this.tosbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnDelete.Name = "tosbtnDelete";
            this.tosbtnDelete.Size = new System.Drawing.Size(34, 28);
            this.tosbtnDelete.Text = "Delete";
            this.tosbtnDelete.Click += new System.EventHandler(this.tosbtnDelete_Click);
            // 
            // tosbtnEdit
            // 
            this.tosbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnEdit.Image")));
            this.tosbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnEdit.Name = "tosbtnEdit";
            this.tosbtnEdit.Size = new System.Drawing.Size(34, 28);
            this.tosbtnEdit.Text = "Edit Employee";
            this.tosbtnEdit.Click += new System.EventHandler(this.tosbtnEdit_Click);
            // 
            // tosbtnSave
            // 
            this.tosbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnSave.Image")));
            this.tosbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnSave.Name = "tosbtnSave";
            this.tosbtnSave.Size = new System.Drawing.Size(34, 28);
            this.tosbtnSave.Text = "Save";
            this.tosbtnSave.Click += new System.EventHandler(this.tosbtnSave_Click);
            // 
            // tosbtnCalculate
            // 
            this.tosbtnCalculate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnCalculate.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnCalculate.Image")));
            this.tosbtnCalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnCalculate.Name = "tosbtnCalculate";
            this.tosbtnCalculate.Size = new System.Drawing.Size(34, 28);
            this.tosbtnCalculate.Text = "Calculate Taxes";
            this.tosbtnCalculate.Click += new System.EventHandler(this.tosbtnCalculate_Click);
            // 
            // dgvEmployeeData
            // 
            this.dgvEmployeeData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployeeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeData.Location = new System.Drawing.Point(28, 68);
            this.dgvEmployeeData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvEmployeeData.Name = "dgvEmployeeData";
            this.dgvEmployeeData.RowHeadersWidth = 62;
            this.dgvEmployeeData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeData.Size = new System.Drawing.Size(840, 302);
            this.dgvEmployeeData.TabIndex = 1;
            this.dgvEmployeeData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployeeData_CellEndEdit);
            this.dgvEmployeeData.DoubleClick += new System.EventHandler(this.dgvEmployeeData_DoubleClick);
            // 
            // sstripMain
            // 
            this.sstripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.sstripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toslblMessage,
            this.tosStatus});
            this.sstripMain.Location = new System.Drawing.Point(0, 398);
            this.sstripMain.Name = "sstripMain";
            this.sstripMain.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.sstripMain.Size = new System.Drawing.Size(898, 22);
            this.sstripMain.TabIndex = 2;
            this.sstripMain.Text = "statusStrip1";
            // 
            // toslblMessage
            // 
            this.toslblMessage.Name = "toslblMessage";
            this.toslblMessage.Size = new System.Drawing.Size(0, 15);
            // 
            // tosStatus
            // 
            this.tosStatus.Name = "tosStatus";
            this.tosStatus.Size = new System.Drawing.Size(0, 15);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 420);
            this.Controls.Add(this.sstripMain);
            this.Controls.Add(this.dgvEmployeeData);
            this.Controls.Add(this.tosMain);
            this.Name = "frmMain";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tosMain.ResumeLayout(false);
            this.tosMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeData)).EndInit();
            this.sstripMain.ResumeLayout(false);
            this.sstripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tosMain;
        private System.Windows.Forms.ToolStripButton tosbtnAdd;
        private System.Windows.Forms.DataGridView dgvEmployeeData;
        private System.Windows.Forms.StatusStrip sstripMain;
        private System.Windows.Forms.ToolStripStatusLabel toslblMessage;
        private System.Windows.Forms.ToolStripButton tosbtnDelete;
        private System.Windows.Forms.ToolStripButton tosbtnEdit;
        private System.Windows.Forms.ToolStripButton tosbtnSave;
        private System.Windows.Forms.ToolStripButton tosbtnCalculate;
        private System.Windows.Forms.ToolStripStatusLabel tosStatus;
    }
}

