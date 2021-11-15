using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment5
{
    public partial class MainForm : Form
    {
        private CustomerManager customerManager = new CustomerManager();
        private Customer currentCustomer = new Customer();
        private Contact currentContact = new Contact();
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            // Show columns in listview
            lvRegistry.View = View.Details;
            // Using a listView with fullrow select set to true and multiselect false to avoid weirdness when edit/delete
            // Adding columns, as it looks nicer. Although they perhaps should be automatically sized
            lvRegistry.Columns.Add("ID", 50, HorizontalAlignment.Left);
            lvRegistry.Columns.Add("Name (Surname, first name)", -2, HorizontalAlignment.Left);
            lvRegistry.Columns.Add("Office phone", -2, HorizontalAlignment.Center);
            lvRegistry.Columns.Add("Office e-mail", 150, HorizontalAlignment.Left);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm(currentContact);            
            DialogResult dlgResult = contactForm.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                customerManager.AddCustomer(currentContact);
                currentCustomer = customerManager.GetCustomer(lvRegistry.Items.Count);
                if(currentCustomer != null) { 
                    // TODO Validate data?
                    string[] row = { currentCustomer.ContactId.ToString(), currentContact.LastName.ToUpper() + ", " + currentContact.FirstName, currentContact.PhoneData.CellPhone.ToString(), currentContact.EmailData.EmailBusiness.ToString() };
                    var listViewItem = new ListViewItem(row);
                    lvRegistry.Items.Add(listViewItem);

                    // Setting references to new objects
                    currentCustomer = new Customer();
                    currentContact = new Contact();
                        //if (currentRecipe.GetNumberOfIngredients() <= 0)
                    //{
                    //    MessageBox.Show("No ingredients specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    MessageBox.Show("Could not get customer!", "Invalid index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvRegistry.SelectedItems.Count == 1)
            {
                // Get customer of chosen index                
                currentCustomer = customerManager.GetCustomer(lvRegistry.SelectedItems[0].Index);
                if (currentCustomer != null)
                {                    
                    ContactForm contactForm = new ContactForm(currentCustomer.Contact);
                    DialogResult dlgResult = contactForm.ShowDialog();
                    if (dlgResult == DialogResult.OK)
                    {
                        // TODO
                        customerManager.EditCustomer(currentCustomer, lvRegistry.SelectedItems[0].Index);
                        string[] row = { currentCustomer.ContactId.ToString(), currentCustomer.Contact.LastName.ToUpper() + ", " + currentCustomer.Contact.FirstName, currentCustomer.Contact.PhoneData.CellPhone.ToString(), currentCustomer.Contact.EmailData.EmailBusiness.ToString() };
                        var listViewItem = new ListViewItem(row);
                        lvRegistry.Items[lvRegistry.SelectedItems[0].Index] = listViewItem;
                    }
                } else
                {
                    MessageBox.Show("Could not get customer!", "Invalid index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("You have to choose a contact to edit!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvRegistry.SelectedItems.Count == 1)
            {
                // Get the index from the GUI
                int index = lvRegistry.SelectedItems[0].Index;
                // Delete the row from the listview (instead of reloading all customers each time)
                lvRegistry.Items.RemoveAt(index);
                // Delete the actual customer
                customerManager.DeleteCustomer(index);
            }
            else
            {
                MessageBox.Show("You have to choose a recipe to delete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
