using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractionAssignment1
{
    public class Cylinders:Shape
    {
        private double _area;
        private double _volume;
        public override double Area { get{return _area;} set{_area = value;}}

        public override double Volume { get{return _volume;} set{_volume = value;} }
        public Cylinders(double radius,double height)
        {
            Radius=radius;
            Height=height;
        }
        public override double CalculateArea()
        {
            Area=2*3.14*Radius*(Radius+Height);
            return Area;
        }
        public override double CalculateVolume()
        {
            Volume=3.14*Radius*Radius*Height;
            return Volume;
        }

    }
}