using System;
using System.Collections.Generic;
using System.Text;

namespace MyDecorator
{
    class ChristmasTree : Spruce
    {
        public ChristmasTree(int _tiers)
        {
            TiersCount = _tiers;
            BranchCount = 1 + (TiersCount - 1) * 2;
        }
        public override void Create()
        {
            StringBuilder treeSb = new StringBuilder();
            for (int i = 0; i < TiersCount; i++)
            {
                int curBranchCount = 1 + 2 * i;
                treeSb.Append(' ', (BranchCount - curBranchCount) / 2);
                treeSb.Append('*', curBranchCount);
                treeSb.Append(' ', (BranchCount - curBranchCount) / 2);
                treeSb.Append('\n');
            }
            Tree = treeSb.ToString();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Tree);
        }
    }
}
