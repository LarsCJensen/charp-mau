/* 
 * 2021-09-14
 * Author: Lars Jensen 
 */

using System;

namespace Assignment1
{
    public class Pet
    {
        private string name;
        private int age;
        // I chose to explicitly 
        private bool isFemale = false;
        public void Start()
        {
            ReadAndSavePetData();
            PrintPetData();

        }
        // Keeping this private since the class should only expose Start as "interface"
        private void ReadAndSavePetData()
        {
            Console.WriteLine("What is the name of your pet?");
            name = Console.ReadLine();
            Console.WriteLine("What is the age of your pet?");
            age = Convert.ToInt32(Console.ReadLine());
            // I wanted to verify that the input was correct and that it didn't matter what case you put in
            do
            {
                Console.WriteLine("Is your pet female (y/n)?");
                string response = Console.ReadLine();
                if (response.ToLower() == "y" || response.ToLower() == "n")
                {
                    if (response.ToLower() == "y")
                    {
                        isFemale = true;
                    }
                    break;
                }
            } while (true);

        }
        // Keeping this private since the class should only expose Start as "interface"
        private void PrintPetData()
        {
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            // One could have a if statement here, but I prefered a helper method. Or rather,
            // I was planning on having an enum for it but couldn't find a good example fast enough
            Console.WriteLine(name + " is a good " + getGender() + "!");
            Console.WriteLine("+++++++++++++++++++++++");
        }

        private string getGender()
        {
            if (isFemale)
            {
                return "girl";
            }
            return "boy";
        }
    }
}
