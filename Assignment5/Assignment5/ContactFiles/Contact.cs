using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Contact
    {
        /// <summary>
        /// Default constructor of class Contact
        /// </summary>
        public Contact() // THIS!!!
        {
            // Required to provide: 
            // 1. first name or last name
            // 2 city AND country
        }

        public Contact(Contact toCopy)
        {

        }
        public Contact(string firstName, string lastName, Address address, Phone phone, Email email)
        {

        }


        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        private Address addressData;
        public Address AddressData
        {
            get
            {
                return addressData;
            }
            set
            {
                if(value != null)
                {
                    addressData = value;
                }
            }
        }
        private Email email;
        public Email EmailData
        {
            get
            {
                return email;
            }
            set
            {
                if (value != null)
                {
                    email = value;
                }
            }
        }

        private Phone phone;
        public Phone PhoneData
        {
            get
            {
                return phone;
            }
            set
            {
                if (value != null)
                {
                    phone = value;
                }
            }
        }
        public bool ValidateData() 
        {
            // If data is valid according to rules:
            // Required to provide: 
            // 1. first name or last name
            // 2 city AND country
            if ((string.IsNullOrEmpty(firstName) && 
                string.IsNullOrEmpty(lastName)) || 
                (string.IsNullOrEmpty(addressData.City) || 
                string.IsNullOrEmpty(addressData.Country)))
            {
                return false;
            }
            return true;            
        }






    }
}
