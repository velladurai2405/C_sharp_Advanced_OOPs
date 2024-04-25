using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCard_Management
{
    public enum Gender{Select,Male,Female}
    public class PersonalDetails
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
       
        public long Mobile { get; set; }
        public string MailID { get; set; }
         

    public PersonalDetails(string name,string fatherName,long mobile,string mailID,Gender gender)
    {
        Name=name;
        FatherName=fatherName;
        Gender=gender;
        Mobile=mobile;
        MailID=mailID;

    }

    }
    
}