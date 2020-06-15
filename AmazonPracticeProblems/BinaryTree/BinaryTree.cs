using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public partial class BinaryTree
    {

        public Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void Insert(int i)
        {
            Node newNode = new Node();
            newNode.Data = i;

            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;

                while (true)
                {
                    parent = current;
                    if (i < current.Data)
                    {
                        current = current.Left;

                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else if (i > current.Data)
                    {
                        current = current.Right;

                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                    else break;
                }
            }
        }

        public void TraversePreOrder(Node parent)
        {
            if(parent != null)
            {
                parent.DisplayNode();
                TraversePreOrder(parent.Left);
                TraversePreOrder(parent.Right);
            }
        }

        public void TraversePostOrder(Node parent)
        {
            if(parent != null)
            {
                TraversePostOrder(parent.Left);
                TraversePostOrder(parent.Right);
                parent.DisplayNode();
            }
        }

        public void TraverseInOrder(Node parent)
        {
            if(parent != null)
            {
                TraverseInOrder(parent.Left);
                parent.DisplayNode();
                TraverseInOrder(parent.Right);
            }
        }

        public void DrawTree(Node parent, int padding)
        {
            if(parent != null)
            {
                if(parent.Right != null)
                {
                    DrawTree(parent.Right, padding + 4);
                }

                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }

                if(parent.Right != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }

                Console.Write(parent.Data.ToString() + "\n ");

                if(parent.Left != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    DrawTree(parent.Left, padding + 4);
                }
            }
        }
    }
}
