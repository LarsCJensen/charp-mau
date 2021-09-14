/* 
 * 2021-09-14
 * Author: Lars Jensen 
 */

using System;

namespace Assignment1AB
{
    public class Game
    {
        // Making it constant
        const int fixedValue = 250;
        private string name;
        private double value;
        private int chosenPlatform;
        private DateTime lastSoldOn;
        // Array of platforms to choose from
        private string[] platforms = new string[] { "PC", "NES", "SNES", "Atari", "SMS", "SMD" };

        public void Start()
        {
            SetGameValue();
            PrintGameInformation();
            
        }
        private void SetGameValue()
        {
            Console.WriteLine("Which game do you want to check the value of?");
            name = Console.ReadLine();
            // Will loop until you write a correct one, but does not match case
            do
            {
                Console.WriteLine("Choose platform from one of:");
                Console.WriteLine("[{0}]", string.Join(", ", platforms));
                string response = Console.ReadLine();
                // I could just as well have used the chosenPlatform as a string, but I wanted to use the index of the array instead to see how that works.
                int foundPlatform = (Array.IndexOf(platforms, response.ToUpper()));
                if (foundPlatform != -1)
                {
                    // Again, I could just as well have used the sent in string, but wanted to use the index of the array
                    chosenPlatform = foundPlatform;
                    // The + 1 is to get a the fixedValue times a random percentage to get a double value
                    value = fixedValue * (1 + GetRandomDoubleValue());
                    lastSoldOn = GetRandomDate();
                    break;
                }
            } while (true);
        }
        private void PrintGameInformation()
        {
            Console.WriteLine("The game : " + name);
            Console.WriteLine("For platform: " + platforms[chosenPlatform]);
            // If I wanted to round the double I would save it in a string and use string.Format to only show two decimals)
            Console.WriteLine("Is valued to $" + value.ToString());
            // I only want to print out the date, not the timestamp.
            Console.WriteLine("Last sold copy of the game was on " + lastSoldOn.ToString("yyyy/MM/dd"));
            Console.WriteLine();
            Console.WriteLine("But don't sell it!");
        }
        // Could be added to a helper class instead if it was to be re-used
        private double GetRandomDoubleValue()
        {
            // Since I use it in GetRandomDate too it should perhaps be a member variable instead.
            Random random = new Random();
            // NextDouble will be a double between 0 and 1
            return random.NextDouble();            
        }
        // Could be added to a helper class instead if it was to be re-used
        private DateTime GetRandomDate()
        {
            // Since I use it in above too it should perhaps be a member variable instead.
            Random random = new Random();
            DateTime startDate = new DateTime(1985, 1, 1);
            int range = (DateTime.Today - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }
    }
}
