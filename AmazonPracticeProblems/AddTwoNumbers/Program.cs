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
            ListNode l1 = new ListNode(5);
            ListNode l2 = new ListNode(5);

            Solution solution = new Solution();
            ListNode lResult = solution.AddTwoNumbers(l1, l2);

            Console.WriteLine(lResult.val);
        }

        public class Solution
        {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {

                ListNode lResult = new ListNode();

                if (l1 != null && l2 != null)
                {
                    lResult.val = l1.val + l2.val;

                    if (l1.next != null && l2.next != null)
                    {
                        if (lResult.val > 9)
                        {
                            (l1.next).val += lResult.val / 10;
                            lResult.val = lResult.val % 10;
                        }

                        lResult.next = AddTwoNumbers(l1.next, l2.next);
                    }
                }

                return lResult;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
