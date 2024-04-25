using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagementApplication
{
    public class PersonalDetails 
    {
        //properties
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }

        //constructor
        public PersonalDetails(string userName,long phoneNumber)
        {
            UserName=userName;
            PhoneNumber=phoneNumber;

        }
        public PersonalDetails()
        {
            
        }
    }
}