using System;
using System.Collections.Generic;
using System.Text;

namespace MyDecorator
{
    abstract class SpruceDecorator:Spruce
    {
        protected Spruce treeToDecorate;
        public SpruceDecorator(Spruce _tree) { treeToDecorate = _tree; }
    }
}
