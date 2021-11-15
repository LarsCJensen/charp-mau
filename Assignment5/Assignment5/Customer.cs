using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment5
{
    public class Customer
    {
        private Contact contact;
        public Contact Contact 
        {
            get {
                return contact;
            }
            set
            {
                if(value != null)
                {
                    contact = value;
                }
            }
        }
        private Guid contactId;
        public Guid ContactId
        {
            // Only allowed to get
            get
            {
                return contactId;
            }
         }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Customer() 
        {
            // TODO Default values??
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        public Customer(Contact newContact)
        {
            // Create a new Guid which will identify the customer
            // TODO Generate ID - have counter
            contactId = Guid.NewGuid();
            contact = newContact;
        }        
    }
}
