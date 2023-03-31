using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace Practice1 {
    public class Program { 
        static void Main(string[] args) {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            string result;

            var incorrectSymbols = GetIncorrectSymbols(str);
            if (incorrectSymbols.Length != 0) {
                incorrectSymbols.Remove(incorrectSymbols.Length - 2, 2);
                Console.WriteLine($"Ошибка, введены неверные символы: {incorrectSymbols}.");
                return;
            }

            Dictionary<char, int> allSymbolsCount = GetCountSymbols(str);
            if (str.Length % 2 == 0)
            {
                char[] leftStr = str.Substring(0, str.Length / 2).ToCharArray();
                char[] rightStr = str.Substring(str.Length / 2).ToCharArray();
                Array.Reverse(leftStr);
                Array.Reverse(rightStr);
                result = new string(leftStr) + new string(rightStr);
            }
            else {
                char[] brokenStr = str.ToCharArray();
                Array.Reverse(brokenStr);
                result = new string(brokenStr) + str;
            }

                Console.WriteLine(result, "\nКоличество символов:");
            foreach (var symbolPair in allSymbolsCount)
            {
                Console.WriteLine($"{symbolPair.Key}: {symbolPair.Value};");
            }
            
            string match = VowelWords(result);
            Console.WriteLine(match);

        }

        private static StringBuilder GetIncorrectSymbols(string inputString)
        {
            string correctSymbols = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder incorrectSymbols = new StringBuilder();

            foreach (char ch in inputString)
            {
                if (!correctSymbols.Contains(ch))
                {
                    incorrectSymbols.AppendFormat("{0}, ", ch);
                }
            }
            
            return incorrectSymbols;
        }

        private static Dictionary<char, int> GetCountSymbols(string inputString) 
        {
            var symbolCount = new Dictionary<char, int>();
            foreach (char ch in inputString)
            {
                if (symbolCount.ContainsKey(ch))
                    symbolCount[ch]++;
                else
                    symbolCount[ch] = 1;
            }
            return symbolCount;
        }

        private static string VowelWords(string inputString)
        {
            string correctSymbols = "aeiouy";
            int vowelCount = 0;

            foreach (char ch in inputString)
            {
                if (correctSymbols.Contains(ch))
                    vowelCount++;
            }
            Regex regex;
            if (vowelCount > 1)
                regex = new Regex(@"^[^aeiouy]*([aeiouy]{1}\w*[aeiouy]{1})[^aeiouy]*$");
            else if (vowelCount == 0)
                return "Гласные буквы не найдены.";
            else
                regex = new Regex(@"^[^aeiouy]*([aeiouy]{1})[^aeiouy]*$");

            return regex.Match(inputString).Groups[1].Value;
        }

    }
}
