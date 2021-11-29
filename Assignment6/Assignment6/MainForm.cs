using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO;

namespace Assignment6
{
    public partial class MainForm : Form
    {
        private TodoManager todoManager = new TodoManager();
        private Todo currentTodo = new Todo();        
        private DateTime time;
        private static String delimiter = ";";
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            // Also set this through GUI
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "yyyy-MM-dd HH:mm";
            txtTitle.Text = "";
            dtpDate.Value = DateTime.Now;

            cboPriority.DataSource = GetPriorities();
            // Clear items and colums
            lvTodo.Clear();
            // Show columns in listview
            lvTodo.View = View.Details;
            // Using a listView with fullrow select set to true and multiselect false to avoid weirdness when edit/delete
            // Adding columns, as it looks nicer. Although they perhaps should be automatically sized
            lvTodo.Columns.Add("Date", 75, HorizontalAlignment.Left);
            lvTodo.Columns.Add("Hour", 50, HorizontalAlignment.Left);
            lvTodo.Columns.Add("Priority", 100, HorizontalAlignment.Left);
            lvTodo.Columns.Add("Title", 250, HorizontalAlignment.Left);

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            lblTimeDisplay.Text = "00:00:00";
        }
        private List<string> GetPriorities()
        {
            List<string> prioList = new List<string>();
            foreach(PriorityType prio in Enum.GetValues(typeof(PriorityType)))
            {
                prioList.Add(prio.ToString().Replace("_", " "));
            }
            return prioList;
        }

        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open FileDIalog to save file
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save todos to file";
            saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if(saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName != "")
            {
                // Using "using" to close the file handle at end of scope
                using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                {
                    foreach (ListViewItem row in lvTodo.Items)
                    {
                        sw.WriteLine("{0}{1}{2}", row.SubItems[0].Text + " " + row.SubItems[1].Text + delimiter, row.SubItems[2].Text + delimiter, row.SubItems[3].Text + delimiter);
                    }
                }
            }
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open FileDIalog to save file
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Title = "Load todos from file";
            loadFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (loadFile.ShowDialog() == DialogResult.OK && loadFile.FileName != "")
            {
                // Using "using" to close the file handle at end of scope
                using (StreamReader reader = new StreamReader(loadFile.FileName))
                {
                    while (reader.Peek() >= 0)
                    {
                        // Load rows and create todo:
                        string line = reader.ReadLine();
                        Tuple<string, string, string> todoItems = GetValuesFromRow(line);
                        // More verbose way to program. Easier to follow
                        DateTime date = DateTime.Parse(todoItems.Item1);
                        string priority = todoItems.Item2;
                        string title = todoItems.Item3;
                        
                        todoManager.AddTodo(date, priority, title);
                        Todo todo = todoManager.GetTodo(lvTodo.Items.Count);
                        if (todo != null)
                        {
                            string[] row = {
                                todo.TodoDate.ToString("yyyy-MM-dd"),
                                todo.TodoDate.ToString("HH:mm"),
                                todo.Priority.ToString(),
                                todo.Title.ToString()
                            };
                            var listViewItem = new ListViewItem(row);
                            // TODO change color of listitem
                            //listViewItem.BackColor = Color.Red;
                            lvTodo.Items.Add(listViewItem);
                        }
                    }
                }
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeGUI();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if e-mail addresses are correctly formatted
            currentTodo.Title = txtTitle.Text;
            currentTodo.TodoDate = dtpDate.Value;
            currentTodo.Priority = cboPriority.SelectedItem.ToString();
            // Validate data before save or edit
            if (!currentTodo.ValidateData())
            {
                MessageBox.Show("You need to set a title and the date needs to be greater than now!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }else
            {
                // If we add a new todo
                if ((sender as Button).Text == "Add")
                {
                    todoManager.AddTodo(currentTodo);
                    Todo newTodo = todoManager.GetTodo(lvTodo.Items.Count);
                    if (newTodo != null)
                    {
                        string[] row = {
                        newTodo.TodoDate.ToString("yyyy-MM-dd"),
                        newTodo.TodoDate.ToString("HH:mm"),
                        newTodo.Priority.ToString(),
                        newTodo.Title.ToString()
                    };
                        var listViewItem = new ListViewItem(row);
                        // TODO change color of listitem
                        //listViewItem.BackColor = Color.Red;
                        lvTodo.Items.Add(listViewItem);                        
                    }
                    else
                    {
                        MessageBox.Show("Could not get todo!", "Invalid index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // If we edit an existing todo
                else if ((sender as Button).Text == "Save Edit")
                {
                    todoManager.EditTodo(currentTodo, lvTodo.SelectedItems[0].Index);
                    string[] row = { currentTodo.TodoDate.ToString("yyyy-MM-dd"), currentTodo.TodoDate.ToString("HH:mm"), currentTodo.Priority.ToString(), currentTodo.Title.ToString()  };
                    var listViewItem = new ListViewItem(row);
                    lvTodo.Items[lvTodo.SelectedItems[0].Index] = listViewItem;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnAdd.Text = "Add";
;               }
                // Resetting references to new objects
                currentTodo = new Todo();
                ResetGUI();

            }            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvTodo.SelectedItems.Count == 1)
            {
                // Get customer of chosen index                
                Todo currentTodo = todoManager.GetTodo(lvTodo.SelectedItems[0].Index);
                if (currentTodo != null)
                {
                    // Pass in customer object and it's index to update it.
                    txtTitle.Text = currentTodo.Title;
                    dtpDate.Value = currentTodo.TodoDate;
                    cboPriority.SelectedItem = currentTodo.Priority;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnAdd.Text = "Save Edit";
                    //// TODO Here we let currentTodo = edit. When add = editTodo
                    //todoManager.EditTodo(currentTodo, lvTodo.SelectedItems[0].Index);
                    //string[] row = { currentTodo.TodoDate.ToString("yyyy-MM-dd"), currentTodo.TodoDate.ToString("HH:mm"), currentTodo.Title.ToString(), currentTodo.Priority.ToString() };
                    //var listViewItem = new ListViewItem(row);
                    //lvTodo.Items[lvTodo.SelectedItems[0].Index] = listViewItem;                    
                }
                else
                {
                    // Should not be able to happen, but still
                    MessageBox.Show("Could not get todo!", "Invalid index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have to choose a todo to edit!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvTodo.SelectedItems.Count == 1)
            {
                // Get the index from the GUI
                int index = lvTodo.SelectedItems[0].Index;
                // Delete the row from the listview (instead of reloading all customers each time)
                // I would probably add a try catch here as not to accidentally remove customer from GUI but not from list
                lvTodo.Items.RemoveAt(index);
                // Delete the actual customer
                todoManager.DeleteTodo(index);
            }
            else
            {
                MessageBox.Show("You have to choose a customer to delete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {            
            DialogResult response = MessageBox.Show("Do you want to exit the program?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // If response is No, then cancel exit
            if (response == DialogResult.No)
            {
                e.Cancel=true;
            }
        }

        // Reset GUI
        private void ResetGUI()
        {
            txtTitle.Text = "";
            dtpDate.Value = DateTime.Now;
            cboPriority.SelectedIndex = 0;
        }

        // When item is selected, activate Edit and Delete
        private void lvTodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTodo.SelectedItems.Count > 0)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip.ShowAlways = true;

            // Timer
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            time = DateTime.Now;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(UpdateTime);            
            timer.Start();


            // Set up the ToolTip text for the Button and Checkbox.            
            toolTip.SetToolTip(this.dtpDate, "Click to open calendar for date, write time here");
        }
        private void UpdateTime(object sender, EventArgs e)
        {
            lblTimeDisplay.Text = (DateTime.Now-time).ToString("hh\\:mm\\:ss");
            Application.DoEvents();
        }        

        private Tuple<string, string, string> GetValuesFromRow(string row)
        {
            string[] rowValues = row.Split(delimiter);
            return Tuple.Create(rowValues[0], rowValues[1],rowValues[2]);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutTodo about = new AboutTodo();
            about.ShowDialog();
        }
    }
}
