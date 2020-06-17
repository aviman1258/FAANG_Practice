using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfArrayExceptSelf
{
    class Program
    {
        //Given an array nums of n integers where n > 1,
        //return an array output such that output[i]
        //is equal to the product of all the elements of nums
        //except nums[i].

        //Solve it without division in O(n).
        
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4 };

            int[] output = ProductExceptSelf(nums);

            for(int i = 0; i < output.Length; i++)
            {
                Console.Write(output[i] + " ");
            }
        }

        private static int[] ProductExceptSelf(int[] nums)
        {
            //return ProductExceptSelfByDivision(nums);
            //return ProductExceptSelfWithoutDivision(nums);
            return ProductExceptSelfWithOutDivisionConstSpace(nums);
        }

        private static int[] ProductExceptSelfWithOutDivisionConstSpace(int[] nums)
        {
            int N = nums.Length;

            int[] output = new int[N];

            output[0] = 1;

            for(int i = 1; i < N; i++)
            {
                output[i] = nums[i - 1] * output[i - 1];
            }

            int R = 1;

            for(int i = N - 1; i >= 0; i--)
            {
                output[i] = output[i] * R;
                R *= nums[i];
            }

            return output;
        }

        private static int[] ProductExceptSelfWithoutDivision(int[] nums)
        {
            int N = nums.Length;
            
            int[] prodsfwd = new int[N];
            int[] prodsbck = new int[N];

            int[] output = new int[N];

            prodsfwd[0] = 1;
            prodsbck[N - 1] = 1;

            for (int i = 1; i < N; i++)
            {
                prodsfwd[i] = nums[i - 1] * prodsfwd[i - 1];
            }

            for(int j = N - 2; j >= 0; j--)
            {
                prodsbck[j] = nums[j + 1] * prodsbck[j + 1];
            }

            for(int i = 0; i < N; i++)
            {
                output[i] = prodsfwd[i] * prodsbck[i];
            }

            return output;
        }

        private static int[] ProductExceptSelfByDivision(int[] nums)
        {
            int product = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                product *= nums[i];
            }

            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = product / nums[i];
            }

            return nums;
        }
    }
}
