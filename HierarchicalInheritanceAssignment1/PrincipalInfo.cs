using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritanceAssignment1
{
    public class PrincipalInfo:PersonalInfo
    {
        //static field
        private static int s_principalID=1000;
        //properties
        public string PrincipalID { get; set; }
        public string Qualification { get; set; }
        public string YearOfExperience { get; set; }
        public DateTime DateOfJoining { get; set; }

        public PrincipalInfo(string name,string fatherName,long phone,DateTime dob,string gender,string mail,string qualification,string yearOfExperience,DateTime dateOfJoining):base(name,fatherName,phone,dob,gender,mail)
        {
            s_principalID++;
            PrincipalID="PID"+s_principalID;
            Qualification=qualification;
            YearOfExperience=yearOfExperience;
            DateOfJoining=dateOfJoining;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"{PrincipalID}|{Name}|{FatherName}|{Phone}|{DOB}|{Gender}|{Mail}|{Qualification}|{YearOfExperience}|{DateOfJoining}");
        }
    }
}