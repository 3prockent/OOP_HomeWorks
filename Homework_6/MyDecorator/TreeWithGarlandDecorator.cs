using System;
using System.Collections.Generic;
using System.Text;

namespace MyDecorator
{
    class TreeWithGarlandDecorator : SpruceDecorator
    {
        public TreeWithGarlandDecorator(Spruce _tree) : base(_tree) { }
        private void PaintToy(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write('@');
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public override void Create()
        {
            treeToDecorate.Create();
            bool isblue = true;
            bool isred = false;
            Console.ForegroundColor = ConsoleColor.Green;
            foreach(var symb in treeToDecorate.Tree)
            {
                if(symb == '@')
                {
                    if(isblue)
                    {
                        PaintToy(ConsoleColor.Blue);
                        isblue = false;
                        isred = true;
                        continue;
                    }
                    else if(isred)
                    {
                        PaintToy(ConsoleColor.Red);
                        isred = false;
                        continue;
                    }
                    else
                    {
                        PaintToy(ConsoleColor.Yellow);
                        isblue = true;
                        continue;
                    }
                }
                Console.Write(symb);
            }
        }
    }
}
