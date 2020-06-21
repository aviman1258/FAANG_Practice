using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndLastPositionOfElementInSortedArray
{
    class Program
    {
        /*
         Given an array of integers nums sorted in ascending order, 
        find the starting and ending position of a given target value.

        Your algorithm's runtime complexity must be in the order of O(log n).

         If the target is not found in the array, return [-1, -1].
         */
        static void Main(string[] args)
        {
            int[] nums = { 5, 7, 7, 8, 8, 10 };
            int target = 5;

            //int[] result = SearchRangeLinerTime(nums, target);
            int[] result = SearchRangeLogTime(nums, target);

            Console.WriteLine("Range: [ " + result[0] + " , " + result[1] + " ]");
        }

        private static int[] SearchRangeLogTime(int[] nums, int target)
        {
            int[] result = new int[2];

            result[0] = FindStartingIndex(nums, target);
            result[1] = FindEndingIndex(nums, target);

            return result;
        }

        private static int FindEndingIndex(int[] nums, int target)
        {
            int index = -1;

            int start = 0;
            int end = nums.Length - 1;

            //do binary search
            while (start <= end)
            {
                //avoids overflow
                int midpoint = start + (end - start) / 2;
                if (nums[midpoint] <= target)
                    start = midpoint + 1;
                else
                    end = midpoint - 1;

                if (nums[midpoint] == target) index = midpoint;
            }

            return index;
        }

        private static int FindStartingIndex(int[] nums, int target)
        {
            int index = -1;

            int start = 0;
            int end = nums.Length - 1;

            //do binary search
            while(start <= end)
            {
                //avoids overflow
                int midpoint = start + (end - start) / 2;
                if(nums[midpoint] >= target)
                    end = midpoint - 1;
                else
                    start = midpoint + 1;

                if (nums[midpoint] == target) index = midpoint;
            }

            return index;
        }

        private static int[] SearchRangeLinerTime(int[] nums, int target)
        {
            int start = -1;
            int end = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    if (start == -1) start = i;
                    else end = i;
                }
            }

            if (start != -1 && end == -1) end = start;

            return new int[2] { start, end };
        }
    }
}
