using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;


namespace Assignment7
{
    /// <summary>
    /// Class which holds and manages MastermindRows
    /// </summary>
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
        private GameMode gameMode;
        public GameMode GameMode
        {
            get
            {
                return gameMode;
            }
        }
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="numberOfGuesses">Parameter for number of guesses</param>
        /// <param name="gameModeToSet">Parameter for game mode (easy, medium, hard)</param>
        public MastermindManager(int numberOfGuesses, GameMode gameModeToSet)
        {
            guessesLeft = numberOfGuesses;
            gameMode = gameModeToSet;
        }
        /// <summary>
        /// Method to add a guess and to get the result
        /// </summary>
        /// <param name="guess">The MastermindRow to guess</param>
        /// <returns></returns>
        public List<GuessResult> Guess(MastermindRow guess)
        {
            guesses.Add(guess);
            List<GuessResult> answer = GetAnswer(guess);            
            guessesLeft--;
            return answer;
        }        
        /// <summary>
        /// Method to generate a random sequence which is the row to guess
        /// </summary>
        public void GenerateRandomRow()        {   
             
            List<MastermindItem> randomItems = getRandomItems();
            correctRow = new MastermindRow(randomItems);            
        }
        /// <summary>
        /// Helper method to get random MastermindItems
        /// </summary>
        /// <param name="onlyUnique">For hard mode colors can exist multiple times</param>
        /// <returns></returns>
        private List<MastermindItem> getRandomItems(bool onlyUnique=true)
        {
            List<MastermindItem> listOfItems = new List<MastermindItem>();
            List<int> pickedNumbers = new List<int>();
            for(int i = 0; i < 4; i++)
            {
                int randomNumber;
                // If not hard mode, then only pick unique colors. Picked colors are added to list
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
        /// <summary>
        /// Helper method to generate a random number
        /// </summary>
        /// <param name="start">Start number</param>
        /// <param name="end">End number</param>
        /// <returns></returns>
        private int getRandomNumber(int start, int end)
        {
            return new Random().Next(start, end);
        }

        /// <summary>
        /// Helper method to get answer for a guess
        /// </summary>
        /// <param name="guess">Guess to get result for</param>
        /// <returns></returns>
        private List<GuessResult> GetAnswer(MastermindRow guess)
        {
            List<GuessResult> answer = new List<GuessResult>();
            Type correctRow = CorrectRow.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(correctRow.GetProperties());

            for (int i = 0; i < 4; i++)
            {
                MastermindItem guessItem = (MastermindItem)props[i].GetValue(guess);
                answer.Add(CompareItemWithCorrectRow(guessItem, i, props));                
            }
            return answer;
        }
        /// <summary>
        /// Compare Guess with correctRow
        /// </summary>
        /// <param name="guessItem">MastermindItem to compare result with</param>
        /// <param name="index">Which index the item is located at</param>
        /// <param name="props">Properties to get color of item</param>
        /// <returns></returns>
        /// 
        private GuessResult CompareItemWithCorrectRow(MastermindItem guessItem, int index, IList<PropertyInfo> props)
        {
            MastermindItem correctRowVal = (MastermindItem)props[index].GetValue(CorrectRow);

            // If guess is right color on the right place
            if (guessItem.Color == correctRowVal.Color)
            {
                return GuessResult.RIGHT_COLOR_AND_PLACE;
            }

            // If color is used in other indexes
            for (int i = 0; i < props.Count; i++)
            {
                // Skip the same index. It is eather RIGHT_COLOR_AND_PLACE or default INCORRECT
                if (i == index)
                    continue;
                // Compare guess with all other guesses
                MastermindItem correctRowItem  = (MastermindItem)props[i].GetValue(CorrectRow);
                if (guessItem.Color == correctRowItem.Color)
                    return GuessResult.RIGHT_COLOR;
            }
            
            return GuessResult.INCORRECT;
        }
    }
}