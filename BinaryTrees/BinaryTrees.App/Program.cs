using BinaryTrees.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BinaryTrees.App
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeList tree = new TreeList();
            tree.Add(5);
            tree.Add(3);
            tree.Add(20);
            tree.Add(10);
            tree.Add(15);
            tree.Add(9);
            int count = tree.depth();
            Console.ReadKey();
        }
    }
}
