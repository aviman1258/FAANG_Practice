using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseInt
{
    class Program
    {
        //Given a 32-bit signed integer, 
        //reverse digits of an integer.

        //Assume we are dealing with an environment
        //which could only store integers within the 32-bit
        //signed integer range: [−231,  231 − 1]. 
        //For the purpose of this problem, 
        //assume that your function returns 0 
        //when the reversed integer overflows.
        static void Main(string[] args)
        {
            int x = -2147483648;

            int result = Reverse(x);

            Console.WriteLine(result);
        }

        public static int Reverse(int x)
        {
            if (x == 0) return 0;
            if (x == -2147483648) return 0;

            bool neg = false;
            if (x < 0) neg = true;

            x = Math.Abs(x);

            int result = 0;

            //check first digit to be swapped for overflow check
            int lastDigitOfXCheck = x % 10;
            int digitsInX = -1;

            while (x > 0)
            {
                digitsInX++;
                int lastDigit = x % 10;
                result = (result * 10) + lastDigit;
                x /= 10;
            }
            int firstDigitOfResultCheck = result / (int)Math.Pow(10, digitsInX);

            //there was an overflow
            if (lastDigitOfXCheck != firstDigitOfResultCheck) return 0;

            if (neg) result *= -1;

            return result;
        }
    }
}
