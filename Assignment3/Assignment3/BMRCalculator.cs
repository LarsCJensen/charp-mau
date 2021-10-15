/*
 * Lars Jensen
 * 2021-10-15
 * */

namespace Assignment3
{
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
        public double calculateBMR()
        {            
            // Have to make Height into cm and not m as BMI            
            double bmr = 10 * Weight + 6.25 * (Height * 100) - (5 * Age);
            if (gender == Gender.Female)
            {
                return bmr - 161;
            }
            return bmr + 5; 
        }
        public double calculateMaintainWeight()
        {
            // Thought it should perhaps not be calculated over and over, but to just be set as a class property
            return calculateBMR() * bmrFactor;
        }
        public double calculateGainOrLossWeight(int factor)
        {
            // If the factor is negative, this will still work.
            return calculateMaintainWeight() + factor;
        }        
    }
}
