using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeBakery
{
	public class BakeryModel
	{
        public event Action StockUpdated;

        public string Name { get; set; }
        public int Revenue { get; set; }
        public List<SandwichModel> SandwichesInStock { get; set; } = new List<SandwichModel>();
        public List<SandwichModel> SoldSandwiches { get; set; } = new List<SandwichModel>();
        public List<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>(); //all available ingredients

        public BakeryModel()
        {
            Ingredients.Add(new IngredientModel("Kip", 5));
            Ingredients.Add(new IngredientModel("Steak", 5));
            Ingredients.Add(new IngredientModel("Bacon", 2));
            Ingredients.Add(new IngredientModel("Gehakt bal", 5));
            Ingredients.Add(new IngredientModel("Veggie burger", 4));
            Ingredients.Add(new IngredientModel("Gebakken ei", 2));
            Ingredients.Add(new IngredientModel("Tomaat", 2));
            Ingredients.Add(new IngredientModel("ui", 2));
        }
        public void AddSandwich(SandwichModel sandwich)
        {
            SandwichesInStock.Add(sandwich);
            StockUpdated?.Invoke();
        }

    }
}
