using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    /// <summary>
    /// Enum for colors which can be chosen
    /// </summary>
    public enum Colors
    {
        WHITE,
        BLUE,
        GREEN,
        BLACK,
        RED,
        YELLOW,            
    }

    /// <summary>
    /// Enum for guess result
    /// </summary>
    public enum GuessResult
    {
        INCORRECT,        
        RIGHT_COLOR,
        RIGHT_COLOR_AND_PLACE,
    }

    /// <summary>
    /// Enum for game modes
    /// </summary>
    public enum GameMode
    {
        EASY,
        MEDIUM,
        HARD,
    }

}