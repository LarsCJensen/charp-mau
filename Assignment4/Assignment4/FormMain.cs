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
        private Recipe currentRecipe = new Recipe(maxNumOfIngredients);
        public FormMain()
        {
            InitializeComponent();
            InitializeGUI();
        }
        private void InitializeGUI()
        {
            txtNameOfRecipe.Text = "";            
            cboCategory.DataSource = Enum.GetValues(typeof(FoodCategory));
            txtDescription.Text = "";
            // Show columns in listview
            lvRecipes.View = View.Details;
            // Add columns that grows with the items
            // Check also https://stackoverflow.com/questions/1257500/c-sharp-listview-column-width-auto
            // Using a listView with fullrow select set to true and multiselect false to avoid weirdness when edit/delete
            lvRecipes.Columns.Add("Name", 150, HorizontalAlignment.Left);
            lvRecipes.Columns.Add("Category", 100, HorizontalAlignment.Left);
            lvRecipes.Columns.Add("Number of ingredients", -2, HorizontalAlignment.Right);            
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {   
            // TODO Validate all input fields
            if(string.IsNullOrEmpty(txtNameOfRecipe.Text)) {
                MessageBox.Show("You must provide a name for the recipe!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            currentRecipe.Name = txtNameOfRecipe.Text;
            // I don't need to validate this since it will have a value set at start
            currentRecipe.FoodCategory = (FoodCategory)cboCategory.SelectedValue;
            if (string.IsNullOrEmpty(txtDescription.Text)) {
                MessageBox.Show("You must provide a description for the recipe!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            currentRecipe.Description = txtDescription.Text;
            
            if(currentRecipe.GetNumberOfIngredients() == 0)
            {
                MessageBox.Show("You must provide at least one ingredient for the recipe!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            recipeManager.AddRecipe(currentRecipe);
            // Create helper method
            AddRecipeToListView();
            UpdateGUI();
            // ?? Implement delete button
            // ??. Implement Edit buttons
            // ?? Implement double click to view recipe

            // ?? Implement Add ingredients

            // ?. If no ingredients is not present 
            // ???Recreate currentRecipe as it else would be a reference to the already created object???
            currentRecipe = new Recipe(maxNumOfIngredients);
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
        private void UpdateGUI()
        {
            txtNameOfRecipe.Text = "";
            cboCategory.SelectedIndex = 0;
            txtDescription.Text = "";
            //ReloadRecipes();
        }

        private void btnAddIngredients_Click(object sender, EventArgs e)
        {
            FormIngredients formIngredients = new FormIngredients();
            formIngredients.Recipe = currentRecipe;
            DialogResult dlgResult = formIngredients.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if(currentRecipe.GetNumberOfIngredients() <= 0)
                {
                    MessageBox.Show("No ingredients specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }        
        private void btnClear_Click(object sender, EventArgs e)
        {
            lvRecipes.SelectedIndices.Clear();
        }

        private void AddRecipeToListView()
        {
            string[] row = { currentRecipe.Name, currentRecipe.FoodCategory.ToString(), currentRecipe.Ingredients.Length.ToString() };
            var listViewItem = new ListViewItem(row);
            lvRecipes.Items.Add(listViewItem);
        }

        private void lvRecipes_DoubleClick(object sender, EventArgs e)
        {
            Recipe recipe = recipeManager.GetRecipe(lvRecipes.SelectedItems[0].Index);
            string messageText = "INGREDIENTS \n";
            for(int i=0; i < recipe.GetNumberOfIngredients(); i++)
            {
                messageText += recipe.Ingredients[i] + "\n";
            }
            messageText += "\n DESCRIPTION \n";
            messageText += "\n" + recipe.Description;
            MessageBox.Show(messageText, "Cooking instructions", MessageBoxButtons.OK);
        }
    }
}
