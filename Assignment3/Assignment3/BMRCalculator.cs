/*
 * Lars Jensen
 * 2021-10-15
 * */

namespace Assignment3
{
    /// <summary>
    /// class <c>BMRCalculator</c> calculates BMR from user input. Inherits properties from BMICalculator.
    /// </summary>
    class BMRCalculator : BMICalculator
    {
        private int age = 0;
        // Using a struct for the different factors. I find it more clear in code
        public struct BMRFactors
        {
            public const double Sedentary = 1.2;
            public const double Lightly = 1.375;
            public const double Moderately = 1.550;
            public const double Very = 1.725;
            public const double Extra = 1.9;
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        
        private Gender gender;
        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private double bmrFactor;
        public double BMRFactor
        {
            get { return bmrFactor; }
            set { bmrFactor = value; }
        }
        /// <summary>
        /// method <c>calculateBMR</c> calculates BMR from user input
        /// </summary>
        /// <returns></returns>
        public double calculateBMR()
        {            
            double bmr = 10 * Weight + 6.25 * Height - (5 * Age);
            if (gender == Gender.Female)
            {
                return bmr - 161;
            }
            return bmr + 5; 
        }
        /// <summary>
        /// method <c>calculateMaintainWeight</c> calculates amount of calories to maintain weight
        /// </summary>
        /// <param name="bmr">BMR to caclulate amount of calories to maintain weight for</param>
        /// <returns></returns>
        public double calculateMaintainWeight(double bmr)
        {            
            return bmr * bmrFactor;
        }
        /// <summary>
        /// method <c>calculateGainOrLossWeight</c> calculates amount of calories to gain or lose weight
        /// </summary>
        /// <param name="maintainWeight">Amount of calories for maintaining weight</param>
        /// <param name="factor">Amount of calories to calculate weight gain or loss for</param>
        /// <returns></returns>
        public double calculateGainOrLossWeight(double maintainWeight, int factor)
        {
            // If the factor is negative, this will still work.
            return maintainWeight + factor;
        }        
    }
}
