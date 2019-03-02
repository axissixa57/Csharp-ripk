using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите любую строку = ");
            string str = "";
            str = Console.ReadLine();

            int result = FinalValue(str);

            Console.Write($"Сумма (всех кодов символов в строке и в степени количества их повторений) - {result} по модулю 8 = ");
            Console.WriteLine(result % 8);

            //string str = "Мурсапилами";
            //var result = str.Select(c => new
            //{
            //    @Char = c,
            //    Code = (int)c,
            //    Count = str.Where(ch => ch == c).Count()
            //}).Distinct().Sum(e => Math.Pow(e.Code, e.Count)) % 8;
            //Console.WriteLine($"Final result: {result}");
        }

        static int FinalValue(string strng)
        {
            char[] chrs = new char[strng.Length];
            for (int i = 0; i < chrs.Length; i++) // преобразуем строку в массив символов
            {
                chrs[i] = strng[i];
            }

            Console.Write("Строка в виде массива символов = ");
            foreach (char i in chrs)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            int[] intChars = new int[chrs.Length];
            for (int i = 0; i < intChars.Length; i++) // преобразуем строку в массив кодов символов
            {
                intChars[i] = (int)chrs[i];
            }

            Console.Write("Строка в виде кодов массива символов = ");
            foreach (int i in intChars)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            char[] tmp = chrs;
            Console.WriteLine("Число повторений символа в массиве: ");
            for (int i = 0; i < tmp.Length; )
            {
                Console.WriteLine($"{tmp[i]} = {CountRepetedCharOfArray(tmp[i], tmp)}");
                tmp = DeleteCharofArray(tmp[i], tmp);
            }

            double sumIntCharsOfArray = 0;
            char[] tempChrs = chrs;

            for (int i = 0; i < tempChrs.Length; )
            {
                int temp = CountRepetedCharOfArray(tempChrs[i], tempChrs);
                double pow = Math.Pow((int)tempChrs[i], temp);
                sumIntCharsOfArray += pow;
                tempChrs = DeleteCharofArray(tempChrs[i], tempChrs); // удаляем первый символ в массиве
            }

            return (int)sumIntCharsOfArray;
        }

        static int CountRepetedCharOfArray(char chr, char[] arr) // подсчитывает число повторений символа
        {
            int count = 0;
            foreach (char i in arr)
            {
                if (chr == i)
                {
                    count++;
                }
            }
            return count;
        }

        static char[] DeleteCharofArray(char chr, char[] arr) // возращает массив без символа, который идёт первым параметром
        {
            int size = arr.Length - CountRepetedCharOfArray(chr, arr);
            char[] newArr = new char[size];
            int temp = 0;
            foreach (char i in arr)
            {
                if (chr != i)
                {
                    newArr[temp] = i;
                    temp++;
                }
            }
            return newArr;
        }
    }
}
