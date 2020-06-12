using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLargestOrSmallestElementsInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write an efficient program for printing k largest elements in an array.
            //Elements in array can be any order.
            //For example, if given array is [1,23,12,9,30,2,50] and you are asked for the 3 elements i.e.,
            //k = 3 then your program should print 50, 30 and 23.

            int[] arr = { 1, 23, 12, 9, 30, 2, 50 };
            int k = 3;

            KLargest(arr, k);

            Console.ReadLine();
        }

        private static void KLargest(int[] arr, int k)
        {
            Array.Sort(arr);
            Array.Reverse(arr);

            for(int i = 0; i < k; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
