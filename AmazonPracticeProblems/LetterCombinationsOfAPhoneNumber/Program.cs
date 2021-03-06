﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterCombinationsOfAPhoneNumber
{
    class Program
    {
        /*
        Given a string containing digits from 2-9 inclusive, 
        return all possible letter combinations that the number could represent.
        A mapping of digit to letters (just like on the telephone buttons) is given below.
        Note that 1 does not map to any letters.

        Example:
        Input: "23"
        Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

        Note:
        Although the above answer is in lexicographical order, your answer could be in any order you want.
        */

        public static Dictionary<char, string> dialPad = new Dictionary<char, string>{
            {'2',"abc"},
            {'3',"def"},
            {'4',"ghi"},
            {'5',"jkl"},
            {'6',"mno"},
            {'7',"pqrs"},
            {'8',"tuv"},
            {'9',"wxyz"}
        };

        static void Main(string[] args)
        {
            string digits = "23";

            IList<string> combinations = LetterCombinations(digits);

            foreach(string combination in combinations)
            {
                Console.Write("\"" + combination + "\" ");
            }
        }

        public static IList<string> LetterCombinations(string digits)
        {
            List<string> comboList = new List<string>();

            if (digits.Length == 0) return comboList;

            comboList.Add("");

            return GetCombo(comboList, digits);
        }

        public static List<string> GetCombo(List<string> comboList, string digits)
        {

            List<string> localList = new List<string>();

            if (dialPad.TryGetValue(digits[0], out string letters))
            {
                foreach (string s in comboList)
                {
                    foreach (char letter in letters)
                    {
                        localList.Add(s + letter);
                    }
                }
            }

            if (digits.Length > 1)
                return GetCombo(localList, digits.Substring(1));
            else
                return localList;
        }
    }
}
