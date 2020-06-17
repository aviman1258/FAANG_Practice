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

        public Node InOrderSuccessor(Node root, Node n)
        {
            //if right subtree of node is not NULL,
            //then succ lies in right subtree. Do the following.
            //Go to right subtree and return the node 
            //with minimum key value in the right subtree.

            if (n.Right != null)
                return MinValue(n.Right);

            //If right subtree of node is NULL, 
            //then start from the root and us search like technique. Do the following.
            //Travel down the tree, 
            //if a node’s data is greater than root’s data 
            //then go right side, otherwise, go to left side.

            Node successor = new Node();

            while(root != null)
            {
                if (n.Data < root.Data)
                {
                    successor = root;
                    root = root.Left;
                }
                else if (n.Data > root.Data)
                {
                    root = root.Right;
                }
                else break;
            }

            return successor;
        }

        private Node MinValue(Node node)
        {
            Node current = node;

            //loop down to find the leftmost leaf
            while(current.Left != null)
            {
                current = current.Left;
            }
            
            return current;
        }

        public int SumInRange(int min, int max, Node root)
        {
            //Base Case
            if (root == null) return 0;
            
            //If current node is in range,
            //include it in the sum and
            //recur for left and right children of it
            if(root.Data >= min && root.Data <= max)            
                return  root.Data 
                    + SumInRange(min, max, root.Left) 
                    + SumInRange(min, max, root.Right);
            
            //If current node is smaller than low,
            //then recur for right child
            else if(root.Data < min)
                return SumInRange(min, max, root.Right);

            // Else recur for left child
            else
                return SumInRange(min, max, root.Left);
        }
    }
}
