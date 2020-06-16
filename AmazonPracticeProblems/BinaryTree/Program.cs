using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Insert(20);
            binaryTree.Insert(8);
            binaryTree.Insert(22);
            binaryTree.Insert(4);
            binaryTree.Insert(12);
            binaryTree.Insert(10);
            binaryTree.Insert(14);
            binaryTree.Insert(23);

            int sum = binaryTree.SumInRange(8, 20, binaryTree.root);

            Console.WriteLine("Sum = " + sum);

            Console.ReadLine();
        }
    }
}
