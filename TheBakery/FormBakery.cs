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
            var FormNew = new FormNew(_bakery);
            FormNew.Show();
        }
    }
}
