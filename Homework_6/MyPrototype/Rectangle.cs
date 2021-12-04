using System;
using System.Collections.Generic;
using System.Text;

namespace MyPrototype
{
    class Rectangle : IFigure
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Rectangle(int _width, int _height)
        {
            Width = _width;
            Height = _height;
        }
        public IFigure Clone()
        {
            return new Rectangle(Width, Height);
        }

        public void GetInfo()
        {
            Console.WriteLine("Rectangle with width {0} and height {1}", Width, Height);
        }
    }
}
