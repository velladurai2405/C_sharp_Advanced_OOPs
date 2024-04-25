using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard_Management
{
    public class UserDetails:PersonalDetails,IBalance
    {
        private int _balance;
        private static int _userID=1000;
        public string UserID { get; set; }
        public string WorkStationNumber { get; set; }
        public int WalletBalance { get{return _balance;}  }
       public UserDetails(string name,string fatherName,long mobile,string mailID,Gender gender,string workStationNumber,int walletBalance):base(name,fatherName,mobile,mailID,Gender.Select)
        {
            _userID++;
            UserID="SF"+_userID;
            WorkStationNumber=workStationNumber;
            _balance=walletBalance;

        }

    public int WalletRecharge(int amount)
    {
        _balance=WalletBalance+amount;
        return _balance;
    }
    public int DeductAmount(int amount)
    {
        _balance=WalletBalance-amount;
        return _balance;
    }

    }
    
}