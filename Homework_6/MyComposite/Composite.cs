using System;
using System.Collections.Generic;
using System.Text;

namespace MyComposite
{
    class Composite : Component
    {
        Operation root;
        Component operator1;
        Component operator2;

        public Composite(Operation _root)
        {
            root = _root;
        }

        public bool Add(Component child)
        {
            if(operator1 == null)
            {
                operator1 = child;
                return true;
            }
            else
            {
                operator2 = child;
                return true;
            }
            return false;
        }

        public void Remove()
        {
            if(operator1 != null && operator2 != null)
            {
                operator2 = null;
            }
            else if(operator2 == null)
            {
                operator1 = null;
            }
        }

        public override double Calculate()
        {
            double result = 0;
            if(operator1 == null || operator2 == null)
            {
                throw new ArithmeticException();
            }
            double left = operator1.Calculate();
            double right = operator2.Calculate();
            switch(root.OperationSymb)
            {
                case "+":
                    result = left + right;
                    break;
                case "-":
                    result = left - right;
                    break;
                case "/":
                    result = left / right;
                    break;
                case "*":
                    result = left * right;
                    break;
            }
            return result;
        }
    }
}
