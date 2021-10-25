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
            if (ValidateInput())
            {
                recipeManager.AddRecipe(currentRecipe);
                AddRecipeToListView();
                UpdateGUI();
                currentRecipe = new Recipe(maxNumOfIngredients);
            }
        }

        private void btnEditBegin_Click(object sender, EventArgs e)
        {
            // Since I set multiselect to disabled it should be 0 or 1
            if(lvRecipes.SelectedItems.Count == 1)
            {
                // Don't want the user to be able to add while editing
                btnAddRecipe.Enabled = false;
                btnEditBegin.Enabled = false;
                btnEditFinish.Enabled = true;
                currentRecipe = recipeManager.GetRecipe(lvRecipes.SelectedItems[0].Index);
                txtNameOfRecipe.Text = currentRecipe.Name;
                cboCategory.SelectedItem = currentRecipe.FoodCategory;
                txtDescription.Text = currentRecipe.Description;
            }
        }
        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            if (lvRecipes.SelectedItems.Count == 1 && ValidateInput())
            {                
                recipeManager.EditRecipe(lvRecipes.SelectedItems[0].Index, currentRecipe);
                string[] row = { currentRecipe.Name, currentRecipe.FoodCategory.ToString(), currentRecipe.Ingredients.Length.ToString() };
                var listViewItem = new ListViewItem(row);
                lvRecipes.Items[lvRecipes.SelectedItems[0].Index] = listViewItem;
                UpdateGUI();
                currentRecipe = new Recipe(maxNumOfIngredients);
                btnAddRecipe.Enabled = true;
                btnEditBegin.Enabled = true;
                btnEditFinish.Enabled = false;
            }            
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lvRecipes.SelectedIndices.Clear();
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
            }
        }

        private void UpdateGUI()
        {
            txtNameOfRecipe.Text = "";
            cboCategory.SelectedIndex = 0;
            txtDescription.Text = "";
            btnAddRecipe.Enabled = true;
            btnEditBegin.Enabled = true;
            btnEditFinish.Enabled = false;
        }

        private void btnAddIngredients_Click(object sender, EventArgs e)
        {
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
        
        private void AddRecipeToListView()
        {
            string[] row = { currentRecipe.Name, currentRecipe.FoodCategory.ToString(), currentRecipe.Ingredients.Length.ToString() };
            var listViewItem = new ListViewItem(row);
            lvRecipes.Items.Add(listViewItem);
        }

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

        // Helper function for validating input
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtNameOfRecipe.Text))
            {
                MessageBox.Show("You must provide a name for the recipe!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            currentRecipe.Name = txtNameOfRecipe.Text;
            // I don't need to validate this since it will have a value set at start
            currentRecipe.FoodCategory = (FoodCategory)cboCategory.SelectedValue;
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

    }
}
