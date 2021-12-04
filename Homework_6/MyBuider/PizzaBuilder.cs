using System;
using System.Collections.Generic;
using System.Text;

namespace MyBuider
{
    abstract class PizzaBuilder//AbstractBuilder
    {
        protected Pizza pizza;
        public PizzaBuilder() { }
        public Pizza GetPizza() { return pizza; }
        public void CreateNewPizza() { pizza = new Pizza(); }
        public abstract void BuildDough();
        public abstract void BuildSauce();
        public abstract void BuildTopping();
    }
}
