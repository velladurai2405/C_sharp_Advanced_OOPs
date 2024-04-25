using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritanceAssignment2
{
    public class PermanentEmployee:SalaryInfo
    {
        //static field
        private static int s_pemployeeID=1000;
        // properties
        public string PermanentEmployeeID { get; set; }
        public string EmployeeType { get; set; }
        private double _DA { get{return 0.2*BasicSalary;} set{value=0.2*BasicSalary;} }
        public double _HRA { get{return 0.18*BasicSalary;} set{value=0.18*BasicSalary;} }
        public double _PF { get{return 0.1*BasicSalary;} set{value=0.1*BasicSalary;} }
        public double Total { get; set; }

        public PermanentEmployee(int basicSalary,string month,string employeeType):base(basicSalary,month)
        {
            s_pemployeeID++;
            PermanentEmployeeID="PEID"+s_pemployeeID;
            EmployeeType=employeeType;

        }

        public double CalculateSalary()
        {
            double Total=+BasicSalary+_DA+_HRA-_PF;
            return Total;
        }
        public void ShowSalary()
        {
            Console.WriteLine($"EmployeeID:{PermanentEmployeeID} salary for {Month} is {CalculateSalary()}");

        }
    }
}