using System;
using System.Collections.Generic;
using System.Windows.Forms;
// Using nuget package with all countries, codes because I wanted to try it out. I don't feel that it is "cheating", but instead a way to learn more stuff about C#
// I did write my own function (getCountries) to show that I know how to write my own
using ISO3166;

namespace Assignment5
{
    public partial class ContactForm : Form
    {
        private Contact contact;
        private Country[] countries = Country.List;
        public ContactForm(Contact currentContact)
        {
            InitializeComponent();
            contact = currentContact;
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            // My own function, but will use the nuget package instead as it is better
            //cboCountry.DataSource = GetCountries();
            cboCountry.DataSource = countries;
            cboCountry.DisplayMember = "name";
            cboCountry.ValueMember = "name";
            
            if (existingCustomer())
            {
                txtFirstName.Text = contact.FirstName;
                txtLastName.Text = contact.LastName;

                txtBusinessPhone.Text = contact.PhoneData.BusinessPhone;
                txtPrivatePhone.Text = contact.PhoneData.PrivatePhone; 
                txtEmailBusiness.Text = contact.EmailData.EmailBusiness;
                txtEmailPrivate.Text = contact.EmailData.EmailPrivate;

                txtStreet.Text = contact.AddressData.Street;
                txtCity.Text = contact.AddressData.City;
                txtZipCode.Text = contact.AddressData.Zipcode;
                cboCountry.Text = contact.AddressData.Country;
            }
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            // If existing contact is passed to the form then change text of the form
            this.Text = "Add new contact";
            if (existingCustomer())
            {
                this.Text = "Edit " + contact.FirstName + " " + contact.LastName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
            
            contact.PhoneData = new Phone(txtBusinessPhone.Text, txtPrivatePhone.Text);

            // Check if e-mail addresses are correctly formatted
            try
            {
                contact.EmailData = new Email(txtEmailBusiness.Text, txtEmailPrivate.Text);
            } catch (ArgumentException ex)
            {
                // If not, catch the exception and show the message box.
                MessageBox.Show(ex.Message, "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }

            // Because the assignment requires Address to be overloaded this weird if block is needed to target the correct constructor
            if ((txtCity.Text != "" && cboCountry.SelectedValue.ToString() != "") && (txtStreet.Text == "" && txtZipCode.Text == ""))
            {
                // Only city and country is set
                contact.AddressData = new Address(txtCity.Text, ((ISO3166.Country)cboCountry.SelectedItem).Name);
            } else if ((txtCity.Text != "" && cboCountry.SelectedValue.ToString() != "" && txtStreet.Text != "") && txtZipCode.Text == "") {
                // Only city and country and street is set
                contact.AddressData = new Address(txtCity.Text, ((ISO3166.Country)cboCountry.SelectedItem).Name, txtStreet.Text);
            }
            else
            {
                // Set all fields and let validation fail if city and country is not set
                contact.AddressData = new Address(txtCity.Text, ((ISO3166.Country)cboCountry.SelectedItem).Name, txtStreet.Text, txtZipCode.Text);
            }                

            if (!contact.ValidateData())
            {
                MessageBox.Show("You need to add information for First or last name and both city and country!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Avoid dialog from closing if input is wrong
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            AskOnClose();
        }

        // A bit crude check if contact is an existing contact or a new one, but since either FirstName or LastName is required than if both is null or empty then it's a new contact
        private bool existingCustomer()
        {
            if (!(string.IsNullOrEmpty(contact.FirstName) && string.IsNullOrEmpty(contact.LastName)))
            {
                return true;
            }
            return false;
        }
        
        // Returns array of countries to be used in combobox from enums
        private List<string> GetCountries()
        {
            List<string> countriesList = new List<string>();
            foreach (Countries country in Enum.GetValues(typeof(Countries)))
            {
                countriesList.Add(country.ToString().Replace("_", " "));
            }           

            return countriesList;
        }

        // Only used for testing
        private void btnFillConcact_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "Test";
            txtLastName.Text = "Testsson";
            txtBusinessPhone.Text = "0708-9998882";
            txtPrivatePhone.Text = "052-35124";
            txtEmailBusiness.Text = "test@company.com";
            txtEmailPrivate.Text = "personal@email.com";
            txtStreet.Text = "Street 1";
            txtCity.Text = "City 5";
            txtZipCode.Text = "123 45";
            cboCountry.Text = "Sweden";
        }

        // Handle if you also close the form
        private void ContactForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason != CloseReason.None || e.Cancel == true)
            {
                AskOnClose();
            }
            
        }
        // Function to ask if user wants to close without saving.
        private void AskOnClose()
        {
            DialogResult response = MessageBox.Show("Do you want to leave the contact form without saving?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // If response is No, then stay on the form
            if (response == DialogResult.No)
            {
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
