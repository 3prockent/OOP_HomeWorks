using System;
using System.Collections.Generic;
using System.Text;

namespace MyBuider
{
    class Pizza//Product
    {
        string dough;
        string sauce;
        string topping;
        public Pizza() { }
        public void SetDough(string d) { dough = d; }
        public void SetSauce(string s) { sauce = s; }
        public void SetTopping(string t) { topping = t; }
        public void Info()
        {
            Console.WriteLine("Dough: {0}\nSause: {1}\nTopping: {2}",
           dough, sauce, topping);
        }
    }
}
