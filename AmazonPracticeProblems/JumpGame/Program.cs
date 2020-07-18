using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpGame
{
    class Program
    {
        /*
         * Given an array of non-negative integers,
         * you are initially positioned at the first index of the array. 
         * Each element in the array represents your maximum jump length at that position. 
         * Determine if you are able to reach the last index.
         */

        static void Main(string[] args)
        {
            int[] nums = { 3, 2, 1, 0, 4 };

            if (CanJump(nums)) Console.WriteLine("True");
            else Console.WriteLine("False;");
        }

        public static bool CanJump(int[] nums)
        {
            HashSet<int> badIndex = new HashSet<int>();
            int badNum = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] <= badNum)
                {
                    badIndex.Add(i);
                    badNum++;
                }
                else
                {
                    badNum = 0;
                }
            }

            if (badIndex.Contains(0)) return false;
            return true;
        }
    }
}
