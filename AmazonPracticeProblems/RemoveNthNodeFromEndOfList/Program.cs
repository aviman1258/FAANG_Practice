using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNthNodeFromEndOfList
{
    class Program
    {
        /*
        Given a linked list, remove the n-th node from the end of list and return its head.
        Example:  Given linked list: 1->2->3->4->5, and n = 2.
        After removing the second node from the end, the linked list becomes 1->2->3->5.
            
        Note:
        Given n will always be valid.

        Follow up:
        Could you do this in one pass?
        */
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            ListNode.InsertAtEnd(head, 2);
            ListNode.InsertAtEnd(head, 3);
            ListNode.InsertAtEnd(head, 4);
            ListNode.InsertAtEnd(head, 5);
            ListNode.InsertAtEnd(head, 6);
            ListNode.InsertAtEnd(head, 7);

            ListNode.DisplayList(head);

            ListNode.RemoveNthFromEnd_OnePass(head, 3);

            ListNode.DisplayList(head);
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

        public static void DisplayList(ListNode head)
        {
            if (head == null) return;

            ListNode current = head;

            while(current != null)
            {
                Console.Write(current.val + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        public static ListNode InsertAtEnd(ListNode head, int value)
        {
            if(head == null)
            {
                head = new ListNode(value);
            }
            else
            {
                ListNode current = head;

                while(current.next != null)
                {
                    current = current.next;
                }

                current.next = new ListNode(value);
            }
           
            return head;
        }

        public static ListNode RemoveNthFromEnd_OnePass(ListNode head, int n)
        {
            if (head.next == null) return null;

            ListNode first = head;
            ListNode second = head;

            int count = 1;
            while (count <= n)
            {
                count++;
                first = first.next;
            }

            if (first == null) return head.next;

            while (first.next != null)
            {
                first = first.next;
                second = second.next;
            }

            second.next = (second.next).next;

            return head;
        }

        public static ListNode RemoveNthFromEnd_TwoPass(ListNode head, int n)
        {
            ListNode current = head;
            int count = 1;

            while (current.next != null)
            {
                count++;
                current = current.next;
            }

            current = head;
            int count2 = 1;

            if (n == count) return head.next;

            while (current.next != null)
            {
                if (count2 == count - n)
                {
                    current.next = (current.next).next;
                    break;
                }

                count2++;
                current = current.next;
            }

            return head;
        }
    }
}
