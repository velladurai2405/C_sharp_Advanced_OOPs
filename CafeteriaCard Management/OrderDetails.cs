using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard_Management
{
    public enum OrderStatus{Default, Initiated, Ordered, Cancelled} 
    public class OrderDetails
    {
        private static int _orderID=1000;
        public string OrderID { get; }
        public string UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public OrderStatus  OrderStatus  { get; set; }
        public OrderDetails(string userID,DateTime orderDate,int totalPrice,OrderStatus  orderStatus)
        {
            _orderID++;
            OrderID="OID"+_orderID;
            UserID=userID;
            OrderDate=orderDate;
            TotalPrice=totalPrice;
            OrderStatus=orderStatus;
            

        }
    }
}