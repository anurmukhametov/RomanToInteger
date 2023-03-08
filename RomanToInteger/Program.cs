using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanToInteger
{
    public class Solution
    {
        public int RomanToInt(string romanString)
        {
            var reverseRomanString = Reverse(romanString);
            int result = 0;
            char previousChar = '0';
            foreach (var currentChar in reverseRomanString)
            {
                switch (currentChar)
                {
                    case 'I':
                        result += previousChar == 'V' || previousChar == 'X' ? -1 : 1;
                        break;
                    case 'V':
                        result += 5;
                        break;
                    case 'X':
                        result += previousChar == 'L' || previousChar == 'C' ? -10 : 10;
                        break;
                    case 'L':
                        result += 50;
                        break;
                    case 'C':
                        result += previousChar == 'D' || previousChar == 'M' ? -100 : 100;
                        break;
                    case 'D':
                        result += 500;
                        break;
                    case 'M':
                        result += 1000;
                        break;
                    default:
                        result += 0;
                        break;
                }
                previousChar = currentChar;
            }
            return result;
        }
        private string Reverse(string input)
        {
            var output = string.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }
            return output;
        }
    }

    internal class Program
    {
        private const string Case_1 = "III";
        private const string Case_2 = "LVIII";
        private const string Case_3 = "MCMXCIV";
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine($"{Case_1} -> {solution.RomanToInt(Case_1)}");
            Console.WriteLine($"{Case_2} -> {solution.RomanToInt(Case_2)}");
            Console.WriteLine($"{Case_3} -> {solution.RomanToInt(Case_3)}");
            Console.ReadLine();
        }
    }
}
