using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Phone
    {
        private string businessPhone;
        public string BusinessPhone
        {
            get
            {
                return businessPhone;
            }            
        }

        private string privatePhone;
        public string PrivatePhone
        {
            get
            {
                return privatePhone;
            }            
        }       
        /// <summary>
        /// As phone numbers aren't required we create a default constructor which passes values through chain calling
        /// </summary>
        public Phone(): this("")
        {         
        }

        public Phone(string newPhone) : this(newPhone, "")
        {
            // TODO If newPhone starts with 07X...
            privatePhone = newPhone;
        }

        public Phone(string newHomePhone, string newCellPhone)
        {
            privatePhone = newHomePhone;
            businessPhone = newCellPhone;            
        }
    }
}
