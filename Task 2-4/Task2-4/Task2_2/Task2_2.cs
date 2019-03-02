using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task2_2
{
    class Task2_2
    {
        public static int consoleWindowWidth = 120;
        public static int consoleWindowHeight = 46;

        static void RemoveScrollBars()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        class Helicopter
        {
            private string model; //Black hawk, Tiger, Sikorsky, Cobra, Viper, Boeing
            private int length;
            private int height;
            private int weight;
            private int engine_power;
            private int carrying_capacity;
            private string location;
            private const string kind = "Type: Military";
            private int startX;
            private int startY;
            private List<string> helicopterRows = new List<string>()
                {
                    "    ------- # -------",
                    "###     -******-     ",
                    "**********#    ***   ",
                    " #      *******      "
                };

            public string Model { get; set; }
            public int Length { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }

            public int Engine_power
            {
                get { return engine_power; }
                set
                {
                    if (value < 0)
                        throw new Exception("Engine power parameter must be greater than zero");
                    else
                        engine_power = value;
                }
            }

            public int Carrying_capacity
            {
                get { return carrying_capacity; }
                set
                {
                    if (value < 0)
                        throw new Exception("Capacity parameter must be greater than zero");
                    else
                        carrying_capacity = value;
                }
            }

            public string Location { get; set; }

            public string Kind
            {
                get { return kind; }
            }

            public int StartX
            {
                get { return startX; }
                set { startX = value; }
            }

            public int StartY
            {
                get { return startY; }
                set { startY = value; }
            }

            public int Image
            {
                get { return helicopterRows.Count; }
            }

            public Helicopter()
            {
                Model = "";
                Length = 0;
                Height = 0;
                Weight = 0;
                Engine_power = 0;
                Carrying_capacity = 0;
                Location = "";
            }

            public Helicopter(string name, int length, int height, int weight, int engine_power, int carrying_capacity, string location)
            {
                Model = name;
                Length = length;
                Height = height;
                Weight = weight;
                Engine_power = engine_power;
                Carrying_capacity = carrying_capacity;
                Location = location;
            }

            public Helicopter(Helicopter obj_helicopter)
            {
                Model = obj_helicopter.Model;
                Length = obj_helicopter.Length;
                Height = obj_helicopter.Height;
                Weight = obj_helicopter.Weight;
                Engine_power = obj_helicopter.Engine_power;
                Carrying_capacity = obj_helicopter.Carrying_capacity;
                Location = obj_helicopter.Location;
            }

            public void CreateHelicopter()
            {
                Console.WriteLine("Модель: " + Model);
                Console.WriteLine("Длина, м: " + Length);
                Console.WriteLine("Высота, м: " + Height);
                Console.WriteLine("Вес, кг: " + Weight);
                Console.WriteLine("Мощность двигателя, кВт: " + Engine_power);
                Console.WriteLine("Грузоподъёмность, т: " + Carrying_capacity);
            }

            public void Fly()
            {
                Console.WriteLine("The {0} is flying!", this.model);
                Random randGen = new Random();
                int rndNumber = randGen.Next(5);
                if (rndNumber == 3)
                {
                    this.Refuel();
                }
            }

            private void Refuel()
            {
                Console.WriteLine("The {0} needs to refuel!", this.model);
            }

            public void Point_A()
            {
                Console.WriteLine("The {0} is flying to the point of {1}.", this.model, this.location);
            }

            public void Point_A(string name)
            {
                Location = name;
                Console.WriteLine($"{Model} летит в направлении {Location}.");
            }

            public void SetPosition(int x, int y)
            {
                StartX = x;
                StartY = y;
            }

            public void Draw()
            {
                int helicopterPositionY = StartY;
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var helicopterRow in helicopterRows)
                {
                    Console.SetCursorPosition(StartX, helicopterPositionY);
                    Console.WriteLine(helicopterRow);
                    helicopterPositionY++;
                }
                Console.ResetColor();
            }

            public void MoveUp()
            {
                if (StartY > 0)
                {
                    StartY--;
                }
            }
            public void MoveDown()
            {
                if (StartY + Image - 1 < Console.WindowHeight - 1)
                {
                    StartY++;
                }
            }

            public void MoveLeft()
            {
                if (StartX > 0)
                {
                    StartX--;
                }
            }

            public void MoveRight()
            {
                if (StartX < Console.WindowWidth - 21)
                {
                    StartX++;
                }
            }

            ~Helicopter()  // Финализатор
            {
                Console.WriteLine($"{Model} достиг места назначения!");
            }

        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Добро пожаловать в симулятор управления военным вертолётом.");
            Console.ResetColor();
            Console.WriteLine("Задайте характеристики своему вертолёту.");

            Helicopter h = new Helicopter();

            Console.Write("Название вертолёта: ");
            h.Model = Console.ReadLine();
            Console.Write("Длина вертолёта, м = ");
            h.Length = int.Parse(Console.ReadLine());
            Console.Write("Высота вертолёта, м = ");
            h.Height = int.Parse(Console.ReadLine());
            Console.Write("Вес вертолёта, кг = ");
            h.Weight = int.Parse(Console.ReadLine());
            Console.Write("Мощность двигателя вертолёта, кВт = ");
            h.Engine_power = int.Parse(Console.ReadLine());
            Console.Write("Грузоподъемность вертолёта, т = ");
            h.Carrying_capacity = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.Write("Ваш вертолёт создан!\n");
            h.CreateHelicopter();

            Console.Write("\nНапишите желаемое место, куда бы хотели полететь: ");
            string name = Console.ReadLine();
            h.Point_A(name);

            Console.Write("\nХотите поуправлять вертолётом?(Да/Нет): ");
            string answer = Console.ReadLine();
            if (answer == "Да" || answer == "да")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nДля управления используйте стрелочки вверх, вниз, вправо, влево." +
                "\nДля выхода нажимите Esc." +
                "\nЧтобы начать напишите Start: ");
                Console.ResetColor();

                string start = Console.ReadLine();

                if (start == "Start" || start == "start")
                {
                    Console.SetWindowSize(consoleWindowWidth, consoleWindowHeight);
                    RemoveScrollBars();
                    Console.CursorVisible = false;

                    h.SetPosition(5, 2);

                    while (true)
                    {
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                            if (keyInfo.Key == ConsoleKey.UpArrow)
                            {
                                h.MoveUp();
                            }
                            if (keyInfo.Key == ConsoleKey.DownArrow)
                            {
                                h.MoveDown();
                            }
                            if (keyInfo.Key == ConsoleKey.LeftArrow)
                            {
                                h.MoveLeft();
                            }
                            if (keyInfo.Key == ConsoleKey.RightArrow)
                            {
                                h.MoveRight();
                            }
                            if (keyInfo.Key == ConsoleKey.Escape)
                                break;
                        }

                        h.Draw();
                        Thread.Sleep(150);
                        Console.Clear();
                    }

                    Console.Clear();
                }
            }

            //Helicopter helicop = new Helicopter();
            //Helicopter helicop1 = new Helicopter();
            //Helicopter helicop2 = new Helicopter("Cobra", 18, 5, 6838, 1468, 10000);
            //Helicopter helicop3 = new Helicopter();
            //Helicopter helicop4 = new Helicopter(helicop3);
            //helicop.Model = "Apache";
            //helicop1.Model = "Viper";
            //helicop2.CreateHelicopter();
            //Console.WriteLine(helicop2.Kind);
            //Console.WriteLine();
            //helicop.Fly();
            //helicop1.Fly();
            //helicop.Point_A();
            ////helicop.Point_A("Belarus");
            //helicop1.Land();
            ////Helicopter.Fly_on_Console("Sikorsky is flying!");
            //Console.WriteLine();
            //helicop = new Helicopter();
            ////Console.WriteLine(helicop4.length);
            //helicop = helicop4;
            ////Console.WriteLine(helicop.Location);
        }
    }
}