using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task4
{
    class Task4
    {
        public static int consoleWindowWidth = 120;
        public static int consoleWindowHeight = 46;

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

        class Helicopter : IFlyable, IMovableRightAndLeft, IMovableTopAndBottom, IDrawable
        {
            private int length;
            private int height;
            private int weight;
            private int altitude;
            private int maxHieghtFly;
            private int x;
            private int y;
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
            public string Color { get; set; }
            public int Image
            {
                get { return helicopterRows.Count; }
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

            public virtual int Climb(int increment)
            {
                if (Altitude + increment > MaxHieghtFly)
                {
                    throw new Exception($"Слишком высоко!");
                }

                Console.WriteLine("Вертолёт набирает высоту!");
                return Altitude += increment;
            }

            public virtual int Down(int increment)
            {
                if (Altitude - increment < 0)
                {
                    throw new Exception($"Осторожно! Вертолёт разобьётся!");
                }

                Console.WriteLine("Вертолёт опускается!");
                return Altitude -= increment;
            }

            public void SetPosition(int x = 0, int y = 0)
            {
                X = x;
                Y = y;
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

            public void Clear()
            {
                Console.Clear();
            }

        }

        class Bird : IDrawable, IMovableTopAndBottom, IMovableRightAndLeft
        {
            private int x;
            private int y;
            private List<string> birdRows = new List<string>()
            {
                "__________________________________________________",
                "___________________________111¶111________________",
                "____________11__________1¶¶¶¶¶¶¶¶¶¶¶¶1____________",
                "______¶¶111¶¶¶¶¶¶1_____¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶1_________",
                "______1¶¶¶¶¶¶¶¶¶¶¶¶1__¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶1_______",
                "_________1¶¶¶¶¶¶¶¶¶¶¶1¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶1_____",
                "___________¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶____",
                "____1¶¶¶¶¶11¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶1_____111¶¶¶¶¶__",
                "___¶¶¶¶¶¶¶¶¶¶¶¶____11¶¶¶¶¶¶¶¶¶¶¶1_____________¶¶¶_",
                "__¶¶¶¶¶¶¶¶¶¶¶¶1_______1¶¶¶¶¶¶¶1___________________ ",
                "__¶¶¶¶¶¶¶¶¶¶¶¶¶__________¶¶¶¶1____________________ ",
                "__¶¶¶¶¶¶¶¶¶¶¶¶¶1__________1¶¶¶____________________ ",
                "__¶¶¶¶¶¶¶¶¶¶¶¶¶¶1__________1¶¶¶___________________ ",
                "__1¶¶¶¶¶¶¶¶¶¶111¶¶__________¶¶¶¶__________________ ",
                "___¶¶¶¶¶¶¶¶______¶¶¶_________¶¶¶1_________________ ",
                "___1¶¶¶¶1__________¶¶¶1______1¶¶¶1________________ ",
                "____¶¶¶¶_____________1¶¶¶¶____¶¶¶¶1_______________ ",
                "_____¶¶1________________1¶¶¶¶¶¶¶¶¶¶¶______________ ",
                "_____1¶1____________________¶¶¶¶¶¶¶¶¶1____________ ",
                "______¶¶_______________________1¶¶11¶¶¶___________ ",
                "_______¶1________________________¶¶__¶¶¶__________ ",
                "__________________________________¶1___¶¶¶________ ",
                "__________________________________¶¶____1¶¶_______ ",
                "___________________________________¶¶_____________ ",
                "__________________________________________________ "
            };

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
            public int Image
            {
                get { return birdRows.Count; }
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

            public void SetPosition(int x = 0, int y = 5)
            {
                X = x;
                Y = y;
            }

            public void Draw()
            {
                int helicopterPositionY = Y;
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var helicopterRow in birdRows)
                {
                    Console.SetCursorPosition(X, helicopterPositionY);
                    Console.WriteLine(helicopterRow);
                    helicopterPositionY++;
                }
                Console.ResetColor();
            }

            public void Clear()
            {
                Console.Clear();
            }
        }

        class Train : ITransportable, IDrawable, IMovableRightAndLeft
        {
            private int x;
            private int y;
            private int carrying_capacity;
            private List<string> trainRows = new List<string>()
            {
                "_______________________________$$$$$       ",
                "$$$$$$$$$$$$$$________$$$______$$$$$       ",
                "_$$$$$$$$$$$$$_______$$$$$______$$$        ",
                "__$$____$___$$_______$$$$$______$$$__$$    ",
                "__$$____$___$$$$$$$$$$$$$$$$$$$$$$$$$$$$   ",
                "__$$$$$$$$$$$$_$$$$$_$$$$$$$$$_$$$$$$_$$$  ",
                "__$$$$$$$$$$$$_$$$$$__$$$$$$$$__$$$$$$_$$  ",
                "__$$$$$$$$$$$$_$$$$$$_$$$$$$$$$_$$$$$$_$   ",
                "___$$$$$$$$$$$_$$$$$__$$$$$$$$__$$$$$_$$   ",
                "___$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$  ",
                "_____$__$$$$$___$__$$$$$$___$$__$$$$__$$$$ ",
                "______$$$$$$_____$$$$$$$_____$$$$$         "
            };

            public int Carrying_capacity
            {
                get { return carrying_capacity; }
                set
                {
                    try
                    {
                        if (value < 49)
                        {
                            throw new Exception($"Грузоподъемность должна быть >= 50");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                    carrying_capacity = value;
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

            public Train(int carrying_capacity = 50)
            {
                Carrying_capacity = carrying_capacity;
            }

            public int Transportation(int weight)
            {
                if (weight > Carrying_capacity)
                {
                    throw new Exception($"Поезд не может перевозить такой вес!");
                }

                Console.WriteLine($"Поезд перевозит {weight} т.");
                return weight;
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

            public void SetPosition(int x = 0, int y = 15)
            {
                X = x;
                Y = y;
            }

            public void Draw()
            {
                int trainPositionY = Y;
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var helicopterRow in trainRows)
                {
                    Console.SetCursorPosition(X, trainPositionY);
                    Console.WriteLine(helicopterRow);
                    trainPositionY++;
                }
                Console.ResetColor();
            }

            public void Clear()
            {
                Console.Clear();
            }
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(consoleWindowWidth, consoleWindowHeight);
            Console.SetBufferSize(consoleWindowWidth, consoleWindowHeight);

            Helicopter mi6 = new Helicopter();
            Train train = new Train();
            Bird bird = new Bird();
            List<IDrawable> listObjs = new List<IDrawable> { new Helicopter(), new Bird(), new Train() };

            string[] menu = new string[] { "1. Вертолёт", "2. Поезд", "3. Птица", "4. Метод, который принимает объект по интерфейсу" };
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
                                    mi6.SetPosition(0, 0);

                                    Console.Write("Для управления используйте ←, →, ↑, ↓. Напишите - Старт, для запуска: ");
                                    string str = Console.ReadLine();
                                    if (str == "Старт" || str == "старт")
                                    {
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
                                            Thread.Sleep(50);
                                            Console.Clear();
                                        }
                                    }
                                }
                                else if (row == 1)
                                {
                                    Console.Clear();
                                    Console.ResetColor();
                                    train.SetPosition(0, 0);
                                    train.Carrying_capacity = 200;

                                    Console.Write($"Для управления используйте ←, →. Введите желаемый вес для перевозки, но учтите что поезд может перевезти {train.Carrying_capacity} т. : ");
                                    int weight = int.Parse(Console.ReadLine());

                                    if (train.Transportation(weight) < train.Carrying_capacity)
                                    {
                                        train.Transportation(weight);
                                        while (true)
                                        {
                                            if (Console.KeyAvailable)
                                            {
                                                ConsoleKeyInfo keyInfo = Console.ReadKey();
                                                if (keyInfo.Key == ConsoleKey.LeftArrow)
                                                {
                                                    train.MoveLeft();
                                                }
                                                else if (keyInfo.Key == ConsoleKey.RightArrow)
                                                {
                                                    train.MoveRight();
                                                }
                                                else if (keyInfo.Key == ConsoleKey.Escape)
                                                    break;
                                            }

                                            train.Draw();
                                            Thread.Sleep(50);
                                            Console.Clear();
                                        }
                                    }
                                }
                                else if (row == 2)
                                {
                                    Console.Clear();
                                    Console.ResetColor();
                                    bird.SetPosition(0, 0);

                                    Console.Write("Для управления используйте ←, →, ↑, ↓. Напишите - Старт, для запуска: ");
                                    string str = Console.ReadLine();
                                    if (str == "Старт" || str == "старт")
                                    {
                                        while (true)
                                        {
                                            if (Console.KeyAvailable)
                                            {
                                                ConsoleKeyInfo keyInfo = Console.ReadKey();
                                                if (keyInfo.Key == ConsoleKey.UpArrow)
                                                {
                                                    bird.MoveUp();
                                                }
                                                else if (keyInfo.Key == ConsoleKey.DownArrow)
                                                {
                                                    bird.MoveDown();
                                                }
                                                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                                                {
                                                    bird.MoveLeft();
                                                }
                                                else if (keyInfo.Key == ConsoleKey.RightArrow)
                                                {
                                                    bird.MoveRight();
                                                }
                                                else if (keyInfo.Key == ConsoleKey.Escape)
                                                    break;
                                            }
                                            bird.Draw();
                                            Thread.Sleep(50);
                                            Console.Clear();
                                        }
                                    }
                                }
                                else if (row == 3)
                                {
                                    Console.Clear();
                                    for (int i = 0; i < listObjs.Count; i++)
                                    {
                                        Test(listObjs[i]);
                                    }
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
                                    else if (row == 3)
                                    {
                                        row--;
                                        MarkedThird(menu);
                                    }
                                    else
                                    {
                                        row--;
                                        MarkedFourth(menu);
                                    }
                                }
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            {
                                if (row == 0 || row == 1 || row == 2 || row == 3)
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
                                    else if (row == 2)
                                    {
                                        row++;
                                        MarkedFourth(menu);
                                    }
                                    else
                                    {
                                        row++;
                                        //MarkedFifth(menu);
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
        }

        static void Test(IDrawable obj)
        {
            obj.Draw();
            Thread.Sleep(1000);
            obj.Clear();
        }
    }
}



