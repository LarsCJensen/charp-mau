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
        private GameMode gameMode;
        public GameMode GameMode
        {
            get
            {
                return gameMode;
            }
        }

        public MastermindManager(int numberOfGuesses, GameMode gameModeToSet)
        {
            guessesLeft = numberOfGuesses;
            gameMode = gameModeToSet;
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
                MastermindItem guessItem = (MastermindItem)props[i].GetValue(guess);
                answer.Add(CompareGuessWithCorrectRow(guessItem, i, props));                
            }
            return answer;
        }
        /// <summary>
        /// Compare Guess with correctRow
        /// </summary>
        /// <param name="guessItem"></param>
        /// <param name="index"></param>
        /// <param name="props"></param>
        /// <returns></returns>
        /// 
        // TODO REfactor if needed
        private GuessResult CompareGuessWithCorrectRow(MastermindItem guessItem, int index, IList<PropertyInfo> props)
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