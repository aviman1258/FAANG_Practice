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
            
            int[] a = { 2, 3, 2, 1, 3 };

            int dup = FindFirstDup(a);


            Console.WriteLine("The first duplicate is " + dup);
        }

        private static int FindFirstDup(int[] a)
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
