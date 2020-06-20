using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TernarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            TernarySearchTree ternarySearchTree = new TernarySearchTree();

            ternarySearchTree.Insert(ref ternarySearchTree.Root, "boat");
            ternarySearchTree.Insert(ref ternarySearchTree.Root, "boats");
            ternarySearchTree.Insert(ref ternarySearchTree.Root, "bats");
            ternarySearchTree.Insert(ref ternarySearchTree.Root, "bat");
        }
    }


    class TernarySearchTree
    {
        public Node Root;

        public void Insert(ref Node node, string word)
        {
            
            if(Root == null)
            {
                Root = new Node(word[0]);

                Node center = new Node(word[1]);
                //set this leaf's center field to new leaf
                node.Center = center;
                //iterate through tree with chopped word
                Insert(ref center, word.Substring(1));
            }
            

            if(word[0] > node.Data)
            {
                //first char belongs left of this one
                if (node.Left != null)
                    Insert(ref node.Left, word);
                //iterate through tree with current word
                else
                {
                    //ther is no left leaf -> create new leaf
                    Node left = new Node(word[0]);

                    //set this leaf's left field to new leaf
                    node.Left = left;

                    //if there are more letters in word
                    //iterate through tree with current word
                    if (word.Length > 1)
                        Insert(ref left, word);
                }
            }
            else if(word[0] < node.Data)
            {
                //first char belongs right of this one
                if (node.Right != null)
                    Insert(ref node.Right, word);
                //iterate through tree with current word
                else
                {
                    //there is no right leaf -> create new leaf
                    Node right = new Node(word[0]);

                    //set this leaf's right field to new new leaf
                    node.Right = right;

                    //if there are more letters in the word
                    //iterate through tree with current word
                    if (word.Length > 1)
                        Insert(ref right, word);
                }
            }
            else //first char is indentical to this leaf's data field
            {
                if(word.Length > 1)
                {
                    //the word insertion is not complete
                    if(node.Center != null)
                    {
                        Insert(ref node.Center, word.Substring(1));
                        //iterate through tree with chopped word
                    }
                    else //there is no center leaf -> create new leaf
                    {
                        Node center = new Node(word[1]);
                        //set this leaf's center field to new leaf
                        node.Center = center;
                        //iterate through tree with chopped word
                        Insert(ref center, word.Substring(1));
                    }
                }
            }
        }


        public bool Search(ref Node node, string word)
        {
            //test first char of word against input leaf's Data field
            if (word[0] > node.Data)
            {
                //first char belongs left of this leaf
                if (node.Left != null)
                    return Search(ref node.Left, word);
                else
                    return false;
            }
            else if (word[0] < node.Data)
            {
                //first char belongs right of this leaf
                if (node.Right != null)
                    return Search(ref node.Right, word);
                else
                    return false;
            }
            else
            {
                //first char matches this leaf
                if (word.Length == 1) //last char in input word
                    return true;
                else //iterate along center leaf for second char
                    return Search(ref node.Center, word.Substring(1));
            }            
        }

        public class Node
        {
            public char Data;
            public Node Left;
            public Node Center;
            public Node Right;

            public Node(char data)
            {
                Data = data;
            }
        }
    }
}
