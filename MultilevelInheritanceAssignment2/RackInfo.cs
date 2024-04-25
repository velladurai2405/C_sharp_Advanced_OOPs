using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritanceAssignment2
{
    public class RackInfo:DepartmentDetails
    {
        //properties
        // RackNumber, ColumnNumber
        public int RackNumber { get; set; }
        public int ColumnNumber { get; set; }

        public RackInfo(int rackNumber,int columnNumber,string departmentName,string degree):base(departmentName,degree)
        {
            RackNumber=rackNumber;
            ColumnNumber=columnNumber;


        }
    }
}