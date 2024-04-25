using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritanceAssignment2
{
    public class TemporaryEmployee:SalaryInfo
    {
         //static field
        private static int s_temployeeID=1000;
        // properties
        public string TemporaryEmployeeID { get; set; }
        public string EmployeeType { get; set; }
        private double _DA { get{return 0.15*BasicSalary;} set{value=0.2*BasicSalary;} }
        public double _HRA { get{return 0.13*BasicSalary;} set{value=0.18*BasicSalary;} }
        
        public double Total { get; set; }

         public TemporaryEmployee(int basicSalary,string month,string employeeType):base(basicSalary,month)
        {
            s_temployeeID++;
            TemporaryEmployeeID="TEID"+s_temployeeID;
            EmployeeType=employeeType;

        }
        public double CalculateSalary()
        {
            double Total=_DA+_HRA+BasicSalary;
            return Total;
        }
        public void ShowSalary()
        {
            Console.WriteLine($"EmployeeID:{TemporaryEmployeeID} salary for {Month} is {CalculateSalary()}");

        }

    }
}