using System;
using System.Collections.Generic;
using System.Text;

namespace MyAbstractFactory
{
    class ToyotaFactory : ICarFactory//ConcreteFactory2
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Toyota();
        }
        Engine ICarFactory.CreateEngine()
        {
            return new ToyotaEngine();
        }
    }
    class Toyota : Car//ConcreteProductA2
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }
    class ToyotaEngine : Engine//ConcreteProductB2
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine 3.2");
        }
    }
}
