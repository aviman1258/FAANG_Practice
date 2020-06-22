using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubstringWithoutRepeatingChars
{
    class Program
    {
        //Given a string, find the length of the longest substring 
        //without repeating characters.
        static void Main(string[] args)
        {
            string s = "abcabcbb";
            int len = LengthOfLongestSubstring(s);

            Console.WriteLine(s + ": " + len);
        }

        public static int LengthOfLongestSubstring(string s)
        {

            if (s == null || s.Length < 1) return 0;

            if (s.Length == 1) return 1;

            int leftPtr = 0;
            int rightPtr = 0;
            HashSet<char> lettersSeen = new HashSet<char>();
            int subStrLen = 0;

            while (leftPtr < s.Length && rightPtr < s.Length)
            {
                if (lettersSeen.Contains(s[rightPtr]))
                {
                    //This means that you already have seen this char in this substring                
                    lettersSeen.Remove(s[leftPtr]);
                    leftPtr++;
                }
                else
                {
                    lettersSeen.Add(s[rightPtr]);
                    rightPtr++;
                    subStrLen = Math.Max(subStrLen, rightPtr - leftPtr);
                }
            }

            return subStrLen;

        }
    }
}
