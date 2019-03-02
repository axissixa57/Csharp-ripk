using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_9
{
    class Program
    {
        static void Main(string[] args)
        {
            //example1();
            //example2();
            //example3();
            example4();
            //example5();
        }

        static void example1()
        {
            int[] a = new int[4];
            try
            {
                a[5] = 4; // тут возникнет исключение, так как у нас в массиве только 4 элемента
                Console.WriteLine("Завершение блока try");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally");
            }
            Console.ReadLine();
        }

        static void example2()
        {
            try
            {
                string message = Console.ReadLine();
                if (message.Length > 6)
                {
                    throw new Exception("Длина строки больше 6 символов");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }

        static void example3()
        {
            int x = 1;
            int y = 0;

            try
            {
                int result = x / y;
            }
            catch (Exception ex) when (y == 0)
            {
                Console.WriteLine("y не должен быть равен 0");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void example4()
        {
            Console.WriteLine("Введите число");
            int x = Int32.Parse(Console.ReadLine());    // исключение

            x *= x;
            Console.WriteLine("Квадрат числа: " + x);
            Console.Read();
        }

        static void example5()
        {
            Console.WriteLine("Введите число");
            int x;
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out x))       // встроенная проверка исключения
            {
                x *= x;
                Console.WriteLine("Квадрат числа: " + x);
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
            Console.Read();
        }
    }
}
