using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard_Management
{
    public class FoodDetails
    {
        private static int _foodID=100;
        public string FoodID { get;  }
        public string FoodName { get; set; }
        public int FoodPrice { get; set; }
        public int AvailableQuantity { get; set; }

        public FoodDetails(string foodName,int foodPrice,int availableQuantity)
        {
            _foodID++;
            FoodID="FID"+_foodID;
            FoodName=foodName;
            FoodPrice=foodPrice;
            AvailableQuantity=availableQuantity;

        }
    }
}