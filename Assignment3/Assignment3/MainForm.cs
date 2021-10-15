/*
 * Lars Jensen
 * 2021-10-21
 * */

using System;
using System.Windows.Forms;
using static Assignment3.BMRCalculator;

namespace Assignment3
{
    public partial class MainForm : Form
    {
        private BMICalculator bmiCalc = new BMICalculator();
        private string name = "No name";

        private SavingsCalculator savingCalc = new SavingsCalculator();

        private BMRCalculator bmrCalc = new BMRCalculator();

        /// <summary>
        /// Initialize method
        /// </summary>
        public MainForm()
        {            
            InitializeComponent();
            InitializeGUI();
            calculator.SelectedIndexChanged += new EventHandler(calculator_SelectIndexChanged);
        }

        private void InitializeGUI()
        {
            // BMI Calculator
            txtName.Text = "";
            txtHeightMetric.Text = "";
            txtWeightMetric.Text = "";
            optMetric.Checked = true;
            optImperial.Checked = false;
            lblBMIResult.Text = "";
            lblBMICategory.Text= "";
            lblBMI.Visible = false;
            lblWeightResult.Visible = false;

            // SavingCalculator
            lblAmountPaid.Text = "";
            lblFinalBalance.Text = "";
            lblAmountEarned.Text = "";
            lblTotalFees.Text = "";

            //BMR Calculator
            optFemale.Checked = true;
            optMale.Checked = false;
            txtAge.Text = "";

        }

        private void btnCalculateBMI_Click(object sender, EventArgs e)
        {
            // If all I'm checking is if a string is empty, then this is what I prefer instead of a validating method.
            name = !string.IsNullOrEmpty(txtName.Text) ? txtName.Text : "No name";
            //1.MainForm saves input given on the GUI and saves them in bmiCalc, using its set-methods. 
            double height = GetHeight();
            if(height > 0)
            {
                bmiCalc.Height = height;
            } else
            {
                return;
            }

            double weight = GetWeight();
            if (weight > 0)
            {
                bmiCalc.Weight = weight;
            }
            else
            {
                return;
            }

            bmiCalc.Unit = optMetric.Checked ? UnitTypes.Metric : UnitTypes.Imperial;

            double calculatedBMI = bmiCalc.CalculateBMI();
            lblBMIResult.Text = calculatedBMI.ToString("0.##");
            lblBMICategory.Text = bmiCalc.GetBMIWeightCategory(calculatedBMI);
            
            grpResult.Text = "Results for: " + name;
            
            lblBMI.Visible = true;
            lblWeightResult.Text = GetWeightResultText(height, optMetric.Checked);
            lblWeightResult.Visible = true;

        }
        // Perhaps these helper functions should be moved to a helper class instead.
        private double ReadDouble(string inputValue, out bool success)
        {
            double value = -1.00;
            success = false;
            if (double.TryParse(inputValue, out value))
                success = true;
            
            return value;
        }
        // Perhaps these helper functions should be moved to a helper class instead.
        private int ReadInt(string inputValue, out bool success)
        {
            int value = -1;
            success = false;
            if (int.TryParse(inputValue, out value))
                success = true;

            return value;
        }

        private void optMetric_CheckedChanged(object sender, EventArgs e)
        {
            lblHeight.Text = "Height (cm)";
            lblWeight.Text = "Weight (kg)";
            
            txtHeightMetric.Visible = true;
            txtWeightMetric.Visible = true;

            // Hide imperial
            txtHeightImperialFt.Visible = false;
            txtHeightImperialIn.Visible = false;
            txtWeightImperial.Visible = false;

            
        }

        private void optImperial_CheckedChanged(object sender, EventArgs e)
        {
            lblHeight.Text = "Height (ft/in)";
            lblWeight.Text = "Weight (lbs)";

            txtHeightMetric.Visible = false;
            txtWeightMetric.Visible = false;
            // Show imperial
            txtHeightImperialFt.Visible = true;
            txtHeightImperialIn.Visible = true;
            txtWeightImperial.Visible = true;
        }

