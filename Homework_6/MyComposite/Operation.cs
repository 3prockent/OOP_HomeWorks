using System;
using System.Collections.Generic;
using System.Text;

namespace MyComposite
{
    class Operation : Component
    {
        public string OperationSymb { get; private set; }
        public Operation(string _operation)
        {
            if(_operation != "+" && _operation != "-" && _operation != "*" && _operation != "/")
            {
                throw new ArgumentException("Wrong operation");
            }
            OperationSymb = _operation;
        }
        public override double Calculate()
        {
            throw new ArithmeticException();
        }
    }
}
