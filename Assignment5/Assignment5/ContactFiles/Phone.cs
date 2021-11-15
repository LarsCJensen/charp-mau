using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Phone
    {
        private string homePhone;
        public string HomePhone
        {
            get
            {
                return homePhone;
            }
            set
            {
                if (value != null)
                {
                    homePhone = value;
                }
            }
        }
        private string cellPhone;
        public string CellPhone
        {
            get
            {
                return cellPhone;
            }
            set
            {
                if (value != null)
                {
                    cellPhone = value;
                }
            }
        }

        public Phone(): this("")
        {
            // Setting default values
            homePhone = "";
            cellPhone = "";
        }

        public Phone(string newPhone) : this(newPhone, "")
        {
            // TODO If newPhone starts with 07X...
            homePhone = newPhone;
        }

        public Phone(string newHomePhone, string newCellPhone)
        {
            homePhone = newHomePhone;
            cellPhone = newCellPhone;            
        }
    }
}
