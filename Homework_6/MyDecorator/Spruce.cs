using System;
using System.Collections.Generic;
using System.Text;

namespace MyDecorator
{
    abstract class Spruce
    {
        public string Tree { get; protected set; }
        public int TiersCount { get; protected set; }
        public int BranchCount { get; protected set; }
        public abstract void Create();
    }
}
