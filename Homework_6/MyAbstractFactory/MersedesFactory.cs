using System;
using System.Collections.Generic;
using System.Text;

namespace MyAbstractFactory
{
    class MersedesFactory : ICarFactory//ConcreteFactory3
    {
        public Car CreateCar()
        {
            return new Mersedes();
        }

        public Engine CreateEngine()
        {
            return new MersedesEngine();
        }
    }

    class Mersedes : Car//ConcreteProductA3
    {
        public override void Info()
        {
            Console.WriteLine("Mersedes");
        }
    }
    class MersedesEngine: Engine//ConcreteProductB3
    {
        public override void GetPower()
        {
            Console.WriteLine("Mersedes Engine 3.8");
        }
    }
}
