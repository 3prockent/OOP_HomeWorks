using System;
using System.Collections.Generic;
using System.Text;

namespace MyBuider
{
    class SpicyPizzaBuilder : PizzaBuilder//ConcreteBuilder2
    {
        public override void BuildDough()
        {
            pizza.SetDough("panbaked");
        }
        public override void BuildSauce() { pizza.SetSauce("hot"); }
        public override void BuildTopping()
        {
            pizza.SetTopping("pepparoni+salami");
        }
    }
}
