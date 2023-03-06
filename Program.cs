using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace Practice1 {
    public class Program { 
        static void Main(string[] args) {
            String correctSymbols = "abcdefghijklmnopqrstuvwxyz";
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            string result;
            if (!str.Contains(@"[a-z]*"))
            {
                StringBuilder errorMessage = new StringBuilder("Ошибка, введены неверные символы: ");
                List<char> errorSymbols = new List<char>();
                for (int i = 0; i < str.Length; i++)
                {
                    if (!(correctSymbols.Contains(str[i])))
                    {
                        errorSymbols.Add(str[i]);
                    }
                }
                for (int i = 0; i < errorSymbols.Count; i++)
                {
                    errorMessage.AppendFormat("{0}", errorSymbols[i]);
                    if (i < errorSymbols.Count - 1)
                    {
                        errorMessage.Append(", ");
                    }
                }
                Console.WriteLine(errorMessage);
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
    }
}
