using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// This class holds all customers and is responsible for CRUD of them
    /// </summary>
    class CustomerManager
    {
        private List<Customer> customers = new List<Customer>();
        public CustomerManager()
        {            
        }
        /// <summary>
        /// Add a customer to the customers list.
        /// </summary>
        /// <param name="newContact"></param>
        public void AddCustomer(Contact newContact)
        {
            Customer newCustomer = new Customer(newContact);
            customers.Add(newCustomer);
        }
        /// <summary>
        /// Edit customer
        /// </summary>
        /// <param name="editedCustomer">customer information to replace with</param>
        /// <param name="index">Index of customer</param>
        public void EditCustomer(Customer editedCustomer, int index)
        {
            customers[index] = editedCustomer;
        }
        /// <summary>
        /// Delete customer at index
        /// </summary>
        /// <param name="index">index of customer to delete</param>
        public void DeleteCustomer(int index)
        {
            customers.RemoveAt(index);
        }
        /// <summary>
        /// Get customer at index.
        /// </summary>
        /// <param name="customerIndex">Index to get customer for. Returns null if index is out of bounds</param>
        /// <returns></returns>
        public Customer GetCustomer(int customerIndex)
        {
            if(customerIndex >= 0 && customerIndex <= customers.Count-1)
            {
                return customers[customerIndex];
            }
            return null;            
        }

        /// <summary>
        /// Method to copy contact data of customer
        /// </summary>
        /// <param name="customerIndex">Index of customer</param>
        /// <returns></returns>
        public Contact CopyContact(int customerIndex)
        {
            Contact contactCopy = new Contact(customers[customerIndex].Contact);
            return contactCopy;
        }
    }
}
