/*
 * Lars Jensen
 * 2021-10-31
 * */

using System;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class FormMain : Form
    {
        const int maxNumOfRecipes = 200;
        const int maxNumOfIngredients = 50;
        // Initialize RecipeManager and Recipe with max num of recipes and ingredients
        private RecipeManager recipeManager = new RecipeManager(maxNumOfRecipes);
        private Recipe currentRecipe = new Recipe(maxNumOfIngredients);
        public FormMain()
        {
            InitializeComponent();
            InitializeGUI();
        }
        // Initializes the GUI
        private void InitializeGUI()
        {
            txtNameOfRecipe.Text = "";            
            // Adds the FoodCategory enums to the combobox
            cboCategory.DataSource = Enum.GetValues(typeof(FoodCategoryEnums));
            txtDescription.Text = "";
            // Show columns in listview
            lvRecipes.View = View.Details;
            // Using a listView with fullrow select set to true and multiselect false to avoid weirdness when edit/delete
            // Adding columns, as it looks nicer. Although they perhaps should be automatically sized
            lvRecipes.Columns.Add("Name", 150, HorizontalAlignment.Left);
            lvRecipes.Columns.Add("Category", 100, HorizontalAlignment.Left);
            lvRecipes.Columns.Add("Num of ingredients", 125, HorizontalAlignment.Center);            
        }

        // Add recipe
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                // Pass the current recipe to the Add method of class RecipeManager
                bool recipeAdded = recipeManager.AddRecipe(currentRecipe);
                if(!recipeAdded)
                {
                    MessageBox.Show("Max number of recipes have been reached. Please change the const value to add more!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Adds the current recipe to the list view
                AddRecipeToListView();
                // Updates the GUI (clears fields)
                UpdateGUI();
                // Re-initalizes currentRecipe to not overwrite the newly added one.
                currentRecipe = new Recipe(maxNumOfIngredients);
            }
        }

        // Edit recipe
        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            // Since I set multiselect to disabled it could only be 0 or 1, but to be sure if multiselect is added in the future.            
            if(lvRecipes.SelectedItems.Count == 1)
            {
                // Don't want the user to be able to add while editing
                btnAddRecipe.Enabled = false;
                btnEditBegin.Enabled = false;
                btnDelete.Enabled = false;
                btnEditFinish.Enabled = true;
                // Get recipe of chosen index
                currentRecipe = recipeManager.GetRecipe(lvRecipes.SelectedItems[0].Index);
                txtNameOfRecipe.Text = currentRecipe.Name;
                cboCategory.SelectedItem = currentRecipe.FoodCategory;
                txtDescription.Text = currentRecipe.Description;
            }else
            {
                MessageBox.Show("You have to choose a recipe to edit!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Edit finished
        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            // If only one has been chosen and the input that you have edited is valid
            if (lvRecipes.SelectedItems.Count == 1 && ValidateInput())
            {                
                // Save the recipe to the same position as it was.
                recipeManager.EditRecipe(lvRecipes.SelectedItems[0].Index, currentRecipe);
                // And add it to the listview on the same index.
                string[] row = { currentRecipe.Name, currentRecipe.FoodCategory.ToString(), currentRecipe.Ingredients.Length.ToString() };
                var listViewItem = new ListViewItem(row);
                lvRecipes.Items[lvRecipes.SelectedItems[0].Index] = listViewItem;
                UpdateGUI();
                // And re-initialize current recipe.
                currentRecipe = new Recipe(maxNumOfIngredients);
                // And re-enable the buttons
                btnAddRecipe.Enabled = true;
                btnEditBegin.Enabled = true;
                btnEditFinish.Enabled = false;
                btnDelete.Enabled = true;
            }            
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lvRecipes.SelectedIndices.Clear();
            // In case you clear the selection during editing then you shouldn't have the recipe loaded
            currentRecipe = new Recipe(maxNumOfIngredients);
            UpdateGUI();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvRecipes.SelectedItems.Count == 1)
            {
                // Get the index from the GUI
                int index = lvRecipes.SelectedItems[0].Index;
                // Delete the row from the listview (instead of reloading all recipes each time)
                lvRecipes.Items.RemoveAt(index);
                // Delete the actual recipe
                recipeManager.DeleteRecipe(index);                
            } else
            {
                MessageBox.Show("You have to choose a recipe to delete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Function to update the GUI
        private void UpdateGUI()
        {
            txtNameOfRecipe.Text = "";
            cboCategory.SelectedIndex = 0;
            txtDescription.Text = "";
            btnAddRecipe.Enabled = true;
            btnEditBegin.Enabled = true;
            btnEditFinish.Enabled = false;
            btnDelete.Enabled = true;
        }

        // Add Ingredients 
        private void btnAddIngredients_Click(object sender, EventArgs e)
        {
            // Creates FormIngredients and passes the current recipe
            FormIngredients formIngredients = new FormIngredients(currentRecipe);
            DialogResult dlgResult = formIngredients.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                if(currentRecipe.GetNumberOfIngredients() <= 0)
                {
                    MessageBox.Show("No ingredients specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }        
        
        // Adds the current recipe to the ListView
        private void AddRecipeToListView()
        {            
            string[] row = { currentRecipe.Name, currentRecipe.FoodCategory.ToString(), currentRecipe.Ingredients.Length.ToString() };
            var listViewItem = new ListViewItem(row);
            lvRecipes.Items.Add(listViewItem);            
        }

        // Event handler for double click
        private void lvRecipes_DoubleClick(object sender, EventArgs e)
        {
            Recipe recipe = recipeManager.GetRecipe(lvRecipes.SelectedItems[0].Index);
            string messageText = "INGREDIENTS\n";
            for(int i=0; i < recipe.GetNumberOfIngredients(); i++)
            {
                messageText += recipe.Ingredients[i] + "\n";
            }
            messageText += "\nDESCRIPTION\n";
            messageText += recipe.Description;
            MessageBox.Show(messageText, "Cooking instructions", MessageBoxButtons.OK);
        }        
        
        // Helper function to validate input.        
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtNameOfRecipe.Text))
            {
                MessageBox.Show("You must provide a name for the recipe!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            currentRecipe.Name = txtNameOfRecipe.Text;
            // I don't need to validate this since it will have a value set at start
            currentRecipe.FoodCategory = (FoodCategoryEnums)cboCategory.SelectedIndex;
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("You must provide a description for the recipe!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            currentRecipe.Description = txtDescription.Text;

            if (currentRecipe.GetNumberOfIngredients() == 0)
            {
                MessageBox.Show("You must provide at least one ingredient for the recipe!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }
        
        // Event handler for the form load event        
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Focus on the textbox for name of the recipe
            txtNameOfRecipe.Focus();
        }
    }
}
