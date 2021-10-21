using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class RecipeManager
    {
        
        private Recipe[] recipes;
        public void AddRecipe()
        {
            // FindEmptyPos
            // ?? Return if it succeeded?
        }
        public void DeleteRecipe()
        {

        }

        public void EditRecipe()
        {

        }

        public int GetNumberOfRecipes()
        {
            return 5;
        }

        public Recipe GetRecipe(int index)
        {
            Recipe recipe = new Recipe();
            recipe.Name = "New REEEEC";
            recipe.FoodCategory = FoodCategory.Meats;
            string[] ings = { "ing", "ing2", "ing3" };
            recipe.Ingredients = ings;
            return recipe;
        }

        public RecipeManager(int maxNumOfRecipes)
        {
            recipes = new Recipe[maxNumOfRecipes];
        }
        private int FindEmptyPosition()
        {
            int index = -1;
            //for (int i = 0; i < recipes.Length; i++)
            //{
            //    if (recipes[i] == -1)
            //    {
            //        index = i;
            //        break;
            //    }
            //}
            return index;
        }
        
    }
}
