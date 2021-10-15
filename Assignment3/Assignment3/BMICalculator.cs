/*
 * Lars Jensen
 * 2021-10-15
 * */

namespace Assignment3
{
    class BMICalculator
    {
        // According to the structural requirements this should not be in the calculator class, which I agree.
        // But in the instructions it seems like it has a property name so I'll leave this commented here.
        //private string name = "No Name";
        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}
        private double height = 0;
        // I like this newer for of getters and setters
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        private double weight = 0;
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private UnitTypes unit;
        public UnitTypes Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        public double CalculateBMI()
        {

            //BMI = weight in kg / (height * heightin m2)  (Metric Units) BMI = 703.0 *·weight in lb / (height * heightin inch2) (Imperial(U.S.) Units) 
            if (unit == UnitTypes.Metric)
            {
                return weight / (height * height);
            }
            return 703 * weight / (height * height);
        }
        public string GetBMIWeightCategory(double bmi)
        {            
            switch (bmi)
            {   
                // As of C# 7 switch with between can be used, so I'll use it
                case double n when (n < 18.5):
                    return "Underweight";
                case double n when (n <= 24.9 && n >= 18.5):
                    return "Normal weight";
                case double n when (n <= 29.9 && n >= 25.0):
                    return "Overweight(Pre - obesity)";
                case double n when (n <= 34.9 && n >= 30.0):
                    return "Overweight(Obesity class I)";
                case double n when (n <= 39.9 && n >= 35.0):
                    return "Overweight(Obesity class II)";
                case double n when (n > 40):
                    return "Overweight(Obesity class III)";                
            }
            return "";
        }
    }
}
