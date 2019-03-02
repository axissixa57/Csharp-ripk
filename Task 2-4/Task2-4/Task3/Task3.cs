using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task3
{
    class Task3
    {
        public static int consoleWindowWidth = 120;
        public static int consoleWindowHeight = 46;

        abstract class FlyingObject
        {
            private int length;
            private int height;

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

            public FlyingObject(int length, int height)
            {
                Length = length;
                Height = height;
            }

            public abstract void CreateObject();
        }

        class Helicopter : FlyingObject
        {
            private int altitude;
            private int maxHieghtFly;

            public int Altitude
            {
                get { return altitude; }
                set
                {
                    try
                    {
                        if (value < -1)
                        {
                            throw new Exception($"Высота должна быть >= 0");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
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

            public Helicopter(int length = 0, int height = 0) : base(length, height)
            {
                Altitude = 0;
                MaxHieghtFly = 11000;
            }

            public override void CreateObject()
            {
                Console.WriteLine("Длина, м: " + Length);
                Console.WriteLine("Высота, м: " + Height);
            }

            public virtual int Climb(int increment)
            {
                if (Altitude + increment > MaxHieghtFly)
                {
                    throw new Exception($"Слишком высоко!");
                }

                Console.WriteLine($"Вертолёт набирает высоту = {Altitude}");
                return Altitude += increment;
            }

            public virtual int Down(int decrement)
            {
                if (Altitude - decrement < 0)
                {
                    throw new Exception($"Осторожно! Вертолёт может разбиться.");
                }

                Console.WriteLine($"Вертолёт опускается = {Altitude}");
                return Altitude -= decrement;
            }
        }

        class CombatHelicopter : Helicopter
        {
            private int weight;
            private int x;
            private int y;

            public string Model { get; }
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
            public string Color { get; set; }
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

            public CombatHelicopter(string model = "", int length = 0, int height = 0, int weight = 1000) : base(length, height)
            {
                Model = model;
                Weight = weight;
            }

            public override void CreateObject()
            {
                Console.WriteLine("Модель: " + Model);
                base.CreateObject();
                Console.WriteLine("Вес, кг: " + Weight);
            }

            public override int Climb(int increment)
            {
                if (Altitude + increment * 5 > MaxHieghtFly)
                {
                    throw new Exception($"Слишком высоко!");
                }

                Console.WriteLine($"Вертолёт набирает высоту = {Altitude}");
                return Altitude += increment;
            }

            public override int Down(int decrement)
            {
                if (Altitude - decrement * 5 < 0)
                {
                    throw new Exception($"Осторожно! Вертолёт может разбиться!");
                }

                Console.WriteLine($"Вертолёт опускается = {Altitude}");
                return Altitude -= decrement;
            }

            public virtual void SetPosition(int x, int y)
            {
                X = x;
                Y = y;
            }

            public virtual ConsoleColor RandomColor()
            {
                int randomColorNumber = new Random().Next(0, 15);

                ConsoleColor randomColor = (ConsoleColor)randomColorNumber;
                return randomColor;
            }
        }

        sealed class MI6 : CombatHelicopter
        {
            private List<string> helicopterRows = new List<string>()
            {
                    "    ------- # -------",
                    "###     -******-     ",
                    "**********#    ***   ",
                    " #      *******      "
            };

            public int Image
            {
                get { return helicopterRows.Count; }
            }

            public MI6(string model = "МИ-6", int length = 10, int height = 7, int weight = 7777) : base(model, length, height, weight)
            {

            }

            public override void CreateObject()
            {
                base.CreateObject();
            }

            public override void SetPosition(int x = 15, int y = 15)
            {
                base.SetPosition(x, y);
            }

            public override ConsoleColor RandomColor()
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
                if (Y > 0)
                {
                    Y--;
                }
            }

            public void MoveDown()
            {
                if (Y + Image - 1 < Console.WindowHeight - 1)
                {
                    Y++;
                }
            }

            public void MoveLeft()
            {
                if (X > 0)
                {
                    X--;
                }
            }

            public void MoveRight()
            {
                if (X < Console.WindowWidth - 21)
                {
                    X++;
                }
            }

            public void Draw()
            {
                int helicopterPositionY = Y;
                Console.ForegroundColor = RandomColor();
                foreach (var helicopterRow in helicopterRows)
                {
                    Console.SetCursorPosition(X, helicopterPositionY);
                    Console.WriteLine(helicopterRow);
                    helicopterPositionY++;
                }
                Console.ResetColor();
            }
        }

        class Airplane : FlyingObject
        {
            public string ProducingCountry { get; set; }
            public string Type { get; set; }
            public string Traveling { get; set; }

            public Airplane(int length, int height, string type, string producingCountry) : base(length, height)
            {
                ProducingCountry = producingCountry;
                Type = type;
            }

            public override void CreateObject()
            {
                Console.WriteLine("Страна производитель: " + ProducingCountry);
                Console.WriteLine("Тип самолёта: " + ProducingCountry);
                Console.WriteLine("Длина, м: " + Length);
                Console.WriteLine("Высота, м: " + Height);
            }

            public virtual void SetPlace(string name)
            {
                Traveling = name;
                Console.WriteLine($"Самолёт летит в направлении {Traveling}.");
            }
        }

        static void Main(string[] args)
        {
            MI6 mi6 = new MI6();

            Console.SetWindowSize(consoleWindowWidth, consoleWindowHeight);
            Console.SetBufferSize(consoleWindowWidth, consoleWindowHeight); // удаляет полосы прокрутки в консольном окне
            Console.Title = $"МИ-6"; // название консольного окна
            Console.CursorVisible = false;

            string[] menu = new string[] { "1. Характеристики вертолёта", "2. Полетать на консоли", "3. ...", "4. Exit" };
            bool choice = false;
            int row = 0;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(menu[0]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"\n{menu[1]}");
            Console.WriteLine($"\n{menu[2]}");
            Console.WriteLine($"\n{menu[3]}");

            while (!choice)
            {
                if (Console.KeyAvailable) // ожидание нажатия клавиши
                {
                    switch (Console.ReadKey().Key) // получаем нажатую клавишу и сравнивает с case вариантами
                    {
                        case ConsoleKey.Enter:
                            {
                                choice = true;
                                if (row == 0)
                                {
                                    Console.Clear();
                                    Console.ResetColor();
                                    Console.CursorVisible = false;
                                    mi6.CreateObject();
                                    Console.WriteLine();
                                }
                                else if (row == 1)
                                {
                                    Console.Clear();
                                    mi6.SetPosition(5, 2);

                                    while (true)
                                    {
                                        if (Console.KeyAvailable)
                                        {
                                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                                            if (keyInfo.Key == ConsoleKey.UpArrow)
                                            {
                                                mi6.MoveUp();
                                            }
                                            else if (keyInfo.Key == ConsoleKey.DownArrow)
                                            {
                                                mi6.MoveDown();
                                            }
                                            else if (keyInfo.Key == ConsoleKey.LeftArrow)
                                            {
                                                mi6.MoveLeft();
                                            }
                                            else if (keyInfo.Key == ConsoleKey.RightArrow)
                                            {
                                                mi6.MoveRight();
                                            }
                                            else if (keyInfo.Key == ConsoleKey.Escape)
                                                break;
                                        }

                                        mi6.Draw();
                                        Thread.Sleep(50); // скорость вертолёта
                                        Console.Clear();
                                    }
                                }
                                else if (row == 2)
                                {

                                }
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            {
                                if (row == 1 || row == 2 || row == 3)
                                {
                                    if (row == 1)
                                    {
                                        row--;
                                        MarkedFirst(menu);
                                    }
                                    else if (row == 2)
                                    {
                                        row--;
                                        MarkedSecound(menu);
                                    }
                                    else
                                    {
                                        row--;
                                        MarkedThird(menu);
                                    }
                                }
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            {
                                if (row == 0 || row == 1 || row == 2)
                                {
                                    if (row == 0)
                                    {
                                        row++;
                                        MarkedSecound(menu); // т.к. choice = false после вып-я ф-ции снова зайдёт в цикл
                                    }
                                    else if (row == 1)
                                    {
                                        row++;
                                        MarkedThird(menu);
                                    }
                                    else
                                    {
                                        row++;
                                        MarkedFourth(menu);
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            void MarkedFirst(string[] listMenu)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 7); // благодаря (0, Console.CursorTop - 7) устанавливает курсор в левый вверхний угол и рисует поверх прошлого текста
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine(menu[0]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"\n{menu[1]}");
                Console.WriteLine($"\n{menu[2]}");
                Console.WriteLine($"\n{menu[3]}");
            }

            void MarkedSecound(string[] listMenu)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 7);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(menu[0]);
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine($"\n{menu[1]}");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"\n{menu[2]}");
                Console.WriteLine($"\n{menu[3]}");
            }

            void MarkedThird(string[] listMenu)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 7);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(menu[0]);
                Console.WriteLine($"\n{menu[1]}");
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine($"\n{menu[2]}");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"\n{menu[3]}");
            }

            void MarkedFourth(string[] listMenu)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 7);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(menu[0]);
                Console.WriteLine($"\n{menu[1]}");
                Console.WriteLine($"\n{menu[2]}");
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine($"\n{menu[3]}");
                Console.BackgroundColor = ConsoleColor.Black;
            }

            //CombatHelicopter ch = new CombatHelicopter("Апачи", 10, 7, 6000);
            //ch.SetColor(true);

            //MI6 mi6 = new MI6("МИ-6", 10, 7, 5555);
            //mi6.SetColor(false);

            //Helicopter h = new Helicopter(10, 5);
            //for (int k = 0; k < h.Max_Hieght_Fly; k++)
            //{
            //    int a = h.Climb(k);
            //    if (a > 5000)
            //        break;
            //}

            //for (int k = 0; k < h.Max_Hieght_Fly; k++)
            //{
            //    //h.Altitude = 5000;
            //    int a = h.Down(k);
            //}
        }
    }
}
