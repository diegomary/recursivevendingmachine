using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
 public   class FoodItem
    {
        public FoodItem(string name,int initialQuantity,float price)
        {
            Quantity = initialQuantity;
            Price = price;
            Name = name;
        }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }

    }



}
