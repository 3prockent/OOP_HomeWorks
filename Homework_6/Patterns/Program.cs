using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    public class Student
    {
        public int Age;
        public string Name;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List<int>() {1,2,3,4 };
            var list2 = new List<int>() { 1, 2, 3, 4, 5};
            var result = list1.Concat(list2);
            foreach(var num in result)
            {
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }
    }
}
