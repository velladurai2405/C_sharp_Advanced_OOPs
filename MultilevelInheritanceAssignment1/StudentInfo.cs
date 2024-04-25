using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritanceAssignment1
{
    public class StudentInfo:PersonalInfo
    {
        
        private static int s_registerNumber=1000;
        //RegisterNumber, Standard, Branch, AcadamicYear
        public string RegisterNumber { get; set; }
        public int Standard { get; set; }
        public string Branch { get; set; }
        public int AcadamicYear { get; set; }

       

        public StudentInfo(string name,string fatherName,long phone,string mail,DateTime dob,string gender,int standard,string branch,int acadamicYear):base(name,fatherName,phone,mail,dob,gender)
        {
            s_registerNumber++;
            RegisterNumber="RID"+s_registerNumber;
            
        }

        public void GetStudentInfo(string RegisterNumber,string name,string fatherName,long phone,string mail,DateTime dob,string gender,int standard,string branch,int acadamicYear):base(name,fatherName,phone,mail,dob,gender)
        {

        }
       
    }
}