/*
 * Lars Jensen
 * 2021-09-20
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class SelectionAndIteration
    {
        // Declaring it as a static readonly, private to this class. Might have use for it in more places.
        private static readonly List<string> validDays = new List<string>(new string[] { "1", "2", "3", "4", "5", "6", "7" });
        public SelectionAndIteration()
        {
            Console.WriteLine();
            Console.WriteLine("My name is: Lars Jensen I am a student of the HT21 semester!");
            Console.WriteLine();

            Console.WriteLine("Let me calculate the length of strings for you!");
            // I chose to keep this code in the public method and not moving it into ShowStringLength as that has a single purpose.
            // I would probably not clutter the public method in a real case this much though. It should be kept short.
            do
            {
                Console.WriteLine("Give me a text of any length, or press Enter to exit!");
                string inputStr = Console.ReadLine();
                if (inputStr.Length > 0)
                {
                    ShowStringLength(inputStr);
                }
                else
                {
                    break;
                }

            } while (true);


            Console.WriteLine();

            Console.WriteLine("Let me tell you the week day!");
            // Looping until the user has input a value that is betweek 1 and 7
            do
            {
                Console.WriteLine("Please enter a number between 1 and 7:");
                string numberOfDay = Console.ReadLine();
                // Using the read only list to validate the accepted input
                if (validDays.Any(numberOfDay.Contains))
                {
                    MakeMyDay(numberOfDay);
                    Console.WriteLine();
                    //Break the loop
                    break;
                }
            } while (true);


            Console.WriteLine("Let me calculate sum between numbers!");
            int x;
            int y;
            string input; 
            // Loop until the user input is able to be converted to int
            do
            {
                Console.WriteLine("Give start number: ");
                do
                {                    
                    input = Console.ReadLine();
                    // If it is not parsable then we loop until it is.
                    if (Int32.TryParse(input, out x))
                    {
                        break;
;                   } else
                    {
                        Console.WriteLine("Please enter a proper start number: ");
                    }
                } while (true);
                Console.WriteLine("Give end number: ");
                input = Console.ReadLine();
                // Using TryParse here to make sure we get a number as input, or rather a string which can be parsed as int as input.
                // If too big then it will ask again.
                if (Int32.TryParse(input, out y))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a proper end number: ");
                }

            } while (true);
            
            int sum = SumNumbers(x, y);
            Console.WriteLine("The sum of numbers between " + x.ToString() + " and " + y.ToString() + " is: " + sum.ToString());
        }
        // Could have chosen to have this public in case it is to be called directly. But didn't in this case.
        private void ShowStringLength(string str)
        {
            Console.Write("The string \"" + str + "\" has the length of " + str.Length + " characters!\n");
        }
        
        // Could have chosen to have this public in case it is to be called directly. But didn't in this case
        private void MakeMyDay(string day) // I'll keep it as string instead of casting it to integer. Feels unnecessary.
        {
            switch (day)
            {                 
                case "1":
                    Console.WriteLine("Monday: Keep calm! You can fall apart!");
                    break;
                case "2":
                    Console.WriteLine("Tuesday and Wednesday break your heart!");
                    break;
                case "3":
                    Console.WriteLine("Tuesday and Wednesday break your heart!");
                    break;
                case "4":
                    Console.WriteLine("Thursday, Uuush, still one day to Friday!");
                    break;
                case "5":
                    Console.WriteLine("It's Friday! You are in love!");
                    break;
                case "6":
                    Console.WriteLine("Saturday, do nothing and do plenty of it!");
                    break;
                case "7":
                    Console.WriteLine("And Sunday always comes too soon!" );
                    break;
                default:
                    Console.WriteLine("Not in a good mood? This is not a valid date!");
                    break;

            }
        }
        private int SumNumbers(int x, int y)
        {
            int count;
            int sum = 0; 
            // If the start is less and or equal to
            if(x <= y)
            {
                // We need to add y + 1 to make sure we iterate over the y value
                for(count = x; count < y + 1; count++)
                {
                    sum += count;
                }
            }
            else
            {
                // If you put in a lower number as y we switch them
                // We need to add x + 1 to make sure we iterate over the x value
                for (count = y; count < x + 1; count++)
                {
                    sum += count;
                }
            }
            return sum;
        }
    }
}
