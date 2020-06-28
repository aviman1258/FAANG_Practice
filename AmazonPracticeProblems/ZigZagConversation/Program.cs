using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZigZagConversation
{
    class Program
    {
        /*
        The string "PAYPALISHIRING" is written 
        in a zigzag pattern on a given number of rows like this:
            P   A   H   N
            A P L S I I G
            Y   I   R
        And then read line by line: "PAHNAPLSIIGYIR" 
         */

        static void Main(string[] args)
        {
            string s = "PAYPALISHIRING";
            int rows = 2;

            //string result = Convert_ON3(s, rows);
            string result = Convert_ON(s, rows);

            Console.WriteLine(String.Format("Input: {0} \nRows: {1} \nOutput: {2}", s, rows, result));
        }

        private static string Convert_ON(string s, int numRows)
        {
            if (numRows == 1 || numRows >= s.Length) return s;

            string[] rows = new string[numRows];
            int row = 0;
            bool downMove = true;
            
            for(int i = 0; i < s.Length; i++)
            {
                rows[row] += s[i];

                if (downMove) row++;
                else row--;

                if (row == 0) downMove = true;
                if (row == numRows - 1) downMove = false;
            }

            string result = "";

            for (int j = 0; j < numRows; j++)
                result += rows[j];

            return result;
        }

        public static string Convert_ON3(string s, int numRows)
        {
            if (numRows == 1 || numRows >= s.Length) return s;

            char[,] zigzag = new char[numRows, s.Length / 2 + 1];

            int zigzagRow = 0;
            int zigzagCol = 0;
            bool downMove = true;

            for (int i = 0; i < s.Length; i++)
            {
                zigzag[zigzagRow, zigzagCol] = s[i];

                if (downMove)
                {
                    zigzagRow++;
                }
                else
                {
                    zigzagCol++;
                    zigzagRow--;
                }

                if (zigzagRow >= numRows - 1)
                {
                    downMove = false;
                }

                if (zigzagRow <= 0)
                {
                    downMove = true;
                }
            }

            string result = "";

            for (int i = 0; i < zigzag.GetLength(0); i++)
            {
                for (int j = 0; j < zigzag.GetLength(1); j++)
                {
                    if (zigzag[i, j] != '\0')
                    {
                        result += zigzag[i, j];
                    }
                }
            }

            return result;
        }
    }
}
