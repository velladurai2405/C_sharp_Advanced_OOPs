using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodDeliveryApplication
{
    public static class Operations
    {
        public static CustomerDeatails currentUser;
        static CustomList<CustomerDeatails> customerList = new CustomList<CustomerDeatails>();
        static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
        static CustomList<ItemDetails> itemList = new CustomList<ItemDetails>();
        static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();

        public static void AddDefaultInfo()
        {
            CustomerDeatails customer1 = new CustomerDeatails(10000, "Ravi", "Ettapparajan", Gender.Male, "974774646", new DateTime(11 / 11 / 1999), "ravi@gmail.com", "Chennai");
            customerList.Add(customer1);
            CustomerDeatails customer2 = new CustomerDeatails(15000, "Baskaran", "Sethurajan", Gender.Male, "847575775", new DateTime(11 / 11 / 1999), "baskaran@gmail.com", "Chennai");
            customerList.Add(customer2);

            FoodDetails food1 = new FoodDetails("Chicken Briyani 1Kg", 100, 12);
            foodList.Add(food1);
            FoodDetails food2 = new FoodDetails("Mutton Briyani 1Kg", 150, 10);
            foodList.Add(food2);
            FoodDetails food3 = new FoodDetails("Veg Full Meals", 80, 30);
            foodList.Add(food3);
            FoodDetails food4 = new FoodDetails("Noodles", 100, 40);
            foodList.Add(food4);
            FoodDetails food5 = new FoodDetails("Dosa", 40, 40);
            foodList.Add(food5);
            FoodDetails food6 = new FoodDetails("Idly (2 pieces)", 20, 50);
            foodList.Add(food6);
            FoodDetails food7 = new FoodDetails("Pongal", 40, 20);
            foodList.Add(food7);
            FoodDetails food8 = new FoodDetails("Vegetable Briyani", 80, 15);
            foodList.Add(food8);
            FoodDetails food9 = new FoodDetails("Lemon Rice", 50, 30);
            foodList.Add(food9);
            FoodDetails food10 = new FoodDetails("Veg Pulav", 120, 30);
            foodList.Add(food10);
            FoodDetails food11 = new FoodDetails("Chicken 65 (200 Grams)", 75, 30);
            foodList.Add(food11);

            OrderDetails order1 = new OrderDetails(customer1.CustomerID, 580, new DateTime(26 / 11 / 2022), OrderStatus.Ordered);
            orderList.Add(order1);
            OrderDetails order2 = new OrderDetails(customer2.CustomerID, 870, new DateTime(26 / 11 / 2022), OrderStatus.Ordered);
            orderList.Add(order2);
            OrderDetails order3 = new OrderDetails(customer1.CustomerID, 820, new DateTime(26 / 11 / 2022), OrderStatus.Cancelled);
            orderList.Add(order3);

            ItemDetails item1 = new ItemDetails(order1.OrderID, food1.FoodID, 2, 200);
            itemList.Add(item1);
            ItemDetails item2 = new ItemDetails(order1.OrderID, food2.FoodID, 2, 300);
            itemList.Add(item2);
            ItemDetails item3 = new ItemDetails(order1.OrderID, food3.FoodID, 1, 80);
            itemList.Add(item3);
            ItemDetails item4 = new ItemDetails(order2.OrderID, food1.FoodID, 1, 100);
            itemList.Add(item4);
            ItemDetails item5 = new ItemDetails(order2.OrderID, food2.FoodID, 4, 600);
            itemList.Add(item5);
            ItemDetails item6 = new ItemDetails(order2.OrderID, food10.FoodID, 1, 120);
            itemList.Add(item6);
            ItemDetails item7 = new ItemDetails(order2.OrderID, food9.FoodID, 1, 50);
            itemList.Add(item7);
            ItemDetails item8 = new ItemDetails(order3.OrderID, food2.FoodID, 2, 300);
            itemList.Add(item8);
            ItemDetails item9 = new ItemDetails(order3.OrderID, food8.FoodID, 4, 320);
            itemList.Add(item9);
            ItemDetails item10 = new ItemDetails(order3.OrderID, food1.FoodID, 2, 200);
            itemList.Add(item10);

        }
        public static void MainMenu()
        {
            int mainMenuOption;
            do
            {
                Console.WriteLine("1.Customer Registration\n2.Customer Login\n3.Exit");
                mainMenuOption = int.Parse(Console.ReadLine());
                switch (mainMenuOption)
                {
                    case 1:
                        {
                            CustomerRegistration();
                            break;
                        }
                    case 2:
                        {
                            CustomerLogin();
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                }
            } while (mainMenuOption != 3);
        }

        public static void CustomerRegistration()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your father name: ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your Gender: ");
            Gender gender;
            bool temp = Enum.TryParse<Gender>(Console.ReadLine(), true, out gender);
            Console.Write("Enter your mobile number: ");
            string mobile = Console.ReadLine();
            Console.Write("Enter your date of birth: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter your mail ID: ");
            string mailID = Console.ReadLine();
            Console.Write("Enter your location: ");
            string loaction = Console.ReadLine();
            Console.Write("Enter you wallet balance: ");
            double walletBalance = double.Parse(Console.ReadLine());
            CustomerDeatails customer = new CustomerDeatails(walletBalance, name, fatherName, gender, mobile, dob, mailID, loaction);
            customerList.Add(customer);
            Console.WriteLine("Succsfully registerd and your customer ID is " + customer.CustomerID);
            Console.WriteLine();

        }
        public static void CustomerLogin()
        {
            Console.WriteLine("************Login*************");
            Console.WriteLine("enter your login ID");
            string login = Console.ReadLine();
            foreach (CustomerDeatails customerData in customerList)
            {
                if (login.Equals(customerData.CustomerID))
                {
                    currentUser = customerData;
                    Console.WriteLine("Login succesfull");
                    SubMenu();


                }
            }

        }
        public static void SubMenu()
        {
            int subMenuOption;
            do
            {
                Console.WriteLine("1.Show Profile\n2.Order Food\n3.Cancel Order\n4.Modify Order\n5.Order History\n6.Recharge Wallet\n7.Show Wallet Balance\n8.Exit");
                subMenuOption = int.Parse(Console.ReadLine());
                switch (subMenuOption)
                {
                    case 1:
                        {
                            ShowProfile();
                            break;
                        }
                    case 2:
                        {
                            OrderFood();
                            break;
                        }
                    case 3:
                        {
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            ModifyOrder();
                            break;
                        }
                    case 5:
                        {
                            OrderHistory();
                            break;
                        }
                    case 6:
                        {
                            RechargeWallet();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("balance"+currentUser.WalletBalance);
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("you are redirected to mainmenu");
                            break;
                        }
                }
            } while (subMenuOption != 8);
        }
        public static void ShowProfile()
        {
            Console.WriteLine($"Customer ID:{currentUser.CustomerID}| Customer Name:{currentUser.Name}| Father Name:{currentUser.FatherName}| Gender:{currentUser.Gender}| DOB;{currentUser.DOB}| Mobile Number{currentUser.Mobile}| Mail:{currentUser.MailID} Location:{currentUser.Location}| Blance:{currentUser.WalletBalance}");

        }
        public static void OrderFood()
        {
            OrderDetails order = new OrderDetails(currentUser.CustomerID, 0, DateTime.Now, OrderStatus.Initiated);
            CustomList<ItemDetails> localItemList = new CustomList<ItemDetails>();
            int totalAmount = 0;

            string extraAddConfirmation = "yes";
            do
            {
                foreach (FoodDetails foodData in foodList)
                {
                    Console.WriteLine($"FoodID:{foodData.FoodID}| Food Name:{foodData.FoodName}| Price:{foodData.PricePerQuantity}| Available:{foodData.QuantityAvailable}");
                }
                Console.Write("Enter FoodID which you want: ");
                string userFoodID = Console.ReadLine().ToUpper();
                foreach (FoodDetails foodData in foodList)
                {
                    if (userFoodID.Equals(foodData.FoodID))
                    {
                        Console.Write("Enter number of quantity do you want: ");
                        int purchaseCount = int.Parse(Console.ReadLine());
                        if (foodData.QuantityAvailable >= purchaseCount)
                        {
                            foodData.QuantityAvailable -= purchaseCount;
                            int priceOfItem = foodData.PricePerQuantity * purchaseCount;
                            totalAmount += priceOfItem;
                            ItemDetails item = new ItemDetails(order.OrderID, foodData.FoodID, purchaseCount, priceOfItem);
                            localItemList.Add(item);
                            Console.WriteLine("succesfully added to item");
                            break;
                        }

                    }
                }
                Console.WriteLine("Do you order more: yes/no");
                extraAddConfirmation = Console.ReadLine().ToLower();

            } while (extraAddConfirmation == "yes");

            if (extraAddConfirmation == "no")
            {
                Console.WriteLine("Do you want confirm to purchase: yes/no");
                string purchaseConformation = Console.ReadLine().ToLower();
                if (purchaseConformation == "yes")
                {
                    if (currentUser.WalletBalance >= totalAmount)
                    {
                        order.TotalPrice = totalAmount;
                        order.OrderStatus = OrderStatus.Ordered;
                        currentUser.DeductBalance(totalAmount);
                        itemList.AddRange(localItemList);
                        orderList.Add(order);
                        Console.WriteLine("You have succesfully ordered");
                    }
                    else
                    {
                        Console.WriteLine("Sorry...you dont have sufficent balance.");
                        Console.WriteLine("Do you want to recharge: yes/no");
                        string rechargeConformation = Console.ReadLine().ToLower();
                        if (rechargeConformation == "yes")
                        {
                            RechargeWallet();
                        }
                        else if (rechargeConformation == "no")
                        {
                            foreach (ItemDetails itemData in localItemList)
                            {
                                foreach (FoodDetails foodData in foodList)
                                {
                                    if (itemData.FoodID.Equals(foodData.FoodID))
                                    {
                                        foodData.QuantityAvailable += itemData.PurchaseCount;
                                    }
                                }
                            }

                        }
                    }
                }
                else if (purchaseConformation == "no")
                {
                    foreach (ItemDetails itemData in localItemList)
                    {
                        foreach (FoodDetails foodData in foodList)
                        {
                            if (itemData.FoodID.Equals(foodData.FoodID))
                            {
                                foodData.QuantityAvailable += itemData.PurchaseCount;
                            }
                        }
                    }
                }
            }

        }
        public static void CancelOrder()
        {
            bool orderStatusFlag = true;
            foreach (OrderDetails orderData in orderList)
            {
                if (currentUser.CustomerID.Equals(orderData.CustomerID))
                {
                    if (orderData.OrderStatus.Equals(OrderStatus.Ordered))
                    {
                        orderStatusFlag = false;
                        Console.WriteLine($" Order ID:{orderData.OrderID}| Customer ID:{orderData.CustomerID}| Total Price:{orderData.TotalPrice}| Date:{orderData.DateOfOrder}| Order Status:{orderData.OrderStatus}");
                    }
                }
            }
            if (orderStatusFlag)
            {
                Console.WriteLine("no orders to cancel");
            }
            else if (orderStatusFlag == false)
            {
                Console.Write("Choose order ID to cancel: ");
                string cancelID = Console.ReadLine().ToUpper();
                foreach (OrderDetails orderData in orderList)
                {
                    if (cancelID.Equals(orderData.OrderID))
                    {
                        orderData.OrderStatus = OrderStatus.Cancelled;
                        if (currentUser.CustomerID.Equals(orderData.OrderID))
                        {
                            currentUser.WalletRecharge(orderData.TotalPrice);
                        }
                        foreach (ItemDetails itemData in itemList)
                        {
                            if (orderData.OrderID.Equals(itemData.OrderID))
                            {
                                foreach (FoodDetails foodData in foodList)
                                {
                                    if (itemData.FoodID.Equals(foodData.FoodID))
                                    {
                                        foodData.QuantityAvailable += itemData.PurchaseCount;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        public static void ModifyOrder()
        {
            bool modifyStatusFlag = true;
            foreach (OrderDetails orderData in orderList)
            {
                if (currentUser.CustomerID.Equals(orderData.CustomerID))
                {
                    if (orderData.OrderStatus.Equals(OrderStatus.Ordered))
                    {
                        modifyStatusFlag = false;
                        Console.WriteLine($" Order ID:{orderData.OrderID}| Customer ID:{orderData.CustomerID}| Total Price:{orderData.TotalPrice}| Date:{orderData.DateOfOrder}| Order status:{orderData.OrderStatus}");
                    }
                }
            }
            if (modifyStatusFlag)
            {
                Console.WriteLine("no orders to modify");
            }
            else if (modifyStatusFlag == false)
            {
                bool itemFound = false;
                Console.WriteLine("Enter order ID which you want to modify");
                string modifyOrderID = Console.ReadLine();


                foreach (ItemDetails itemData in itemList)
                {
                    if (modifyOrderID.Equals(itemData.OrderID))
                    {
                        itemFound = true;
                        Console.WriteLine($"Item ID:{itemData.ItemID}| Order ID:{itemData.OrderID}| Food ID:{itemData.FoodID}| Purchase Count:{itemData.PurchaseCount}| Price:{itemData.PriceOfOrder}");
                    }
                }



                Console.WriteLine("Enter Item ID which you want to modify");
                string modifyItemID = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter number of quantity to add or decrease");
                int modifyQuantity = int.Parse(Console.ReadLine());
                if (itemFound)
                {
                    foreach (OrderDetails orderData in orderList)
                    {
                        foreach (ItemDetails itemData in itemList)
                        {
                            if (modifyItemID.Equals(itemData.ItemID))
                            {
                                foreach (FoodDetails foodData in foodList)
                                {
                                    if (itemData.FoodID.Equals(foodData.FoodID))
                                    {
                                        if (modifyQuantity >= 0)
                                        {
                                            foodData.QuantityAvailable -= modifyQuantity;
                                            int amount = foodData.PricePerQuantity * modifyQuantity;
                                            currentUser.DeductBalance(amount);
                                            orderData.TotalPrice += amount;

                                        }
                                        else
                                        {
                                            foodData.QuantityAvailable += modifyQuantity;
                                            int amount = foodData.PricePerQuantity * modifyQuantity;
                                            currentUser.WalletRecharge(amount);
                                            orderData.TotalPrice -= amount;
                                        }
                                       
                                    }
                                }
                            }
                        }
                    }
                }
                 Console.WriteLine("Modified succesfully");

            }

        }
        public static void OrderHistory()
        {
            foreach (OrderDetails orderData in orderList)
            {
                Console.WriteLine($"Order ID{orderData.OrderID}| Customer ID:{orderData.CustomerID}| Total Price:{orderData.TotalPrice}| Date:{orderData.DateOfOrder}| Order Status:{orderData.OrderStatus}");
            }
        }
        public static void RechargeWallet()
        {
            Console.Write("Enter how much amount do you want to recharge: ");
            double rechargeAmount = double.Parse(Console.ReadLine());
            double balance = currentUser.WalletRecharge(rechargeAmount);
            Console.WriteLine($"succesfully recharged and your updated balance is {currentUser.WalletBalance}");

        }

    }
}