using System;
using System.Collections.Generic;
using System.Text;

namespace MyDecorator
{
    class SpruceWithToysDecorator : SpruceDecorator
    {
        public SpruceWithToysDecorator(Spruce _tree) : base(_tree) { }
        public override void Create()
        {
            treeToDecorate.Create();
            StringBuilder treeWithToys = new StringBuilder(treeToDecorate.Tree);
            for (int i = 1; i < treeToDecorate.TiersCount; i++)
            {
                int curBrancCount = 1 + i * 2;
                int spacesCount = (treeToDecorate.BranchCount - curBrancCount) / 2;
                int toyPos = (treeToDecorate.BranchCount + 1) * i + spacesCount;
                int toysCount = 1 + i;
                for (int k = 0; k < toysCount; k++)
                {
                    treeWithToys.Replace("*", "@", toyPos, 1);
                    toyPos += 2;
                }
            }
            Tree = treeWithToys.ToString();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Tree);
        }
    }
}
