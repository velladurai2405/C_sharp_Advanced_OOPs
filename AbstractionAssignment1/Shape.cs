using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractionAssignment1
{
    public abstract class Shape
    {
        
       
        public abstract double Area { get; set; }
        public abstract double Volume { get; set; }
        public double Radius { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Side { get; set; }
        public abstract double CalculateArea();
        public abstract double CalculateVolume();
    }
}