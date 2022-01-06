using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    public class MastermindItem
    {
        /// <summary>
        /// Class to handle MastermindItem which only has one property
        /// </summary>
        private Colors color;
        public Colors Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
    }
}