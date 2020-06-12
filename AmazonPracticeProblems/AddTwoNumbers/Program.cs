using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbers
{
    class Program
    {

        //You are given two non - empty linked lists representing two non - negative integers.
        //The digits are stored in reverse order and each of their nodes contain a single digit.
        //Add the two numbers and return it as a linked list.

        //You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        //Example
        //Input: (2-> 4-> 3) +(5-> 6-> 4)
        //Output: 7-> 0-> 8
        //Explanation: 342 + 465 = 807.

        static void Main(string[] args)
        {
            int num1 = 56823;
            int num2 = 352;

            ListNode l1 = ListNode.GetListNodeFromNum(num1);
            ListNode l2 = ListNode.GetListNodeFromNum(num2);

            ListNode resultListNode = ListNode.AddTwoNumbers(l1, l2);

            int result = ListNode.GetNumFromListNode(resultListNode);

            Console.WriteLine("Expected: " + num1 + " + " + num2 + " = " + (num1 + num2));
            Console.WriteLine("Result: " + result);
        }
    }
}
