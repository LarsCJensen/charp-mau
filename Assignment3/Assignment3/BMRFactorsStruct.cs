using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public struct BMRFactors
    {
        private const double sedentary = 1.2;
        private const double lightly = 1.375;
        private const double moderately = 1.550;
        private const double very = 1.725;
        private const double extra = 1.9;
        public double Sedentary
        {
            get { return sedentary; }
        }

        public double Lightly
        {
            get { return lightly; }
        }
        public double Moderately
        {
            get { return moderately; }
        }
        public double Very
        {
            get { return very; }
        }
        public double Extra
        {
            get { return extra; }
        }
    }
}
