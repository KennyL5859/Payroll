
namespace Payroll
{
    partial class frmAddEditEmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditEmp));
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.tosStripMenu = new System.Windows.Forms.ToolStrip();
            this.tosbtnSave = new System.Windows.Forms.ToolStripButton();
            this.lblSSN = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblZipCode = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblExtraFed = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblExtraState = new System.Windows.Forms.Label();
            this.mstFirstName = new System.Windows.Forms.MaskedTextBox();
            this.mstLastName = new System.Windows.Forms.MaskedTextBox();
            this.mstSSN = new System.Windows.Forms.MaskedTextBox();
            this.mstDob = new System.Windows.Forms.MaskedTextBox();
            this.mstStreet = new System.Windows.Forms.MaskedTextBox();
            this.mstCity = new System.Windows.Forms.MaskedTextBox();
            this.mstZipCode = new System.Windows.Forms.MaskedTextBox();
            this.mstState = new System.Windows.Forms.MaskedTextBox();
            this.mstSalary = new System.Windows.Forms.MaskedTextBox();
            this.mstXFed = new System.Windows.Forms.MaskedTextBox();
            this.mstXState = new System.Windows.Forms.MaskedTextBox();
            this.lblDependents = new System.Windows.Forms.Label();
            this.lblOtherDep = new System.Windows.Forms.Label();
            this.ddlChildDep = new System.Windows.Forms.ComboBox();
            this.ddlOtherDep = new System.Windows.Forms.ComboBox();
            this.lblFilingStatus = new System.Windows.Forms.Label();
            this.radSingle = new System.Windows.Forms.RadioButton();
            this.radHOH = new System.Windows.Forms.RadioButton();
            this.radMFJ = new System.Windows.Forms.RadioButton();
            this.radMFS = new System.Windows.Forms.RadioButton();
            this.lblMultipleJobs = new System.Windows.Forms.Label();
            this.chkMultiple = new System.Windows.Forms.CheckBox();
            this.lblWithholding = new System.Windows.Forms.Label();
            this.ddlWithholding = new System.Windows.Forms.ComboBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.tosStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(38, 51);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(112, 25);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(38, 103);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(112, 25);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name:";
            // 
            // tosStripMenu
            // 
            this.tosStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tosStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tosbtnSave});
            this.tosStripMenu.Location = new System.Drawing.Point(0, 0);
            this.tosStripMenu.Name = "tosStripMenu";
            this.tosStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tosStripMenu.Size = new System.Drawing.Size(884, 33);
            this.tosStripMenu.TabIndex = 2;
            this.tosStripMenu.Text = "toolStrip1";
            // 
            // tosbtnSave
            // 
            this.tosbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tosbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tosbtnSave.Image")));
            this.tosbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tosbtnSave.Name = "tosbtnSave";
            this.tosbtnSave.Size = new System.Drawing.Size(34, 28);
            this.tosbtnSave.Text = "Save ";
            // 
            // lblSSN
            // 
            this.lblSSN.AutoSize = true;
            this.lblSSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSN.Location = new System.Drawing.Point(38, 155);
            this.lblSSN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSSN.Name = "lblSSN";
            this.lblSSN.Size = new System.Drawing.Size(60, 25);
            this.lblSSN.TabIndex = 3;
            this.lblSSN.Text = "SSN:";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreet.Location = new System.Drawing.Point(38, 260);
            this.lblStreet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(70, 25);
            this.lblStreet.TabIndex = 4;
            this.lblStreet.Text = "Street:";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(38, 208);
            this.lblDOB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(61, 25);
            this.lblDOB.TabIndex = 5;
            this.lblDOB.Text = "DOB:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(38, 312);
            this.lblCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(52, 25);
            this.lblCity.TabIndex = 6;
            this.lblCity.Text = "City:";
            // 
            // lblZipCode
            // 
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZipCode.Location = new System.Drawing.Point(38, 365);
            this.lblZipCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(98, 25);
            this.lblZipCode.TabIndex = 7;
            this.lblZipCode.Text = "Zip Code:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(38, 417);
            this.lblState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(64, 25);
            this.lblState.TabIndex = 8;
            this.lblState.Text = "State:";
            // 
            // lblExtraFed
            // 
            this.lblExtraFed.AutoSize = true;
            this.lblExtraFed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtraFed.Location = new System.Drawing.Point(38, 522);
            this.lblExtraFed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtraFed.Name = "lblExtraFed";
            this.lblExtraFed.Size = new System.Drawing.Size(102, 25);
            this.lblExtraFed.TabIndex = 9;
            this.lblExtraFed.Text = "Extra Fed:";
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.Location = new System.Drawing.Point(38, 469);
            this.lblSalary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(74, 25);
            this.lblSalary.TabIndex = 10;
            this.lblSalary.Text = "Salary:";
            // 
            // lblExtraState
            // 
            this.lblExtraState.AutoSize = true;
            this.lblExtraState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtraState.Location = new System.Drawing.Point(38, 574);
            this.lblExtraState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtraState.Name = "lblExtraState";
            this.lblExtraState.Size = new System.Drawing.Size(114, 25);
            this.lblExtraState.TabIndex = 11;
            this.lblExtraState.Text = "Extra State:";
            // 
            // mstFirstName
            // 
            this.mstFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstFirstName.Location = new System.Drawing.Point(192, 46);
            this.mstFirstName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mstFirstName.Mask = "???????????????????";
            this.mstFirstName.Name = "mstFirstName";
            this.mstFirstName.Size = new System.Drawing.Size(182, 30);
            this.mstFirstName.TabIndex = 12;
            // 
            // mstLastName
            // 
            this.mstLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstLastName.Location = new System.Drawing.Point(192, 98);
            this.mstLastName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mstLastName.Mask = "???????????????????";
            this.mstLastName.Name = "mstLastName";
            this.mstLastName.Size = new System.Drawing.Size(182, 30);
            this.mstLastName.TabIndex = 13;
            // 
            // mstSSN
            // 
            this.mstSSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstSSN.Location = new System.Drawing.Point(192, 151);
            this.mstSSN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mstSSN.Mask = "000-00-0000";
            this.mstSSN.Name = "mstSSN";
            this.mstSSN.Size = new System.Drawing.Size(116, 30);
            this.mstSSN.TabIndex = 14;
            // 
            // mstDob
            // 
            this.mstDob.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstDob.Location = new System.Drawing.Point(192, 203);
            this.mstDob.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mstDob.Mask = "00/00/0000";
            this.mstDob.Name = "mstDob";
            this.mstDob.Size = new System.Drawing.Size(103, 30);
            this.mstDob.TabIndex = 15;
            this.mstDob.ValidatingType = typeof(System.DateTime);
            // 
            // mstStreet
            // 
            this.mstStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstStreet.Location = new System.Drawing.Point(194, 257);
            this.mstStreet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mstStreet.Mask = "??????????????????????";
            this.mstStreet.Name = "mstStreet";
            this.mstStreet.Size = new System.Drawing.Size(228, 30);
            this.mstStreet.TabIndex = 16;
            // 
            // mstCity
            // 
            this.mstCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstCity.Location = new System.Drawing.Point(192, 308);
            this.mstCity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mstCity.Mask = "???????????????????";
            this.mstCity.Name = "mstCity";
            this.mstCity.Size = new System.Drawing.Size(182, 30);
            this.mstCity.TabIndex = 17;
            // 
            // mstZipCode
            // 
            this.mstZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstZipCode.Location = new System.Drawing.Point(192, 355);
            this.mstZipCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mstZipCode.Mask = "00000";
            this.mstZipCode.Name = "mstZipCode";
            this.mstZipCode.Size = new System.Drawing.Size(64, 30);
            this.mstZipCode.TabIndex = 18;
            // 
            // mstState
            // 
            this.mstState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstState.Location = new System.Drawing.Point(194, 412);
            this.mstState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mstState.Mask = "LL";
            this.mstState.Name = "mstState";
            this.mstState.Size = new System.Drawing.Size(34, 30);
            this.mstState.TabIndex = 19;
            // 
            // mstSalary
            // 
            this.mstSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstSalary.Location = new System.Drawing.Point(192, 465);
            this.mstSalary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mstSalary.Mask = "999999";
            this.mstSalary.Name = "mstSalary";
            this.mstSalary.Size = new System.Drawing.Size(64, 30);
            this.mstSalary.TabIndex = 20;
            // 
            // mstXFed
            // 
            this.mstXFed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstXFed.Location = new System.Drawing.Point(192, 517);
            this.mstXFed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mstXFed.Mask = "9999";
            this.mstXFed.Name = "mstXFed";
            this.mstXFed.Size = new System.Drawing.Size(54, 30);
            this.mstXFed.TabIndex = 21;
            // 
            // mstXState
            // 
            this.mstXState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstXState.Location = new System.Drawing.Point(192, 569);
            this.mstXState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mstXState.Mask = "9999";
            this.mstXState.Name = "mstXState";
            this.mstXState.Size = new System.Drawing.Size(54, 30);
            this.mstXState.TabIndex = 22;
            // 
            // lblDependents
            // 
            this.lblDependents.AutoSize = true;
            this.lblDependents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDependents.Location = new System.Drawing.Point(471, 51);
            this.lblDependents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDependents.Name = "lblDependents";
            this.lblDependents.Size = new System.Drawing.Size(104, 25);
            this.lblDependents.TabIndex = 23;
            this.lblDependents.Text = "Child Dep:";
            // 
            // lblOtherDep
            // 
            this.lblOtherDep.AutoSize = true;
            this.lblOtherDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherDep.Location = new System.Drawing.Point(471, 103);
            this.lblOtherDep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOtherDep.Name = "lblOtherDep";
            this.lblOtherDep.Size = new System.Drawing.Size(108, 25);
            this.lblOtherDep.TabIndex = 24;
            this.lblOtherDep.Text = "Other Dep:";
            // 
            // ddlChildDep
            // 
            this.ddlChildDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlChildDep.FormattingEnabled = true;
            this.ddlChildDep.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.ddlChildDep.Location = new System.Drawing.Point(612, 49);
            this.ddlChildDep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlChildDep.Name = "ddlChildDep";
            this.ddlChildDep.Size = new System.Drawing.Size(79, 28);
            this.ddlChildDep.TabIndex = 25;
            // 
            // ddlOtherDep
            // 
            this.ddlOtherDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOtherDep.FormattingEnabled = true;
            this.ddlOtherDep.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.ddlOtherDep.Location = new System.Drawing.Point(612, 95);
            this.ddlOtherDep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlOtherDep.Name = "ddlOtherDep";
            this.ddlOtherDep.Size = new System.Drawing.Size(79, 28);
            this.ddlOtherDep.TabIndex = 26;
            // 
            // lblFilingStatus
            // 
            this.lblFilingStatus.AutoSize = true;
            this.lblFilingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilingStatus.Location = new System.Drawing.Point(471, 160);
            this.lblFilingStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilingStatus.Name = "lblFilingStatus";
            this.lblFilingStatus.Size = new System.Drawing.Size(125, 25);
            this.lblFilingStatus.TabIndex = 27;
            this.lblFilingStatus.Text = "Filing Status:";
            // 
            // radSingle
            // 
            this.radSingle.AutoSize = true;
            this.radSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSingle.Location = new System.Drawing.Point(612, 160);
            this.radSingle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radSingle.Name = "radSingle";
            this.radSingle.Size = new System.Drawing.Size(92, 29);
            this.radSingle.TabIndex = 28;
            this.radSingle.TabStop = true;
            this.radSingle.Text = "Single";
            this.radSingle.UseVisualStyleBackColor = true;
            // 
            // radHOH
            // 
            this.radHOH.AutoSize = true;
            this.radHOH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHOH.Location = new System.Drawing.Point(612, 225);
            this.radHOH.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radHOH.Name = "radHOH";
            this.radHOH.Size = new System.Drawing.Size(81, 29);
            this.radHOH.TabIndex = 29;
            this.radHOH.TabStop = true;
            this.radHOH.Text = "HOH";
            this.radHOH.UseVisualStyleBackColor = true;
            // 
            // radMFJ
            // 
            this.radMFJ.AutoSize = true;
            this.radMFJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMFJ.Location = new System.Drawing.Point(736, 160);
            this.radMFJ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radMFJ.Name = "radMFJ";
            this.radMFJ.Size = new System.Drawing.Size(77, 29);
            this.radMFJ.TabIndex = 30;
            this.radMFJ.TabStop = true;
            this.radMFJ.Text = "MFJ";
            this.radMFJ.UseVisualStyleBackColor = true;
            // 
            // radMFS
            // 
            this.radMFS.AutoSize = true;
            this.radMFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMFS.Location = new System.Drawing.Point(736, 225);
            this.radMFS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radMFS.Name = "radMFS";
            this.radMFS.Size = new System.Drawing.Size(80, 29);
            this.radMFS.TabIndex = 31;
            this.radMFS.TabStop = true;
            this.radMFS.Text = "MFS";
            this.radMFS.UseVisualStyleBackColor = true;
            // 
            // lblMultipleJobs
            // 
            this.lblMultipleJobs.AutoSize = true;
            this.lblMultipleJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultipleJobs.Location = new System.Drawing.Point(471, 289);
            this.lblMultipleJobs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMultipleJobs.Name = "lblMultipleJobs";
            this.lblMultipleJobs.Size = new System.Drawing.Size(133, 25);
            this.lblMultipleJobs.TabIndex = 32;
            this.lblMultipleJobs.Text = "Multiple Jobs:";
            // 
            // chkMultiple
            // 
            this.chkMultiple.AutoSize = true;
            this.chkMultiple.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMultiple.Location = new System.Drawing.Point(632, 288);
            this.chkMultiple.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkMultiple.Name = "chkMultiple";
            this.chkMultiple.Size = new System.Drawing.Size(72, 29);
            this.chkMultiple.TabIndex = 33;
            this.chkMultiple.Text = "Yes";
            this.chkMultiple.UseVisualStyleBackColor = true;
            // 
            // lblWithholding
            // 
            this.lblWithholding.AutoSize = true;
            this.lblWithholding.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWithholding.Location = new System.Drawing.Point(471, 365);
            this.lblWithholding.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWithholding.Name = "lblWithholding";
            this.lblWithholding.Size = new System.Drawing.Size(121, 25);
            this.lblWithholding.TabIndex = 34;
            this.lblWithholding.Text = "Withholding:";
            // 
            // ddlWithholding
            // 
            this.ddlWithholding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlWithholding.FormattingEnabled = true;
            this.ddlWithholding.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.ddlWithholding.Location = new System.Drawing.Point(612, 358);
            this.ddlWithholding.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlWithholding.Name = "ddlWithholding";
            this.ddlWithholding.Size = new System.Drawing.Size(79, 28);
            this.ddlWithholding.TabIndex = 35;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(471, 438);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(105, 25);
            this.lblStartDate.TabIndex = 36;
            this.lblStartDate.Text = "Start Date:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(471, 503);
            this.lblEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(99, 25);
            this.lblEndDate.TabIndex = 37;
            this.lblEndDate.Text = "End Date:";
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Location = new System.Drawing.Point(612, 438);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(250, 30);
            this.dtpStart.TabIndex = 38;
            this.dtpStart.Value = new System.DateTime(2021, 4, 23, 0, 0, 0, 0);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Location = new System.Drawing.Point(612, 495);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(250, 30);
            this.dtpEnd.TabIndex = 39;
            this.dtpEnd.Value = new System.DateTime(2021, 4, 23, 0, 0, 0, 0);
            // 
            // frmAddEditEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 618);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.ddlWithholding);
            this.Controls.Add(this.lblWithholding);
            this.Controls.Add(this.chkMultiple);
            this.Controls.Add(this.lblMultipleJobs);
            this.Controls.Add(this.radMFS);
            this.Controls.Add(this.radMFJ);
            this.Controls.Add(this.radHOH);
            this.Controls.Add(this.radSingle);
            this.Controls.Add(this.lblFilingStatus);
            this.Controls.Add(this.ddlOtherDep);
            this.Controls.Add(this.ddlChildDep);
            this.Controls.Add(this.lblOtherDep);
            this.Controls.Add(this.lblDependents);
            this.Controls.Add(this.mstXState);
            this.Controls.Add(this.mstXFed);
            this.Controls.Add(this.mstSalary);
            this.Controls.Add(this.mstState);
            this.Controls.Add(this.mstZipCode);
            this.Controls.Add(this.mstCity);
            this.Controls.Add(this.mstStreet);
            this.Controls.Add(this.mstDob);
            this.Controls.Add(this.mstSSN);
            this.Controls.Add(this.mstLastName);
            this.Controls.Add(this.mstFirstName);
            this.Controls.Add(this.lblExtraState);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.lblExtraFed);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblZipCode);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.lblSSN);
            this.Controls.Add(this.tosStripMenu);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddEditEmp";
            this.Text = "Add Employee";
            this.Load += new System.EventHandler(this.frmAddEditEmp_Load);
            this.tosStripMenu.ResumeLayout(false);
            this.tosStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.ToolStrip tosStripMenu;
        private System.Windows.Forms.ToolStripButton tosbtnSave;
        private System.Windows.Forms.Label lblSSN;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblZipCode;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblExtraFed;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Label lblExtraState;
        private System.Windows.Forms.MaskedTextBox mstFirstName;
        private System.Windows.Forms.MaskedTextBox mstLastName;
        private System.Windows.Forms.MaskedTextBox mstSSN;
        private System.Windows.Forms.MaskedTextBox mstDob;
        private System.Windows.Forms.MaskedTextBox mstStreet;
        private System.Windows.Forms.MaskedTextBox mstCity;
        private System.Windows.Forms.MaskedTextBox mstZipCode;
        private System.Windows.Forms.MaskedTextBox mstState;
        private System.Windows.Forms.MaskedTextBox mstSalary;
        private System.Windows.Forms.MaskedTextBox mstXFed;
        private System.Windows.Forms.MaskedTextBox mstXState;
        private System.Windows.Forms.Label lblDependents;
        private System.Windows.Forms.Label lblOtherDep;
        private System.Windows.Forms.ComboBox ddlChildDep;
        private System.Windows.Forms.ComboBox ddlOtherDep;
        private System.Windows.Forms.Label lblFilingStatus;
        private System.Windows.Forms.RadioButton radSingle;
        private System.Windows.Forms.RadioButton radHOH;
        private System.Windows.Forms.RadioButton radMFJ;
        private System.Windows.Forms.RadioButton radMFS;
        private System.Windows.Forms.Label lblMultipleJobs;
        private System.Windows.Forms.CheckBox chkMultiple;
        private System.Windows.Forms.Label lblWithholding;
        private System.Windows.Forms.ComboBox ddlWithholding;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
    }
}