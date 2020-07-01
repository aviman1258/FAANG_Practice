using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromicSubstring
{
    class Program
    {
        //Given a string s, find the longest palindromic substring in s.

        static void Main(string[] args)
        {
            string s = "a";

            string palindrom = LongestPalindrom(s);

            Console.WriteLine(palindrom);
        }

        private static string LongestPalindrom(string s)
        {
           //base cases
            if (s == null || s.Length < 1) return "";

            int start = 0;
            int end = 0;

            //loop through the letters of the string
            for(int i = 0; i < s.Length; i++)
            {
                //dealing with racecar
                int len1 = LengthOfPalindromInSubstring(s, i, i);

                //dealing with abba
                int len2 = LengthOfPalindromInSubstring(s, i, i + 1);

                int len = Math.Max(len1, len2);

                if(len > end - start + 1)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end + 1);
        }

        //Find palindrom length in substring
        private static int LengthOfPalindromInSubstring(string s, int left, int right)
        {
            //as long as left and right are in range and the two letters 
            //being compared are same.
            while(left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
        }
    }
}
