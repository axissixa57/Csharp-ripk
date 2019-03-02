using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            int[] arr2 = new int[10];
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(100);
            }

            Console.Write("arr = ");

            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = random.Next(100);
            }

            Console.Write("arr2 = ");

            foreach (int i in arr2)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            Console.Write("sort arr2 = ");

            Array.Sort(arr2);

            foreach (int i in arr2)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            Console.Write("reverse arr2 = ");

            Array.Reverse(arr2);

            foreach (int i in arr2)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = arr2[i] + arr[i];
            }

            Console.Write("[reverse arr2 + arr] = ");

            foreach (int i in arr2)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }
    }
}
