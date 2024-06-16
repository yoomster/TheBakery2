using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeBakery
{
    public partial class FormBakery : Form
    {
        private BakeryModel _bakery = new BakeryModel();

        public FormBakery()
        {
            InitializeComponent();
            _bakery.StockUpdated += OnStockUpdated;
            UpdateStock();
        }

        private void UpdateStock()
        {
            listBoxSandwiches.DataSource = null;
            listBoxSandwiches.DataSource = _bakery.SandwichesInStock;
        }

        private void OnStockUpdated()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateStock));
            }
            else
            {
                UpdateStock();
            }
        }

        private void buttonNewSandwich_Click(object sender, EventArgs e)
        {
            if (_bakery.SandwichesInStock.Count < 5)
            {
                var FormNew = new FormNew(_bakery);
                FormNew.Show();
            }
            else
            {
                MessageBox.Show("Maximaal 5 broodjes is het assortiment mogelijk");
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }





          private void buttonSell_Click(object sender, EventArgs e)
        {
        }

        private void listBoxSandwiches_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxSandwiches.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < _bakery.SandwichesInStock.Count)
            {
                SandwichModel selectedSandwich = _bakery.SandwichesInStock[selectedIndex];
                UpdateIngredientsList(selectedSandwich);
            }



        }

        private void UpdateBreadType(SandwichModel sandwich)
        {
            listBoxIngredients.Items.Clear();
            textBoxBreadType.Text = sandwich.Name;
        }

        private void UpdateIngredientsList(SandwichModel sandwich)
        {
            listBoxIngredients.Items.Clear();

            foreach (var ingredient in sandwich.Ingredients)
            {
                listBoxIngredients.Items.Add($"{ingredient.Name}, prijs {ingredient.Price}");
            }
        }
    }
}

//textBoxBreadType shows the bread type of the selected sandwich
//listBoxIngredients shows the ingredients on selected sandwich
//buttonSell removes sandwich from stock list and into sold and triggers method for adding to revenue