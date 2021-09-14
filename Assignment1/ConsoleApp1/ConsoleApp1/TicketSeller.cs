/* 
 * 2021-09-14
 * Author: Lars Jensen 
 */

using System;

namespace Assignment1
{
    class TicketSeller
    {
        private string name;
        private double price = 100;
        // It is preferable to have the discount as a variable instead of hard-coding it
        private double childrensDiscount = 0.75;
        private int numOfAdults;
        private int numOfChildren;

        private double amountToPay;
        public void Start()
        {
            ReadAndSaveTicketData();
            PrintReceipt();
        }
        // Keeping this private since the class should only expose Start as "interface"
        private void ReadAndSaveTicketData()
        {
            Console.WriteLine("Your name please:");
            name = Console.ReadLine();
            Console.WriteLine("Number of adults:");
            numOfAdults = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number of children:");
            numOfChildren = Convert.ToInt32(Console.ReadLine());
        }
        // Keeping this private since the class should only expose Start as "interface"
        private void PrintReceipt()
        {
            Console.WriteLine("+++ Your receipt +++");
            // convert to string to make it concatinabled (is that a word?!?)
            Console.WriteLine("+++ Amount to pay = " + calculateSum().ToString());
            Console.WriteLine();
            Console.WriteLine("+++ Thank you " + name + " and please come back +++");            
        }        

        // I chose to return as double since this might be used elsewhere. Should perhaps be public since consumers of the class might want to run this directly
        private double calculateSum()
        {
            // Using the discount variable to calculate sum
            amountToPay = (numOfAdults * price) + (numOfChildren * (price - (price * childrensDiscount)));
            return amountToPay;
        }
    }
}
