/*
 * 2021-11-16
 * Lars Jensen
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Assignment5
{
    public partial class MainForm : Form
    {
        private CustomerManager customerManager = new CustomerManager();
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
            lvRegistry.Columns.Add("Name (SURNAME, First name)", -2, HorizontalAlignment.Left);
            lvRegistry.Columns.Add("Business phone", -2, HorizontalAlignment.Left);
            lvRegistry.Columns.Add("Business e-mail", 150, HorizontalAlignment.Left);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm(currentContact);            
            DialogResult dlgResult = contactForm.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                customerManager.AddCustomer(currentContact);
                Customer currentCustomer = customerManager.GetCustomer(lvRegistry.Items.Count);
                // This should not be possible, but adding the check anyway
                if(currentCustomer != null) { 
                    string[] row = { currentCustomer.CustomerId.ToString(), currentContact.LastName.ToUpper() + ", " + currentContact.FirstName, currentContact.PhoneData.BusinessPhone.ToString(), currentContact.EmailData.EmailBusiness.ToString() };
                    var listViewItem = new ListViewItem(row);
                    lvRegistry.Items.Add(listViewItem);

                    // Resetting references to new objects
                    currentContact = new Contact();
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
                Customer currentCustomer = customerManager.GetCustomer(lvRegistry.SelectedItems[0].Index);
                if (currentCustomer != null)
                {                    
                    ContactForm contactForm = new ContactForm(currentCustomer.Contact);
                    DialogResult dlgResult = contactForm.ShowDialog();
                    if (dlgResult == DialogResult.OK)
                    {
                        // Pass in customer object and it's index to update it.
                        customerManager.EditCustomer(currentCustomer, lvRegistry.SelectedItems[0].Index);
                        string[] row = { currentCustomer.CustomerId.ToString(), currentCustomer.Contact.LastName.ToUpper() + ", " + currentCustomer.Contact.FirstName, currentCustomer.Contact.PhoneData.BusinessPhone.ToString(), currentCustomer.Contact.EmailData.EmailBusiness.ToString() };
                        var listViewItem = new ListViewItem(row);
                        lvRegistry.Items[lvRegistry.SelectedItems[0].Index] = listViewItem;
                    }
                } else
                {
                    // Should not be able to happen, but still
                    MessageBox.Show("Could not get customer!", "Invalid index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
            else
            {
                MessageBox.Show("You have to choose a customer to edit!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvRegistry.SelectedItems.Count == 1)
            {
                // Get the index from the GUI
                int index = lvRegistry.SelectedItems[0].Index;                                
                // Delete the row from the listview (instead of reloading all customers each time)
                // I would probably add a try catch here as not to accidentally remove customer from GUI but not from list
                lvRegistry.Items.RemoveAt(index);
                // Delete the actual customer
                customerManager.DeleteCustomer(index);
            }
            else
            {
                MessageBox.Show("You have to choose a customer to delete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lvRegistry_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbDetails.Items.Clear();
            if (lvRegistry.SelectedItems.Count == 1)
            {
                // I feel that it should be the frontend's resposibility to decide how the
                // information is displayed. Thus not adding a helper function to customer manager
                Customer selectedCustomer = customerManager.GetCustomer(lvRegistry.SelectedItems[0].Index);
                if (selectedCustomer != null)
                {
                    List<string> customerString = getCustomerString(selectedCustomer);
                    foreach (string info in customerString)
                    {
                        lbDetails.Items.Add(info);
                    }
                }
                else
                {
                    MessageBox.Show("Could not get customer!", "Invalid index!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // A helper function to create a collection to show details
        private List<string> getCustomerString(Customer customer)
        {            
            List<string> customerInfo = new List<string>();
            
            customerInfo.Add("----- CONTACT DETAILS -----");
            customerInfo.Add("");
            // Using Trim() so the line won't have an ugly space if firstName is not set
            customerInfo.Add((customer.Contact.FirstName + " " + customer.Contact.LastName).Trim());
            customerInfo.Add(customer.Contact.AddressData.Street);
            // Using Trim() so the line won't have an ugly space if Zipcode is not set
            customerInfo.Add((customer.Contact.AddressData.Zipcode + " " + customer.Contact.AddressData.City).Trim());
            customerInfo.Add(customer.Contact.AddressData.Country);
            customerInfo.Add("");
            customerInfo.Add("E-mail(s)");
            customerInfo.Add(" Business \t" + customer.Contact.EmailData.EmailBusiness);
            customerInfo.Add(" Private \t" + customer.Contact.EmailData.EmailPrivate);

            customerInfo.Add("");
            customerInfo.Add("Phone number(s)");
            customerInfo.Add(" Business \t" + customer.Contact.PhoneData.BusinessPhone);
            customerInfo.Add(" Private \t" + customer.Contact.PhoneData.PrivatePhone);

            return customerInfo;
        }

        // Wanted to add a way to copy an existing customer. Usually wanted in a CRM system.
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (lvRegistry.SelectedItems.Count == 1)
            {
                // Get customer of chosen index                
                //Customer currentCustomer = customerManager.GetCustomer(lvRegistry.SelectedItems[0].Index);
                Contact contactCopy = customerManager.CopyContact(lvRegistry.SelectedItems[0].Index);
                customerManager.AddCustomer(contactCopy);
                Customer newCustomer = customerManager.GetCustomer(lvRegistry.Items.Count);
                DialogResult response = MessageBox.Show("Do you want to edit the copied customer now?", "Edit copied customer?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(response == DialogResult.Yes)
                {
                    ContactForm contactForm = new ContactForm(newCustomer.Contact);
                    DialogResult dlgResult = contactForm.ShowDialog();
                }
                string[] row = { newCustomer.CustomerId.ToString(), newCustomer.Contact.LastName.ToUpper() + ", " + newCustomer.Contact.FirstName, newCustomer.Contact.PhoneData.BusinessPhone.ToString(), newCustomer.Contact.EmailData.EmailBusiness.ToString() };
                var listViewItem = new ListViewItem(row);
                lvRegistry.Items.Add(listViewItem);
            }
            else
            {
                MessageBox.Show("You have to choose a customer to copy!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
