using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Find the first duplicate in array.
            //All elements of array must be 1 <= a[i] <= N.
            
            int[] a = { 4, 4, 2, 1, 3 };

            int dup = FindFirstDupConstSpace(a);
            //int dup = FindFirstDupHash(a);
            //int dup = FindFirstDupBruteForce(a);


            Console.WriteLine("The first duplicate is " + dup);
        }

        private static int FindFirstDupBruteForce(int[] a)
        {
            int N = a.Length;

            int indexOfFirstDup = N;

            for (int i = 0; i < N; i++)
            {
                for(int j = i + 1; j < N; j++)
                {
                    if (a[i] == a[j] && j < indexOfFirstDup) 
                        indexOfFirstDup = j;
                }
            }

            if (indexOfFirstDup == N) return -1;
            else return a[indexOfFirstDup];
        }

        private static int FindFirstDupHash(int[] a)
        {
            Dictionary<int, int> valuePairs = new Dictionary<int, int>();
            int N = a.Length;
            
            for(int i = 0; i < N; i++)
            {
                if (valuePairs.ContainsKey(a[i])) return a[i];
                else valuePairs.Add(a[i], 1);
            }

            return -1;
        }

        private static int FindFirstDupConstSpace(int[] a)
        {
            int N = a.Length;

            for(int i = 0; i < N; i++)
            {
                int index = Math.Abs(a[i]);

                if (a[index] < 0) return Math.Abs(a[i]);
                else a[index] *= -1;
            }

            return -1;
        }
    }
}
