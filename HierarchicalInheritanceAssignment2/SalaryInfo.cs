using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritanceAssignment2
{
    public class SalaryInfo
    {
        // properties
        public int BasicSalary { get; set; }
        public string Month { get; set; }

        //constructor
        public SalaryInfo(int basicSalary,string month)
        {
            BasicSalary=basicSalary;
            Month=month;

        }
    }
}