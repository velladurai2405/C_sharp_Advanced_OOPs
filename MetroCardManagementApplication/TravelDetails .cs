using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagementApplication
{
    public class TravelDetails 
    {
        //static fields
        private static int s_travelID=2000;
        public string TravelId { get; }
        //properties
        public string CardNumber { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime Date { get; set; }
        public int TravelCost { get; set; }

        //constructor
        public TravelDetails(string cardNumber,string fromLocation,string toLocation,DateTime date,int travelCost)
        {
            s_travelID++;
            TravelId="TID"+s_travelID;
            CardNumber=cardNumber;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            Date=date;
            TravelCost=travelCost;
        }
        public TravelDetails(string travel)
        {
            string[] values=travel.Split(",");
            s_travelID=int.Parse(values[0].Remove(0,3));
            TravelId=values[0];
            CardNumber=values[1];
            FromLocation=values[2];
            ToLocation=values[3];
            Date=DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
            TravelCost=int.Parse(values[5]);
        }
    }
}