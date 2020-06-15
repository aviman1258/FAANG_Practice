using System;

namespace BinaryTree
{
    public partial class BinaryTree
    {
        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
            public void DisplayNode()
            {
                Console.Write(Data + " ");
            }
        }
    }
}
