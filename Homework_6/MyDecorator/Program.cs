using System;

namespace MyDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new TreeWithGarlandDecorator(new SpruceWithToysDecorator(new ChristmasTree(10)));
            tree.Create();
        }
    }
}
