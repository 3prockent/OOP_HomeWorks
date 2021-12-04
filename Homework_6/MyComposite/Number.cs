using System;
using System.Collections.Generic;
using System.Text;

namespace MyComposite
{
    class Number : Component
    {
        double number;
        public Number(double _number)
        {
            number = _number;
        }
        public override double Calculate()
        {
            return number;
        }
    }
}
