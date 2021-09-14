using System;
/* 
 * 2021-09-14
 * Author: Lars Jensen 
 */

namespace Assignment1
{
    class Album
    {
        private string albumName;
        private string artistName;
        private int numberOfTracks;
        public void Start()
        {
            ReadAndSaveAlbumData();
            PrintAlbumInformation();

        }
        // Keeping this private since the class should only expose Start as "interface"
        private void ReadAndSaveAlbumData()
        {
            Console.WriteLine("What is the name of your favourite music album?");
            albumName= Console.ReadLine();
            Console.WriteLine("What is the name of the Artist or Band for " + albumName +  "?");
            artistName = Console.ReadLine();
            // Will loop until a valid int is used as input
            do
            {
                Console.WriteLine("How many tracks does " + albumName + " have?");
            } while (!Int32.TryParse(Console.ReadLine(), out numberOfTracks));
            
            
        }
        private void PrintAlbumInformation()
        {
            Console.WriteLine("Album name: " + albumName);
            Console.WriteLine("Artist/Band: " + artistName);
            Console.WriteLine("Number of tracks: " + numberOfTracks.ToString());
            Console.WriteLine("Enjoy listening!");
        }
    }
}

