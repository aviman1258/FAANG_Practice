using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambaExpressions
{
    class Program
    {
        //delegate double CalAreaPointer(int r);
        //static CalAreaPointer cpointer = CalculateArea;
        static void Main(string[] args)
        {
            //double area = cpointer.Invoke(20);

            //Anonymous function lets you write the function
            //inline and reduce code.

            //CalAreaPointer cpointer = new CalAreaPointer(
            //    delegate (int r)
            //    {
            //        return 3.14 * r * r;
            //    }
            //    );

            //double area = cpointer(20);


            //Lamba expression minimizes the lines of code

            //CalAreaPointer cpointer = r => 3.14 * r * r;

            //We can minimize lines of code even more
            //Func is a generic delegate:
            //Takes in Double and outputs a double

            Func<double, double> cpointer = r => 3.14 * r * r;

            double area = cpointer(20);

            //Action delegates have an input but void output
            Action<string> myAction = y => Console.Write(y);
            myAction("Hello");

            //Predicate can take any input and will
            //output a boolean type

            Predicate<string> CheckGreaterThan5 = x => x.Length > 5;
            Console.WriteLine(CheckGreaterThan5("Avishek"));

            List<string> oString = new List<string>();

            oString.Add("Duke");
            oString.Add("Avishek");

            //You can pass a predicate into the Find function
            //You will find strings that match that predicate
            //or strings with length greater than 5
            string str = oString.Find(CheckGreaterThan5);
            Console.Write(str);

            //Expression trees
            
        }

        //static double CalculateArea(int r)
        //{
        //    return 3.14 * r * r;
        //}
    }
}
