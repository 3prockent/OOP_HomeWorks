using System;
using System.Collections.Generic;
using System.Text;

namespace MyBuider
{
    class MargaritaPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough()
        {
            pizza.SetDough("panbaked");
        }

        public override void BuildSauce()
        {
            pizza.SetSauce("with basil");
        }

        public override void BuildTopping()
        {
            pizza.SetTopping("mozzarella cheese + basil + tomato");
        }
    }
}
