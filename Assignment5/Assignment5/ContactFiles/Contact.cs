using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// Class which holds contact object
    /// </summary>
    public class Contact
    {
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
        private Email emailData;
        public Email EmailData
        {
            get
            {
                return emailData;
            }
            set
            {
                if (value != null)
                {
                    emailData = value;
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

        /// <summary>
        /// Default constructor of class Contact
        /// </summary>
        public Contact()
        {

        }

        
        public Contact(Contact toCopy)
        {
            firstName = toCopy.FirstName;
            lastName = toCopy.LastName;
            addressData = toCopy.AddressData;
            emailData = toCopy.EmailData;
            PhoneData = toCopy.PhoneData;
        }
        /// <summary>
        /// Validates contact data according to set of rules
        /// </summary>
        /// <returns></returns>
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
