using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagementApplication
{
    public class UserDetails:PersonalDetails,IBalance 
    {
        //static fields
        private static int s_cardNumber=1000;
        private double _balance;
        //properties
        public string CardNumber { get;  }
        public double Balance { get{return _balance;}  }

        //constructor
        public UserDetails(string userName,long phoneNumber,double balance):base(userName,phoneNumber)
        {
            s_cardNumber++;
            CardNumber="CMRL"+s_cardNumber;
            _balance=balance;

        }
        public UserDetails(string user)
        {
            string[] values=user.Split(",");
            s_cardNumber=int.Parse(values[0].Remove(0,4));
            CardNumber=values[0];
            UserName=values[1];
            PhoneNumber=long.Parse(values[2]);
            _balance=double.Parse(values[3]);
        }
        //methods
        public double WalletRecharge(double reachargeAmount)
        {
            _balance+=reachargeAmount;
            return _balance;

        }
         public double DeductBalance(double deductAmount)
        {
            _balance-=deductAmount;
            return _balance;

        }
    }
}