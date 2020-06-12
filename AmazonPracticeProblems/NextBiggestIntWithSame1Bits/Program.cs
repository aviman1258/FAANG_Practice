using System;

namespace NextBiggestIntWithSame1Bits
{
    class Program
    {
        //Given an integer n, find the next biggest integer with the same number of 1-bits on.
        //For example, given the number 6 (0110 in binary), return 9 (1001).

        static void Main(string[] args)
        {
            Console.WriteLine(string.Format("N = {0}; Expected: {1}; Actual: {2}", 2, 4, GetNextBiggestIntWithSameOneBits(2)));
            Console.WriteLine(string.Format("N = {0}; Expected: {1}; Actual: {2}", 3, 5, GetNextBiggestIntWithSameOneBits(3)));
            Console.WriteLine(string.Format("N = {0}; Expected: {1}; Actual: {2}", 4, 8, GetNextBiggestIntWithSameOneBits(4)));
            Console.WriteLine(string.Format("N = {0}; Expected: {1}; Actual: {2}", 6, 9, GetNextBiggestIntWithSameOneBits(6)));
            Console.WriteLine(string.Format("N = {0}; Expected: {1}; Actual: {2}", 7, 11, GetNextBiggestIntWithSameOneBits(7)));
            Console.WriteLine(string.Format("N = {0}; Expected: {1}; Actual: {2}", 0, "Exception", GetNextBiggestIntWithSameOneBits(0)));
        }

        private static int GetNextBiggestIntWithSameOneBits(int n)
        {
            if (n < 1) throw new ArgumentException();

            int numOf1sInBinaryOfN = Get1sInBinaryOfNumber(n);

            int numOf1sInBinaryOfBiggerN;

            do
            {
                n++;
                numOf1sInBinaryOfBiggerN = Get1sInBinaryOfNumber(n);

            } while (numOf1sInBinaryOfBiggerN != numOf1sInBinaryOfN);

            return n;
        }


        private static int Get1sInBinaryOfNumber(int n)
        {
            int numOf1s = 0;

            while(n >= 1)
            {
                if (n % 2 == 1) 
                    numOf1s++;

                n /= 2;
            }

            return numOf1s;
        }
    }
}
