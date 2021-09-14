
namespace Assignment5
{
    partial class MainForm
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
            this.lvRegistry = new System.Windows.Forms.ListView();
            this.lbDetails = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvRegistry
            // 
            this.lvRegistry.FullRowSelect = true;
            this.lvRegistry.HideSelection = false;
            this.lvRegistry.Location = new System.Drawing.Point(12, 39);
            this.lvRegistry.MultiSelect = false;
            this.lvRegistry.Name = "lvRegistry";
            this.lvRegistry.Size = new System.Drawing.Size(510, 320);
            this.lvRegistry.TabIndex = 0;
            this.lvRegistry.UseCompatibleStateImageBehavior = false;
            this.lvRegistry.SelectedIndexChanged += new System.EventHandler(this.lvRegistry_SelectedIndexChanged);
            // 
            // lbDetails
            // 
            this.lbDetails.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbDetails.ForeColor = System.Drawing.Color.Blue;
            this.lbDetails.FormattingEnabled = true;
            this.lbDetails.ItemHeight = 15;
            this.lbDetails.Location = new System.Drawing.Point(543, 39);
            this.lbDetails.Name = "lbDetails";
            this.lbDetails.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbDetails.Size = new System.Drawing.Size(245, 319);
            this.lbDetails.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 376);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 35);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(133, 376);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 35);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(253, 376);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 35);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(372, 376);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(95, 35);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbDetails);
            this.Controls.Add(this.lvRegistry);
            this.Name = "MainForm";
            this.Text = "Customer Registry By Lars Jensen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvRegistry;
        private System.Windows.Forms.ListBox lbDetails;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCopy;
    }
}

