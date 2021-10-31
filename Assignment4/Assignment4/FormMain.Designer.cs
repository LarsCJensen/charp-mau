
namespace Assignment4
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAddIngredients = new System.Windows.Forms.Button();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameOfRecipe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.lvRecipes = new System.Windows.Forms.ListView();
            this.btnEditBegin = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEditFinish = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.btnAddIngredients);
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNameOfRecipe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new recipe";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 86);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(302, 209);
            this.txtDescription.TabIndex = 5;
            // 
            // btnAddIngredients
            // 
            this.btnAddIngredients.Location = new System.Drawing.Point(205, 55);
            this.btnAddIngredients.Name = "btnAddIngredients";
            this.btnAddIngredients.Size = new System.Drawing.Size(109, 25);
            this.btnAddIngredients.TabIndex = 4;
            this.btnAddIngredients.Text = "Add ingredients";
            this.btnAddIngredients.UseVisualStyleBackColor = true;
            this.btnAddIngredients.Click += new System.EventHandler(this.btnAddIngredients_Click);
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(73, 55);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 23);
            this.cboCategory.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Category";
            // 
            // txtNameOfRecipe
            // 
            this.txtNameOfRecipe.Location = new System.Drawing.Point(104, 23);
            this.txtNameOfRecipe.Name = "txtNameOfRecipe";
            this.txtNameOfRecipe.Size = new System.Drawing.Size(212, 23);
            this.txtNameOfRecipe.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name of recipe";
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(82, 324);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(169, 23);
            this.btnAddRecipe.TabIndex = 1;
            this.btnAddRecipe.Text = "Add recipe";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
            // 
            // lvRecipes
            // 
            this.lvRecipes.FullRowSelect = true;
            this.lvRecipes.HideSelection = false;
            this.lvRecipes.Location = new System.Drawing.Point(372, 22);
            this.lvRecipes.MultiSelect = false;
            this.lvRecipes.Name = "lvRecipes";
            this.lvRecipes.Size = new System.Drawing.Size(399, 295);
            this.lvRecipes.TabIndex = 2;
            this.lvRecipes.UseCompatibleStateImageBehavior = false;
            this.lvRecipes.DoubleClick += new System.EventHandler(this.lvRecipes_DoubleClick);
            // 
            // btnEditBegin
            // 
            this.btnEditBegin.Location = new System.Drawing.Point(372, 323);
            this.btnEditBegin.Name = "btnEditBegin";
            this.btnEditBegin.Size = new System.Drawing.Size(78, 23);
            this.btnEditBegin.TabIndex = 3;
            this.btnEditBegin.Text = "Edit Begin";
            this.btnEditBegin.UseVisualStyleBackColor = true;
            this.btnEditBegin.Click += new System.EventHandler(this.btnEditBegin_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(574, 323);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEditFinish
            // 
            this.btnEditFinish.Enabled = false;
            this.btnEditFinish.Location = new System.Drawing.Point(472, 324);
            this.btnEditFinish.Name = "btnEditFinish";
            this.btnEditFinish.Size = new System.Drawing.Size(78, 23);
            this.btnEditFinish.TabIndex = 5;
            this.btnEditFinish.Text = "Edit Finish";
            this.btnEditFinish.UseVisualStyleBackColor = true;
            this.btnEditFinish.Click += new System.EventHandler(this.btnEditFinish_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(678, 323);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear selection";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(397, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(346, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Double click on an item for ingrediants and cooking instructions";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 451);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnEditFinish);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEditBegin);
            this.Controls.Add(this.lvRecipes);
            this.Controls.Add(this.btnAddRecipe);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMain";
            this.Text = "Apu Recipe Book By Lars Jensen";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAddIngredients;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameOfRecipe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.ListView lvRecipes;
        private System.Windows.Forms.Button btnEditBegin;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEditFinish;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
    }
}

