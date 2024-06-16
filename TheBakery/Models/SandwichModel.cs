﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBakery;

namespace DeBakery
{
public class SandwichModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public BreadTypeEnum BreadType { get; set; }
        public List<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>(); //only the ingredients that go in this sandwich


        public override string ToString()
        {
            return Name;
        }
    }
}