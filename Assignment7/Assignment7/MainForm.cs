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
        private Timer timer = new Timer();
        private DateTime time;

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
            btnAddGuess.Enabled = false;
            btnResetGuess.Enabled = false;
        }
        // Method which is triggered upon click of color box
        private void pb_Click(object sender, EventArgs e)
        {
            // TODO If not hard mode then one color can only be used once
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
                    DialogResult playAgain = MessageBox.Show("WIIIIIN!!!\n\nYou succeeded in " + (10-(row-1)).ToString() + " guesses!\n\nWanna play a new game?", "You are a true Mastermind!", MessageBoxButtons.YesNo);
                    if (playAgain == DialogResult.No)
                    {
                        Application.Exit();
                    }
                    StartNewGame();

                } else
                {
                    row--;
                    if(row == 0)
                    {
                        DialogResult playAgain = MessageBox.Show("LOOOOOSER!!!\n\nWanna play a new game?", "You are NO Mastermind!", MessageBoxButtons.YesNo);
                        if (playAgain == DialogResult.No)
                        {
                            Application.Exit();
                        } else
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
        private void AddGuessRowToTLP()
        {
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
                string toolTipText = "Click the box to choose color";
                toolTip1.SetToolTip(pictureBox, toolTipText);
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
                string toolTipText = "Click the box to choose color";
                toolTip1.SetToolTip(pictureBox, toolTipText);

                // If the guess is wrong then add error image to illustrate it
                if (pictureBox.BackColor == Color.Gray)
                    pictureBox.Image = pictureBox.ErrorImage;
                                
                newPanel.Controls.Add(pictureBox, i, 0);
            }
            for (int i = 0; i < 2; i++)
            {
                PictureBox pictureBox = GetNewPictureBox(false);
                pictureBox.BackColor = GetColorFromResult(result[2+i]);
                string toolTipText = "Click the box to choose color";
                toolTip1.SetToolTip(pictureBox, toolTipText);

                if (pictureBox.BackColor == Color.Gray)
                    pictureBox.Image = pictureBox.ErrorImage;

                newPanel.Controls.Add(pictureBox, i, 1);                
            }
            string panelToolTipText = "Black means right color in the right place" + Environment.NewLine + "White means right color in the wrong place" + Environment.NewLine + "Crossed box means wrong color";
            toolTip1.SetToolTip(newPanel, panelToolTipText);

            tlpContainer.Controls.Add(newPanel, 1, row);            
        }
        // Helper function to get Tooltip from background color
        private string GetToolTip(Color color)
        {
            if (color == Color.Black)
                return "Right color in the right place!";
            if (color == Color.White)
                return "Right color in the wrong place!";
            return "Wrong color!";
        }

        // TODO Refactor
        private void AddCorrectRowToTLP()
        {
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
        // Map enum to color
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
                    return Color.Gray;
            }
        }

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

        private void MainForm_Shown(object sender, EventArgs e)
        {            
            DialogResult showRules = MessageBox.Show("Do you want to see the rules?", "Mastermind rules?", MessageBoxButtons.YesNo);
            if (showRules == DialogResult.Yes)
            {
                RulesMastermind mastermindRules = new RulesMastermind();
                mastermindRules.Show();
            } else
            {
                DialogResult doYouWantToPlay = MessageBox.Show("Are you ready to play?", "Are you a mastermind?", MessageBoxButtons.YesNo);
                if (doYouWantToPlay != DialogResult.Yes)
                {
                    MessageBox.Show("Come back when you are ready!", "Return to become a Mastermind!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
                StartNewGame();
            }
        }

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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("Are you sure you want to quit?", "Quit?", MessageBoxButtons.YesNo);
            if(response == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(row < 10)
            {
                DialogResult response = MessageBox.Show("Are you sure you want to start a new game?", "Quit?", MessageBoxButtons.YesNo);
                if (response == DialogResult.Yes)
                {
                    StartNewGame();
                }
            } else
            {
                StartNewGame();
            }           
            
        }

        private void StartNewGame()
        {
            InitializeGUI();
            mastermindManager = new MastermindManager(10, GameMode.MEDIUM);
            mastermindManager.GenerateRandomRow();
            row = 10;
            AddGuessRowToTLP();
            AddCorrectRowToTLP();
            btnAddGuess.Enabled = true;
            btnResetGuess.Enabled = true;


            // Chose to have timer in form show as it is more user friendly
            time = DateTime.Now;
            timer.Interval = 1000;
            // Call each second
            timer.Tick += new EventHandler(UpdateTime);

            timer.Start();
        }
    }
}
