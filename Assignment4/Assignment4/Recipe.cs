using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{   

    public class Recipe
    {
        public Recipe(int maxNumOfIngredients)
        {
            ingredients = new string[maxNumOfIngredients];
        } 
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
                if(value.Length > 0)
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
        public int GetNumberOfIngredients()
        {
            // It will loop over all array indexes to check and not just stop at the first null value
            int noOfIngredients = 0;
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[0] != null)
                {
                    noOfIngredients++;
                }
            }
            return noOfIngredients;
        }

    }
}
