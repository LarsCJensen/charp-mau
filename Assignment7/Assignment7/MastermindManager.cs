using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    public class MastermindManager
    {
        private List<MastermindRow> guesses = new List<MastermindRow>();
        private MastermindRow correctRow;
        public MastermindRow CorrectRow
        {
            get
            {
                return correctRow;
            }
        }
        public MastermindResult MastermindResult
        {
            get => default;
            set
            {
            }
        }

        public void Guess(MastermindRow guess)
        {
            
        }

        public void GenerateRandomRow()
        {
            
            MastermindItem[] randomItems = new MastermindItem[4];
            randomItems = getRandomItems();
            correctRow = new MastermindRow(randomItems);            
        }
        private MastermindItem[] getRandomItems(bool onlyUnique=true)
        {
            MastermindItem[] listOfItems = new MastermindItem[4];
            List<int> pickedNumbers = new List<int>();
            for(int i = 0; i < 4; i++)
            {
                int randomNumber;
                // TODO Refactor
                if(onlyUnique)
                {
                    while (true)
                    {
                        randomNumber = getRandomNumber(1, 6);
                        if (!pickedNumbers.Contains(randomNumber))
                            break;
                    }
                } else
                {
                    randomNumber = getRandomNumber(1, 6);
                }
                
                pickedNumbers.Add(randomNumber);
                MastermindItem item = new MastermindItem();
                item.Color = (Colors)randomNumber;
                listOfItems[i] = item;                
            }
            return listOfItems;
        }
        private int getRandomNumber(int start, int end)
        {
            return new Random().Next(start, end);
        }
    }
}