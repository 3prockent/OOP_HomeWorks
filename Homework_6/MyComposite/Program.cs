using System;

namespace MyComposite
{
    class Program
    {
        static void Main(string[] args)
        {
            //(3 * 5 - 10) / 2
            Composite root = new Composite(new Operation("/"));
            Composite rootL = new Composite(new Operation("-"));
            Composite rootLL = new Composite(new Operation("*"));
            rootLL.Add(new Number(3));
            rootLL.Add(new Number(5));
            rootL.Add(rootLL);
            rootL.Add(new Number(10));
            root.Add(rootL);
            root.Add(new Number(2));
            Console.WriteLine(root.Calculate());
        }
    }
}
