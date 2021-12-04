using System;
using System.Collections.Generic;
using System.Text;

namespace MyAbstractFactory
{
    class FordFactory : ICarFactory//ConcreteFactory1
    {
        Car ICarFactory.CreateCar()
        {
            return new Ford();
        }
        Engine ICarFactory.CreateEngine()
        {
            return new FordEngine();
        }
    }
    class Ford : Car//ConcreteProductA1
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    class FordEngine : Engine//ConcreteProductB1
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine 4.4");
        }
    }
}
