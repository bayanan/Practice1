using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using static Practice1.TreeNode;
using static Practice1.QuickSort;

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

            Console.Write("Выберите способ сортировки: q - QuickSort, t - Tree Sort. ");
            string sort = Console.ReadLine();
            string processedString;
            if (sort == "q")
            {
                var quickSort = new QuickSort();
                processedString = quickSort.Quick(result.ToCharArray(), 0, result.Length - 1);
            }
            else
                processedString = TreeSort(result);

            Console.WriteLine(result, "\nКоличество символов:");
            foreach (var symbolPair in allSymbolsCount)
            {
                Console.WriteLine($"{symbolPair.Key}: {symbolPair.Value};");
            }

            string match = VowelWords(result);
            
            Console.WriteLine(match);            
            Console.WriteLine(processedString);
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

        private static string TreeSort(string inputString)
        {
            var treeNode = new TreeNode(inputString[0]);

            for (int i = 1; i < inputString.Length; i++)
            {
                treeNode.Insert(inputString[i]);
            }
            
            return new string(treeNode.Transform());
        }
    }
}
