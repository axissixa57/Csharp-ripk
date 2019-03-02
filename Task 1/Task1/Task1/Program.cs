using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите любую строку: ");
            string str = Console.ReadLine();
            string str1 = "Я буду усердно делать все задания по C# и заниматься дома";
            //int cmpr = String.Compare(str, str1);
            if (str == str1)
            {
                Console.WriteLine("За это ты получишь печеньку");
            }
        }
    }
}
