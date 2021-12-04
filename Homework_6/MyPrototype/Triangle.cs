using System;
using System.Collections.Generic;
using System.Text;

namespace MyPrototype
{
    class Triangle : IFigure
    {
        public int Side1 { get; private set; }
        public int Side2 { get; private set; }
        public int Side3 { get; private set; }
        public Triangle(int _side1, int _side2, int _side3)
        {
            if(CheckTriange(_side1,_side2,_side3))
            {
                Side1 = _side1;
                Side2 = _side2;
                Side3 = _side3;
            }
        }
        bool CheckTriange(int _side1, int _side2, int _side3)
        {
            return _side1 + _side2 > _side3 &&
                   _side1 + _side3 > _side2 &&
                   _side3 + _side2 > _side1;
        }
        public IFigure Clone()
        {
            return new Triangle(Side1, Side2, Side3);
        }

        public void GetInfo()
        {
            Console.WriteLine("Triangle with sides: {0}, {1}, {2}", Side1, Side2, Side3);
        }
    }
}
