using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str1 = { "Камень", "Ножницы", "Бумага" };

            Console.WriteLine("Игра - «Камень-Ножницы-Бумага» (чтобы выйти из игры введите - выход). Введите ваш выбор: ");
            string str = " ";

            while(true)
            {
                Random random = new Random();
                int r = random.Next(3);

                str = Console.ReadLine();
                if (str == "Выход" || str == "выход")
                    break;

                if (str == "Камень")
                {
                    Console.WriteLine(str1[r]);
                    if (String.Compare(str, str1[r]) == 0)
                    {
                        Console.WriteLine("Ничья!"); // камень
                    }
                    else if (String.Compare(str, str1[r]) == -1) // ножницы
                    {
                        Console.WriteLine("Камень победил!");
                    }
                    else if (String.Compare(str, str1[r]) == 1) // бумага
                    {
                        Console.WriteLine("Бумага победила!");
                    }
                }
                else if (str == "Ножницы")
                {
                    Console.WriteLine(str1[r]);
                    if (String.Compare(str, str1[r]) == 0) // ножницы
                    {
                        Console.WriteLine("Ничья!");
                    }
                    else if (str1[r] == "Бумага") // бумага
                    {
                        Console.WriteLine("Ножницы победили!");
                    }
                    else if (str1[r] == "Камень") // камень
                    {
                        Console.WriteLine("Камень победил!");
                    }
                }
                else if (str == "Бумага")
                {
                    Console.WriteLine(str1[r]);
                    if (String.Compare(str, str1[r]) == 0)
                    {
                        Console.WriteLine("Ничья!");
                    }
                    else if (str1[r] == "Камень")
                    {
                        Console.WriteLine("Бумага победила!"); // камень
                    }
                    else if (str1[r] == "Ножницы")
                    {
                        Console.WriteLine("Ножницы победили!"); // ножницы
                    }
                }
                else
                {
                    Console.WriteLine("Введите только: или Камень, или Бумага, или Ножницы!");
                }
            }
        }
    }
}
