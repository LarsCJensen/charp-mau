using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    /// <summary>
    /// Class that have all recipes, as well as methods to add, delete, edit and get them. 
    /// Also has helper method for getting number of recipes
    /// </summary>
    public class RecipeManager
    {
        
        private Recipe[] recipes;
        public RecipeManager(int maxNumOfRecipes)
        {
            recipes = new Recipe[maxNumOfRecipes];
        }
        /// <summary>
        /// Add new recipe to recipes array at first empty index
        /// </summary>
        /// <param name="newRecipe">New recipe of type Recipe</param>
        /// <returns>false if no vacant index can be found, else true</returns>
        public bool AddRecipe(Recipe newRecipe)
        {
            if(newRecipe==null)
            {
                return false;
            }

            int emptyIndex = GetEmptyIndex();
            if(emptyIndex == -1)
            {
                return false;
            }
            recipes[emptyIndex] = newRecipe;
            return true;
        }
        // Deletes recipe on a certain index and re-aranges the recipes
        public void DeleteRecipe(int recipeIndex)
        {
            recipes[recipeIndex] = null;
            ArrangeRecipes(recipeIndex);
        }

        // Replaces edited recipe
        public void EditRecipe(int index, Recipe recipe)
        {
            recipes[index] = recipe;
        }

        public int GetNumberOfRecipes()
        {
            // Even if the recipes array is organized each time, it still feels more save to go over all indexes and check if null.
            int noOfRecipes = 0;
            for(int i = 0; i < recipes.Length; i++)
            {
                if(recipes[i]!=null)
                {
                    noOfRecipes++;
                }                
            }
            return noOfRecipes;
        }

        public Recipe GetRecipe(int index)
        {            
            return recipes[index];
        }

        // Get the first empty index to place the new recipe in
        private int GetEmptyIndex()
        {
            int index = -1;
            for (int i = 0; i < recipes.Length; i++)
            {
                if (recipes[i] == null)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        
        private void ArrangeRecipes(int removedIndex)
        {
            // If this is run each time a recipe is deleted and because you only can select one item
            // then it shouldn't need to loop over all items and setting them to null. But this solution will be 
            // future proff if multi-select is introduced.
            for (int i = removedIndex+1; i < recipes.Length; i++)
            {
                recipes[i - 1] = recipes[i];
                recipes[i] = null;
            }
        }
    }
}
