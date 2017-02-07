using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
 public  class FoodStore
    {
        public static List<FoodItem> foodStorage;
        public FoodStore()
        {
            foodStorage= new List<FoodItem>();
            foodStorage.Add(new FoodItem("Drink", 5, 1.00F));
            foodStorage.Add(new FoodItem("Crisps", 5, 0.35F));
            foodStorage.Add(new FoodItem("Chocolate", 1, 0.85F));
            foodStorage.Add(new FoodItem("Apple", 3, 0.66F));
            foodStorage.Add(new FoodItem("Banana", 3, 0.75F));
        

        }

       
    }
}
