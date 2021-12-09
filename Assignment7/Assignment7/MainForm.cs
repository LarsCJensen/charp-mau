using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment7
{
    public partial class MainForm : Form
    {
        private MastermindManager mastermindManager = new MastermindManager();
        private MastermindRow mastermindRow = new MastermindRow();
        private int row = 10;
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }


        private void InitializeGUI()
        {
            tlpContainer.Controls.Clear();
            AddGuessRowToTLP();
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

        private PictureBox GetNewPictureBox(bool guess=true)
        {
            PictureBox newPictureBox;
            if (guess)
            {
                newPictureBox = new PictureBox() { BackColor = Color.Gainsboro, Size = new Size(35, 35), Enabled=true, Anchor=AnchorStyles.None};
                newPictureBox.Click += pb_Click;
            } else
            {
                newPictureBox = new PictureBox() { BackColor = Color.White, Size = new Size(15, 15), Enabled=false };
            }
            
            return newPictureBox;
        }

        //private void AddResultRowToTLP()
        //{
        //    TableLayoutPanel newPanel = new TableLayoutPanel();
        //    newPanel.ColumnCount = 4;
        //    newPanel.RowCount = 1;
        //    newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
        //    newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
        //    newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
        //    newPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
        //    newPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            
        //    newPanel.Controls.Add(new Label() { Text = "1" }, 0, 0);
        //    newPanel.Controls.Add(new Label() { Text = "2" }, 1, 0);
        //    newPanel.Controls.Add(new Label() { Text = "3" }, 2, 0);
        //    newPanel.Controls.Add(new Label() { Text = "4" }, 3, 0);
        //    tlpContainer.Controls.Add(newPanel, 1, row);
        //}
    }
}
