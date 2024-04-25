using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodDeliveryApplication
{
   
    public class CustomerDeatails:PersonalDetails,IBalance
    {
        private double _balance;
        private static int s_customerID=1000;
        public string CustomerID { get;  }
        public double WalletBalance { get{return _balance;} }

        public CustomerDeatails(double walletBalance,string name,string fatherName,Gender gender,string mobile,DateTime dob,string mailID,string location):base(name,fatherName,gender,mobile,dob,mailID,location)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            _balance=walletBalance;

        }
        public double  WalletRecharge(double rechargeAmount)
        {
            _balance+=rechargeAmount;
            return _balance;
        }
        public double DeductBalance(double deductAmount)
        {
            _balance-=deductAmount;
            return _balance;
        }

    }
}