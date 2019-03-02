using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] arr = new int[10];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-10,10);
            }

            Console.Write("arr = ");

            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            Console.Write("newArr = ");

            int[] x = NewArr(arr, 1, 2, 3, 4, 5, 0, -3);

            foreach (int i in x)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
        }

        static int[] NewArr(int[] randArr, params int[] randIntegers)
        {
            bool[] tempArr = new bool[randArr.Length]; // tempArr = [false, false, ...]
            int lengthForFinishArr = 0;

            for (int i = 0; i < randArr.Length; i++)
            {
                bool check = false; // нужна, чтобы определить длину конечного массива без чисел из массива равных числам в params

                for (int j = 0; j < randIntegers.Length; j++)
                {
                    if (randArr[i] == randIntegers[j])
                    {
                        check = true;
                        tempArr[i] = true;
                        break;
                    }
                }

                if (check == false)
                    lengthForFinishArr++;
            }

            int[] finishArr = new int[lengthForFinishArr];

            for (int i = 0, j = 0; i < randArr.Length; i++)
            {
                if (tempArr[i] == false)
                {
                    finishArr[j] = randArr[i]; // позиция равных и неравных чисел в массивах tempArr и randArr совпадают, поэтому присваивам значение из массива, который передаем как аргумент
                    j++;
                }
            }

            return finishArr;
        }

        //static int[] NewArr(int[] randArr, params int[] randIntegers)
        //{
        //    int[] tempArr = new int[randArr.Length];
        //    int lengthForFinishArr = randArr.Length;

        //    for (int i = 0; i < randArr.Length; i++)
        //    {
        //        for (int j = 0; j < randIntegers.Length; j++)
        //        {
        //            if (randArr[i] == randIntegers[j])
        //            {
        //                tempArr[i] = 0;
        //                lengthForFinishArr--;
        //                break;
        //            }
        //            else
        //            {
        //                tempArr[i] = randArr[i];
        //            }
        //        }
        //    }

        //    int[] finishArr = new int[lengthForFinishArr];

        //    for (int i = 0, j = 0; i < randArr.Length; i++)
        //    {
        //        if (tempArr[i] != 0)
        //        {
        //            finishArr[j] = tempArr[i];
        //            j++;
        //        }
        //    }

        //    return finishArr;
        //}
    }
}
