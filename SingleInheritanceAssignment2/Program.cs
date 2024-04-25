using System;
using System.Collections.Generic;
namespace SingleInheritanceAssignment2;
class Program{
    public static void Main(string[] args)
    {
        PersonalInfo personal=new PersonalInfo("velladurai","jeyaraj",123456,"vella@mail.com",new DateTime(22/04/2024),"male");
        AccountInfo account1=new AccountInfo(personal.Name,personal.FatherName,personal.Phone,personal.Mail,personal.DOB,personal.Gender,"West mambalam","IFSC2345",5000);
        AccountInfo account2=new AccountInfo("Abinash","vignesg",12345,"vick@mail.com",new DateTime(22/04/2024),"male","West mambalam","IFSC2345",10000);
        AccountInfo account3=new AccountInfo("saran","natraj",1234534,"saran@mail.com",new DateTime(21/04/2024),"male","West mambalam","IFSC2345",50000);

        //List creation
        List<AccountInfo> accountList=new List<AccountInfo>();
        accountList.Add(account1);
        accountList.Add(account2);
        accountList.Add(account3);
        foreach (AccountInfo account in accountList)
        {
            //For deposit
            Console.Write("Enter how much amount you want to deposit: ");
            int depositAmount = int.Parse(Console.ReadLine());
            account.Deposit(depositAmount);
            //For withdraw
            Console.Write("Enter how much amount you want to withdraw: ");
            int withdrawAmount = int.Parse(Console.ReadLine());
            account.Withdraw(withdrawAmount);
            //For balance check
            account.AccountBalance();
            Console.WriteLine();
        }
    }
}
