using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagementApplication
{
    public static class Operations
    {
        //userDetails temp object
        public static UserDetails currentUser;
        //list creation-custom list
        public static CustomList<UserDetails> userList=new CustomList<UserDetails>();
        public static CustomList<TicketFairDetails> ticketList=new CustomList<TicketFairDetails>();
        public static CustomList<TravelDetails> travelList=new CustomList<TravelDetails>();

        //Adding default info
        public static void AddDefaultInfo()
        {
            UserDetails user1=new UserDetails("Ravi",9848812345,1000);
            userList.Add(user1);
            UserDetails user2=new UserDetails("Baskaran",9948854321,1000);
            userList.Add(user2);

            TicketFairDetails ticket1=new TicketFairDetails("Airport","Egmore",55);
            ticketList.Add(ticket1);
            TicketFairDetails ticket2=new TicketFairDetails("Airport","Koyambedu",25);
            ticketList.Add(ticket2);
            TicketFairDetails ticket3=new TicketFairDetails("Alandur","Koyambedu",25);
            ticketList.Add(ticket3);
            TicketFairDetails ticket4=new TicketFairDetails("Koyambedu","Egmore",32);
            ticketList.Add(ticket4);
            TicketFairDetails ticket5=new TicketFairDetails("Vadapalani","Egmore",45);
            ticketList.Add(ticket5);
            TicketFairDetails ticket6=new TicketFairDetails("Arumbakkam","Egmore",25);
            ticketList.Add(ticket6);
            TicketFairDetails ticket7=new TicketFairDetails("Vadapalani","Koyambedu",25);
            ticketList.Add(ticket7);
            TicketFairDetails ticket8=new TicketFairDetails("Arumbakkam","Koyambedu",16);
            ticketList.Add(ticket8);

            TravelDetails travel1=new TravelDetails("CMRL1001","Airport","Egmore",new DateTime(2023,10,10),55);
            travelList.Add(travel1);
            TravelDetails travel2=new TravelDetails("CMRL1001","Egmore","Koyambedu",new DateTime(2023,10,10),32);
            travelList.Add(travel2);
            TravelDetails travel3=new TravelDetails("CMRL1002","Alandur","Koyambedu",new DateTime(2023,11,10),25);
            travelList.Add(travel3);
            TravelDetails travel4=new TravelDetails("CMRL1002","Egmore","Thirumangalam",new DateTime(2023,11,10),25);
            travelList.Add(travel4);

        }

        public static void MainMenu()
        {
            int mainMenuOption;
            //excute until given 3
            do
            {
                Console.WriteLine();
                Console.WriteLine("1.New User Registration\n2.Login User\n3.Exit");
                mainMenuOption=int.Parse(Console.ReadLine());
                switch(mainMenuOption)
                {
                    case 1:
                    {
                        NewUserRegistration();
                        break;
                    }
                    case 2:
                    {
                        LoginUser();
                        break;
                    }
                }

            }while(mainMenuOption!=3);
        }

        public static void NewUserRegistration()
        {
            //getting user input to register
            Console.Write("Enter your name: ");
            string userName=Console.ReadLine();
            Console.Write("Enter your phone number: ");
            long phoneNumber=long.Parse(Console.ReadLine());
            Console.Write("Enter your balance: ");
            int balance=int.Parse(Console.ReadLine());

            //userdetails object creation
            UserDetails user=new UserDetails(userName,phoneNumber,balance);

            //adding information to the user list
            userList.Add(user);
            Console.WriteLine();
            Console.WriteLine($"You have succefully registered and your card number is {user.CardNumber}");

        }
        public static void LoginUser()
        {
            Console.Write("Enter your card number: ");
            bool userExist=true;
            string login=Console.ReadLine().ToUpper();
            foreach(UserDetails userData in userList)
            {
                if(login.Equals(userData.CardNumber))
                {
                    userExist=false;
                    currentUser=userData;
                    SubMenu();
                    break;

                }
            }
            if(userExist)
            {
                Console.WriteLine("No user found");
            }

        }

        public static void SubMenu()
        {
            int subMenuOption;
            Console.WriteLine("Login succesfull");
            Console.WriteLine();
            do
            {
                //Execute untill enter 5
                Console.WriteLine();
                Console.WriteLine("1.Balance Check\n2.Recharge\n3.View Travel History\n4.Travel\n5.Exit");
                subMenuOption=int.Parse(Console.ReadLine());
                switch(subMenuOption)
                {
                    case 1:
                    {
                        Console.WriteLine($"Your balance amount is {currentUser.Balance}");
                        break;
                    }
                    case 2:
                    {
                        Recharge();
                        break;
                    }
                    case 3:
                    {
                        ViewTravelHistory();
                        break;
                    }
                    case 4:
                    {
                        Travel();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("You are redirected to Main Menu");
                        break;
                    }
                }
            }while(subMenuOption!=5);

        }
        
        public static void Recharge()
        {
            Console.Write("Enter how much amount do you want to recharge: ");
            //recharge amount getting
            double rechargeAmount=double.Parse(Console.ReadLine());
            //adding money in current user and showing updated balance
            double balance=currentUser.WalletRecharge(rechargeAmount);
            Console.WriteLine($"Sucessfully recharged and your updated balance is {currentUser.Balance}");
            
        }
        public static void ViewTravelHistory()	
        {
            //showing travel history
            foreach(TravelDetails travelData in travelList)
            {
                Console.WriteLine($"Travel ID:{travelData.TravelId} Card Number:{travelData.CardNumber} Start Location:{travelData.FromLocation} End Location:{travelData.ToLocation} Ticket Price:{travelData.TravelCost}");
            }          
            
        }
        public static void Travel()
        {
            //showing available ticket ID
            foreach(TicketFairDetails ticketData in ticketList)
            {
                Console.WriteLine($"TicketID:{ticketData.TicketID} Start Location:{ticketData.FromLocation} End Location:{ticketData.ToLocation} Ticket Price:{ticketData.TicketPrice}");
            }
            Console.Write("Enter ticket ID based on your travel: ");
            string ticket=Console.ReadLine().ToUpper();
            bool isTicket=true;
            foreach(TicketFairDetails ticketData in ticketList)
            {
                //checking user input ticketID and default ticketID 
                if(ticket.Equals(ticketData.TicketID))
                {
                    isTicket=false;
                    //checking user have sufficient balance
                    if(currentUser.Balance>=ticketData.TicketPrice)
                    {
                        //balance deduction to book ticket
                        currentUser.DeductBalance(ticketData.TicketPrice);
                        //object creation for travel Details
                        TravelDetails travel=new TravelDetails(currentUser.CardNumber,ticketData.FromLocation,ticketData.ToLocation,DateTime.Now,ticketData.TicketPrice);
                        //adding travel object to travel list
                        travelList.Add(travel);
                        Console.WriteLine("Successfully ticket booked.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry....you don't have sufficient balance.so,please reachrge");
                        break;

                    }

                }
            }
            if(isTicket)
            {
                Console.WriteLine("No ticket found");
            }
            
        }
    }
}