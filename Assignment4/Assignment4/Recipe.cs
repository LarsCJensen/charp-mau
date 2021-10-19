using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{   

    class Recipe
    {
        private string name = "";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }
        private FoodCategory foodCategory;
        public FoodCategory FoodCategory
        {
            get
            {
                return foodCategory;
            }
            set
            {
                foodCategory = value;
            }
        }

        private string[] ingredients;
        public string[] Ingredients
        {
            get
            {
                return ingredients;
            }
            set
            {
                if(ingredients.Length > 0)
                {
                    ingredients = value;
                }                
            }
        }
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    description = value;
                }
            }
        }
        public void WHATSHOULDITDO()
        {
            // WHADAPPP!
        }

    }
}
