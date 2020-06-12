using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public static class MergeSort
    {
        public static void  DoMergeSort(int[] arr)
        {
            int n = arr.Length;

            if (n < 2)
                return;

            int mid = n / 2;
            int[] left = new int[mid];
            int[] right = new int[n - mid];

            for(int i = 0; i < mid; i++)
            {
                left[i] = arr[i];
            }

            for(int j = mid; j < n; j++)
            {
                right[j - mid] = arr[j];
            }
            
            DoMergeSort(left);
            DoMergeSort(right);
            Merge(left, right, arr);
        }

        private static void Merge(int[] left, int[] right, int[] arr)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            int nL = left.Length;
            int nR = right.Length;

            while (i < nL && j < nR)
            {
                if(left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                
                k++;
            }

            while(i < nL)
            {
                arr[k] = left[i];
                i++;
                k++;
            }
            
            while(j < nR)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
