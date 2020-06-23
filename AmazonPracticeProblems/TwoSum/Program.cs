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
            //they add up to specific target.

            //You may assume that each input
            //would have exactly one solution,
            //and you may noy use the same element twice.


            int[] nums = { 
                230, 863, 916, 585, 981, 404, 316, 785, 88, 12,
                70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 
                325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 
                168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 
                863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 
                314, 422, 927, 783, 930, 282, 306, 506, 44, 926,
                691, 568, 68, 730, 933, 737, 531, 180, 414, 751,
                28, 546, 60, 371, 493, 370, 527, 387, 43, 541,
                13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 
                538, 427, 583, 368, 375, 173, 809, 896, 370, 789 
            };
            int target = 542;

            int[] indiciesOfSum = TwoSum(nums, target);

            //Console.WriteLine("Expecting: [ 0 , 2 ].");

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

                if(!dictionary.ContainsKey(nums[i]))
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
