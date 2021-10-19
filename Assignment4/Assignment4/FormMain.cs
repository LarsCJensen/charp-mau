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
        private RecipeManager recipeManager = new RecipeManager();
        public FormMain()
        {
            InitializeComponent();
            InitializeGUI();
        }
        private void InitializeGUI()
        {
            cboCategory.DataSource = Enum.GetValues(typeof(FoodCategory));
        }

        private void lvRecipes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set selected index?
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            recipeManager.Add(txtNameOfRecipe.Text);
            // 1. Create recipe with name, category + description.
            // 2. Add it to listView
            // ?? Implement delete button
            // ?? Implement clear selection
            // ??. Implement Edit buttons
            // ?? Implement double click to view recipe
            
            // ?? Implement Add ingredients
            
            // ?. If no ingredients is not present 
        }
    }
}
