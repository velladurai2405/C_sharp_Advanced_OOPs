using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractionAssignment1
{
    public class Cubes:Shape
    {
        private double _area;
        private double _volume;
        public override double Area { get{return _area;} set{_area=value;} }
        public override double Volume { get{return _volume;} set{_volume=value;} }
        public Cubes(double side)
        {
            Side=side;
        }
        public override double CalculateArea()
        {
            Area=6*Side*Side;
            return Area;
        }
        public override double CalculateVolume()
        {
            Volume=Side*Side*Side;
            return Volume;
        }
    }
}