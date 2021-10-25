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
            for(int i = 0; i < recipe.GetNumberOfIngredients(); i++)
            {
                lbIngredients.Items.Add(recipe.Ingredients[i]);
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            recipe.Ingredients = lbIngredients.Items.OfType<string>().ToArray();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lbIngredients.Items.Add(txtIngredientName.Text);
            txtIngredientName.Text = "";
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
    }
}
