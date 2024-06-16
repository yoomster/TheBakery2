﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeBakery
{
	public class IngredientModel
	{
        public string Name { get; set; }
        public int Price { get; set; }

        public IngredientModel(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
