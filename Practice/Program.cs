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

        //вычисление числа повторений символов в строке
        static void GetNumberOfCharsRepetitions(string str)
        {
            Console.WriteLine("Число повторений символов в строке:");
            int count; //переменная для количества повторений
            char currChar;//текущий символ
            bool ThereAreRepeatingChars = false;
            //чтобы информация о количестве повторений того или иного символа
            //не выводилась несколько раз, будем заносить каждый пройденный
            //символ в список и при анализе следующих символов проверять,
            //не посчитали ли мы уже число повторений этого символа
            List<char> nonRepeatingChars = new List<char>(); 
            for(int i = 0; i < str.Length; i++)
            {
                currChar = str[i];
                if(nonRepeatingChars.Contains(currChar))
                    continue;
                count = 0;
                foreach (char c in str)
                {
                    if (c == currChar)
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    ThereAreRepeatingChars = true;
                    Console.Write($"{currChar} - {count}, ");
                }
                nonRepeatingChars.Add(currChar);
            }
            if (ThereAreRepeatingChars)
            {
                Console.Write("\n"); //т.к. мы делали console.write при выводе повторяющихся
            }
            else
                Console.WriteLine("В строке нет повторяющихся символов");
        }

        //проверка строки на чётность

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
                GetNumberOfCharsRepetitions(str);
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
