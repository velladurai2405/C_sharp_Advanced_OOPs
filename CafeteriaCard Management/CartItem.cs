using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard_Management
{
    public class CartItem
    {
        private static int _itemID=100;
        public string ItemID  { get; }
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public int OrderPrice { get; set; }
        public int OrderQuantity { get; set; }

        public CartItem(string orderID,string foodID,int orderPrice,int orderQuantity)
        {
            _itemID++;
            ItemID="ITI"+_itemID;
            OrderID=orderID;
            FoodID=foodID;
            OrderPrice=orderPrice;
            OrderQuantity=orderQuantity;

        }
        
    }
}