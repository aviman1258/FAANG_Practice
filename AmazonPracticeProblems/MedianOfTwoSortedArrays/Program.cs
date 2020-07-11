using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianOfTwoSortedArrays
{
    class Program
    {
        /*
        There are two sorted arrays nums1 and nums2 of size m and n respectively.
        Find the median of the two sorted arrays. 
        The overall run time complexity should be O(log (m+n)).
        You may assume nums1 and nums2 cannot be both empty.
        */

        static void Main(string[] args)
        {
            int[] nums1 = { 1, 3 };
            int[] nums2 = { 2, 4 };

            Console.WriteLine("Median: " + FindMedianSortedArrays(nums1, nums2));
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int ptr1 = 0;
            int ptr2 = 0;
            int[] results = new int[nums1.Length + nums2.Length];
            int ptrResults = 0;

            while (ptr1 < nums1.Length || ptr2 < nums2.Length)
            {
                if (ptr1 >= nums1.Length)
                {
                    while (ptr2 < nums2.Length)
                    {
                        results[ptrResults] = nums2[ptr2];
                        ptr2++;
                        ptrResults++;
                    }
                    break;
                }

                if (ptr2 >= nums2.Length)
                {
                    while (ptr1 < nums1.Length)
                    {
                        results[ptrResults] = nums1[ptr1];
                        ptr1++;
                        ptrResults++;
                    }
                    break;
                }

                if (nums1[ptr1] < nums2[ptr2])
                {
                    results[ptrResults] = nums1[ptr1];
                    ptr1++;
                    ptrResults++;
                }
                else
                {
                    results[ptrResults] = nums2[ptr2];
                    ptr2++;
                    ptrResults++;
                }
            }

            if (results.Length % 2 == 1)
            {
                return results[results.Length / 2];
            }
            else
            {
                int num1 = results[results.Length / 2];
                int num2 = results[(results.Length / 2) - 1];

                return (double)(num1 + num2) / 2;
            }
        }
    }
}
