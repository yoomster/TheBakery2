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
            listBoxSandwiches.Items.Clear();
            foreach (var sandwich in _bakery.SandwichesInStock)
            {
                listBoxSandwiches.Items.Add($"{sandwich.Name} ");
            }
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

        private void listBoxSandwiches_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxSandwiches.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < _bakery.SandwichesInStock.Count)
            {
                SandwichModel selectedSandwich = _bakery.SandwichesInStock[selectedIndex];

                UpdateIngredientsList(selectedSandwich);
                UpdateBreadType(selectedSandwich);
            }
            else if (selectedIndex < 0)
            {
                listBoxIngredients.Items.Clear();
                textBoxBreadType.Clear();
            }
        }

        private void UpdateBreadType(SandwichModel sandwich)
        {
            textBoxBreadType.Clear();
            textBoxBreadType.Text = sandwich.BreadType.ToString();
        }

        private void UpdateIngredientsList(SandwichModel sandwich)
        {
            listBoxIngredients.Items.Clear();

            foreach (var ingredient in sandwich.Ingredients)
            {
                listBoxIngredients.Items.Add($"{ingredient.Name} - ${ingredient.Price}");
            }

            //listBoxIngredients.DataSource = sandwich.Ingredients;
        }


        //NEED A FIX!!
        private void buttonSell_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxSandwiches.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < _bakery.SandwichesInStock.Count)
            {
                SandwichModel selectedSandwich = _bakery.SandwichesInStock[selectedIndex];

                _bakery.SoldSandwiches.Add(selectedSandwich);
                _bakery.SandwichesInStock.Remove(selectedSandwich);

                // Update the revenue - edit the method
                int sandwichPrice = _bakery.CalculatePrice(selectedSandwich.Ingredients);
                _bakery.Revenue += sandwichPrice;

                // Update the UI

                UpdateStock();
                listBoxIngredients.Items.Clear();
                textBoxBreadType.Clear();
            }

        }
    }
}

//buttonSell removes sandwich from stock list
//and into sold
//and triggers method for adding to revenue


//and empties rightside of form
//and refreshes the listbox of sandwiches