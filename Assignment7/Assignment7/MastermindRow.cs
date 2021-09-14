using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    public class MastermindRow
    {
        /// <summary>
        /// Class which holds a Mastermind row, which is equal to a guess
        /// </summary>
        // FUTURE Can this be made generic? List<MastermindItems>!
        private MastermindItem item1;
        public MastermindItem Item1
        {
            get
            {
                return item1;
            }            
        }
        private MastermindItem item2;
        public MastermindItem Item2
        {
            get
            {
                return item2;
            }
        }
        private MastermindItem item3;
        public MastermindItem Item3
        {
            get
            {
                return item3;
            }
        }
        private MastermindItem item4;
        public MastermindItem Item4
        {
            get
            {
                return item4;
            }
        }
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="listOfItems">List of MastermindItems which represents the guess</param>
        public MastermindRow(List<MastermindItem> listOfItems)
        {
            item1 = listOfItems[0];
            item2 = listOfItems[1];
            item3 = listOfItems[2];
            item4 = listOfItems[3];
        }        
    }
}