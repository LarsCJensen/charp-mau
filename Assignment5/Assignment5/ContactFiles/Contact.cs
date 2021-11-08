using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.ContactFiles
{
    class Contact
    {
        /// <summary>
        /// Default constructor of class Contact
        /// </summary>
        public Contact() // THIS!!!
        {

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
                if (value != "")
                {
                    firstName = value;
                }
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
                if (value != "")
                {
                    lastName = value;
                }
            }
        }

        private Address address;
        public Address AddressData
        {
            get
            {
                return address;
            }
            set
            {
                if(value != null)
                {
                    address = value;
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






    }
}
