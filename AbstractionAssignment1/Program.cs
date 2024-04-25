using System;
namespace AbstractionAssignment1;
class Program{
    public static void Main(string[] args)
    {
        Cylinders cylinder=new Cylinders(10,10);
        
        Console.WriteLine(cylinder.CalculateArea());
    
        Console.WriteLine(cylinder.CalculateVolume());

        Cubes cube=new Cubes(10);
        
        Console.WriteLine(cube.CalculateArea());

        Console.WriteLine(cube.CalculateVolume());
    }
}
