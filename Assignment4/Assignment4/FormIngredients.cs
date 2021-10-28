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
    public partial class FormIngredients : Form
    {
        private Recipe recipe;
        public FormIngredients(Recipe currentRecipe)
        {
            InitializeComponent();
            recipe = currentRecipe;
            InitializeGUI();
        }

        private void InitializeGUI ()
        {
            // Fill listbox with all ingredients for the current recipe
            for(int i = 0; i < recipe.GetNumberOfIngredients(); i++)
            {
                lbIngredients.Items.Add(recipe.Ingredients[i]);
            }
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Add all ingredients to the recipe
            recipe.Ingredients = lbIngredients.Items.OfType<string>().ToArray();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check that the name has at least 1 character to not end up with empty rows
            if(txtIngredientName.Text.Length > 0)
            {
                lbIngredients.Items.Add(txtIngredientName.Text);
                txtIngredientName.Text = "";
            } else
            {
                MessageBox.Show("You must provide an ingredient!", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtIngredientName.Text = lbIngredients.SelectedItem.ToString();
            lbIngredients.Items.RemoveAt(lbIngredients.SelectedIndex);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lbIngredients.Items.RemoveAt(lbIngredients.SelectedIndex);
        }

        private void FormIngredients_Load(object sender, EventArgs e)
        {
            // Focus on the name of the ingredient. 
            // Added AddIngredient as Acceptbutton to make it faster for the user to input ingredients.
            txtIngredientName.Focus();
        }
    }
}
