using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fibonacci sequence
            //1 1 2 3 5 8 13...
            //Find the nth number in the sequence

            int n = 45;

            //int nthNumber = Fib(n);
            //int nthNumber = FibDyn(n);
            int nthNumber = FibBottomUp(n);

            Console.WriteLine(string.Format("The {0}(th) number in the Fibonacci sequence is {1}.", n, nthNumber));
            Console.ReadLine();
        }

        public static int Fib(int n)
        {
            int result;

            //If n is 1 or 2 the number is 1.
            if(n == 1 || n == 2)
            {
                result = 1;
            }
            else
            {
                result = Fib(n - 1) + Fib(n - 2);
            }

            return result;
        }

        public static int FibDyn(int n)
        {
            int?[] memo = new int?[n + 1];
            return FibDyn(n, memo);
        }
        
        private static int FibDyn(int n, int?[] memo)
        {
            if(memo[n] != null)
            {
                return memo[n] ?? 0;
            }

            int result;

            if(n == 1 || n == 2)
            {
                result = 1;
            }
            else
            {
                result = Fib(n - 1) + Fib(n - 2);
            }

            memo[n] = result;

            return result;
        }

        public static int FibBottomUp(int n)
        {
            int[] fib = new int[n+1];

            for(int i = 1; i <= n; i++)
            {
                if(i == 1 || i == 2)
                {
                    fib[i] = 1;
                }
                else
                {
                    fib[i] = fib[i - 1] + fib[i - 2];
                }
            }

            return fib[n];
        }
    }
}
