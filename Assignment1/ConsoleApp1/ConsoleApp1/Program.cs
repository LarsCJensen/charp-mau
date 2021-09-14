/* 
 * 2021-09-14
 * Author: Lars Jensen 
 */

using System;
// Importing project to be able to use Game class.
using Assignment1AB;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Pet pet = new Pet();
            Console.WriteLine("Grettings from MyPet Class!");
            pet.Start();
            nextPart();
            Console.WriteLine("Welcome to KIDS' FAIR!");
            Console.WriteLine("Children always get a 75% discount!");
            TicketSeller ticketSeller = new TicketSeller();
            ticketSeller.Start();
            nextPart();
            Console.WriteLine("Starting the Album Program!");
            Album album = new Album();
            album.Start();
            nextPart();
            Console.WriteLine("Get the value of a video game!");
            Game game = new Game();
            game.Start();
        }
        // Instead of copying the code I chose to have a helper method to do all the (albeit small) work
        private static void nextPart()
        {
            Console.WriteLine("Press Enter to start the next part!");
            Console.ReadLine();
            // I think it's more apetizing if the console window is cleared between the different things.
            Console.Clear();
        }
    }    
    
}
