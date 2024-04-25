using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbookApplication
{
    public class BookDetails
    {
        //static field
        private static int s_bookID=1000;
        //properties
        public string BookID { get;  }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int BookCount { get; set; }

        //constructor
        public BookDetails(string bookName,string authorName,int bookCount)
        {
            //Auto increment
            s_bookID++;

            BookID="BID"+s_bookID;
            BookName=bookName;
            AuthorName=authorName;
            BookCount=bookCount;


        }
      
    }

}