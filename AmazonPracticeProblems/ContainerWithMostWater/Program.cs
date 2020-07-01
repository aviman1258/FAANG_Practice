using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerWithMostWater
{
    class Program
    {
        /*
         * Given n non-negative integers a1, a2, ..., an , 
         * where each represents a point at coordinate (i, ai). 
         * n vertical lines are drawn such that the two endpoints of line i
         * is at (i, ai) and (i, 0). Find two lines, 
         * which together with x-axis forms a container, 
         * such that the container contains the most water.
         * Note: You may not slant the container and n is at least 2.
        */
        static void Main(string[] args)
        {
            int[] heights = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            Console.WriteLine("Max area: " + MaxArea(heights));
        }

        public static int MaxArea(int[] height)
        {
            int N = height.Length;
            int start = 0;
            int end = N - 1;
            int maxArea = 0;

            while (start < end)
            {
                int h = Math.Min(height[start], height[end]);
                int l = end - start;
                int area = h * l;
                maxArea = Math.Max(maxArea, area);

                if (h == height[start]) start++;
                else end--;
            }

            return maxArea;
        }
    }
}
