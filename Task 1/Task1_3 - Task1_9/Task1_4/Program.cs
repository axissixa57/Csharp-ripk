using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();

                Console.SetCursorPosition(random.Next(1, Console.WindowHeight), random.Next(1, Console.WindowWidth));

                Thread.Sleep(250);

                Console.WriteLine("C#");
            }
        }
    }
}
