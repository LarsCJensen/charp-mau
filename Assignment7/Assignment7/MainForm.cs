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
        // TODO Make dynamic regarding number of guesses and Gamemode
        private MastermindManager mastermindManager = new MastermindManager(10, GameMode.MEDIUM);
        private int row = 10;
        private Dictionary<Colors, Color> colorsEnumToColorDict = new Dictionary<Colors, Color>();
        private Dictionary<Color, Colors> colorToColorsEnumDict = new Dictionary<Color, Colors>();
        public MainForm()
        {
            InitializeComponent();
            // TODO Refactor
            FillColorDicts();
            InitializeGUI();
        }


        private void InitializeGUI()
        {
            tlpContainer.Controls.Clear();
            GenerateRandomRow();
            AddGuessRowToTLP();
            AddCorrectRowToTLP();            
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

        // TODO Refactor
        private void btnAddGuess_Click(object sender, EventArgs e)
        {            
            Control.ControlCollection rowControls = tlpContainer.GetControlFromPosition(0, row).Controls;
            if (ValidateGuess(rowControls))
            {
                // TODO check sloppy loops without squirly-brackets
                foreach (Control control in rowControls)
                {
                    control.Enabled = false;
                }                    
                List<MastermindItem> guess = GetMastermindItemsFromControls(rowControls);
                // TODO Refactor - validate before GetMastermindItems??
                MastermindRow guessRow = new MastermindRow(guess);
                List<GuessResult> result = mastermindManager.Guess(guessRow);
                // Sort results by "correctness" to prevent it being too easy
                if(mastermindManager.GameMode != GameMode.EASY)
                {
                    // Sort results descending to show the "best guess" first
                    // This will change the list order, but it doesn't matter
                    result.Sort((a, b) => b.CompareTo(a));
                }
                // Show result in result controls
                AddGuessResultRowToTLP(result);

                // TODO Refactor
                if (result.Distinct().Count() == 1 && result[0] == GuessResult.RIGHT_COLOR_AND_PLACE)
                {
                    lblMastermind.Visible = false;
                    DialogResult playAgain = MessageBox.Show("WIIIIIN!!! \nWanna play a new game?", "You won!", MessageBoxButtons.YesNo);
                    if(playAgain == DialogResult.No)
                    {
                        Application.Exit();
                    }
                    InitializeGUI();

                } else
                {
                    row--;
                    if(row == 0)
                    {
                        DialogResult playAgain = MessageBox.Show("LOOOOOSER!!! \nWanna play a new game?", "You're no Mastermind!!", MessageBoxButtons.YesNo);
                        if (playAgain == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    } else
                    {
                        AddGuessRowToTLP();
                    }
                    
                }
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
        private void AddGuessResultRowToTLP(List<GuessResult> result)
        {
            // TODO create helper function?
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
                pictureBox.BackColor = GetColorFromResult(result[i]);
                newPanel.Controls.Add(pictureBox, i, 0);
            }
            for (int i = 0; i < 2; i++)
            {
                PictureBox pictureBox = GetNewPictureBox(false);
                pictureBox.BackColor = GetColorFromResult(result[2+i]);
                newPanel.Controls.Add(pictureBox, i, 1);
            }
            tlpContainer.Controls.Add(newPanel, 1, row);
        }
        // TODO Refactor
        private void AddCorrectRowToTLP()
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
        
        private Color GetColorFromResult(GuessResult result)
        {
            switch(result)
            {
                case GuessResult.RIGHT_COLOR_AND_PLACE:
                    return Color.Black;
                case GuessResult.RIGHT_COLOR:
                    return Color.White;
                default:
                    return Color.Gainsboro;
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutMastermind about = new AboutMastermind();
            about.ShowDialog();            
        }
    }
}
