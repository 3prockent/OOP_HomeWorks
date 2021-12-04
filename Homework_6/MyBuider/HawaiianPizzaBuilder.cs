using System;
using System.Collections.Generic;
using System.Text;

namespace MyBuider
{
    class HawaiianPizzaBuilder : PizzaBuilder//ConcreteBuilder1
    {
        public override void BuildDough() { pizza.SetDough("cross"); }
        public override void BuildSauce() { pizza.SetSauce("mild"); }
        public override void BuildTopping()
        {
            pizza.SetTopping("ham+pineapple");
        }
    }
}
