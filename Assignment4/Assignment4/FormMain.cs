using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class FormMain : Form
    {
        const int maxNumOfRecipes = 200;
        const int maxNumOfIngredients = 50;
        private RecipeManager recipeManager = new RecipeManager(maxNumOfRecipes);
        public FormMain()
        {
            InitializeComponent();
            InitializeGUI();
        }
        private void InitializeGUI()
        {
            cboCategory.DataSource = Enum.GetValues(typeof(FoodCategory));
            // Show columns in listview
            lvRecipes.View = View.Details;
            // Add columns that grows with the items
            // Check also https://stackoverflow.com/questions/1257500/c-sharp-listview-column-width-auto
            // Using a listView with fullrow select set to true and multiselect false to avoid weirdness when edit/delete
            lvRecipes.Columns.Add("Name", 150, HorizontalAlignment.Left);
            lvRecipes.Columns.Add("Category", 100, HorizontalAlignment.Left);
            lvRecipes.Columns.Add("Number of ingredients", -2, HorizontalAlignment.Right);

            for (int i = 0; i < recipeManager.GetNumberOfRecipes(); i++)
            {
                string[] row = { recipeManager.GetNumberOfRecipes[, "Other", "4" };
                var listViewItem = new ListViewItem(row);
                lvRecipes.Items.Add(listViewItem);
            }
        }

        
        

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            //recipeManager.AddRecipe(txtNameOfRecipe.Text);
            // 1. Create recipe with name, category + description.
            // 2. Add it to listView
            // ?? Implement delete button
            // ?? Implement clear selection
            // ??. Implement Edit buttons
            // ?? Implement double click to view recipe
            
            // ?? Implement Add ingredients
            
            // ?. If no ingredients is not present 
        }

        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            // Since I set multiselect to disabled it should be 0 or 1
            if(lvRecipes.SelectedItems.Count == 1)
            {
                MessageBox.Show("HEJ");
                //recipeManager.EditRecipe()
            }
        }
    }
}
