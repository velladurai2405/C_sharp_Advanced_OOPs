using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagementApplication
{
    public static class FileHandling
    {
        public static void CreateFile()
        {
            if(!Directory.Exists("MetroCardManagementApplication"))
            {
                Directory.CreateDirectory("MetroCardManagementApplication");
            }
            if(!File.Exists("MetroCardManagementApplication/UserDetails.csv"))
            {
                File.Create("MetroCardManagementApplication/UserDetails.csv").Close();
            }
            if(!File.Exists("MetroCardManagementApplication/TicketFairDetails.csv"))
            {
                File.Create("MetroCardManagementApplication/TicketFairDetails.csv").Close();
            }
            if(!File.Exists("MetroCardManagementApplication/TravelDetails.csv"))
            {
                File.Create("MetroCardManagementApplication/TravelDetails.csv").Close();
            }
        }
        public static void WriteToCSV()
        {
            string[] users=new string[Operations.userList.Count];
            for(int i=0;i<Operations.userList.Count;i++)
            {
                users[i]=Operations.userList[i].CardNumber+","+Operations.userList[i].UserName+","+Operations.userList[i].PhoneNumber+","+Operations.userList[i].Balance;
            }
            File.WriteAllLines("MetroCardManagementApplication/UserDetails.csv",users);            


            string[] ticket=new string[Operations.ticketList.Count];
            for(int i=0;i<Operations.ticketList.Count;i++)
            {
                ticket[i]=Operations.ticketList[i].TicketID+","+Operations.ticketList[i].FromLocation+","+Operations.ticketList[i].ToLocation+","+Operations.ticketList[i].TicketPrice;
            }
            File.WriteAllLines("MetroCardManagementApplication/TicketFairDetails.csv",ticket);

            string[] travel=new string[Operations.travelList.Count];
            for(int i=0;i<Operations.travelList.Count;i++)
            {
                travel[i]=Operations.travelList[i].TravelId+","+Operations.travelList[i].CardNumber+","+Operations.travelList[i].FromLocation+","+Operations.travelList[i].ToLocation+","+Operations.travelList[i].Date.ToString("dd/MM/yyyy")+","+Operations.travelList[i].TravelCost;
            }
            File.WriteAllLines("MetroCardManagementApplication/TravelDetails.csv",travel);
        }
        public static void ReadFromCSV()
        {
            string[] users=File.ReadAllLines("MetroCardManagementApplication/UserDetails.csv");

            foreach(string user in users)
            {
                UserDetails user1=new UserDetails(user);
                Operations.userList.Add(user1);
            }
           
           string[] tickets=File.ReadAllLines("MetroCardManagementApplication/TicketFairDetails.csv");
           foreach(string ticket in tickets)
           {
            TicketFairDetails ticket1=new TicketFairDetails(ticket);
            Operations.ticketList.Add(ticket1);
           }

           string[] travels=File.ReadAllLines("MetroCardManagementApplication/TravelDetails.csv");
           foreach(string travel in travels)
           {
            TravelDetails travel1=new TravelDetails(travel);
            Operations.travelList.Add(travel1);
           }
        }

        
        
    }
}