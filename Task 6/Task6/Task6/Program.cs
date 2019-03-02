using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task6
{
    interface IFlyable
    {
        int Climb(int increment);
        int Down(int decrement);
    }

    interface IMovableRightAndLeft
    {
        void MoveLeft();
        void MoveRight();
    }

    interface IMovableTopAndBottom
    {
        void MoveUp();
        void MoveDown();
    }

    interface IDrawable
    {
        void Draw();
        void Clear();
    }

    interface ITransportable
    {
        int Transportation(int weight);
    }

    public delegate void Test();

    class Helicopter : IMovableRightAndLeft, IMovableTopAndBottom, IDrawable
    {
        public delegate void HelicopterStateHandler(string message);
        public event HelicopterStateHandler Climb;
        public event HelicopterStateHandler GoDown;
        public event HelicopterStateHandler Attention;

        private int length;
        private int height;
        private int weight;
        private int altitude;
        private int maxHieghtFly;
        private int x = 0;
        private int y = 0;
        private int previousX = 0;
        private int previousY = 0;
        private List<string> helicopterRows = new List<string>()
            {
                    "    ------- # -------",
                    "###     -******-     ",
                    "**********#    ***   ",
                    " #      *******      "
            };

        public string Model { get; set; }
        public int Length
        {
            get { return length; }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception($"Длина должна быть больше 0");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                length = value;
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception($"Высота должна быть больше 0");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                height = value;
            }
        }
        public int Weight
        {
            get { return weight; }
            set
            {
                try
                {
                    if (value < 999)
                    {
                        throw new Exception($"Недостаточный вес для боевого вертолёта. Вес должен быть больше 1000");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                weight = value;
            }
        }
        public int Altitude
        {
            get { return altitude; }
            set
            {
                //try
                //{
                //    if (value < -1)
                //    {
                //        throw new Exception($"Высота должна быть >= 0");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Ошибка: " + ex.Message);
                //}
                altitude = value;
            }
        }
        public int MaxHieghtFly
        {
            get { return maxHieghtFly; }
            set
            {
                try
                {
                    if (value < 999 && value > 11001)
                    {
                        throw new Exception($"Максимальная высота должна быть 1000 - 11000");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                maxHieghtFly = value;
            }
        }
        public int X
        {
            get { return x; }
            set
            {
                try
                {
                    if (value < -1)
                    {
                        throw new Exception($"x >= 0");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                x = value;
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                try
                {
                    if (value < -1)
                    {
                        throw new Exception($"y >= 0");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                y = value;
            }
        }
        public int PreviousX
        {
            get { return previousX; }
            set { previousX = value; }
        }
        public int PreviousY
        {
            get { return previousY; }
            set { previousY = value; }
        }
        public string Color { get; set; }
        public int Image
        {
            get { return helicopterRows.Count; }
        }
        public int Width
        {
            get { return helicopterRows[0].Length; }
        }

        public Helicopter(string model = "", int length = 0, int height = 0, int weight = 1000)
        {
            Model = model;
            Length = length;
            Height = height;
            Weight = weight;
            Altitude = 0;
            MaxHieghtFly = 12000;
        }

        public void CreateObject()
        {
            Console.WriteLine("Модель: " + Length);
            Console.WriteLine("Длина, м: " + Length);
            Console.WriteLine("Высота, м: " + Height);
            Console.WriteLine("Вес, кг: " + Length);
        }

        public virtual void Up(int increment)
        {
            Altitude += increment;

            if (Climb != null)
                Climb($"Вертолёт набрал высоту {Altitude} м!");

            if (Altitude + increment > MaxHieghtFly)
            {
                if (Climb != null)
                    Climb($"Слишком высоко! Немедленно опуститесь!");
            }
        }

        public virtual void Down(int increment)
        {
            Altitude -= increment;

            if (GoDown != null)
                GoDown($"Вертолёт опускается на высоту {Altitude} м!");

            if (Altitude <= 500 && Altitude > 0)
            {
                if (GoDown != null)
                    GoDown($"Осторожно! Вертолёт разобьётся!!");
            }
            else if(Altitude <= 0)
            {
                if (GoDown != null)
                    GoDown($"Вертолёт разбился!");
            }
        }

        public void SetPosition(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
            PreviousX = x;
            PreviousY = y;
        }

        public ConsoleColor RandomColor()
        {
            List<ConsoleColor> colors = new List<ConsoleColor>()
                {
                    ConsoleColor.Red,
                    ConsoleColor.Blue,
                    ConsoleColor.Cyan,
                    ConsoleColor.Green,
                    ConsoleColor.DarkGreen,
                    ConsoleColor.Magenta,
                    ConsoleColor.Yellow,
                    ConsoleColor.DarkYellow
                };

            int randomColorNumber = new Random().Next(0, colors.Count);

            ConsoleColor randomColor = colors[randomColorNumber];
            return randomColor;
        }

        public void MoveUp()
        {
            previousX = x;
            previousY = y;
            if (Y > 0)
            {
                Y--;

                while (Y < 1)
                {
                    if (Attention != null)
                    {
                        Console.SetCursorPosition(30, 23);
                        Attention("You are going to go over the upper limit of console!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                    break;
                }
            }
        }

        public void MoveDown()
        {
            previousX = x;
            previousY = y;
            if (Y + Image < Console.WindowHeight - 1)
            {
                Y++;
                while (Y == 41)
                {
                    if (Attention != null)
                    {
                        Console.SetCursorPosition(30, 23);
                        Attention("You are going to go over the lower limit of console!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                    break;
                }
            }
        }

        public void MoveLeft()
        {
            previousX = x;
            previousY = y;
            if (X > 0)
            {
                X--;
                while (X == 0)
                {

                    if (Attention != null)
                    {
                        Console.SetCursorPosition(30, 23);
                        Attention("You are going to go over the left limit of console!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                    break;
                }
            }
        }

        public void MoveRight()
        {
            previousX = x;
            previousY = y;
            if (X < Console.WindowWidth - 22)
            {
                X++;
                while (X == 98)
                {
                    if (Attention != null)
                    {
                        Console.SetCursorPosition(30, 23);
                        Attention("You are going to go over the right limit of console!");
                        Thread.Sleep(3000);
                        Console.Clear();
                    }
                    break;
                }
            }
        }

        public void Draw()
        {
            int helicopterPositionY = Y;
            foreach (var helicopterRow in helicopterRows)
            {
                Console.SetCursorPosition(X, helicopterPositionY);
                Console.WriteLine(helicopterRow);
                helicopterPositionY++;
            }
            Console.ResetColor();
        }

        public void PrintHelicopter() // перемещает в буфер рисунок предыдущей позиции (удаляет рисунок вертолёта) и рисует копию на новых координатах 
        {
            Console.MoveBufferArea(PreviousX, PreviousY, Width, Image, X, Y);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Shoot(Action shoot)
        {
            if (shoot != null)
                shoot();
            else
                Console.WriteLine($"Helicopter {Model}: Pew-paw-Pew-paw-Pew-paw!");
        }

        public void DoWork(Action<string> callback) // в параметре(аргументе) Dowork делегат, который принимает параметр типа строки(Action<string>) и не возвращает ничего
        {
            callback("Hello world");
        }

        public void Test()
        {
            DoWork((result) => Console.WriteLine(result));
        }

        public delegate ConsoleColor HelicopterColorHandler();

        public ConsoleColor DoColor()
        {
            HelicopterColorHandler test;
            test = RandomColor;
            return test();
        }

        public ConsoleColor DoColorV2(HelicopterColorHandler test)
        {
            return test();
        }
    }

    class Program
    {
        public static int consoleWindowWidth = 120;
        public static int consoleWindowHeight = 46;

        static void Main(string[] args)
        {
            Console.SetWindowSize(consoleWindowWidth, consoleWindowHeight);
            Console.SetBufferSize(consoleWindowWidth, consoleWindowHeight);
            Console.Title = $"Helicopter";
            Console.CursorVisible = false;

            Console.Write("Для управления используйте ←, →, ↑, ↓. Напишите - Старт, для запуска. ESC - выход: ");
            string str = Console.ReadLine();
            if (str == "Старт" || str == "старт")
            {
                Console.Clear();
                Helicopter mi6 = new Helicopter("МИ-6");
                mi6.SetPosition(15, 15);
                mi6.Attention += ShowMessage;

                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            mi6.MoveUp();
                            mi6.PrintHelicopter();
                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            mi6.MoveDown();
                            mi6.PrintHelicopter();
                        }
                        else if (keyInfo.Key == ConsoleKey.LeftArrow)
                        {
                            mi6.MoveLeft();
                            mi6.PrintHelicopter();
                        }
                        else if (keyInfo.Key == ConsoleKey.RightArrow)
                        {
                            mi6.MoveRight();
                            mi6.PrintHelicopter();
                        }
                        else if (keyInfo.Key == ConsoleKey.Escape)
                            break;
                    }

                    mi6.Draw();
                    Thread.Sleep(50);
                    var color = mi6.DoColorV2(() => { return mi6.RandomColor(); });
                    Console.ForegroundColor = color;
                }
            }

            Console.ResetColor();
            Console.Clear();

            Helicopter h = new Helicopter("Apache");

            h.Shoot(() => Console.WriteLine($"Helicopter {h.Model} is shooting!"));
            //h.Shoot(null);

            h.SetPosition(0, 2);
            h.Draw();
            Console.WriteLine();

            h.Climb += ShowMessage;
            h.GoDown += ShowMessage;

            h.Up(2000);
            h.Up(11000);

            h.Down(5000);
            h.Down(7700);
            h.Down(500);
        }

        public static void ShowMessage(string message) // метод для делегата (и события)
        {
            Console.WriteLine(message);
        }
    }
}
