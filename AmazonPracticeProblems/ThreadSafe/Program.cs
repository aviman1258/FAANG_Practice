using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafe
{
    class Program
    {
        static Maths objMaths = new Maths();

        static void Main(string[] args)
        {
            Thread t1 = new Thread(objMaths.Divide);
            t1.Start(); //Child thread
            objMaths.Divide(); //Main thread

        }
    }

    class Maths
    {
        public int Num1;
        public int Num2;

        Random o = new Random();

        public void Divide()
        {
            for(long i = 0; i < 100000; i++)
            {
                lock (this)
                {
                    Num1 = o.Next(1, 2); // 1 to 2
                    Num2 = o.Next(1, 2); // 1 to 2
                    int result = Num1 / Num2; //divides
                    Num1 = 0; //resets to 0
                    Num2 = 0;
                }
            }
        }
    }
}
