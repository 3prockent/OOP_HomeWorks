using System;
using System.Collections.Generic;
using System.Text;

namespace MyPrototype
{
    class Circle : IFigure
    {
        public int Radius { get; private set; }
        public Circle(int _radius)
        {
            Radius = _radius;
        }
        public IFigure Clone()
        {
            return new Circle(Radius);
        }

        public void GetInfo()
        {
            Console.WriteLine("Circle with radius {0}", Radius);
        }
    }
}
