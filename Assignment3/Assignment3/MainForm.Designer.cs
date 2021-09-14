
namespace Assignment3
{
    partial class MainForm
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
            this.calculator = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.grpGender = new System.Windows.Forms.GroupBox();
            this.optMale = new System.Windows.Forms.RadioButton();
            this.optFemale = new System.Windows.Forms.RadioButton();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtHeightImperialIn = new System.Windows.Forms.TextBox();
            this.txtWeightImperial = new System.Windows.Forms.TextBox();
            this.txtHeightImperialFt = new System.Windows.Forms.TextBox();
            this.txtWeightMetric = new System.Windows.Forms.TextBox();
            this.txtHeightMetric = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.lblBMICategory = new System.Windows.Forms.Label();
            this.lblBMIResult = new System.Windows.Forms.Label();
            this.lblWeightResult = new System.Windows.Forms.Label();
            this.lblBMI = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpUnit = new System.Windows.Forms.GroupBox();
            this.optImperial = new System.Windows.Forms.RadioButton();
            this.optMetric = new System.Windows.Forms.RadioButton();
            this.btnCalculateBMI = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCalculateBMR = new System.Windows.Forms.Button();
            this.lbBMRResults = new System.Windows.Forms.ListBox();
            this.grpActivityLevel = new System.Windows.Forms.GroupBox();
            this.optExtra = new System.Windows.Forms.RadioButton();
            this.optVery = new System.Windows.Forms.RadioButton();
            this.optModeratly = new System.Windows.Forms.RadioButton();
            this.optLightly = new System.Windows.Forms.RadioButton();
            this.optSedentary = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCalculateSaving = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAmountEarned = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.lblFinalBalance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.lblFees = new System.Windows.Forms.Label();
            this.txtGrowth = new System.Windows.Forms.TextBox();
            this.lblGrowth = new System.Windows.Forms.Label();
            this.txtInitialDeposit = new System.Windows.Forms.TextBox();
            this.lblInitialDeposit = new System.Windows.Forms.Label();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calculator.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.grpGender.SuspendLayout();
            this.grpResult.SuspendLayout();
            this.grpUnit.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grpActivityLevel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculator
            // 
            this.calculator.Controls.Add(this.tabPage1);
            this.calculator.Controls.Add(this.tabPage3);
            this.calculator.Controls.Add(this.tabPage2);
            this.calculator.Location = new System.Drawing.Point(0, 0);
            this.calculator.Name = "calculator";
            this.calculator.SelectedIndex = 0;
            this.calculator.Size = new System.Drawing.Size(788, 438);
            this.calculator.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(780, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BMI Calculator";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpGeneral);
            this.groupBox1.Controls.Add(this.grpResult);
            this.groupBox1.Controls.Add(this.grpUnit);
            this.groupBox1.Controls.Add(this.btnCalculateBMI);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 400);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BMI Calculator";
            // 
            // grpGeneral
            // 
            this.grpGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpGeneral.Controls.Add(this.grpGender);
            this.grpGeneral.Controls.Add(this.lblAge);
            this.grpGeneral.Controls.Add(this.txtAge);
            this.grpGeneral.Controls.Add(this.txtHeightImperialIn);
            this.grpGeneral.Controls.Add(this.txtWeightImperial);
            this.grpGeneral.Controls.Add(this.txtHeightImperialFt);
            this.grpGeneral.Controls.Add(this.txtWeightMetric);
            this.grpGeneral.Controls.Add(this.txtHeightMetric);
            this.grpGeneral.Controls.Add(this.txtName);
            this.grpGeneral.Controls.Add(this.lblHeight);
            this.grpGeneral.Controls.Add(this.lblWeight);
            this.grpGeneral.Controls.Add(this.label1);
            this.grpGeneral.Location = new System.Drawing.Point(6, 19);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(232, 200);
            this.grpGeneral.TabIndex = 9;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // grpGender
            // 
            this.grpGender.Controls.Add(this.optMale);
            this.grpGender.Controls.Add(this.optFemale);
            this.grpGender.Location = new System.Drawing.Point(9, 129);
            this.grpGender.Name = "grpGender";
            this.grpGender.Size = new System.Drawing.Size(220, 65);
            this.grpGender.TabIndex = 23;
            this.grpGender.TabStop = false;
            this.grpGender.Text = "Gender";
            this.grpGender.Visible = false;
            // 
            // optMale
            // 
            this.optMale.AutoSize = true;
            this.optMale.Location = new System.Drawing.Point(6, 42);
            this.optMale.Name = "optMale";
            this.optMale.Size = new System.Drawing.Size(48, 17);
            this.optMale.TabIndex = 1;
            this.optMale.TabStop = true;
            this.optMale.Text = "Male";
            this.optMale.UseVisualStyleBackColor = true;
            // 
            // optFemale
            // 
            this.optFemale.AutoSize = true;
            this.optFemale.Location = new System.Drawing.Point(6, 19);
            this.optFemale.Name = "optFemale";
            this.optFemale.Size = new System.Drawing.Size(59, 17);
            this.optFemale.TabIndex = 0;
            this.optFemale.TabStop = true;
            this.optFemale.Text = "Female";
            this.optFemale.UseVisualStyleBackColor = true;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(6, 105);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(26, 13);
            this.lblAge.TabIndex = 21;
            this.lblAge.Text = "Age";
            this.lblAge.Visible = false;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(72, 98);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(36, 20);
            this.txtAge.TabIndex = 22;
            this.txtAge.Visible = false;
            // 
            // txtHeightImperialIn
            // 
            this.txtHeightImperialIn.Location = new System.Drawing.Point(116, 46);
            this.txtHeightImperialIn.Name = "txtHeightImperialIn";
            this.txtHeightImperialIn.Size = new System.Drawing.Size(35, 20);
            this.txtHeightImperialIn.TabIndex = 20;
            // 
            // txtWeightImperial
            // 
            this.txtWeightImperial.Location = new System.Drawing.Point(73, 72);
            this.txtWeightImperial.Name = "txtWeightImperial";
            this.txtWeightImperial.Size = new System.Drawing.Size(35, 20);
            this.txtWeightImperial.TabIndex = 19;
            // 
            // txtHeightImperialFt
            // 
            this.txtHeightImperialFt.Location = new System.Drawing.Point(73, 46);
            this.txtHeightImperialFt.Name = "txtHeightImperialFt";
            this.txtHeightImperialFt.Size = new System.Drawing.Size(35, 20);
            this.txtHeightImperialFt.TabIndex = 18;
            // 
            // txtWeightMetric
            // 
            this.txtWeightMetric.Location = new System.Drawing.Point(73, 72);
            this.txtWeightMetric.Name = "txtWeightMetric";
            this.txtWeightMetric.Size = new System.Drawing.Size(35, 20);
            this.txtWeightMetric.TabIndex = 17;
            // 
            // txtHeightMetric
            // 
            this.txtHeightMetric.Location = new System.Drawing.Point(73, 46);
            this.txtHeightMetric.Name = "txtHeightMetric";
            this.txtHeightMetric.Size = new System.Drawing.Size(35, 20);
            this.txtHeightMetric.TabIndex = 16;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(73, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 20);
            this.txtName.TabIndex = 15;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(1, 49);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(61, 13);
            this.lblHeight.TabIndex = 14;
            this.lblHeight.Text = "Height (cm)";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(1, 79);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(62, 13);
            this.lblWeight.TabIndex = 13;
            this.lblWeight.Text = "Weight (kg)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.lblBMICategory);
            this.grpResult.Controls.Add(this.lblBMIResult);
            this.grpResult.Controls.Add(this.lblWeightResult);
            this.grpResult.Controls.Add(this.lblBMI);
            this.grpResult.Controls.Add(this.label4);
            this.grpResult.Controls.Add(this.label5);
            this.grpResult.Location = new System.Drawing.Point(7, 252);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(502, 151);
            this.grpResult.TabIndex = 8;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Results for: ";
            // 
            // lblBMICategory
            // 
            this.lblBMICategory.AutoSize = true;
            this.lblBMICategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBMICategory.Location = new System.Drawing.Point(101, 60);
            this.lblBMICategory.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblBMICategory.Name = "lblBMICategory";
            this.lblBMICategory.Size = new System.Drawing.Size(100, 15);
            this.lblBMICategory.TabIndex = 16;
            this.lblBMICategory.Text = "This will be result...";
            // 
            // lblBMIResult
            // 
            this.lblBMIResult.AutoSize = true;
            this.lblBMIResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBMIResult.Location = new System.Drawing.Point(101, 31);
            this.lblBMIResult.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblBMIResult.Name = "lblBMIResult";
            this.lblBMIResult.Size = new System.Drawing.Size(100, 15);
            this.lblBMIResult.TabIndex = 15;
            this.lblBMIResult.Text = "25.00";
            // 
            // lblWeightResult
            // 
            this.lblWeightResult.AutoSize = true;
            this.lblWeightResult.Location = new System.Drawing.Point(98, 127);
            this.lblWeightResult.Name = "lblWeightResult";
            this.lblWeightResult.Size = new System.Drawing.Size(233, 13);
            this.lblWeightResult.TabIndex = 14;
            this.lblWeightResult.Text = "Normal weight should be between 50 and 68 kg";
            // 
            // lblBMI
            // 
            this.lblBMI.AutoSize = true;
            this.lblBMI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblBMI.Location = new System.Drawing.Point(98, 98);
            this.lblBMI.Name = "lblBMI";
            this.lblBMI.Size = new System.Drawing.Size(191, 13);
            this.lblBMI.TabIndex = 13;
            this.lblBMI.Text = "Normal BMI is between 18.50 and 24.9";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Weight category";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "BMI";
            // 
            // grpUnit
            // 
            this.grpUnit.Controls.Add(this.optImperial);
            this.grpUnit.Controls.Add(this.optMetric);
            this.grpUnit.Location = new System.Drawing.Point(244, 19);
            this.grpUnit.Name = "grpUnit";
            this.grpUnit.Size = new System.Drawing.Size(203, 104);
            this.grpUnit.TabIndex = 1;
            this.grpUnit.TabStop = false;
            this.grpUnit.Text = "Unit";
            // 
            // optImperial
            // 
            this.optImperial.AutoSize = true;
            this.optImperial.Location = new System.Drawing.Point(19, 55);
            this.optImperial.Name = "optImperial";
            this.optImperial.Size = new System.Drawing.Size(95, 17);
            this.optImperial.TabIndex = 1;
            this.optImperial.TabStop = true;
            this.optImperial.Text = "Imperial (ft, lbs)";
            this.optImperial.UseVisualStyleBackColor = true;
            this.optImperial.CheckedChanged += new System.EventHandler(this.optImperial_CheckedChanged);
            // 
            // optMetric
            // 
            this.optMetric.AutoSize = true;
            this.optMetric.Location = new System.Drawing.Point(19, 32);
            this.optMetric.Name = "optMetric";
            this.optMetric.Size = new System.Drawing.Size(95, 17);
            this.optMetric.TabIndex = 0;
            this.optMetric.TabStop = true;
            this.optMetric.Text = "Metric (kg, cm)";
            this.optMetric.UseVisualStyleBackColor = true;
            this.optMetric.CheckedChanged += new System.EventHandler(this.optMetric_CheckedChanged);
            // 
            // btnCalculateBMI
            // 
            this.btnCalculateBMI.Location = new System.Drawing.Point(6, 225);
            this.btnCalculateBMI.Name = "btnCalculateBMI";
            this.btnCalculateBMI.Size = new System.Drawing.Size(175, 21);
            this.btnCalculateBMI.TabIndex = 0;
            this.btnCalculateBMI.Text = "Calculate BMI";
            this.btnCalculateBMI.UseVisualStyleBackColor = true;
            this.btnCalculateBMI.Click += new System.EventHandler(this.btnCalculateBMI_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCalculateBMR);
            this.tabPage3.Controls.Add(this.lbBMRResults);
            this.tabPage3.Controls.Add(this.grpActivityLevel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(780, 412);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "BMR Calculator";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCalculateBMR
            // 
            this.btnCalculateBMR.Location = new System.Drawing.Point(8, 372);
            this.btnCalculateBMR.Name = "btnCalculateBMR";
            this.btnCalculateBMR.Size = new System.Drawing.Size(117, 25);
            this.btnCalculateBMR.TabIndex = 24;
            this.btnCalculateBMR.Text = "Calculate BMR";
            this.btnCalculateBMR.UseVisualStyleBackColor = true;
            this.btnCalculateBMR.Click += new System.EventHandler(this.btnCalculateBMR_Click);
            // 
            // lbBMRResults
            // 
            this.lbBMRResults.FormattingEnabled = true;
            this.lbBMRResults.Location = new System.Drawing.Point(448, 23);
            this.lbBMRResults.Name = "lbBMRResults";
            this.lbBMRResults.Size = new System.Drawing.Size(300, 342);
            this.lbBMRResults.TabIndex = 23;
            // 
            // grpActivityLevel
            // 
            this.grpActivityLevel.Controls.Add(this.optExtra);
            this.grpActivityLevel.Controls.Add(this.optVery);
            this.grpActivityLevel.Controls.Add(this.optModeratly);
            this.grpActivityLevel.Controls.Add(this.optLightly);
            this.grpActivityLevel.Controls.Add(this.optSedentary);
            this.grpActivityLevel.Location = new System.Drawing.Point(8, 222);
            this.grpActivityLevel.Name = "grpActivityLevel";
            this.grpActivityLevel.Size = new System.Drawing.Size(418, 144);
            this.grpActivityLevel.TabIndex = 22;
            this.grpActivityLevel.TabStop = false;
            this.grpActivityLevel.Text = "Weekly activity level";
            // 
            // optExtra
            // 
            this.optExtra.AutoSize = true;
            this.optExtra.Location = new System.Drawing.Point(10, 111);
            this.optExtra.Name = "optExtra";
            this.optExtra.Size = new System.Drawing.Size(81, 17);
            this.optExtra.TabIndex = 4;
            this.optExtra.TabStop = true;
            this.optExtra.Text = "Extra active";
            this.optExtra.UseVisualStyleBackColor = true;
            // 
            // optVery
            // 
            this.optVery.AutoSize = true;
            this.optVery.Location = new System.Drawing.Point(10, 88);
            this.optVery.Name = "optVery";
            this.optVery.Size = new System.Drawing.Size(81, 17);
            this.optVery.TabIndex = 3;
            this.optVery.TabStop = true;
            this.optVery.Text = "Very active ";
            this.optVery.UseVisualStyleBackColor = true;
            // 
            // optModeratly
            // 
            this.optModeratly.AutoSize = true;
            this.optModeratly.Location = new System.Drawing.Point(10, 65);
            this.optModeratly.Name = "optModeratly";
            this.optModeratly.Size = new System.Drawing.Size(103, 17);
            this.optModeratly.TabIndex = 2;
            this.optModeratly.TabStop = true;
            this.optModeratly.Text = "Moderatly active";
            this.optModeratly.UseVisualStyleBackColor = true;
            // 
            // optLightly
            // 
            this.optLightly.AutoSize = true;
            this.optLightly.Location = new System.Drawing.Point(10, 42);
            this.optLightly.Name = "optLightly";
            this.optLightly.Size = new System.Drawing.Size(87, 17);
            this.optLightly.TabIndex = 1;
            this.optLightly.TabStop = true;
            this.optLightly.Text = "Ligthly active";
            this.optLightly.UseVisualStyleBackColor = true;
            // 
            // optSedentary
            // 
            this.optSedentary.AutoSize = true;
            this.optSedentary.Checked = true;
            this.optSedentary.Location = new System.Drawing.Point(10, 19);
            this.optSedentary.Name = "optSedentary";
            this.optSedentary.Size = new System.Drawing.Size(116, 17);
            this.optSedentary.TabIndex = 0;
            this.optSedentary.TabStop = true;
            this.optSedentary.Text = "Little or no exercise";
            this.optSedentary.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCalculateSaving);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(780, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Savings Calculator";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCalculateSaving
            // 
            this.btnCalculateSaving.Location = new System.Drawing.Point(78, 194);
            this.btnCalculateSaving.Name = "btnCalculateSaving";
            this.btnCalculateSaving.Size = new System.Drawing.Size(182, 22);
            this.btnCalculateSaving.TabIndex = 2;
            this.btnCalculateSaving.Text = "Calculate saving";
            this.btnCalculateSaving.UseVisualStyleBackColor = true;
            this.btnCalculateSaving.Click += new System.EventHandler(this.btnCalculateSaving_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTotalFees);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.lblAmountEarned);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lblAmountPaid);
            this.groupBox4.Controls.Add(this.lblFinalBalance);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(16, 230);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(374, 157);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Future value";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalFees.Location = new System.Drawing.Point(112, 99);
            this.lblTotalFees.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(100, 15);
            this.lblTotalFees.TabIndex = 8;
            this.lblTotalFees.Text = "Total fees";
            this.lblTotalFees.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Total fees";
            // 
            // lblAmountEarned
            // 
            this.lblAmountEarned.AutoSize = true;
            this.lblAmountEarned.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAmountEarned.Location = new System.Drawing.Point(112, 51);
            this.lblAmountEarned.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblAmountEarned.Name = "lblAmountEarned";
            this.lblAmountEarned.Size = new System.Drawing.Size(100, 15);
            this.lblAmountEarned.TabIndex = 6;
            this.lblAmountEarned.Text = "Amount earned";
            this.lblAmountEarned.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Amount earned";
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAmountPaid.Location = new System.Drawing.Point(112, 29);
            this.lblAmountPaid.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(100, 15);
            this.lblAmountPaid.TabIndex = 4;
            this.lblAmountPaid.Text = "Amount paid";
            this.lblAmountPaid.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFinalBalance
            // 
            this.lblFinalBalance.AutoSize = true;
            this.lblFinalBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFinalBalance.Location = new System.Drawing.Point(112, 75);
            this.lblFinalBalance.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblFinalBalance.Name = "lblFinalBalance";
            this.lblFinalBalance.Size = new System.Drawing.Size(100, 15);
            this.lblFinalBalance.TabIndex = 3;
            this.lblFinalBalance.Text = "Final Balance";
            this.lblFinalBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Amount paid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Final balance";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFees);
            this.groupBox3.Controls.Add(this.lblFees);
            this.groupBox3.Controls.Add(this.txtGrowth);
            this.groupBox3.Controls.Add(this.lblGrowth);
            this.groupBox3.Controls.Add(this.txtInitialDeposit);
            this.groupBox3.Controls.Add(this.lblInitialDeposit);
            this.groupBox3.Controls.Add(this.txtPeriod);
            this.groupBox3.Controls.Add(this.txtDeposit);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 175);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Saving plan";
            // 
            // txtFees
            // 
            this.txtFees.Location = new System.Drawing.Point(147, 123);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(100, 20);
            this.txtFees.TabIndex = 5;
            this.txtFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Location = new System.Drawing.Point(9, 126);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(81, 13);
            this.lblFees.TabIndex = 8;
            this.lblFees.Text = "Yearly fees in %";
            // 
            // txtGrowth
            // 
            this.txtGrowth.Location = new System.Drawing.Point(147, 97);
            this.txtGrowth.Name = "txtGrowth";
            this.txtGrowth.Size = new System.Drawing.Size(100, 20);
            this.txtGrowth.TabIndex = 4;
            this.txtGrowth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGrowth
            // 
            this.lblGrowth.AutoSize = true;
            this.lblGrowth.Location = new System.Drawing.Point(9, 100);
            this.lblGrowth.Name = "lblGrowth";
            this.lblGrowth.Size = new System.Drawing.Size(132, 13);
            this.lblGrowth.TabIndex = 6;
            this.lblGrowth.Text = "Yearly growth/interest in %";
            // 
            // txtInitialDeposit
            // 
            this.txtInitialDeposit.Location = new System.Drawing.Point(147, 19);
            this.txtInitialDeposit.Name = "txtInitialDeposit";
            this.txtInitialDeposit.Size = new System.Drawing.Size(100, 20);
            this.txtInitialDeposit.TabIndex = 1;
            this.txtInitialDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInitialDeposit
            // 
            this.lblInitialDeposit.AutoSize = true;
            this.lblInitialDeposit.Location = new System.Drawing.Point(9, 22);
            this.lblInitialDeposit.Name = "lblInitialDeposit";
            this.lblInitialDeposit.Size = new System.Drawing.Size(68, 13);
            this.lblInitialDeposit.TabIndex = 4;
            this.lblInitialDeposit.Text = "Initial deposit";
            // 
            // txtPeriod
            // 
            this.txtPeriod.Location = new System.Drawing.Point(147, 71);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(100, 20);
            this.txtPeriod.TabIndex = 3;
            this.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(147, 45);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(100, 20);
            this.txtDeposit.TabIndex = 2;
            this.txtDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Period (years)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Monthly deposit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.calculator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Calculator by Lars Jensen";
            this.calculator.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpGender.ResumeLayout(false);
            this.grpGender.PerformLayout();
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            this.grpUnit.ResumeLayout(false);
            this.grpUnit.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.grpActivityLevel.ResumeLayout(false);
            this.grpActivityLevel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl calculator;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpUnit;
        private System.Windows.Forms.Button btnCalculateBMI;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton optImperial;
        private System.Windows.Forms.RadioButton optMetric;
        private System.Windows.Forms.Label lblBMI;
        private System.Windows.Forms.Label lblWeightResult;
        private System.Windows.Forms.Label lblBMICategory;
        private System.Windows.Forms.Label lblBMIResult;
        private System.Windows.Forms.Button btnCalculateSaving;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Label lblFinalBalance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInitialDeposit;
        private System.Windows.Forms.Label lblInitialDeposit;
        private System.Windows.Forms.TextBox txtGrowth;
        private System.Windows.Forms.Label lblGrowth;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAmountEarned;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnCalculateBMR;
        private System.Windows.Forms.ListBox lbBMRResults;
        private System.Windows.Forms.GroupBox grpActivityLevel;
        private System.Windows.Forms.RadioButton optExtra;
        private System.Windows.Forms.RadioButton optVery;
        private System.Windows.Forms.RadioButton optModeratly;
        private System.Windows.Forms.RadioButton optLightly;
        private System.Windows.Forms.RadioButton optSedentary;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TextBox txtHeightImperialIn;
        private System.Windows.Forms.TextBox txtWeightImperial;
        private System.Windows.Forms.TextBox txtHeightImperialFt;
        private System.Windows.Forms.TextBox txtWeightMetric;
        private System.Windows.Forms.TextBox txtHeightMetric;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.GroupBox grpGender;
        private System.Windows.Forms.RadioButton optMale;
        private System.Windows.Forms.RadioButton optFemale;
    }
}

