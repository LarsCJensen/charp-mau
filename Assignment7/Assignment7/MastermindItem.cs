using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    public class MastermindItem
    {
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
        //public Enums Enums
        //{
        //    get => default;
        //    set
        //    {
        //    }
        //}
        public MastermindItem()
        {
            // Default constructor
        }
    }
}