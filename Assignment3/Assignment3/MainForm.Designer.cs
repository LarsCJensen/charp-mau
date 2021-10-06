
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
            this.txtHeightImperialIn = new System.Windows.Forms.TextBox();
            this.txtWeightImperial = new System.Windows.Forms.TextBox();
            this.txtHeightImperialFt = new System.Windows.Forms.TextBox();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.lblBMICategory = new System.Windows.Forms.Label();
            this.lblBMIResult = new System.Windows.Forms.Label();
            this.lblWeightResult = new System.Windows.Forms.Label();
            this.lblBMI = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWeightMetric = new System.Windows.Forms.TextBox();
            this.txtHeightMetric = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optImperial = new System.Windows.Forms.RadioButton();
            this.optMetric = new System.Windows.Forms.RadioButton();
            this.btnCalculateBMI = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.txtYears = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFinalBalance = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.btnCalculateSaving = new System.Windows.Forms.Button();
            this.calculator.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpResult.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculator
            // 
            this.calculator.Controls.Add(this.tabPage1);
            this.calculator.Controls.Add(this.tabPage2);
            this.calculator.Location = new System.Drawing.Point(5, 2);
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
            this.groupBox1.Controls.Add(this.txtHeightImperialIn);
            this.groupBox1.Controls.Add(this.txtWeightImperial);
            this.groupBox1.Controls.Add(this.txtHeightImperialFt);
            this.groupBox1.Controls.Add(this.grpResult);
            this.groupBox1.Controls.Add(this.txtWeightMetric);
            this.groupBox1.Controls.Add(this.txtHeightMetric);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblHeight);
            this.groupBox1.Controls.Add(this.lblWeight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnCalculateBMI);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 377);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BMI Calculator";
            // 
            // txtHeightImperialIn
            // 
            this.txtHeightImperialIn.Location = new System.Drawing.Point(135, 53);
            this.txtHeightImperialIn.Name = "txtHeightImperialIn";
            this.txtHeightImperialIn.Size = new System.Drawing.Size(35, 20);
            this.txtHeightImperialIn.TabIndex = 11;
            // 
            // txtWeightImperial
            // 
            this.txtWeightImperial.Location = new System.Drawing.Point(92, 79);
            this.txtWeightImperial.Name = "txtWeightImperial";
            this.txtWeightImperial.Size = new System.Drawing.Size(35, 20);
            this.txtWeightImperial.TabIndex = 10;
            // 
            // txtHeightImperialFt
            // 
            this.txtHeightImperialFt.Location = new System.Drawing.Point(92, 53);
            this.txtHeightImperialFt.Name = "txtHeightImperialFt";
            this.txtHeightImperialFt.Size = new System.Drawing.Size(35, 20);
            this.txtHeightImperialFt.TabIndex = 9;
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.lblBMICategory);
            this.grpResult.Controls.Add(this.lblBMIResult);
            this.grpResult.Controls.Add(this.lblWeightResult);
            this.grpResult.Controls.Add(this.lblBMI);
            this.grpResult.Controls.Add(this.label4);
            this.grpResult.Controls.Add(this.label5);
            this.grpResult.Location = new System.Drawing.Point(37, 211);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(502, 160);
            this.grpResult.TabIndex = 8;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Results for: ";
            // 
            // lblBMICategory
            // 
            this.lblBMICategory.AutoSize = true;
            this.lblBMICategory.Location = new System.Drawing.Point(101, 60);
            this.lblBMICategory.Name = "lblBMICategory";
            this.lblBMICategory.Size = new System.Drawing.Size(96, 13);
            this.lblBMICategory.TabIndex = 16;
            this.lblBMICategory.Text = "This will be result...";
            // 
            // lblBMIResult
            // 
            this.lblBMIResult.AutoSize = true;
            this.lblBMIResult.Location = new System.Drawing.Point(101, 31);
            this.lblBMIResult.Name = "lblBMIResult";
            this.lblBMIResult.Size = new System.Drawing.Size(34, 13);
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
            // txtWeightMetric
            // 
            this.txtWeightMetric.Location = new System.Drawing.Point(92, 79);
            this.txtWeightMetric.Name = "txtWeightMetric";
            this.txtWeightMetric.Size = new System.Drawing.Size(35, 20);
            this.txtWeightMetric.TabIndex = 7;
            // 
            // txtHeightMetric
            // 
            this.txtHeightMetric.Location = new System.Drawing.Point(92, 53);
            this.txtHeightMetric.Name = "txtHeightMetric";
            this.txtHeightMetric.Size = new System.Drawing.Size(35, 20);
            this.txtHeightMetric.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(92, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 20);
            this.txtName.TabIndex = 5;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(20, 56);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(61, 13);
            this.lblHeight.TabIndex = 4;
            this.lblHeight.Text = "Height (cm)";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(20, 86);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(62, 13);
            this.lblWeight.TabIndex = 3;
            this.lblWeight.Text = "Weight (kg)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optImperial);
            this.groupBox2.Controls.Add(this.optMetric);
            this.groupBox2.Location = new System.Drawing.Point(337, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 104);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Unit";
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
            this.btnCalculateBMI.Location = new System.Drawing.Point(37, 143);
            this.btnCalculateBMI.Name = "btnCalculateBMI";
            this.btnCalculateBMI.Size = new System.Drawing.Size(175, 30);
            this.btnCalculateBMI.TabIndex = 0;
            this.btnCalculateBMI.Text = "Calculate BMI";
            this.btnCalculateBMI.UseVisualStyleBackColor = true;
            this.btnCalculateBMI.Click += new System.EventHandler(this.btnCalculateBMI_Click);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtYears);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Monthly deposit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Period (years)";
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(119, 21);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(87, 20);
            this.txtDeposit.TabIndex = 2;
            // 
            // txtYears
            // 
            this.txtYears.Location = new System.Drawing.Point(119, 50);
            this.txtYears.Name = "txtYears";
            this.txtYears.Size = new System.Drawing.Size(87, 20);
            this.txtYears.TabIndex = 3;
            // 
            // groupBox4
            // 
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Final balance";
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
            // lblFinalBalance
            // 
            this.lblFinalBalance.AutoSize = true;
            this.lblFinalBalance.Location = new System.Drawing.Point(112, 61);
            this.lblFinalBalance.Name = "lblFinalBalance";
            this.lblFinalBalance.Size = new System.Drawing.Size(66, 13);
            this.lblFinalBalance.TabIndex = 3;
            this.lblFinalBalance.Text = "Amount paid";
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.Location = new System.Drawing.Point(112, 29);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(66, 13);
            this.lblAmountPaid.TabIndex = 4;
            this.lblAmountPaid.Text = "Amount paid";
            // 
            // btnCalculateSaving
            // 
            this.btnCalculateSaving.Location = new System.Drawing.Point(78, 194);
            this.btnCalculateSaving.Name = "btnCalculateSaving";
            this.btnCalculateSaving.Size = new System.Drawing.Size(182, 22);
            this.btnCalculateSaving.TabIndex = 2;
            this.btnCalculateSaving.Text = "Calculate saving";
            this.btnCalculateSaving.UseVisualStyleBackColor = true;
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
            this.groupBox1.PerformLayout();
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl calculator;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCalculateBMI;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWeightMetric;
        private System.Windows.Forms.TextBox txtHeightMetric;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton optImperial;
        private System.Windows.Forms.RadioButton optMetric;
        private System.Windows.Forms.Label lblBMI;
        private System.Windows.Forms.Label lblWeightResult;
        private System.Windows.Forms.Label lblBMICategory;
        private System.Windows.Forms.Label lblBMIResult;
        private System.Windows.Forms.TextBox txtWeightImperial;
        private System.Windows.Forms.TextBox txtHeightImperialFt;
        private System.Windows.Forms.TextBox txtHeightImperialIn;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Button btnCalculateSaving;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Label lblFinalBalance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtYears;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

