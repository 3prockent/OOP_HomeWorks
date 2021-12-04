using System;

namespace MyBuider
{
    class Program
    {
        public static void Main(String[] args)
        {
            Waiter waiter = new Waiter();
            PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
            PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
            PizzaBuilder margaritaPizzaBuilder = new MargaritaPizzaBuilder();
            waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
            waiter.ConstructPizza();
            Pizza pizzaHaw = waiter.GetPizza();
            pizzaHaw.Info();
            waiter.SetPizzaBuilder(spicyPizzaBuilder);
            waiter.ConstructPizza();
            Pizza pizzaSp = waiter.GetPizza();
            pizzaSp.Info();
            waiter.SetPizzaBuilder(margaritaPizzaBuilder);
            waiter.ConstructPizza();
            Pizza pizzaMar = waiter.GetPizza();
            pizzaMar.Info();
            Console.ReadKey();
        }
    }

}
