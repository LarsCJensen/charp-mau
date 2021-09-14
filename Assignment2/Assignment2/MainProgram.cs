/*
 * Lars Jensen
 * 2021-09-20
 * */

using System;

namespace Assignment2
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Console.Title = "Selection and iteration in C#";
            SelectionAndIteration warmupObj = new SelectionAndIteration();

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

            Console.Title = "Fahrenheit and Celcius Converter";
            TemperatureConverter converter = new TemperatureConverter();

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

            Console.Title = "Working Schedule";
            WorkingSchedule workingSchedule = new WorkingSchedule();

            Console.WriteLine("Press any key to Exit!");
            Console.ReadLine();
        }
    }
}
