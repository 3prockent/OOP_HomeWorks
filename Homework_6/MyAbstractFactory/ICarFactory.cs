using System;
using System.Collections.Generic;
using System.Text;

namespace MyAbstractFactory
{
    interface ICarFactory//AbstractFactory
    {
        Car CreateCar();
        Engine CreateEngine();
    }
}
