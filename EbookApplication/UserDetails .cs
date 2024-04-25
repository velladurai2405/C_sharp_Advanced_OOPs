using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbookApplication
{
    //enum
    public enum Gender{select,Male,Female}
    public enum Deparment{ECE, EEE, CSE}
    public class UserDetails 
    {
        //static field
        private static int s_userId=3000;
        //properties
        public string UserID { get;  }
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public Deparment Deparment { get; set; }
        public long MobileNumber { get; set; }
        public string MailID { get; set; }
        public int WalletBalance { get; set; }

        //constructor
        public UserDetails(string userName,Gender gender,Deparment deparment,long mobileNumber,string mailID,int walletBalance)
        {
            //Auto increment
            s_userId++;

            UserID="SF"+s_userId;
            UserName=userName;
            Gender=gender;
            Deparment=deparment;
            MobileNumber=mobileNumber;
            MailID=mailID;
            WalletBalance=walletBalance;

        }
        public int WalletRecharge(int amount)
        {
            WalletBalance=WalletBalance+amount;
            return WalletBalance;
        }
        

        /*a.	UserID (Auto Increment – SF3000)
b.	UserName
c.	Gender
d.	Department – (Enum – 
e.	MobileNumber
f.	MailID
*/
    }
}