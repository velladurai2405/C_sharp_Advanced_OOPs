using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class DepartmentDetails
    {
        //static field
        private static int s_departmentId=100;
        //properties
        public string DepartmentID { get;  }
        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }

        //constructor
        public DepartmentDetails(string departmentName,int numberOfSeats)
        {
            //Auto increment
            s_departmentId++;
            DepartmentID="DID"+s_departmentId;
            DepartmentName=departmentName;
            NumberOfSeats=numberOfSeats;
        }
        public DepartmentDetails(string department)
        {
            string[] values=department.Split();
            //Auto increment
            
            DepartmentID=values[0];
            s_departmentId=int.Parse(values[0].Remove(0,3));
            DepartmentName=values[1];
            NumberOfSeats=int.Parse(values[2]);
        }


        /*a.	DepartmentID – (AutoIncrement - DID101)
            b.	DepartmentName
            c.	NumberOfSeats
            */
    }
}