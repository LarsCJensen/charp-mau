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
        // FUTURE Make dynamic regarding gamemode
        private MastermindManager mastermindManager = new MastermindManager(10, GameMode.MEDIUM);
        private int row = 10;
        private Dictionary<Colors, Color> colorsEnumToColorDict = new Dictionary<Colors, Color>();
        private Dictionary<Color, Colors> colorToColorsEnumDict = new Dictionary<Color, Colors>();
        private Timer timer = new Timer();
        private DateTime time;

        public MainForm()
        {
            InitializeComponent();
            FillColorDicts();
            InitializeGUI();
        }


        private void InitializeGUI()
        {
            lblMastermind.Visible = true;
            tlpContainer.Controls.Clear();
            btnAddGuess.Enabled = false;
            btnResetGuess.Enabled = false;
        }
        // Method which is triggered upon click of color box
        private void pb_Click(object sender, EventArgs e)
        {
            ChangeColor(sender);
        }        
        // Method which changes color. Each picture box has a tag representation of it's current color
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

        // Method to guess row of chosen colors
        private void btnAddGuess_Click(object sender, EventArgs e)
        {            
            Control.ControlCollection rowControls = tlpContainer.GetControlFromPosition(0, row).Controls;
            if (ValidateGuess(rowControls))
            {
                // Disable the guessed row controls
                foreach (Control control in rowControls)
                {
                    control.Enabled = false;
                }                    
                List<MastermindItem> guess = GetMastermindItemsFromControls(rowControls);
                MastermindRow guessRow = new MastermindRow(guess);
                List<GuessResult> result = mastermindManager.Guess(guessRow);
                // Only easy mode will have information about which color is correct and/or in the right place
                if(mastermindManager.GameMode != GameMode.EASY)
                {
                    // Sort results descending to show the "best guess" result first
                    // This will change the list order, but it doesn't matter
                    result.Sort((a, b) => b.CompareTo(a));
                }
                // Show result in result controls
                AddGuessResultRowToTLP(result);

                // If all results are of the same type (RIGHT_COLOR_AND_PLACC) then guess is correct
                if (result.Distinct().Count() == 1 && result[0] == GuessResult.RIGHT_COLOR_AND_PLACE)
                {
                    lblMastermind.Visible = false;
                    DialogResult playAgain = MessageBox.Show("WIIIIIN!!!\n\nYou succeeded in " + (10-(row-1)).ToString() + " guesses in " + lblTimer.Text + "!\n\nWanna play a new game?", "You are a true Mastermind!", MessageBoxButtons.YesNo);
                    if (playAgain == DialogResult.Yes)
                    {
                        StartNewGame();
                    }                    
                } else
                {
                    row--;
                    if(row == 0)
                    {
                        lblMastermind.Visible = false;
                        DialogResult playAgain = MessageBox.Show("LOOOOOSER!!!\n\nWanna play a new game?", "You are NO Mastermind!", MessageBoxButtons.YesNo);
                        if (playAgain == DialogResult.Yes)
                        { 
                            StartNewGame();
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
        // Method to dynamically add a row of picture boxes to TableLayoutPanel
        private void AddGuessRowToTLP()
        {
            // FUTURE create helper function which takes column count, rowcount and size as inparams
            TableLayoutPanel newPanel = new TableLayoutPanel();
            newPanel.ColumnCount = 4;
            newPanel.RowCount = 1;
            newPanel.Size = new Size(289, 45);
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            newPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            for(int i = 0; i < 4;i++)
            {
                PictureBox pictureBox = GetNewPictureBox();
                // Dynamically add ToolTip for pictureBox
                string toolTipText = "Click the box to choose color";
                toolTip1.SetToolTip(pictureBox, toolTipText);
                newPanel.Controls.Add(pictureBox, i, 0);                
            }
            
            tlpContainer.Controls.Add(newPanel, 0, row);
        }
        // Method to add the results of a guess to TableLayoutPanel
        private void AddGuessResultRowToTLP(List<GuessResult> result)
        {
            // FUTURE create helper function which takes column count, rowcount and size as inparams
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

            // Two for-loops since I want the results to be in a square
            for (int i = 0; i < 2; i++)
            {                
                PictureBox pictureBox = GetNewPictureBox(false);
                pictureBox.BackColor = GetColorFromResult(result[i]);
                
                // If the guess is wrong then add error image to illustrate it
                if (pictureBox.BackColor == Color.Gray)
                    pictureBox.Image = pictureBox.ErrorImage;
                                
                newPanel.Controls.Add(pictureBox, i, 0);
            }
            for (int i = 0; i < 2; i++)
            {
                PictureBox pictureBox = GetNewPictureBox(false);
                pictureBox.BackColor = GetColorFromResult(result[2+i]);
                
                if (pictureBox.BackColor == Color.Gray)
                    pictureBox.Image = pictureBox.ErrorImage;

                newPanel.Controls.Add(pictureBox, i, 1);                
            }
            // Dynamically add tooltip for the panel which explains the result
            string panelToolTipText = "Black means right color in the right place" + Environment.NewLine + "White means right color in the wrong place" + Environment.NewLine + "Crossed box means wrong color";
            toolTip1.SetToolTip(newPanel, panelToolTipText);

            tlpContainer.Controls.Add(newPanel, 1, row);            
        }
        
        // Function which adds controls based on the CorrectRow which player is to guess
        private void AddCorrectRowToTableLayoutPanel()
        {
            // Since the the correct row doesn't have a result the tablelayoutpanel is a bit different
            TableLayoutPanel newPanel = new TableLayoutPanel();
            newPanel.ColumnCount = 4;
            newPanel.RowCount = 1;
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
                // Get correct color based on enum key.
                pictureBox.BackColor = colorsEnumToColorDict[item.Color];
                newPanel.Controls.Add(pictureBox, i, 0);
            }            
            tlpContainer.Controls.Add(newPanel, 0, 0);
        }
        // Helper method to create and return new pictureBox
        private PictureBox GetNewPictureBox(bool guess=true)
        {
            PictureBox newPictureBox;
            if (guess)
            {
                newPictureBox = new PictureBox() { BackColor = Color.Gray, Size = new Size(35, 35), Enabled=true, Anchor=AnchorStyles.None};
                newPictureBox.Click += pb_Click;
            } else
            {
                newPictureBox = new PictureBox() { BackColor = Color.DimGray, Size = new Size(15, 15), Enabled=false, Anchor = AnchorStyles.None };                
            }
            
            return newPictureBox;
        }
        // Map enum to actual color
        // This might be overkill and over complicated, since I could just have an array of color items
        // instead of an own Enum which I need to translate to colors but I wanted to try more Enum
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
            // Make sure guess is valid
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
        // FUTURE - one could perhaps also warn if player has chosen same color multiple times on Easy and Medium
        private bool ValidateGuess(Control.ControlCollection controls)
        {
            for (int i = 0; i < controls.Count; i++)
            {
                // If backcolor is not set to one of the colors enums then the player hasn't chosen a color
                if (!colorToColorsEnumDict.ContainsKey(controls[i].BackColor))
                {
                    return false;
                }
            }
            return true;
        }
        // Helper method to translate guessresult to a Color
        private Color GetColorFromResult(GuessResult result)
        {
            switch(result)
            {
                case GuessResult.RIGHT_COLOR_AND_PLACE:
                    return Color.Black;
                case GuessResult.RIGHT_COLOR:
                    return Color.White;
                default:
                    return Color.Gray;
            }
        }
        // Menu items ------>
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutMastermind about = new AboutMastermind();
            about.ShowDialog();            
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RulesMastermind rules = new RulesMastermind();
            rules.ShowDialog();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Application.Exit();            
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If guess has been made and game has not ended (no guesses left) ask if player is sure.
            if (row < 10 && row != 0)
            {
                DialogResult response = MessageBox.Show("Are you sure you want to start a new game?", "Quit?", MessageBoxButtons.YesNo);
                if (response == DialogResult.Yes)
                {
                    StartNewGame();
                }
            }
            else
            {
                StartNewGame();
            }
        }
        // <------------------
        
        private void MainForm_Shown(object sender, EventArgs e)
        {            
            // Make it easier for new players to get started. 
            // FUTURE - Have a setting which disables this
            DialogResult showRules = MessageBox.Show("Do you want to see the rules?", "Mastermind rules?", MessageBoxButtons.YesNo);
            if (showRules == DialogResult.Yes)
            {
                RulesMastermind mastermindRules = new RulesMastermind();
                mastermindRules.Show();
            } else
            {
                DialogResult doYouWantToPlay = MessageBox.Show("Are you ready to play (time will start upon Yes)?", "Are you a mastermind?", MessageBoxButtons.YesNo);
                if (doYouWantToPlay == DialogResult.Yes)
                {
                    StartNewGame();
                }                
            }
        }
        // Reset guesses in a not submitted row
        private void btnResetGuess_Click(object sender, EventArgs e)
        {
            Control.ControlCollection rowControls = tlpContainer.GetControlFromPosition(0, row).Controls;
            foreach (Control control in rowControls)
            {
                control.BackColor = Color.Gray;
            }            
        }
        // Update time each second
        private void UpdateTime(object sender, EventArgs e)
        {
            lblTimer.Text = (DateTime.Now - time).ToString("hh\\:mm\\:ss");
            // So program doesn't hang.
            Application.DoEvents();
        }

        // Method to start new game
        private void StartNewGame()
        {
            InitializeGUI();
            mastermindManager = new MastermindManager(10, GameMode.MEDIUM);
            mastermindManager.GenerateRandomRow();
            row = 10;
            AddGuessRowToTLP();
            AddCorrectRowToTableLayoutPanel();
            btnAddGuess.Enabled = true;
            btnResetGuess.Enabled = true;

            // Chose to have timer in form show as it is more user friendly
            time = DateTime.Now;
            timer.Interval = 1000;
            // Call each second
            timer.Tick += new EventHandler(UpdateTime);

            timer.Start();
        }
        // Method to handle Exit of application
        private DialogResult ExitGame()
        {
            DialogResult response = MessageBox.Show("Are you sure you want to quit?", "Quit?", MessageBoxButtons.YesNo);
            return response;            
        }
        // Handle exit cross of application
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult response = ExitGame();
            if (response == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
