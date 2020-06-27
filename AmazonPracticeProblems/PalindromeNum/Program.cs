using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeNum
{
    class Program
    {
        //Determine whether an integer is a palindrome. 
        //An integer is a palindrome 
        //when it reads the same backward as forward.
        static void Main(string[] args)
        {
            int x = 1277227721;

            Console.Write(x + ": ");
            if (IsPalindrome(x)) Console.WriteLine("true");
            else Console.WriteLine("false");
        }

        public static bool IsPalindrome(int x)
        {

            if (x < 0) return false;

            ArrayList digits = new ArrayList();

            while (x > 0)
            {
                digits.Add(x % 10);
                x /= 10;
            }

            int i = 0;
            int j = digits.Count - 1;

            while (i < j)
            {
                if ((int)digits[i] == (int)digits[j])
                {
                    i++;
                    j--;
                }
                else return false;
            }

            return true;

        }
    }
}
