
using System;
namespace OnlineFoodDeliveryApplication;
class Program{
    public static void Main(string[] args)
    {
        CustomList<int> customList=new CustomList<int>();
        Operations.AddDefaultInfo();
        Operations.MainMenu();
    }
}