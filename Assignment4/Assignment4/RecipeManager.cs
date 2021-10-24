using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class RecipeManager
    {
        
        private Recipe[] recipes;
        public RecipeManager(int maxNumOfRecipes)
        {
            recipes = new Recipe[maxNumOfRecipes];
        }
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
        public void DeleteRecipe()
        {

        }

        public void EditRecipe()
        {

        }

        public int GetNumberOfRecipes()
        {
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
        
    }
}
