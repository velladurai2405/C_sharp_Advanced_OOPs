using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritanceAssignment1
{
    public class TeacherInfo:PersonalInfo
    {
        //static field
        private static int s_teacherID=1000;
        //properties
        public string TeacherID { get; set; }
        public string Department { get; set; }
        public string SubjectTeaching { get; set; }
        public string Qualification { get; set; }
        public int YearOfExperience { get; set; }
        public DateTime Doj { get; set; }

        public TeacherInfo(string name,string fatherName,long phone,DateTime dob,string gender,string mail,string department,string subjectTeaching,string qualification,int yearOfExperience,DateTime doj):base(name,fatherName,phone,dob,gender,mail)
        {
            s_teacherID++;
            TeacherID="TID"+s_teacherID;
            Department=department;
            SubjectTeaching=subjectTeaching;
            Qualification=qualification;
            YearOfExperience=yearOfExperience;
            Doj=doj;


        }
         public void ShowDetails()
        {
            Console.WriteLine($"{Name}|{FatherName}|{Phone}|{DOB}|{Gender}|{Mail}|{Department}|{SubjectTeaching}|{Qualification}|{YearOfExperience}|{Doj}");
        }
    }
}