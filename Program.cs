﻿using System;
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
            Console.WriteLine(result);
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
    }
}
