using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritanceAssignment1
{
    public class StudentInfo:PersonalInfo
    {
        //private staic field
        private static int s_studentID=1000;
        //properties
        public string StudentID { get; set; }
        public string Degree { get; set; }
        public string Department { get; set; }
        public int Semester { get; set; }

        public StudentInfo(string name,string fatherName,long phone,DateTime dob,string gender,string mail,string degree,string department,int semester):base(name,fatherName,phone,dob,gender,mail)
        {
            s_studentID++;
            StudentID="SID"+s_studentID;
            Degree=degree;
            Department=department;
            Semester=semester;

        }

        public void ShowDetails()
        {
            Console.WriteLine($"{Name}|{FatherName}|{Phone}|{DOB}|{Gender}|{Mail}|{StudentID}|{Degree}|{Department}|{Semester}");
        }
    }
}