using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class CustomerManager
    {
        private List<Customer> customers = new List<Customer>();
        public CustomerManager()
        {
            // TODO WHat do do here? DEFAULT VALUES?
        }
        public void AddCustomer(Contact newContact)
        {
            Customer newCustomer = new Customer(newContact);
            customers.Add(newCustomer);
        }

        public void EditCustomer(Customer editedCustomer, int index)
        {
            customers[index] = editedCustomer;
        }

        public void DeleteCustomer(int index)
        {
            customers.RemoveAt(index);
        }

        public Customer GetCustomer(int customerIndex)
        {
            if(customerIndex >= 0 && customerIndex <= customers.Count-1)
            {
                return customers[customerIndex];
            }
            return null;            
        }
    }
}
