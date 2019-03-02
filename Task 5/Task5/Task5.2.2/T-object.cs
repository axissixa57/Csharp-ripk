using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5._2._2
{
    class Program
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
                Console.WriteLine("Модель: " + Model);
                Console.WriteLine("Длина, м: " + Length);
                Console.WriteLine("Высота, м: " + Height);
                Console.WriteLine("Вес, кг: " + Weight);
            }

            //public override string ToString()
            //{
            //    string str = $"\nМодель: {Model}\nДлина, м: {Length}\nВысота, м: {Height}\nВес, кг: {Weight}\n";
            //    return str;
            //}

            public override string ToString()
            {
                return $"\nМодель: {Model}";
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

        class Set<T>
        {
            private List<T> num = new List<T>();

            public int Count
            {
                get { return num.Count; }
            }

            public Set(T[] arr)
            {
                foreach (var i in arr)
                {
                    if (!num.Contains(i))
                        num.Add(i);
                }
            }

            public Set()
            {

            }

            public void Add(T x)
            {
                bool check = false;

                foreach (var i in num)
                {
                    if (Equals(x, i)) // if (x == i)
                        check = true;
                }

                if (check == false)
                    num.Add(x);
                else
                {
                    try
                    {
                        if (check == true)
                        {
                            throw new Exception($"The list must not contain duplicates!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            public void Remove(int x)
            {
                bool check = false;

                foreach (var i in num)
                {
                    if (Equals(i, x)) // if (i == x) 
                    {
                        check = true;
                        num.Remove(i);
                        break;
                    }
                }

                try
                {
                    if (check == false)
                    {
                        throw new Exception($"The element can't be deleted because it is not there!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            public void ShowElements()
            {
                foreach (var i in num)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }

            public static Set<T> Union(Set<T> set1, Set<T> set2)
            {
                Set<T> resultSet = new Set<T>();
                List<T> items = new List<T>();

                items.AddRange(set1.num); // добавляет диапозон данных в конец списка
                items.AddRange(set2.num);

                resultSet.num = items.Distinct().ToList(); // удаляет все дубликаты и преобразует к листу; без .ToList() не может неявно преобразовать System.Collections.Generic.IEnumerable<int> к System.Collections.Generic.List<int> 

                return resultSet;
            }

            public static void UnionV2(Set<T> set1, Set<T> set2)
            {
                var result = set1.num.Union(set2.num);
                foreach (var id in result)
                    Console.WriteLine(id);
            }

            public static Set<T> Intersection(Set<T> set1, Set<T> set2)
            {
                Set<T> resultSet = new Set<T>();

                if (set1.Count < set2.Count)
                {
                    foreach (var i in set1.num)
                    {
                        if (set2.num.Contains(i))
                            resultSet.Add(i);
                    }
                }
                else
                {
                    foreach (var i in set2.num)
                    {
                        if (set1.num.Contains(i))
                            resultSet.Add(i);
                    }
                }

                return resultSet;
            }

            public static void Intersect(Set<T> set1, Set<T> set2)
            {
                var result = set1.num.Intersect(set2.num);
                foreach (var id in result)
                    Console.WriteLine(id);
            }

            public static Set<T> Difference(Set<T> set1, Set<T> set2)
            {
                Set<T> resultSet = new Set<T>();

                foreach (var i in set1.num)
                {
                    if (!set2.num.Contains(i))
                        resultSet.Add(i);
                }

                return resultSet;
            }

            public static Set<T> SymetricDifference(Set<T> set1, Set<T> set2)
            {
                Set<T> resultSet = new Set<T>();

                foreach (var i in set1.num)
                {
                    if (!set2.num.Contains(i))
                        resultSet.Add(i);
                }

                foreach (var i in set2.num)
                {
                    if (!set1.num.Contains(i))
                        resultSet.Add(i);
                }

                return resultSet;
            }

            public static bool IsSubsetOf(Set<T> set1, Set<T> set2)
            {
                bool result = set1.num.All(s => set2.num.Contains(s)); // если хотябы одного не совпадает вернёт false
                return result;

                //bool check = false;
                //foreach (var i in set1.num)
                //{
                //    if (set2.num.Contains(i))
                //        check = true;
                //    else
                //        break;
                //}
                //return check;
            }

            public static Set<T> operator +(Set<T> set1, Set<T> set2)
            {
                Set<T> resultSet = new Set<T>();
                List<T> items = new List<T>();

                items.AddRange(set1.num);
                items.AddRange(set2.num);

                resultSet.num = items.Distinct().ToList();

                return resultSet;
            }

            public static Set<T> operator *(Set<T> set1, Set<T> set2)
            {
                Set<T> resultSet = new Set<T>();

                if (set1.Count < set2.Count)
                {
                    foreach (var i in set1.num)
                    {
                        if (set2.num.Contains(i))
                            resultSet.Add(i);
                    }
                }
                else
                {
                    foreach (var i in set2.num)
                    {
                        if (set1.num.Contains(i))
                            resultSet.Add(i);
                    }
                }

                return resultSet;
            }

            public static Set<T> operator -(Set<T> set1, Set<T> set2)
            {
                Set<T> resultSet = new Set<T>();

                foreach (var i in set1.num)
                {
                    if (!set2.num.Contains(i))
                        resultSet.Add(i);
                }

                return resultSet;
            }

            public static Set<T> operator %(Set<T> set1, Set<T> set2)
            {
                Set<T> resultSet = new Set<T>();

                foreach (var i in set1.num)
                {
                    if (!set2.num.Contains(i))
                        resultSet.Add(i);
                }

                foreach (var i in set2.num)
                {
                    if (!set1.num.Contains(i))
                        resultSet.Add(i);
                }

                return resultSet;
            }

            public static bool operator >(Set<T> set1, Set<T> set2)
            {
                bool result = set1.num.All(s => set2.num.Contains(s));
                return result;
            }

            public static bool operator <(Set<T> set1, Set<T> set2)
            {
                bool result = set1.num.All(s => set2.num.Contains(s));
                return result;
            }
        }

        static void Main(string[] args)
        {
            //Set<Helicopter> s1 = new Set<Helicopter>(new Helicopter[] {new Helicopter("Apache", 10, 7, 5000), new Helicopter("Tiger", 9, 6 , 4500), new Helicopter("Sikorsky", 11, 8, 6100)});
            //Set<Helicopter> s2 = new Set<Helicopter>(new Helicopter[] { new Helicopter("Viper", 12, 5, 5500), new Helicopter("Apache", 10, 7, 5000), new Helicopter("Hawk", 7, 5, 4000) });

            var a = new Helicopter() { Model = "Apache" };
            var b = new Helicopter() { Model = "Tiger" };
            var c = new Helicopter() { Model = "Sikorsky" };
            var d = new Helicopter() { Model = "Viper" };
            var e = new Helicopter() { Model = "Hawk" };

            Set<Helicopter> s1 = new Set<Helicopter>(new Helicopter[] { a, b, c });
            Set<Helicopter> s2 = new Set<Helicopter>(new Helicopter[] { d, a, e });

            //List<Helicopter> helicopters = new List<Helicopter>() { new Helicopter() { Model = "Apache" } };
            //helicopters[0].CreateObject();
            //var x = Equals(s1.num[0],s2.num[1]);
            //Console.WriteLine(x);
            //var y = object.ReferenceEquals(s1.num[0], s2.num[1]);

            Console.WriteLine("Set 1: ");
            s1.ShowElements();
            Console.WriteLine("\nSet 2: ");
            s2.ShowElements();

            Console.WriteLine("\nUnion: ");
            //Set<Helicopter> s3 = Set<Helicopter>.Union(s1, s2);
            //Set<Helicopter>.UnionV2(s1, s2);
            Set<Helicopter> s3 = s1 + s2;
            s3.ShowElements();

            Console.WriteLine("\nIntersection: ");
            //Set<Helicopter> s4 = Set<Helicopter>.Intersection(s1, s2);
            //Set<Helicopter>.Intersect(s1, s2);
            Set<Helicopter> s4 = s1 * s2;
            s4.ShowElements();

            Console.WriteLine("\nDifference: ");
            //Set<Helicopter> s5 = Set<Helicopter>.Difference(s1, s2);
            Set<Helicopter> s5 = s1 - s2;
            s5.ShowElements();

            Console.WriteLine("\nSymetricDifference: ");
            //Set<Helicopter> s6 = Set<Helicopter>.SymetricDifference(s1, s2);
            Set<Helicopter> s6 = s1 % s2;
            s6.ShowElements();

            //Set<Helicopter> s7 = new Set<Helicopter>(new Helicopter[] { new Helicopter() { Model = "A" }, new Helicopter() { Model = "B" }, new Helicopter() { Model = "C" } });
            //Set<Helicopter> s8 = new Set<Helicopter>(new Helicopter[] { new Helicopter() { Model = "C" }, new Helicopter() { Model = "X" }, new Helicopter() { Model = "Z" } });
            //Set<Helicopter> s9 = new Set<Helicopter>(new Helicopter[] { new Helicopter() { Model = "B" }, new Helicopter() { Model = "C" }, new Helicopter() { Model = "G" }, new Helicopter() { Model = "Z" }, new Helicopter() { Model = "X" } });

            var f = new Helicopter() { Model = "A" };
            var g = new Helicopter() { Model = "B" };
            var h = new Helicopter() { Model = "C" };
            var i = new Helicopter() { Model = "X" };
            var j = new Helicopter() { Model = "Z" };
            var k = new Helicopter() { Model = "G" };

            Set<Helicopter> s7 = new Set<Helicopter>(new Helicopter[] { f, g, h });
            Set<Helicopter> s8 = new Set<Helicopter>(new Helicopter[] { h, i, j });
            Set<Helicopter> s9 = new Set<Helicopter>(new Helicopter[] { g, h, k, j, i }); 

            Console.WriteLine("\nSet 7: ");
            s7.ShowElements();
            Console.WriteLine("\nSet 8: ");
            s8.ShowElements();
            Console.WriteLine("\nSet 9: ");
            s9.ShowElements();

            Console.WriteLine($"\nIs Set 7 a subset of Set 9: ");
            //Console.WriteLine($"{Set<Helicopter>.IsSubsetOf(s7, s9)}");
            Console.WriteLine($"{s7 > s9}");

            Console.WriteLine("Is Set 8 a subset of Set 9: ");
            //Console.WriteLine($"{Set<Helicopter>.IsSubsetOf(s8, s9)}");
            Console.WriteLine($"{s8 < s9}");
        }
    }
}
