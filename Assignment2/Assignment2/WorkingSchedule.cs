/*
 * Lars Jensen
 * 2021-09-21
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class WorkingSchedule
    {
        // Using a constant here to set the last week of the schedule
        const int lastWeek = 52;
        public WorkingSchedule()
        {
            Start();
        }

        private void Start()
        {
            int chosenOption = -1;
            while (chosenOption != 0)
            {
                Console.WriteLine("Show schedule for: ");
                Console.WriteLine();
                Console.WriteLine("1: Weekend shifts");
                Console.WriteLine("2: Night shifts");
                Console.WriteLine("0: Exit");
                // Try parse to make sure we get a proper figure. I use this in the SelectionAndIteration as well
                // If user doesn't enter anything the chosenOption will be 0 and exit out.
                // One could of course check if the user input was anything, and then go back in the loop.
                int.TryParse(Console.ReadLine(), out chosenOption);
                // Instead of hardcoding the values in the call to the function I make it more clear using variables.
                int startWeek = 0;
                int interval = 0;
                switch (chosenOption)
                {
                    case 0:
                        break;
                    case 1:
                        // Here I set the individual values for the options
                        startWeek = 2;
                        interval = 3;
                        // Again, hard coding the choice instead of using chosenOption.ToString(), might be lazy
                        Console.WriteLine("Your choice: 1");
                        Console.WriteLine("List of weeks you work weekend shifts:");
                        // And here I use them in a general print method which takes the start and interval
                        printSchedule(startWeek, interval);
                        continue;
                    case 2:
                        // Here I set the individual values for the options
                        startWeek = 1;
                        interval = 4;
                        // Again, hard coding the choice instead of using chosenOption.ToString(), might be lazy
                        Console.WriteLine("Your choice: 2");
                        Console.WriteLine("List of weeks you work night shifts:");
                        // And here I use them in a general print method which takes the start and interval
                        printSchedule(startWeek, interval);
                        continue;
                }                
            }
        }
        private void printSchedule(int start, int interval)
        {
            int count;
            // Here I set the count to start with the start paramater
            for (count = start; count < lastWeek + 1; count++)
            {
                // For the initial start count we can't use the modulus, instead I check if it's the original value, print OR if modulus
                if ( count == start || (count-start) % interval == 0 )
                {
                    // To prettify the print
                    Console.Write("\tWeek " + count.ToString() + "\t");
                }
            }
            // Some extra lines to make it better looking
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }
    }
}
