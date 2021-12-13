using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Assignment7
{
    public partial class MainForm : Form
    {        
        // TODO Make dynamic
        private MastermindManager mastermindManager = new MastermindManager(10);
        private int row = 10;
        private Dictionary<Colors, Color> colorsEnumToColorDict = new Dictionary<Colors, Color>();
        private Dictionary<Color, Colors> colorToColorsEnumDict = new Dictionary<Color, Colors>();
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }


        private void InitializeGUI()
        {
            // TODO Refactor
            FillColorDicts();

            tlpContainer.Controls.Clear();
            GenerateRandomRow();
            AddGuessRowToTLP();
            AddCorrectRowToTLP();
            AddGuessResultRowToTLP();
            
            //HandlePictureBoxes(this);
        }

        // Recursively bind click event to all picture boxes and reset them to default
        private void HandlePictureBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(PictureBox) && c.Enabled == true) // Disabled picture boxes are for result
                {
                    c.BackColor = Color.Gainsboro;
                    c.Tag = null;
                    c.Click += pb_Click;
                } else
                {
                    HandlePictureBoxes(c);
                }
            }
        }
        private void pb_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }
        private void ChangeColor(object sender)
        {
            var pictureBox = sender as PictureBox;
            
            switch (pictureBox.Tag)
            {
                case Colors.WHITE:
                    pictureBox.BackColor = Color.Black;
                    pictureBox.Tag = Colors.BLACK;
                    break;
                case Colors.BLACK:
                    pictureBox.BackColor = Color.Blue;
                    pictureBox.Tag = Colors.BLUE;
                    break;
                case Colors.BLUE:
                    pictureBox.BackColor = Color.Green;
                    pictureBox.Tag = Colors.GREEN;
                    break;
                case Colors.GREEN:
                    pictureBox.BackColor = Color.Red;
                    pictureBox.Tag = Colors.RED;
                    break;
                case Colors.RED:
                    pictureBox.BackColor = Color.Yellow;
                    pictureBox.Tag = Colors.YELLOW;
                    break;
                default:
                    pictureBox.BackColor = Color.White;
                    pictureBox.Tag = Colors.WHITE;
                    break;

            }
        }

        private void btnAddGuess_Click(object sender, EventArgs e)
        {
            // Create guess
            // TODO s
            Control.ControlCollection rowControls = tlpContainer.GetControlFromPosition(0, row).Controls;
            if (ValidateGuess(rowControls))
            {
                List<MastermindItem> guess = GetMastermindItemsFromControls(rowControls);
                // TODO Refactor - validate before GetMastermindItems??
                MastermindRow guessRow = new MastermindRow(guess);
                List<GuessResult> result = mastermindManager.Guess(guessRow);                

                lblMastermind.Visible = false;
                row--;
            }
            else
            {
                MessageBox.Show("You need to choose a color for all items!", "Guess again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void AddGuessRowToTLP()
        {
            TableLayoutPanel newPanel = new TableLayoutPanel();
            newPanel.ColumnCount = 4;
            newPanel.RowCount = 1;
            //TODO REMOVE
            //newPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            newPanel.Size = new Size(289, 45);
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            newPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            for(int i = 0; i < 4;i++)
            {
                PictureBox pictureBox = GetNewPictureBox();                
                newPanel.Controls.Add(pictureBox, i, 0);
                
            }
            
            tlpContainer.Controls.Add(newPanel, 0, row);
        }
        // TODO Refactor
        private void AddCorrectRowToTLP()
        {
            TableLayoutPanel newPanel = new TableLayoutPanel();
            newPanel.ColumnCount = 4;
            newPanel.RowCount = 1;
            //TODO REMOVE
            //newPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            newPanel.Size = new Size(365, 50);
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));            
            newPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            // Getting properties for Row
            Type rowType = mastermindManager.CorrectRow.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(rowType.GetProperties());

            for (int i = 0; i < 4; i++)
            {
                // Dynamically get the correct item property based on index order
                MastermindItem item = (MastermindItem)props[i].GetValue(mastermindManager.CorrectRow);
                PictureBox pictureBox = GetNewPictureBox();
                //TODO Ta bort
                //pictureBox.BackColor = colorsDict[mastermindManager.CorrectRow.Item1.Color];
                // Get correct color based on enum key.
                pictureBox.BackColor = colorsEnumToColorDict[item.Color];
                newPanel.Controls.Add(pictureBox, i, 0);
            }
            // TODO Does this even work?
            tlpContainer.SetColumnSpan(newPanel, 2);
            
            tlpContainer.Controls.Add(newPanel, 0, 0);

        }

        private PictureBox GetNewPictureBox(bool guess=true)
        {
            PictureBox newPictureBox;
            if (guess)
            {
                newPictureBox = new PictureBox() { BackColor = Color.Gainsboro, Size = new Size(35, 35), Enabled=true, Anchor=AnchorStyles.None};
                newPictureBox.Click += pb_Click;
            } else
            {
                newPictureBox = new PictureBox() { BackColor = Color.DimGray, Size = new Size(15, 15), Enabled=false, Anchor = AnchorStyles.None };
            }
            
            return newPictureBox;
        }

        private void AddGuessResultRowToTLP()
        {
            TableLayoutPanel newPanel = new TableLayoutPanel();
            newPanel.ColumnCount = 2;
            newPanel.RowCount = 2;
            newPanel.Size = new Size(68, 44);
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            newPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            newPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));

            for (int i = 0; i < 2; i++)
            {
                PictureBox pictureBox = GetNewPictureBox(false);
                newPanel.Controls.Add(pictureBox, i, 0);
            }            
            for (int i = 0; i < 2; i++)
            {
                PictureBox pictureBox = GetNewPictureBox(false);
                newPanel.Controls.Add(pictureBox, i, 1);
            }
            tlpContainer.Controls.Add(newPanel, 1, row);            
        }

        private void GenerateRandomRow()
        {
            mastermindManager.GenerateRandomRow();
        }
        private void FillColorDicts()
        {
            colorsEnumToColorDict.Add(Colors.BLACK, Color.Black);
            colorsEnumToColorDict.Add(Colors.BLUE, Color.Blue);
            colorsEnumToColorDict.Add(Colors.GREEN, Color.Green);
            colorsEnumToColorDict.Add(Colors.RED, Color.Red);
            colorsEnumToColorDict.Add(Colors.WHITE, Color.White);
            colorsEnumToColorDict.Add(Colors.YELLOW, Color.Yellow);

            colorToColorsEnumDict.Add(Color.Black, Colors.BLACK);
            colorToColorsEnumDict.Add(Color.Blue, Colors.BLUE);
            colorToColorsEnumDict.Add(Color.Green, Colors.GREEN);
            colorToColorsEnumDict.Add(Color.Red, Colors.RED);
            colorToColorsEnumDict.Add(Color.White, Colors.WHITE);
            colorToColorsEnumDict.Add(Color.Yellow, Colors.YELLOW);
        }
        // Helper function to get list of MastermindItems based on controls
        private List<MastermindItem> GetMastermindItemsFromControls(Control.ControlCollection controls)
        {
            List<MastermindItem> listOfItems = new List<MastermindItem>();
            if (ValidateGuess(controls))
            {                
                for (int i = 0; i < controls.Count; i++)
                {
                    MastermindItem item = new MastermindItem();
                    item.Color = colorToColorsEnumDict[controls[i].BackColor];
                    listOfItems.Add(item);
                }                
            } else
            {
                MessageBox.Show("You need to choose a color for all items!", "Guess again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listOfItems;

        }
        // Make sure that player has entered a valid guess
        private bool ValidateGuess(Control.ControlCollection controls)
        {
            for (int i = 0; i < controls.Count; i++)
            {
                if (!colorToColorsEnumDict.ContainsKey(controls[i].BackColor))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
