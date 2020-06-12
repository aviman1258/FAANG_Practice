using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {10, 5, 3, 7, 11, 1, 0, 12, 2, 4, 12, -9};

            int arrLength = arr.Length;

            for (int i = 0; i < arrLength; i++)
                Console.Write(arr[i] + " ");

            MergeSort.DoMergeSort(arr);

            Console.WriteLine();

            for (int i = 0; i < arrLength; i++)
                Console.Write(arr[i] + " ");

            Console.ReadLine();
        }
    }
}
