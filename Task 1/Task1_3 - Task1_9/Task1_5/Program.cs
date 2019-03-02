using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int correct = 0;
            int wrong = 0;
            var keys = Enum.GetValues(typeof(ConsoleKey));  // Console: System.ConsoleKey[], typeof(DayOfWeek) - System.DayOfWeek[], ...   
            Random random = new Random();

            while (true)
            {
                var key = keys.GetValue(random.Next(keys.Length)); // random elemet of array ConsoleKey[], Conosole: K, End, PageDown, Q, F5, ...

                int intKey = (int)key;


                if (intKey < 49 || intKey > 123 || intKey > 90 && intKey < 96)
                    continue; // если не равно условию, то переходим на следующую итерацию цикла

                Console.WriteLine($"Нажмите клавишу: {key}");
                ConsoleKeyInfo pressedKey = Console.ReadKey(true); // например, если нажата клавиша а, ReadKey(true) - считывает нажатую кнопку. Console: System.ConsoleKeyInfo, ReadKey(false) - Console: aSystem.ConsoleKeyInfo

                if (pressedKey.Key == (ConsoleKey)key)
                {
                    correct++;
                    if (correct == 20)
                    {
                        Console.WriteLine("20 из 20. Господи, 20 из 20! Молодец!");
                        break;
                    }
                }
                else
                {
                    correct = 0;
                    wrong++;
                    if (wrong == 3)
                    {
                        Console.WriteLine("3 ошибки! Плохо!");
                        break;
                    }
                }
            }
        }
    }
}
