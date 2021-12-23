using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Assignment7
{
    public partial class RulesMastermind : Form
    {
        public RulesMastermind()
        {
            InitializeComponent();
            InitializeGUI();
        }
        private void InitializeGUI()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Assets\mastermind_rules.txt");            
            txtRules.Text = File.ReadAllText(path);                
            txtRules.SelectionLength = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

    }
}
