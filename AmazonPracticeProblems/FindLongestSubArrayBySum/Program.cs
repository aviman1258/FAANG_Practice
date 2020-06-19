using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FindLongestSubArrayBySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 2, 3, 4, 5, 0, 0, 0, 6, 7, 8, 9, 10};
            int s = 15;

            int[] subArrIndex = FindLongestSubArrayBySum(arr, s);

            Console.WriteLine(string.Format("[ {0} , {1} ]", subArrIndex[0], subArrIndex[1]));
        }

        private static int[] FindLongestSubArrayBySum(int[] arr, int s)
        {
            //return FindLongestSubArrayBySum_BruteForce(arr, s);
            return FindLongestSubArrayBySum_SlidingWindow(arr, s);
        }

        private static int[] FindLongestSubArrayBySum_SlidingWindow(int[] arr, int s)
        {
            int N = arr.Length;
            int[] result = new int[] { -1 };

            int leftPtr = 0;
            int rightPtr = 0;
            int currentSum = 0;       
            
            while(rightPtr < N)
            {
                currentSum += arr[rightPtr];

                while(leftPtr < rightPtr && currentSum > s)
                {
                    currentSum -= arr[leftPtr++];
                }

                if(currentSum == s 
                    && (result.Length == 1 || result[1] - result[0] < rightPtr - leftPtr))
                {
                    result = new int[] { leftPtr + 1, rightPtr + 1 };
                }

                rightPtr++;
            }

            return result;
        }

        private static int[] FindLongestSubArrayBySum_BruteForce(int[] arr, int s)
        {
            int N = arr.Length;
            int[] result = new int[] { -1 };

            for(int leftPtr = 0; leftPtr < N; leftPtr++)
            {
                int currentSum = arr[leftPtr];

                for(int rightPtr = leftPtr + 1; rightPtr < N; rightPtr++)
                {
                    currentSum += arr[rightPtr];

                    if(currentSum == s && result[1] - result[0] < rightPtr - leftPtr)
                    {
                        result = new int[] { leftPtr + 1, rightPtr + 1 };
                    }
                }
            }
            return result;
        }
    }
}