        // Helper function to get height
        private double GetHeight()
        {
            bool valueIsValid = false;
            double height = 0;
            double heightFt = 0;
            double heightIn = 0;
            // Since imperial has two different fields for height, the if-statement is set around the ReadDouble
            if (optMetric.Checked)
            {
                height = ReadDouble(txtHeightMetric.Text, out valueIsValid);
            }
            else
            {
                // If either the controls have invalid value, we want to know.
                heightFt = ReadDouble(txtHeightImperialFt.Text, out valueIsValid);
                heightIn = ReadDouble(txtHeightImperialIn.Text, out valueIsValid);
            }

            if (valueIsValid)
            {
                if (optMetric.Checked)
                {
                    return height / 100;
                }
                else
                {
                    return (heightFt * 12) + heightIn;
                }
            }
            else
            {
                MessageBox.Show("Value for height is invalid. Expected numerical!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private double GetWeight()
        {
            bool valueIsValid = false;
            double weight = 0;
            if (optMetric.Checked)
            {
                weight = ReadDouble(txtWeightMetric.Text, out valueIsValid);
            }
            else
            {
                weight = ReadDouble(txtWeightImperial.Text, out valueIsValid);
            }            

            if (valueIsValid)
            {
                return weight;                
            }
            else
            {
                MessageBox.Show("Value for weight is invalid. Expected numerical!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        private string GetWeightResultText(double height, bool metric)
        {
            double weightMin = 0;
            double weightMax = 0;
            double weight = 0;
            int factorMetric = 1;
            int factorImperial = 703;
            if (metric)
            {
                weight = (height * height) / factorMetric;                
            } else
            {
                weight = (height * height) / factorImperial; ;                
            }

            weightMin = weight * 18.50;
            weightMax = weight * 24.90;
            // Change text depending on unit
            string strUnit = metric ? "kg" : "lbs";
            return "Normal weight should be between " + weightMin.ToString("#") + " " + strUnit + " and " + weightMax.ToString("#") + " " + strUnit;
        }

        private void btnCalculateSaving_Click(object sender, EventArgs e)
        {
            
            bool valueIsValid = false;
            double monthlyDeposit = ReadDouble(txtDeposit.Text, out valueIsValid);
            if (valueIsValid)
            {
                savingCalc.MonthlyDeposit = monthlyDeposit;
            }
            else
            {
                ShowErrorMessage("monthly deposit");
                return;
            }

            int period = ReadInt(txtPeriod.Text, out valueIsValid);
            if (valueIsValid)
            {
                savingCalc.Period = period;
            }
            else
            {
                ShowErrorMessage("period");
                return;
            }

            int initialDeposit = ReadInt(txtInitialDeposit.Text, out valueIsValid);
            if (valueIsValid)
            {
                savingCalc.InitialDeposit = initialDeposit;
            }
            else
            {
                ShowErrorMessage("initial deposit");
                return;
            }

            double growth = ReadDouble(txtGrowth.Text, out valueIsValid);
            // Since we have default 10% it will be reflected in the control.
            if (txtGrowth.Text != "" && valueIsValid)
            {
                // Since it says "in percent" I want the user to add percent, which I then divide by 100
                savingCalc.Growth = growth / 100;
            }
            else
            {
                txtGrowth.Text = "10";               
            }

            double fees = ReadDouble(txtFees.Text, out valueIsValid);
            if (valueIsValid)
            {
                savingCalc.Fees = fees / 100;
            }
            else
            {
                ShowErrorMessage("fees");
                return;
            }

            // Reset TotalFees
            savingCalc.TotalFees = 0;
            // Only want the two last fractions to show
            lblAmountPaid.Text = savingCalc.calculateAmountPaid().ToString("0.##");
            lblFinalBalance.Text = savingCalc.calculateFinalBalance().ToString("0.##");

            lblAmountEarned.Text = savingCalc.calculateAmountEarned().ToString("0.##");
            lblTotalFees.Text = savingCalc.TotalFees.ToString("0.##");

        }
        // Helper method to avoid duplication of code. 
        private void ShowErrorMessage(string value)
        {
            MessageBox.Show("Value for " + value + " is invalid. Expected numerical!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void btnCalculateBMR_Click(object sender, EventArgs e)
        {
            // When I do a new calculation I want the listbox to be cleared
            lbBMRResults.Items.Clear();

            double height = GetHeight();
            if (height > 0)
            {
                if(optImperial.Checked)
                    height = (height * 2.54)/100; // inches to cm and then to m
                bmrCalc.Height = height;
            }
            else
            {
                return;
            }

            double weight = GetWeight();
            if (weight > 0)
            {
                if (optImperial.Checked)
                    weight = weight * 0.45359237; // lbs to kg
                
                bmrCalc.Weight = weight;
            }
            else
            {
                return;
            }
                        
            int age = GetAge();
            if (age > 0)
            {
                bmrCalc.Age = age;
            }
            else
            {
                return;
            }

            bmrCalc.Gender = optFemale.Checked ? Gender.Female: Gender.Male;

            // I thought about looping over all of the radiobuttons in the grpBMRFactor control and use the name of them to set the class values, but decided to go with this instead.
            if (optSedentary.Checked)
            {
                // Using a struct for BMRFactors
                bmrCalc.BMRFactor = BMRFactors.Sedentary;
            }
            else if (optLightly.Checked)
            {
                bmrCalc.BMRFactor = BMRFactors.Lightly;
            }
            else if (optModeratly.Checked)
            {
                bmrCalc.BMRFactor = BMRFactors.Moderately;
            }
            else if (optVery.Checked)
            {
                bmrCalc.BMRFactor = BMRFactors.Very;
            }
            else if (optExtra.Checked)
            {
                bmrCalc.BMRFactor = BMRFactors.Extra;
            }

            lbBMRResults.Items.Add("BMR RESULTS FOR " + txtName.Text.ToUpper() + ":");
            lbBMRResults.Items.Add("");
            lbBMRResults.Items.Add("Your BMR (calories/day)\t\t" + bmrCalc.calculateBMR().ToString("0.##"));
            lbBMRResults.Items.Add("Calories to maintain your weight\t" + bmrCalc.calculateMaintainWeight().ToString("0.##"));
            lbBMRResults.Items.Add("Calories to loose 0,5 kg per week\t" + bmrCalc.calculateGainOrLossWeight(-500).ToString("0.##"));
            lbBMRResults.Items.Add("Calories to loose 1 kg per week \t" + bmrCalc.calculateGainOrLossWeight(-1000).ToString("0.##"));
            lbBMRResults.Items.Add("Calories to gain 0,5 kg per week \t" + bmrCalc.calculateGainOrLossWeight(500).ToString("0.##"));
            lbBMRResults.Items.Add("Calories to gain 1 kg per week \t" + bmrCalc.calculateGainOrLossWeight(1000).ToString("0.##"));
            lbBMRResults.Items.Add("");
            lbBMRResults.Items.Add("Losing more than 1000 calories per day is to be avoided!");
        }

        private int GetAge()
        {
            bool valueIsValid = false;
            int age = 0;
            age = ReadInt(txtAge.Text, out valueIsValid);

            if (valueIsValid)
            {
                return age;
            }
            else
            {
                MessageBox.Show("Value for age is invalid. Expected numerical!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }
        // Using this to be able to re-use the general info controls from first tab
        private void calculator_SelectIndexChanged(object sender, EventArgs e) 
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    calculator.SelectedTab.Controls.Add(grpGeneral);
                    // If I didn't add this the control would not be shown the second time you switch tab
                    grpGeneral.BringToFront();
                    calculator.SelectedTab.Controls.Add(grpUnit);
                    grpUnit.BringToFront();
                    lblAge.Visible = false;
                    txtAge.Visible = false;
                    grpGender.Visible = false;                    
                    break;
                case 1:
                    // Move grpControl General to second tab
                    calculator.SelectedTab.Controls.Add(grpGeneral);
                    calculator.SelectedTab.Controls.Add(grpUnit);
                    optMetric.Checked = true;
                    lblAge.Visible = true;
                    txtAge.Visible = true;
                    grpGender.Visible = true;
                    break;                
            }
        
        }
    }
}

