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
        }

        private void btnCalculateBMI_Click(object sender, EventArgs e)
        {
            // If all I'm checking is if a string is empty, then this is what I prefer instead of a validating method.
            name = !string.IsNullOrEmpty(txtName.Text) ? txtName.Text : "No name";
            //1.MainForm saves input given on the GUI and saves them in bmiCalc, using its set-methods. 
            bool valueIsValid = false;
            double height = ReadDouble(txtHeightMetric.Text, out valueIsValid);
            if(valueIsValid)
            {
                bmiCalc.Height = height;
            } else
            {
                MessageBox.Show("Value for height is invalid. Expected numerical!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double weight = ReadDouble(txtWeightMetric.Text, out valueIsValid);
            if (valueIsValid)
            {
                bmiCalc.Weight = weight;
            }
            else
            {
                MessageBox.Show("Value for weight is invalid. Expected numerical!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bmiCalc.Unit = optMetric.Checked ? UnitTypes.Metric : UnitTypes.Imperial;

            //2.MainForm calls methods of bmiCalc to perform calculations and receive output 
            grpResult.Text = "Results for: " + name;
            lblBMIResult.Text = bmiCalc.CalculateBMI().ToString();
            lblBMIResult.Text = bmiCalc.GetBMIWeightCategory();
            //3.MainForm displays the output on the GUI
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
    }
}
