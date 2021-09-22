using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class TemperatureConverter
    {
        // Chose to have the constants here instead of inside the conveter method.
        // Figured it was better suited as a class property. Perhaps it should be a Celcius/Fahrenheit class with class attributes which TemeratureConverter could use...
        const int celciusMax = 100;
        const int fahrenheitMax = 232;
        public TemperatureConverter() {

            Console.Clear();
            Start();

        }
        private void Start()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("     TEMPERATURE CONVERTER     ");
            Console.WriteLine("-------------------------------");

            int chosenOption = -1;
            double count;
            while (chosenOption != 0)
            {
                PrintMenu();
                chosenOption = int.Parse(Console.ReadLine());
                switch (chosenOption)
                {
                    case 0:
                        // Break loop
                        break;
                    case 1:
                        Console.WriteLine("Your choice: 1");
                        for ( count = 0; count < celciusMax + 1; count++ )
                        {
                            double fahrenheitValues = convertCelciusToFahrenheit(count);
                            // Using modulus to figure out when to print
                            if (count % 4 == 0)
                            {
                                Console.WriteLine(String.Format("{0:00.00}", count) + " C =\t" + String.Format("{0:00.00}", fahrenheitValues) + " F");
                            }                            
                        }                        
                        continue;                        
                    case 2:
                        Console.WriteLine("Your choice: 2");
                        for (count = 0; count < fahrenheitMax + 1; count++)
                        {
                            double celciusValues = convertFahrenheitToCelcius(count);
                            // Using modulus to figure out when to print
                            if (count % 10 == 0)
                            {
                                Console.WriteLine(String.Format("{0:00.00}", count) + " F =\t" + String.Format("{0:00.00}", celciusValues) + " C");
                            }
                        }
                        continue;
                }
            }

        }
        // Just a helper method to print the menu
        private void PrintMenu()
        {
            Console.WriteLine("Celcius to Fahrenheit\t: 1");
            Console.WriteLine("Fahrenheit to Celcius\t: 2");
            Console.WriteLine("Exit\t\t\t: 0");
            Console.WriteLine();
        }

        // Just returns the result
        private double convertCelciusToFahrenheit(double celcius)
        {
            return 9/5.0 * celcius + 32;
        }
        // Just returns the result
        private double convertFahrenheitToCelcius(double fahrenheit)
        {
            return 5/9.0 * (fahrenheit - 32);
        }
    }
}
