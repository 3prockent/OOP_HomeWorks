using System;
using System.Collections.Generic;
using System.Text;

namespace MyPrototype
{
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
}
