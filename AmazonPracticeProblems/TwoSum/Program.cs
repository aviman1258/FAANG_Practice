using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Given an array of integers,
            //return indices of the two numbers such that
            //they add up tp specific target.

            //You may assume that each input
            //would have exactly one solution,
            //and you may noy use the same element twice.


            int[] nums = { 2, 7, 11, 15 };
            int target = 13;

            int[] indiciesOfSum = TwoSum(nums, target);

            Console.WriteLine("Expecting: [ 0 , 2 ].");

            Console.Write("Returned: [ ");

            int indiciesOfSumLength = indiciesOfSum.Length;

            for(int i = 0; i < indiciesOfSumLength; i++)
            {
                if (i < indiciesOfSumLength - 1)
                    Console.Write(indiciesOfSum[i] + " , ");
                else
                    Console.Write(indiciesOfSum[i]);
            }

            Console.WriteLine(" ].");
        }

        private static int[] TwoSum(int[] nums, int target)
        {
            int[] result;

            //Method 1: Brute Force
            //O(n^2) time
            //result = BruteForceTwoSum(nums, target);


            //Method 2: Two Pass Hash
            //O(n) time
            //result = TwoPassHash(nums, target);


            //Method 3: One Pass Hash
            //O(n) time
            result = OnePassHash(nums, target);

            return result;
        }

        private static int[] OnePassHash(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>();
            var numsLen = nums.Length;

            for(int i = 0; i < numsLen; i++)
            {
                int complement = target - nums[i];

                if(dictionary.TryGetValue(complement, out int index) && index != i)
                {
                    return new int[] { i , index };
                }

                dictionary.Add(nums[i], i);
            }

            throw new ArgumentNullException("No two sum solution.");
        }

        private static int[] TwoPassHash(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>();
            var numsLen = nums.Length;

            for(int i = 0; i < numsLen; i++)
            {
                dictionary.Add(nums[i], i);
            }

            for(int j = 0; j < numsLen; j++)
            {
                int complement = target - nums[j];

                if(dictionary.TryGetValue(complement, out int index) && index != j)
                {
                    return new int[] { j , index };
                }
            }

            throw new ArgumentNullException("No two sum solution.");
        }

        private static int[] BruteForceTwoSum(int[] nums, int target)
        {
            int numsLen = nums.Length;

            for(int i = 0; i < numsLen; i++)
            {
                for(int j = 0; j < numsLen; i++)
                {
                    if (i == j) continue;

                    if (nums[i] + nums[j] == target)
                        return new int[] { j , i };
                }
            }

            throw new ArgumentNullException("No two sum solution.");
        }
    }
}
