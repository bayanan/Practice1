using System;

namespace Practice1 {
    public class Program { 
        static void Main(string[] args) {
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            string result;
            if (str.Length % 2 == 0) {
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
