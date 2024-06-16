using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheBakery;

namespace DeBakery
{
	public partial class FormNew : Form
	{
        private readonly BakeryModel _bakery;
        public FormNew(BakeryModel bakery)
		{
			InitializeComponent();
            _bakery = bakery;
        }

        private void FormNew_Load(object sender, EventArgs e)
        {
            comboBoxBreadType.DataSource = Enum.GetValues(typeof(BreadTypeEnum));
            listBoxIngredienten.DataSource = _bakery.Ingredients;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Incorrect, geef je broodje een naam");
            }
            else 
            {
                SandwichModel sandwich = new SandwichModel
                {
                    Name = textBoxName.Text,
                    BreadType = (BreadTypeEnum)comboBoxBreadType.SelectedItem,
                };
      
                if (listBoxIngredienten.SelectedItems.Count > 5)
                {
                    MessageBox.Show("Maximaal 5 ingrediënten toegestaan");
                }
                else
                {
                    AddSelectedIngredients(sandwich);
                    _bakery.AddSandwich(sandwich);

                    this.Close();
                }
            }
        }

        private void AddSelectedIngredients(SandwichModel sandwich)
        {
  
            foreach (IngredientModel ingredient in listBoxIngredienten.SelectedItems)
            {
                sandwich.Ingredients.Add(ingredient);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
