using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritanceAssignment2
{
    public class DepartmentDetails
    {
        // Properties
        public string DepartmentName { get; set; }
        public string Degree { get; set; }

        public DepartmentDetails(string departmentName,string degree)
        {
            DepartmentName=departmentName;
            Degree=degree;

        }
    }
}