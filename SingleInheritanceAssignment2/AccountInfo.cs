using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleInheritanceAssignment2
{
    public class AccountInfo:PersonalInfo
    {
        private static int s_accountNumber=1000;
        
        public string AccountNumber { get; set; }
        public string BranchName { get; set; }
        public string IFSCCode { get; set; }
        public int Balance { get; set; }

        public AccountInfo(string name,string fatherName,long phone,string mail,DateTime dob,string gender,string branchName,string iFSCCode,int balance):base(name,fatherName,phone,mail,dob,gender)
        {
            s_accountNumber++;
            AccountNumber="ACC"+s_accountNumber;
            BranchName=branchName;
            IFSCCode=iFSCCode;
            Balance=balance;

        }
        public void ShowAccountDetails()
        {
            Console.WriteLine($"{AccountNumber}|{BranchName}|{IFSCCode}|{Balance}|{Name}|{DOB}|{Phone}");
        }

        public void Deposit(int depositAmount)
        {
            Balance=Balance+depositAmount;
            Console.WriteLine($" Deposit succesfull Your balance is: {Balance}");
        }
        public void Withdraw(int withdrawAmount)
        {
            Balance=Balance-withdrawAmount;
            Console.WriteLine($"Withdraw succesfull and your balance is: {Balance}");

        }
        public void AccountBalance()
        {
            Console.WriteLine($"Your balance amount is: {Balance}");

        }
    }
}