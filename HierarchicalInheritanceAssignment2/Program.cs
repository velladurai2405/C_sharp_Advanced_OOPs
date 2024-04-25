using System;
namespace HierarchicalInheritanceAssignment2;
class Program{
    public static void Main(string[] args)
    {
        SalaryInfo salary=new SalaryInfo(15000,"may");
        PermanentEmployee permanent1=new PermanentEmployee(salary.BasicSalary,salary.Month,"permanent");
        permanent1.ShowSalary();
        PermanentEmployee permanent2=new PermanentEmployee(20000,salary.Month,"permanent");
        permanent2.ShowSalary();
        TemporaryEmployee temporary1=new TemporaryEmployee(salary.BasicSalary,salary.Month,"Temporary");
        temporary1.ShowSalary();
        TemporaryEmployee temporary2=new TemporaryEmployee(20000,salary.Month,"Temporary");
        temporary2.ShowSalary();

        
        
        
        
    }
}
