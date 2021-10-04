using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return 14.14;
            }
            return 15.00;
        }
        public string GetBMIWeightCategory()
        {
            //BMI
            //Nutritional status
            //Below 18.5 Underweight
            //18.5–24.9 Normal weight
            //25.0–29.9 Overweight(Pre - obesity)
            //30.0–34.9 Overweight(Obesity class I)
            //35.0–39.9 Overweight(Obesity class II)
            //Above 40 Overweight(Obesity class III) 
            return "FAT";
        }
    }
}
