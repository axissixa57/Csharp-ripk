using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] arr = new int[10];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-10, 10);
            }

            Console.Write("arr = ");
            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            try
            {
                arr[10] = 777;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            var Min_Max_Avg = GetValues(arr);
            Console.WriteLine($"Min, and Max, and Avg values of the arr = {Min_Max_Avg}");
        }

        static int Min(int[] randArr)
        {
            int result = 0;
            for (int i = 0; i < randArr.Length - 1; i++)
            {
                if (randArr[i] < randArr[i + 1])
                {
                    result = randArr[i];
                    randArr[i] = randArr[i + 1];
                    randArr[i + 1] = result;
                }

            }
            return result;
        }

        static int Max(int[] randArr)
        {
            int result = 0;
            for (int i = 0; i < randArr.Length - 1; i++)
            {
                if (randArr[i] > randArr[i + 1])
                {
                    result = randArr[i];
                    randArr[i] = randArr[i + 1];
                    randArr[i + 1] = result;
                }

            }
            return result;
        }

        static double Avg(int[] randArr)
        {
            double result = 0;
            int sum = 0;
            double count = 0;
            for (int i = 0; i < randArr.Length; i++)
            {
                if (randArr[i] > 0)
                {
                    sum += randArr[i];
                    count++;
                }
            }
            return result = sum / count;
        }

        static (int, int, double) GetValues(int[] randArr)
        {
            int min = Min(randArr);
            int max = Max(randArr);
            double avg = Avg(randArr);
            var result = (min, max, avg);
            return result;
        }

    }
}