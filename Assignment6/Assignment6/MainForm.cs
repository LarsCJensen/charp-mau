/*
 * 2021-12-02
 * Lars Jensen
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
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
            lvTodo.Columns.Add("Title", 350, HorizontalAlignment.Left);

            // lvTodo is sorted by date, as it makes sense

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            lblTimeDisplay.Text = "00:00:00";

            // Clear all todos
            todoManager.ClearTodos();            
        }
        // Get priorities from Enum
        private List<string> GetPriorities()
        {
            List<string> prioList = new List<string>();
            foreach(PriorityType prio in Enum.GetValues(typeof(PriorityType)))
            {
                // Beautify the list
                prioList.Add(prio.ToString().Replace("_", " "));
            }
            return prioList;
        }
        // Save file
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
        // Load saved file
        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open FileDIalog to save file
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Title = "Load todos from file";
            loadFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (loadFile.ShowDialog() == DialogResult.OK && loadFile.FileName != "")
            {
                InitializeGUI();
                // Using "using" to close the file handle at end of scope
                using (StreamReader reader = new StreamReader(loadFile.FileName))
                {
                    while (reader.Peek() >= 0)
                    {
                        // Load rows and create todo:
                        string line = reader.ReadLine();
                        Tuple<string, string, string> todoItems = GetValuesFromRow(line);
                        // More verbose way to program, but easier to follow
                        DateTime date = DateTime.Parse(todoItems.Item1);
                        string priority = todoItems.Item2;
                        string title = todoItems.Item3;
                        
                        Todo todo = todoManager.AddTodo(date, priority, title);
                        if (todo != null)
                        {
                            string[] row = {
                                todo.TodoDate.ToString("yyyy-MM-dd"),
                                todo.TodoDate.ToString("HH:mm"),
                                todo.Priority.ToString(),
                                todo.Title.ToString()
                            };
                            var listViewItem = new ListViewItem(row);
                            listViewItem.Tag = todo.TodoId;
                            // If loaded todos are older than now, make them disabled
                            if (todo.TodoDate < DateTime.Now)
                            {
                                listViewItem.ForeColor = Color.DarkGray;
                            }
                            lvTodo.Items.Add(listViewItem);
                        }
                    }
                }
            }
            // To create a new reference with correct id
            currentTodo = new Todo();
        }
        // Reset program
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Reset id counter
            currentTodo.ResetTodoID();
            InitializeGUI();
        }
        // Add or save edit of todo
        private void btnAdd_Click(object sender, EventArgs e)
        {
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
                    //Todo newTodo = todoManager.GetTodo(currentTodo.TodoId);
                    if (currentTodo != null)
                    {
                        string[] row = {
                        currentTodo.TodoDate.ToString("yyyy-MM-dd"),
                        currentTodo.TodoDate.ToString("HH:mm"),
                        currentTodo.Priority.ToString(),
                        currentTodo.Title.ToString()
                    };
                        var listViewItem = new ListViewItem(row);
                        listViewItem.Tag = currentTodo.TodoId;
                        lvTodo.Items.Add(listViewItem);                        
                    }
                    else
                    {
                        // Should not happen
                        MessageBox.Show("Could not get todo!", "Invalid index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }
                // If we edit an existing todo
                else if ((sender as Button).Text == "Save Edit")
                {                    
                    todoManager.EditTodo(currentTodo, currentTodo.TodoId);
                    string[] row = { 
                        currentTodo.TodoDate.ToString("yyyy-MM-dd"), 
                        currentTodo.TodoDate.ToString("HH:mm"), 
                        currentTodo.Priority.ToString(), 
                        currentTodo.Title.ToString()  
                    };
                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = currentTodo.TodoId;
                    lvTodo.Items[lvTodo.SelectedItems[0].Index] = listViewItem;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnAdd.Text = "Add";
               }
                // Resetting references to new objects and GUI
                // This will "forsake" id:s however, since we can edit an existing todo. Not that big of a deal
                currentTodo = new Todo();
                ResetGUI();
            }            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvTodo.SelectedItems.Count == 1)
            {
                // Get customer of chosen index                
                currentTodo = todoManager.GetTodo((int)lvTodo.SelectedItems[0].Tag);
                if (currentTodo != null)
                {
                    // Disable listView
                    lvTodo.Enabled = false;
                    // Pass in customer object and it's index to update it.
                    txtTitle.Text = currentTodo.Title;
                    dtpDate.Value = currentTodo.TodoDate;
                    cboPriority.SelectedItem = currentTodo.Priority;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    // Change Add to Edit to use the same process as when adding
                    btnAdd.Text = "Save Edit";                    
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
        // Delete Todo
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvTodo.SelectedItems.Count == 1)
            {
                // Get selected todo
                currentTodo = todoManager.GetTodo((int)lvTodo.SelectedItems[0].Tag);
                if (currentTodo != null) { 
                    // Get the index from the GUI
                    int index = lvTodo.SelectedItems[0].Index;
                    // Delete the row from the listview
                    // I would probably add a try catch here as not to accidentally remove item from GUI but not from list
                    lvTodo.Items.RemoveAt(index);
                    // Delete the actual todo
                    todoManager.DeleteTodo(currentTodo.TodoId);
                    currentTodo = new Todo();
                }
                else
                {
                    // Should not be able to happen, but still
                    MessageBox.Show("Could not get todo!", "Invalid index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            
            }
            else
            {
                MessageBox.Show("You have to choose a todo to delete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // On close form
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult response = CloseForm();
            if (response == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // Reset GUI
        private void ResetGUI()
        {
            txtTitle.Text = "";
            dtpDate.Value = DateTime.Now;
            cboPriority.SelectedIndex = 0;
            lvTodo.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        // When item is selected, activate Edit and Delete
        private void lvTodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If you load todos older than now then they are greyed out.
            // If those are chosen, you can only delete them.
            if (lvTodo.SelectedItems.Count > 0 && lvTodo.SelectedItems[0].ForeColor != Color.DarkGray)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }else if(lvTodo.SelectedItems.Count > 0 && lvTodo.SelectedItems[0].ForeColor == Color.DarkGray)
            {
                btnEdit.Enabled = false;
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

            // Set up the ToolTip text for the Button and Checkbox.            
            toolTip.SetToolTip(this.dtpDate, "Click to open calendar for date, write time here");

            // Timer
            Timer timer = new Timer();
            time = DateTime.Now;
            timer.Interval = 1000;
            // Call each second
            timer.Tick += new EventHandler(UpdateTime);            
            timer.Start();
        }
        // Update time each second
        private void UpdateTime(object sender, EventArgs e)
        {
            lblTimeDisplay.Text = (DateTime.Now-time).ToString("hh\\:mm\\:ss");
            // So program doesn't hang.
            Application.DoEvents();
        }        
        // Helper function to read row from file
        private Tuple<string, string, string> GetValuesFromRow(string row)
        {
            string[] rowValues = row.Split(delimiter);
            return Tuple.Create(rowValues[0], rowValues[1],rowValues[2]);
        }
        // Open About dialog
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutTodo about = new AboutTodo();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Application.Exit();        
        }

        private DialogResult CloseForm()
        {
            DialogResult response = MessageBox.Show("Do you want to exit the program?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // If response is No, then cancel exit
            return response;
            
        }
    }
}
