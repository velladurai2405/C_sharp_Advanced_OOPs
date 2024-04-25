using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagementApplication
{
    public class TicketFairDetails 
    {
        //static fields
        private static int s_ticketID=3000;
        //properties
        public string TicketID  { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int TicketPrice { get; set; }
        //constructor
        public TicketFairDetails(string fromLocation,string toLocation,int ticketPrice)
        {
            s_ticketID++;
            TicketID="MR"+s_ticketID;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            TicketPrice=ticketPrice;

        }
        public TicketFairDetails(string ticket)
        {
            string[] values=ticket.Split(",");
            s_ticketID=int.Parse(values[0].Remove(0,2));
            TicketID=values[0];
            FromLocation=values[1];
            ToLocation=values[2];
            TicketPrice=int.Parse(values[3]);

        }
    }
}