using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment7
{
    public enum Colors
    {
        WHITE,
        BLUE,
        GREEN,
        BLACK,
        RED,
        YELLOW,            
    }

    public enum GuessResult
    {
        INCORRECT,        
        RIGHT_COLOR,
        RIGHT_COLOR_AND_PLACE,
    }

    public enum GameMode
    {
        EASY,
        MEDIUM,
        HARD,
    }

}