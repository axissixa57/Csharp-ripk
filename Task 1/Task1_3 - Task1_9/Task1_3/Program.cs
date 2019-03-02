using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("n = ");
            //int n = int.Parse(Console.ReadLine());
            Console.Write("n = ");
            int n;
            string input = Console.ReadLine();
            if (int.TryParse(input, out n)) 
            {
                Console.WriteLine("n содержит число");
            }
            else
            {
                Console.WriteLine("Нужно ввести число!");
            }

            double sum = 0;

            double factorial(double x)
            {
                return (x == 0 || x == 1) ? 1 : x * factorial(x - 1);
            }

            for (int i = 0; i < n; i++)
            {
                sum += 1 / factorial(i);
            }

            Console.WriteLine($"Сумма {n} - членов первого ряда = {sum}");

            //Console.Write("n = ");
            //n = int.Parse(Console.ReadLine());
            Console.Write("n = ");
            input = Console.ReadLine();
            if (int.TryParse(input, out n))
            {
                Console.WriteLine("n содержит число");
            }
            else
            {
                Console.WriteLine("Нужно ввести число!");
            }

            sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += (4 * Math.Pow(-1, i) / (2 * i + 1));
            }

            Console.WriteLine($"Сумма {n} - членов второго ряда = {sum}");
        }
    }
}
