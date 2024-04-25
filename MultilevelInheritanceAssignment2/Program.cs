using System;
using System.Security.Cryptography.X509Certificates;
namespace MultilevelInheritanceAssignment2;
class Program{
    public static void Main(string[] args)
    {
        //object creation
        BookDetails book1=new BookDetails("solid mechanics","ABCD",500,2,3,"mechanical","BE");
        BookDetails book2=new BookDetails("Fluid mechanics","EFGH",1000,2,4,"mechanical","BE");
        BookDetails book3=new BookDetails("basic mechanics","IJKL",200,1,1,"mechanical","BE");

        //method calling
        book1.DisplayInfo();
        book2.DisplayInfo();
        book3.DisplayInfo();
    }
}
