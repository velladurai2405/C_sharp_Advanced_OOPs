using System;
namespace CollegeAdmission;
class Program{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        //Default Data calling
        Operations.AddDefaultData();
        Operations.MainMenu();
        FileHandling.WriteToCSV();
    }
}
