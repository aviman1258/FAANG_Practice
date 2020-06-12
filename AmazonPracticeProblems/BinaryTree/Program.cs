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

            binaryTree.Insert(4);
            binaryTree.Insert(3);
            binaryTree.Insert(5);
            binaryTree.Insert(1);
            binaryTree.Insert(8);
            binaryTree.Insert(6);
            binaryTree.Insert(7);
            binaryTree.Insert(0);

            binaryTree.DrawTree(binaryTree.root, 4);

            Console.ReadLine();
        }
    }
}
