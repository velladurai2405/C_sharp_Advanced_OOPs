using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace EbookApplication
{
    public static class Operations
    {
        public static UserDetails currentLoggedInUser;
        //List creation
        static List<UserDetails> userList=new List<UserDetails>();
        static List<BookDetails> bookList=new List<BookDetails>();
        static List<BorrowDetails> borrowList=new List<BorrowDetails>();

        public static void AddDefaultData()
        {
            UserDetails user1=new UserDetails("Ravichandran",Gender.Male,Deparment.EEE,9938388333,"ravi@gmail.com",100);
            userList.Add(user1);
            UserDetails user2=new UserDetails("Priyadharshini",Gender.Female,Deparment.CSE,9944444455,"priya@gmail.com",150);
            userList.Add(user2);

            BookDetails book1=new BookDetails("C#","Author1",3);
            bookList.Add(book1);
            BookDetails book2=new BookDetails("HTML","Author2",5);
            bookList.Add(book2);
            BookDetails book3=new BookDetails("CSS","Author3",3);
            bookList.Add(book3);
            BookDetails book4=new BookDetails("JS","Author4",3);
            bookList.Add(book4);
            BookDetails book5=new BookDetails("TS","Author5",2);
            bookList.Add(book5);

            BorrowDetails borrow1=new BorrowDetails(book1.BookID,user1.UserID,new DateTime(2023,09,10),2,Status.Borrowed,0);
            borrowList.Add(borrow1);
            BorrowDetails borrow2=new BorrowDetails(book3.BookID,user1.UserID,new DateTime(2023,09,12),1,Status.Borrowed,0);
            borrowList.Add(borrow2);
            BorrowDetails borrow3=new BorrowDetails(book4.BookID,user1.UserID,new DateTime(2023,09,14),1,Status.Returned,16);
            borrowList.Add(borrow3);
            BorrowDetails borrow4=new BorrowDetails(book2.BookID,user2.UserID,new DateTime(2023,09,11),2,Status.Borrowed,0);
            borrowList.Add(borrow4);
            BorrowDetails borrow5=new BorrowDetails(book5.BookID,user2.UserID,new DateTime(2023,09,09),1,Status.Returned,20);
            borrowList.Add(borrow5);
            
        }
    public static void MainMenu()
    {
        int mainMenuOption;
        do
        {
            //need to run the loop until click exit
            Console.WriteLine("1.UserRegistration\n2.UserLogin\n3.Exit");
            mainMenuOption=int.Parse(Console.ReadLine());
            switch(mainMenuOption)
            {
                case 1:
                {
                    Console.WriteLine("UserRegistration");
                    UserRegistration();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("UserLogin");
                    UserLogin();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("Exited suceefully");
                    break;
                }
            }

        }while(mainMenuOption!=3);
    }
    public static void UserRegistration()
    {
        Console.Write("Enter user name: ");
        string userName=Console.ReadLine();
        Console.WriteLine("Enter Your Gender: ");
        Gender gender;
        bool temp=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
        while(!temp)
        {
            Console.WriteLine("You have entered invalid gender. please reenter");
            temp=Enum.TryParse<Gender>(Console.ReadLine(),true,out gender);
        }
        Console.Write("Enter your Department ECE or CSE or EEE: ");
        Deparment department;
        bool temp1=Enum.TryParse<Deparment>(Console.ReadLine(),true,out department);
        while(!temp1)
        {
            Console.WriteLine("You have entered invalid Department. please reenter");
            temp1=Enum.TryParse<Deparment>(Console.ReadLine(),true,out department);
        }
        
        Console.Write("Enter your Mobile Number: ");
        long mobileNumber=long.Parse(Console.ReadLine());
        Console.Write("Enter your mail ID: ");
        string mailID=Console.ReadLine();
        Console.Write("Enter your wallet balance: ");
        int walletBalance=int.Parse(Console.ReadLine());

        UserDetails userDetails=new UserDetails(userName,gender,department,mobileNumber,mailID,walletBalance);
        userList.Add(userDetails);
        Console.WriteLine("Your user registration complete and your ID is"+userDetails.UserID);

    }
    public static void UserLogin()
    {
        Console.Write("Enter your user ID: ");
        Console.WriteLine();
        string login=Console.ReadLine();
        bool flag=true;
        foreach(UserDetails user in userList)
        {
            if(user.UserID==login)
            {
                Console.WriteLine("Login succefull.");
                    flag= false;
                    currentLoggedInUser=user;
                    SubMenu();
                    break;
            }
        }
        if(flag)
        {
            Console.WriteLine("You have entered wrong login ID.");
        }

    }
    public static void SubMenu()
    {
        int subMenuOption;
        do
        {
            Console.WriteLine("1.Borrowbook\n2.ShowBorrowedhistory\n3.ReturnBooks\n4.WalletRecharge\n5.Exit");
            Console.WriteLine("Enter an option");
            subMenuOption=int.Parse(Console.ReadLine());
            switch(subMenuOption)
            {
                case 1:
                {
                    Borrowbook();
                    break;
                }
                case 2:
                {
                    ShowBorrowedhistory();
                    break;
                }
                case 3:
                {
                    ReturnBooks();
                    break;
                }
                case 4:
                {
                    Console.Write("Enter the amount you want to recharge: ");
                    int amount=int.Parse(Console.ReadLine());
                    Console.WriteLine($"Your updated wallet balance is: {currentLoggedInUser.WalletRecharge(amount)}");
                    break;
                }
                case 5:
                {
                    break;
                }
            }

        }while(subMenuOption!=5);

    }
    public static void Borrowbook()
    {
         foreach(BookDetails book in bookList)
         {
                if (book.BookCount > 0)
                {
                    Console.WriteLine($"{book.BookID}|{book.BookName}|{book.AuthorName}|{book.BookCount}");

                }
            }         
        foreach(BookDetails book in bookList)
        {              
                Console.WriteLine("Enter book ID which you want");
                string bookID = Console.ReadLine();
                if (book.BookID == bookID)
                {
                    if (book.BookCount > 0)
                    {
                        foreach (BorrowDetails borrow in borrowList)
                        {
                            if (borrow.BorrowBookCount > 0)
                            {
                                Console.WriteLine($"You already took {borrow.BorrowBookCount} books");
                            }
                            Console.Write("Enter how many books you want: ");
                            int count = int.Parse(Console.ReadLine());
                            if (borrow.BorrowBookCount + count > 3)
                            {
                                Console.WriteLine($"You cannot take more than 3 books. Your already borrowed books count is {borrow.BorrowBookCount} and requested count is {count}, which exceeds 3 ");
                            }
                            if (borrow.BorrowBookCount + count <= 3)
                            {
                                borrow.BorrowBookCount++;
                                book.BookCount--;
                                BorrowDetails borrow1 = new BorrowDetails(book.BookID, currentLoggedInUser.UserID, DateTime.Now, count, Status.Borrowed, 0);
                                borrowList.Add(borrow1);
                                Console.WriteLine("Book Borrowed successfully");
                                break;
                            }

                        }

                    }
                    else{
                        Console.WriteLine("book not available.");
                    }

                }

            }

    }
    public static void ShowBorrowedhistory()
    {
        bool flag2=true;
         foreach(BorrowDetails borrow in borrowList)
        {
            
            if(currentLoggedInUser.UserID==borrow.UserID)
            {
                flag2=false;
                Console.WriteLine($"{borrow.BorrowID}{borrow.BookID}{borrow.UserID}{borrow.BorrowedDate}{borrow.BorrowBookCount}{borrow.Status}{borrow.PaidFineAmount}");
            }
        }
        if(flag2)
        {
            Console.WriteLine("You did't too ant book till now so nothing to show.");
        }

    }
    public static void ReturnBooks()
    {
        ShowBorrowedhistory();
        Console.WriteLine("Enter your BorrowedID ");
        String borrowID=Console.ReadLine();
        foreach(BorrowDetails borrow in borrowList)
        {
            if(borrow.BorrowID==borrowID)
            {
                DateTime borrowDate=borrow.BorrowedDate;
                DateTime returnDate=DateTime.Now;
                TimeSpan span=returnDate-borrowDate;
                double totaldays=span.TotalDays;
                if(span.TotalDays>15)
                {
                    int fineAmount=(int)totaldays-15;
                    Console.WriteLine("FineAmount"+fineAmount);
                
                }

            }
        }

    }
    
    }
    
}