using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class MainForm : Form
    {
        private BMICalculator bmiCalc = new BMICalculator();
        private string name = "No name"; 

        /// <summary>
        /// Initialize method
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            txtName.Text = "";
            txtHeightMetric.Text = "";
            txtWeightMetric.Text = "";
            optMetric.Checked = true;
            optImperial.Checked = false;
            lblBMIResult.Text = "";
            lblBMICategory.Text= "";
            lblBMI.Visible = false;
            lblWeightResult.Visible = false;
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

            //2.MainForm calls methods of bmiCalc to perform calculations and receive output 
            double calculatedBMI = bmiCalc.CalculateBMI();
            lblBMIResult.Text = calculatedBMI.ToString("0.##");
            lblBMICategory.Text = bmiCalc.GetBMIWeightCategory(calculatedBMI);
            //3.MainForm displays the output on the GUI
            grpResult.Text = "Results for: " + name;
            
            lblBMI.Visible = true;
            lblWeightResult.Text = GetWeightResultText(height, optMetric.Checked);
            lblWeightResult.Visible = true;

        }
        private double ReadDouble(string inputValue, out bool success)
        {
            double value = -1.00;
            success = false;
            if (double.TryParse(inputValue, out value))
                success = true;
            
            return value;
        }

        private void optMetric_CheckedChanged(object sender, EventArgs e)
        {
            lblHeight.Text = "Height (cm)";
            lblWeight.Text = "Weight (kg)";
            // Show Metric
            txtHeightImperialFt.Visible = false;
            txtHeightImperialIn.Visible = false;
            txtWeightImperial.Visible = false;

            txtHeightMetric.Visible = true;
            txtWeightMetric.Visible = true;
        }

        private void optImperial_CheckedChanged(object sender, EventArgs e)
        {
            lblHeight.Text = "Height (ft/in)";
            lblWeight.Text = "Weight (lbs)";

            txtHeightMetric.Visible = false;
            txtWeightMetric.Visible = false;
            // SHow imperial
            txtHeightImperialFt.Visible = true;
            txtHeightImperialIn.Visible = true;
            txtWeightImperial.Visible = true;
        }

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
            // TODO TA HÄNSYN TILL IMPERIAL ETC
            //weight1 = weight * 18.50; //low limit weight2  = weight * 24.9; // high limit
            double weightMin = 0;
            double weightMax = 0;
            if (metric)
            {
                weightMin = height * 18.50;
                weightMax = height * 24.90;
            } else
            {
                weightMin = (height * height/ 703) * 18.50;
                weightMax = (height * height/ 703) * 24.90;
            }
            
            string strUnit = metric ? "kg" : "lbs";
            return "Normal weight should be between " + ((int)weightMin).ToString() + " " + strUnit + " and " + ((int)weightMax).ToString() + " " + strUnit;
        }
    }
}

