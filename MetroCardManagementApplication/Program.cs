using System;
namespace MetroCardManagementApplication;
class Program{
    public static void Main(string[] args)
    {
        FileHandling.CreateFile();
        //initializing default value
       //Operations.AddDefaultInfo();
        FileHandling.ReadFromCSV();
        //calling mainmenu
        Operations.MainMenu();
        FileHandling.WriteToCSV();
        

       
    }
}

