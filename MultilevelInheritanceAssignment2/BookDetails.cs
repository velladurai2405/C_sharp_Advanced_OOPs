using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritanceAssignment2
{
    public class BookDetails:RackInfo
    {
        //static field
        private static int s_bookID=1000;
        //property
        public string BookID { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int Price { get; set; }
        public BookDetails(string bookName,string authorName,int price,int rackNumber,int columnNumber,string departmentName,string degree):base(rackNumber,columnNumber,departmentName,degree)
        {
            s_bookID++;
            BookID="BID"+s_bookID;
            BookName=bookName;
            AuthorName=authorName;
            Price=price;

        }
        public void DisplayInfo()
        {
            Console.WriteLine($"BOOK ID:{BookID}| Book name:{BookName}| Author Name:{AuthorName}| Price:{Price}| Rack Number:{RackNumber}| Column Number{ColumnNumber}| Department:{DepartmentName}| Degree:{Degree}");
        }
        
    }
}