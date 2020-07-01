using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripletSum
{
    class Program
    {
        //Given an array of numbers and a number k, 
        //determine if there are three entries in the array 
        //which add up to the specified number k. 

        //For example, given[20, 303, 3, 4, 25] and k = 49, 
        //return true as 20 + 4 + 25 = 49.

        static void Main(string[] args)
        {
            int[] nums = { -1, 0, 1, 2, -1, 4 };
            int k = 0;

            if (TripletPresent(nums, k))
            {
                Console.WriteLine("Triplet adding to " + k + " present!");

                IList<IList<int>> result = ThreeSum(nums, k);

                foreach(var set in result)
                {
                    foreach(var digit in set)
                    {
                        Console.Write(digit + " ");
                    }
                    Console.WriteLine();
                }               
            }
            else
                Console.WriteLine("Triplet adding to " + k + " not present!");
        }

        /// <summary>
        /// Given an array nums of n integers, 
        /// are there elements a, b, c in nums 
        /// such that a + b + c = 0? 
        /// Find all unique triplets in the array which gives the sum of k.
        /// The solution set must not contain duplicate triplets.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private static IList<IList<int>> ThreeSum(int[] nums, int k)
        {
            Array.Sort(nums);

            int N = nums.Length;
            int headPtr = 0;
            int tailPtr = N - 1;
            List<IList<int>> resultList = new List<IList<int>>();

            for (int i = 0; i < N; i++)
            {
                //If the number is same as last number continue.
                if (i != 0 && nums[i] == nums[i - 1]) continue;

                List<int> localResultList = new List<int>();
                int compliment = k - nums[i];

                while (tailPtr > headPtr)
                {
                    if (headPtr == i)
                    {
                        headPtr++;
                        continue;
                    }
                    if (tailPtr == i)
                    {
                        tailPtr--;
                        continue;
                    }

                    if (nums[headPtr] + nums[tailPtr] == compliment)
                    {
                        localResultList.Add(nums[i]);
                        localResultList.Add(nums[headPtr]);
                        localResultList.Add(nums[tailPtr]);
                        resultList.Add(localResultList);

                        break;
                    }
                    else if (nums[headPtr] + nums[tailPtr] > compliment) tailPtr--;
                    else headPtr++;
                }
            }

            return resultList;
        }

        private static bool TripletPresent(int[] nums, int k)
        {
            //return TripletPresentBruteForce(nums, k);
            return TriplePresentSortMethod(nums, k);
        }


        /// <summary>
        /// Sort the given array.
        /// Loop over the array and fix the first element of the possible triplet, arr[i].
        /// Then fix two pointers, one at i + 1 and the other at n – 1. And look at the sum,
        /// If the sum is smaller than the required sum, increment the first pointer.
        /// Else, If the sum is bigger, Decrease the end pointer to reduce the sum.
        /// Else, if the sum of elements at two-pointer is equal to given sum then print the triplet and brea
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private static bool TriplePresentSortMethod(int[] nums, int k)
        {
            Array.Sort(nums);

            int n = nums.Length;

            for(int i = 0; i < n; i++)
            {
                int headPtr = 0;
                int tailPtr = n - 1;

                int compliment = k - nums[i];

                while(headPtr < tailPtr)
                {
                    if (headPtr == i)
                    {
                        headPtr++;
                        continue;
                    }

                    if (tailPtr == i)
                    {
                        tailPtr--;
                        continue;
                    }

                    int sum = nums[headPtr] + nums[tailPtr];

                    if (sum == compliment)
                        return true;
                    else if (sum > compliment)
                        tailPtr--;
                    else
                        headPtr++;
                }
            }

            return false;
        }

        private static bool TripletPresentBruteForce(int[] nums, int k)
        {
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int m = 0; m < n; m++)
                    {
                        int sum = nums[i] + nums[j] + nums[m];

                        if (sum == k && i != k && k != m && i != m)
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
