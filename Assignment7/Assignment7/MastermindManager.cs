using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;


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
        private int guessesLeft;
        public int GuessesLeft
        {
            get
            {
                return guessesLeft;
            }
        }
        public MastermindManager(int numberOfGuesses)
        {
            guessesLeft = numberOfGuesses;
        }
        
        public List<GuessResult> Guess(MastermindRow guess)
        {
            // TODO Behöver jag adda ett guess till en array?
            guesses.Add(guess);
            List<GuessResult> answer = new List<GuessResult>();
            answer = GetAnswer(guess);            
            guessesLeft--;
            return answer;
        }

        
        public void GenerateRandomRow()
        {
            
            List<MastermindItem> randomItems = new List<MastermindItem>();
            randomItems = getRandomItems();
            correctRow = new MastermindRow(randomItems);            
        }
        private List<MastermindItem> getRandomItems(bool onlyUnique=true)
        {
            List<MastermindItem> listOfItems = new List<MastermindItem>();
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
                listOfItems.Add(item);                
            }
            return listOfItems;
        }
        private int getRandomNumber(int start, int end)
        {
            return new Random().Next(start, end);
        }

        // TODO should I pass guess here or just go with index?
        private List<GuessResult> GetAnswer(MastermindRow guess)
        {
            List<GuessResult> answer = new List<GuessResult>();
            Type correctRow = CorrectRow.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(correctRow.GetProperties());

            for (int i = 0; i < 4; i++)
            {
                // If right color is in the right place
                if ((MastermindItem)props[i].GetValue(guess) == (MastermindItem)props[i].GetValue(CorrectRow))
                {
                    answer.Add(GuessResult.RIGHT_COLOR_AND_PLACE);
                    continue;
                } else if ((MastermindItem)props[i].GetValue(guess) == (MastermindItem)props[0].GetValue(CorrectRow) 
                    || (MastermindItem)props[i].GetValue(guess) == (MastermindItem)props[1].GetValue(CorrectRow) 
                    || (MastermindItem)props[i].GetValue(guess) == (MastermindItem)props[2].GetValue(CorrectRow)
                    || (MastermindItem)props[i].GetValue(guess) == (MastermindItem)props[3].GetValue(CorrectRow)
                    )
                {
                    answer.Add(GuessResult.RIGHT_COLOR);
                } else
                {
                    answer.Add(GuessResult.INCORRECT);
                }
            }
            return answer;

        }
    }
}