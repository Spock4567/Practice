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

        // Быстрая сортировка

        //функция, преобразующая входную строку в массив символов,
        //вызывающая QuickSort для этого массива и преобразующая
        //его обратно в строку уже отсортированную
        public static string QuickSortString(string str)
        {
            char[] charArr = str.ToCharArray();
            QuickSort(charArr, 0, charArr.Length - 1);
            return new string(charArr);
        }

        //сортировка массива символов методом быстрой сортировки
        private static void QuickSort(char[] arr, int left, int right)
        {
            if (left < right)
            {
                int supportElementIndex = Partition(arr, left, right);
                QuickSort(arr, left, supportElementIndex - 1);
                QuickSort(arr, supportElementIndex + 1, right);
            }
        }

        // функция разделения, выбирающая опорный элемент и
        // располагающая элементы меньше опорного слева, а больше – справа
        private static int Partition(char[] arr, int left, int right)
        {
            char supportElement = arr[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (arr[j] <= supportElement) // Сравниваем символы
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, right);
            return i + 1;
        }

        private static void Swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        //Сортировка деревом

        // узел бинарного дерева
        private class Node
        {
            public char Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(char value)
            {
                Value = value;
            }
        }

        // функция для сортировки деревом
        public static string TreeSortString(string str)
        {
            Node root = null;
            foreach (char c in str)
            {
                root = Insert(root, c);
            }

            StringBuilder sortedString = new StringBuilder();
            InOrderTraversal(root, sortedString);
            return sortedString.ToString();

        }

        // вставка узла в дерево
        private static Node Insert(Node root, char value)
        {
            if (root == null)
            {
                return new Node(value);
            }

            if (value < root.Value)
            {
                root.Left = Insert(root.Left, value);
            }
            else
            {
                root.Right = Insert(root.Right, value);
            }
            return root;
        }

        // симметричный обход дерева
        private static void InOrderTraversal(Node node, StringBuilder sb)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, sb);
                sb.Append(node.Value);
                InOrderTraversal(node.Right, sb);
            }
        }

        //получение самой длинной подстроки,
        //начинающейся и заканчивающейся на гласной
        static string GetLongestVowelSubstring(string str)
        {
            string vowels = "aeiouy"; //гласные буквы
            string longestSubstring = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (vowels.Contains(str[i])) // начинаем с гласной
                {
                    for (int j = i; j < str.Length; j++)
                    {
                        if (vowels.Contains(str[j])) // заканчиваем на гласной
                        {
                            string currentSubstring = str.Substring(i, j - i + 1);
                            if (currentSubstring.Length > longestSubstring.Length)
                            {
                                longestSubstring = currentSubstring;
                            }
                        }
                    }
                }
            }

            return longestSubstring;
        }

        //вычисление числа повторений символов в строке
        static void GetNumberOfCharsRepetitions(string str)
        {
            Console.WriteLine("Число повторений символов в обработанной строке:");
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
                Console.WriteLine("В обработанной строке нет повторяющихся символов");
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
                GetNumberOfCharsRepetitions(newStr);
                Console.WriteLine("Самая большая подстрока в обработанной строке," +
                    "которая начинается и заканяивается на гласную:");
                string longestVowelSubstr = GetLongestVowelSubstring(newStr);
                Console.WriteLine(longestVowelSubstr);
                string quickSortedNewStr = QuickSortString(newStr);
                //Быстрая сортировка
                Console.WriteLine("Быстрая сортировка обработанной строки: " + "\n" + quickSortedNewStr);
                // Сортировка деревом
                string treeSortedNewStr = TreeSortString(newStr);
                Console.WriteLine("Сортировка деревом: " + "\n" + treeSortedNewStr);
            }
        }
    }
}
