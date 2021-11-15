using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment5.ContactFiles;
// Using nuget package with all countries, codes because I wanted to try it out. 
// I wrote my own function (GetCountries) to show that I know how
using ISO3166;

namespace Assignment5
{
    public partial class ContactForm : Form
    {
        private Contact contact;
        private Country[] countries = ISO3166.Country.List;
        public ContactForm(Contact currentContact)
        {
            InitializeComponent();
            contact = currentContact;
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            // My own function, but will use the nuget package instead as it is better
            cboCountry.DataSource = GetCountries();
            cboCountry.DataSource = countries;
            cboCountry.DisplayMember = "name";
            cboCountry.ValueMember = "name";
            // Check if contact is an existing contact or a new one
            if (!(string.IsNullOrEmpty(contact.FirstName) && string.IsNullOrEmpty(contact.LastName)))
            {
                txtFirstName.Text = contact.FirstName;
                txtLastName.Text = contact.LastName;

                txtHomePhone.Text = contact.PhoneData.HomePhone;
                txtCellPhone.Text = contact.PhoneData.CellPhone;
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
            //if currentCustomer is given then change text of form
            this.Text = "Add new customer";
            // Check if contact is an existing contact or a new one
            if (!(string.IsNullOrEmpty(contact.FirstName) && string.IsNullOrEmpty(contact.LastName)))
            {
                this.Text = contact.FirstName + " " + contact.LastName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
            // TODO Only pass values that are set, also validate them
            if (txtHomePhone.Text != "")
            {

            }
            contact.PhoneData = new Phone(txtHomePhone.Text, txtCellPhone.Text);

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


            // Hur ska vi göra här?
            contact.AddressData = new Address(txtCity.Text, ((ISO3166.Country)cboCountry.SelectedItem).Name, txtStreet.Text, txtZipCode.Text);

            if (!contact.ValidateData())
            {

                MessageBox.Show("You need to add information for First or last name and both city and country!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Avoid dialog from closing if input is wrong
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("Do you want to leave the contact form without saving?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(response == DialogResult.No)
            {
                this.DialogResult = DialogResult.None;
            }
        }
        /// <summary>
        /// Returns array of countries to be used in combobox
        /// </summary>
        /// <returns></returns>
        private List<string> GetCountries()
        {
            List<string> countriesList = new List<string>();
            foreach (Countries country in Enum.GetValues(typeof(Countries)))
            {
                countriesList.Add(country.ToString().Replace("_", " "));
            }
            //int noOfCountries = countriesArray.Length;
            //string[] countriesList = new string[noOfCountries];
            //for(int i = 0; i < countriesList.Length; i++)
            //{
            //    countriesList[i] = countriesArray[i];
            //}

            return countriesList;
        }
    }
}
