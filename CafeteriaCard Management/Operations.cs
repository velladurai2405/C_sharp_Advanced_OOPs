using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CafeteriaCard_Management
{
    public static class Operations
    {
        public static UserDetails currentUser;
        static List<UserDetails> userList=new List<UserDetails>();
        static List<FoodDetails> foodList=new List<FoodDetails>();
        static List<CartItem> cartList=new List<CartItem>();
        static List<OrderDetails> orderList=new List<OrderDetails>();

        public static void AddDefaultData()
        {
            FoodDetails food1=new FoodDetails("Coffee",20,100);
            FoodDetails food2=new FoodDetails("Tea",15,100);
            FoodDetails food3=new FoodDetails("Biscuit",10,100);
            FoodDetails food4=new FoodDetails("Juice",50,100);
            FoodDetails food5=new FoodDetails("Puff",40,100);
            FoodDetails food6=new FoodDetails("Milk",10,100);
            FoodDetails food7=new FoodDetails("Popcorn",20,20);
            foodList.AddRange(new List<FoodDetails>{food1,food2,food3,food4,food5,food6,food7});

            UserDetails user1=new UserDetails("Ravichandran","Ettapparajan",8857777575,"ravi@gmail.com",Gender.Male,"WS101",400);
            UserDetails user2=new UserDetails("Baskaran","Sethurajan",9577747744,"baskaran@gmail.com",Gender.Male,"WS105",500);
            userList.AddRange(new List<UserDetails>{user1,user2});

            OrderDetails order1=new OrderDetails(user1.UserID,new DateTime(15/06/2022),70,OrderStatus.Ordered);
            OrderDetails order2=new OrderDetails(user2.UserID,new DateTime(15/06/2022),100,OrderStatus.Ordered);

            CartItem item1=new CartItem(order1.OrderID,food1.FoodID,20,1);
            CartItem item2=new CartItem(order1.OrderID,food3.FoodID,10,1);
            CartItem item3=new CartItem(order1.OrderID,food5.FoodID,40,1);
            CartItem item4=new CartItem(order2.OrderID,food3.FoodID,10,1);
            CartItem item5=new CartItem(order2.OrderID,food4.FoodID,50,1);
            CartItem item6=new CartItem(order2.OrderID,food5.FoodID,40,1);



        }
        public static void MainMenu()
        {
            int mainMenu;
            do
            {
                Console.WriteLine("1.User Registration\n2.User Login\n3.Exit\n");
                mainMenu = int.Parse(Console.ReadLine());
                switch(mainMenu)
                {
                    case 1:
                    {
                        UserRegistration();
                        break;
                    }
                    case 2:
                    {
                        UserLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Exited sucessfully.");
                        break;
                    }
                }
            }while(mainMenu!=3);
        }
        public static void UserRegistration()
        {
            Console.Write("Enter your name: ");
            string name=Console.ReadLine();
            Console.Write("Enter your Father Name: ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter your mobile Number: ");
            long mobile=long.Parse(Console.ReadLine());
            Console.Write("Enter mobile ID: ");
            string mailID=Console.ReadLine();
            Console.Write("Enter your gende: ");
            Gender gender;
            bool temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
            while (!temp)
            {
                Console.WriteLine("Invalid gender,Please reenter.");
                temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
            }
            Console.Write("Enter your work station number: ");
            string workStationNumber=Console.ReadLine();
            Console.Write("Enter your Balance: ");
            int balance=int.Parse(Console.ReadLine());
            UserDetails user=new UserDetails(name,fatherName,mobile,mailID,gender,workStationNumber,balance);
            Console.WriteLine("Your registration successfull and your id is: "+user.UserID);
            userList.Add(user);
        
        }
        public static void UserLogin()
        {
            Console.Write("Enter your User ID; ");
            string login=Console.ReadLine();
            bool subflag=false;
            foreach(UserDetails userData in userList)
            {
                if(login.Equals(userData.UserID))
                {
                    subflag=true;
                    currentUser=userData;
                    SubMenu();
                    break;    

                }
            }
            if(subflag==false)
            {
                Console.WriteLine("Invalid login Id.User does not exit.");
            }

        }
        public static void SubMenu()
        {
            int subMenu;
            do
            {
                Console.WriteLine("1.Show My Profile\n2.Food Order\n3.Modify Order\n4.Cancel Order\n5.Order History\n6.Wallet Recharge\n7.Show WalletBalance\n8.Exit");
                Console.WriteLine("Choose an option: ");
                subMenu = int.Parse(Console.ReadLine());
                switch (subMenu)
                {
                    case 1:
                        {
                            ShowMyProfile();
                            break;
                        }
                    case 2:
                        {
                            FoodOrder();
                            break;
                        }
                    case 3:
                        {
                            ModifyOrder();
                            break;
                        }
                    case 4:
                        {
                            CancelOrder();
                            break;
                        }
                    case 5:
                        {
                            OrderHistory();
                            break;
                        }
                    case 6:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 7:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Exited from submenu");
                            break;
                        }
                }
            } while (subMenu != 8);
        }
        public static void ShowMyProfile()
        {
            Console.WriteLine($"{currentUser.UserID}|{currentUser.Name}|{currentUser.FatherName}");

        }
        public static void FoodOrder()
        {
            List<CartItem> tempcartList = new List<CartItem>();
            OrderDetails order = new OrderDetails(currentUser.UserID, DateTime.Now, 0, OrderStatus.Initiated);
            string extraAdd = "yes";
            do
            {
                foreach (FoodDetails foodData in foodList)
                {
                    Console.WriteLine($"{foodData.FoodID}{foodData.FoodName}{foodData.FoodPrice}{foodData.AvailableQuantity}");
                }
                Console.WriteLine("Choose Food ID which you want");
                string food = Console.ReadLine();
                Console.WriteLine("Choose quantity which you want");
                int quantity = int.Parse(Console.ReadLine());
                foreach (FoodDetails foodData in foodList)
                {
                    if (foodData.FoodID.Equals(food))
                    {
                        if (foodData.AvailableQuantity >= quantity)
                        {
                            foodData.AvailableQuantity -= quantity;
                            CartItem cart1 = new CartItem(order.OrderID, foodData.FoodID, foodData.FoodPrice, quantity);
                            tempcartList.Add(cart1);
                            break;
                           
                        }
                    }
                    
                }
                Console.WriteLine("Do you want pick another product:yes/no");
                extraAdd = Console.ReadLine();

            } while(extraAdd=="yes");

            if (extraAdd == "no")
            {
                Console.WriteLine("Are you confirm the wish list to purchase: yes/no");
                String purchaseConfirmation = Console.ReadLine();
                if (purchaseConfirmation == "yes")
                {
                    int totalPrice=0;
                    foreach(CartItem cartData in tempcartList)
                    {
                        totalPrice+=cartData.OrderPrice*cartData.OrderQuantity;
                    }
                    if (totalPrice <= currentUser.WalletBalance)
                    {
                        int balance = currentUser.DeductAmount(totalPrice);
                        cartList.AddRange(tempcartList);
                        order.TotalPrice=totalPrice;
                        order.OrderStatus=OrderStatus.Ordered;
                        orderList.Add(order);
                        Console.WriteLine($"Balance: {balance}");
                    }
                    else
                    {
                        Console.WriteLine("Dot have enougn balance.Please recharge.\nDo you want recharge");
                        string rechargeConfirmation=Console.ReadLine();
                        if(rechargeConfirmation=="yes")
                        {
                           WalletRecharge();

                        }
                        else if(rechargeConfirmation=="no")
                        {
                            foreach(CartItem cartData in tempcartList)
                            {
                                foreach(FoodDetails foodData in foodList)
                                {
                                    if(cartData.FoodID.Equals(foodData.FoodID))
                                    {
                                        foodData.AvailableQuantity+=cartData.OrderQuantity;
                                    }
                                }
                            }
                        }
                    }

                }
                else if (purchaseConfirmation == "no")
                {
                    foreach (CartItem cartData in tempcartList)
                    {
                        foreach (FoodDetails foodData in foodList)
                        {
                            if (cartData.FoodID.Equals(foodData.FoodID))
                            {
                                foodData.AvailableQuantity += cartData.OrderQuantity;
                            }
                        }
                    }

                }

            }

        }
        public static void ModifyOrder()
        {
            bool itemFound=false;
            foreach(OrderDetails orderData in orderList)
            {
                if(orderData.UserID.Equals(currentUser.UserID))
                {
                    
                    if(orderData.OrderStatus==OrderStatus.Ordered)
                    {
                        itemFound=true;
                        Console.WriteLine($"{orderData.OrderID}|{orderData.OrderDate}|{orderData.TotalPrice}");
                    }
                }
            }
            if(itemFound)
            {
                foreach(CartItem cartData in cartList)
                {
                    Console.WriteLine($"{cartData.ItemID}|{cartData.OrderID}|{cartData.FoodID}|{cartData.OrderQuantity}");
                }
                Console.WriteLine("Pick Item which you want to modify");
                String modifyItem=Console.ReadLine();
                foreach(CartItem cartData in cartList)
                {
                    if(modifyItem.Equals(cartData.ItemID))
                    {
                        Console.WriteLine("Enter new quantity of food.");
                        int quantity=int.Parse(Console.ReadLine());
                        int totalPrice=cartData.OrderPrice*quantity;
                        cartData.OrderPrice=totalPrice;
                        foreach(FoodDetails foodData in foodList)
                        {
                            if(foodData.FoodID.Equals(cartData.FoodID))
                            {
                                foodData.AvailableQuantity-=quantity;
                            }
                        }
                        Console.WriteLine("Order modified succesfully");
                    }
                }
            }
            else if (itemFound == false)
            {

                Console.WriteLine("No orders found to modify.");
            }

        }
        public static void CancelOrder()
        {
            bool cancelFlag=false;
            bool isOderTrue=false;
            foreach (OrderDetails orderData in orderList)
            {
                if (orderData.OrderStatus == OrderStatus.Ordered)
                {
                    isOderTrue=true;
                    Console.WriteLine($"{orderData.OrderID}|{orderData.OrderDate}|{orderData.TotalPrice}");
                }

            }
            if (isOderTrue)
            {
                Console.WriteLine("Choose an order to cancel");
                string cancelOrderID = Console.ReadLine();
                foreach (OrderDetails orderData in orderList)
                {


                    if (cancelOrderID.Equals(orderData.OrderID))
                    {
                        foreach (CartItem cartData in cartList)
                        {
                            if (orderData.OrderID.Equals(cartData.OrderID))
                            {
                                foreach (FoodDetails foodData in foodList)
                                {
                                    if (cartData.FoodID.Equals(foodData.FoodID))
                                    {
                                        foodData.AvailableQuantity += cartData.OrderQuantity;
                                        orderData.OrderStatus = OrderStatus.Cancelled;
                                        cancelFlag = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (isOderTrue == false)
            {
                Console.WriteLine("no order found ");
            }
            if (cancelFlag)
            {
                Console.WriteLine("Order canceled sucessfully");
            }

        }
        public static void OrderHistory()
        {
            bool orderFlag=false;
            foreach(OrderDetails orderData in orderList)
            {
                if(currentUser.UserID.Equals(orderData.UserID))
                {
                    
                    if(orderData.OrderStatus==OrderStatus.Ordered)
                    {
                        orderFlag=true;
                        Console.WriteLine($"{orderData.OrderID}|{orderData.OrderDate}|{orderData.TotalPrice}");
                    }
                }
            }
            if(orderFlag==false)
            {
                Console.WriteLine("No order history found");
            }

        }
        public static void WalletRecharge()
        {
            Console.Write("Enter how much amount to recharge: ");
            int rechargeAmount = int.Parse(Console.ReadLine());
            int balance = currentUser.WalletRecharge(rechargeAmount);
            Console.WriteLine($"balance: {balance}");

        }
        public static void ShowWalletBalance()
        {
            Console.WriteLine(currentUser.WalletBalance);

        }
    }
}