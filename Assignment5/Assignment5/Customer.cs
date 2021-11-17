using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment5
{
    /// <summary>
    /// This class holds id and contact information. Id is calculated and incremented by 1.
    /// </summary>
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
        // Switched from Guid to an "own" id
        //private Guid contactId;
        //public Guid ContactId
        //{
        //    // Only allowed to get
        //    get
        //    {
        //        return contactId;
        //    }
        //}
        // Needs to be static so it is increased
        private static int idCounter = 1000;
        private int customerId;
        public int CustomerId
        {
            // Only allowed to get
            get
            {
                return customerId;
            }
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        public Customer(Contact newContact)
        {
            // Create a new Guid which will identify the customer (Not used, using "own" id calculator)
            //contactId = Guid.NewGuid();

            customerId = getCustomerId();
            contact = newContact;
        }

        /// <summary>
        /// Perhaps overkill with a helper method for this, but it gives an abstraction in case we want to change how id's are set.
        /// </summary>
        /// <returns></returns>
        private int getCustomerId()
        {
            idCounter = idCounter += 1;
            return idCounter;
        }
    }
}
