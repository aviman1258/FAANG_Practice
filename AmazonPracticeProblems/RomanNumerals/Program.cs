using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 999;
            string romanNum = IntToRoman(num);
            int decNum = RomanToInt(romanNum);

            Console.WriteLine(decNum + ": " + romanNum);
        }

        public static string IntToRoman(int num)
        {
            int place = 1000;
            Dictionary<int, char> convertChart = new Dictionary<int, char>
            {
                { 1, 'I' },
                { 5, 'V' },
                { 10, 'X' },
                { 50, 'L' },
                { 100, 'C' },
                { 500, 'D' },
                { 1000, 'M' }
            };

            Dictionary<int, string> exceptions = new Dictionary<int, string>
            {
                { 4, "IV" },
                { 40, "XL" },
                { 400, "CD" }
            };

            Dictionary<int, string> exceptions9 = new Dictionary<int, string>
            {
                { 9, "IX" },
                { 90, "XC" },
                { 900, "CM" }
            };

            string romanNum = "";
            int count = 0;

            while (place > 0)
            {
                count++;
                if (exceptions.TryGetValue((num / place) * place, out string romanStr))
                {
                    romanNum += romanStr;
                }
                else if (place > 1 && exceptions9.TryGetValue((num / (place / 5)) * (place / 5), out string romanStr2))
                {
                    romanNum += romanStr2;
                    place /= 5;
                    count++;
                }
                else
                {
                    int numOfRomanChar = num / place;
                    if (convertChart.TryGetValue(place, out char romanChar))
                    {
                        for (int i = 0; i < numOfRomanChar; i++)
                        {
                            romanNum += romanChar;
                        }
                    }
                }
                num = num - ((num / place) * place);

                if (count % 2 == 1) place /= 2;
                else place /= 5;
            }

            return romanNum;
        }
        public static int RomanToInt(string s)
        {
            Dictionary<string, int> romanNumConv = new Dictionary<string, int>{
            {"I",1},
            {"V",5},
            {"X",10},
            {"L",50},
            {"C",100},
            {"D",500},
            {"M",1000},
            {"IV",4},
            {"IX",9},
            {"XL",40},
            {"XC",90},
            {"CD",400},
            {"CM",900}
        };


            int num = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1 && romanNumConv.TryGetValue(s[i].ToString() + s[i + 1].ToString(), out int localNum))
                {
                    num += localNum;
                    i++;
                }
                else if (romanNumConv.TryGetValue(s[i].ToString(), out int localNum2))
                {
                    num += localNum2;
                }
            }

            return num;
        }
    }
}
