using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritanceAssignment1
{
    public class PersonalInfo
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public long Phone { get; set; }
        public DateTime DOB { get; set; }
         public string Gender { get; set; }
        public string Mail { get; set; }

        public PersonalInfo(string name,string fatherName,long phone,DateTime dob,string gender,string mail)
        {
            Name=name;
            FatherName=fatherName;
            Phone=phone;
            Mail=mail;
            DOB=dob;
            Gender=gender;
        }

       
    }
}