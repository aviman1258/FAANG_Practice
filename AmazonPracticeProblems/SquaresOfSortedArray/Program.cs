using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresOfSortedArray
{
    class Program
    {
        /*
       Given an array of integers A sorted in non-decreasing order, 
       return an array of the squares of each number, 
       also in sorted non-decreasing order.

       Input: [-4,-1,0,3,10]
       Output: [0,1,9,16,100]

       1 <= A.length <= 10000
       -10000 <= A[i] <= 10000
       A is sorted in non-decreasing order
        */

        static void Main(string[] args)
        {
            int[] A = { -4, -1, 0, 3, 10 };

            int nA = A.Length;

            int[] B = SquareSortedArrayIntoSortedArray(A);


            Console.Write("Input: [ ");
            for (int i = 0; i < nA; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine("]");

            Console.Write("Output: [ ");
            for (int i = 0; i < nA; i++)
            {
                Console.Write(B[i] + " ");
            }
            Console.WriteLine("]");
        }

        private static int[] SquareSortedArrayIntoSortedArray(int[] A)
        {
            int nA = A.Length;

            int[] B = new int[nA];

            int k = nA - 1;
            int i = 0;
            int j = nA - 1;

            while (k >= 0)
            {
                if (Math.Abs(A[i]) > A[j])
                {
                    B[k] = A[i] * A[i];
                    i++;
                }
                else
                {
                    B[k] = A[j] * A[j];
                    j--;
                }

                k--;
            }

            return B;
        }
    }
}

