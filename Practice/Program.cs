using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Program
    {
        //проверка на наличие в строке неподходящих символов
        static List<Char> GetUnsuitableChars(string str)
        {
            List<char> unsuitableChars = new List<char>(); 
            string alphabet = "abcdefghijklmnopqrstuvwxyz"; 
            foreach (char c in str)
            {
                if (!alphabet.Contains(c))
                {
                    unsuitableChars.Add(c);
                }
            }
            return unsuitableChars;
        }

        //проверка строки на чётностьм
        static bool IsEven(string str)
        {
            int length = str.Length;
            if (length % 2 == 0)
            {
                return true;
            }
            else return false;
        }

        //функция для обработки строки
        //проверяем четная ли строка
        //в зависимости от её четности/нечетности вызываем ту или иную функцию
        static void StringProcessing(string str, out string newStr)
        {
            //если в строке есть неподходящие символы
            if (GetUnsuitableChars(str).Count != 0)
            {
                Console.WriteLine("В сообщении содержатся неподходящие символы:");
                foreach (char c in GetUnsuitableChars(str))
                    Console.Write(c);
                newStr = string.Empty;
            }
            else
            {
                if (IsEven(str))
                    newStr = EvenStringProcessing(str);
                else
                    newStr = OddStringProcessing(str);
            }
        }

        // обработка строк с четным количеством сммволов
        static string EvenStringProcessing(string str)
        {
            int halfLength = str.Length / 2;
            string firstHalf = str.Substring(0, halfLength);
            string secondHalf = str.Substring(halfLength);
            firstHalf = ReverseString(firstHalf);
            secondHalf = ReverseString(secondHalf);
            string newStr = string.Concat(firstHalf, secondHalf);
            return newStr;
        }

        // обработка строк с нечетным количеством сммволов  
        static string OddStringProcessing(string str)
        {
            string reversedStr = ReverseString(str);
            string newStr = string.Concat(reversedStr, str);
            return newStr;
        }

        //переворот строки
        static string ReverseString(string str)
        {
            string newStr = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                newStr += str[i];
            }
            return newStr;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();
            StringProcessing(str, out string newStr);
            if (newStr != string.Empty)
            {
                Console.WriteLine("Обработанная строка:");
                Console.WriteLine(newStr);
            }
        }
    }
}
