using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // FileStream
using System.Xml.Serialization;

namespace TEST
{
    public class TEST
    {
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
                Model = "Apache";
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

            //~Helicopter()  // Финализатор
            //{
            //    Console.WriteLine($"{Model} достиг места назначения!");
            //}

        }

        // класс и его члены объявлены как public
        [Serializable]
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            // стандартный конструктор без параметров
            public Person()
            {

            }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public void Info()
            {
                Console.WriteLine($"Имя: {Name}. Возраст: {Age}");
            }
        }

        static void Main(string[] args)
        {
            Person p = new Person("Tom", 29);
            Person p1 = new Person("Bill", 25);
            Person p2 = new Person("Jake", 25);

            List<Person> list = new List<Person> { };

            list.Add(p);
            list.Add(p1);
            list.Add(p2);

            foreach(var i in list)
            {
                Console.WriteLine($"{i.Name} {i.Age}");
            }

            list.Remove(p);
            list.Remove(p1);
            list.Remove(p2);

            Person p3 = new Person("Ron", 29);
            Person p4 = new Person("Mitch", 25);
            Person p5 = new Person("Alex", 25);

            list.Add(p3);
            list.Add(p4);
            list.Add(p5);

            foreach (var i in list)
            {
                Console.WriteLine($"{i.Name} {i.Age}");
            }

            foreach (var i in list)
            {
                i.Info();
            }

            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
            using (FileStream fs = new FileStream("Z:\\816\\Аксёнов Е.Г\\persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);
            }

            using (FileStream fs = new FileStream("Z:\\816\\Аксёнов Е.Г\\persons.xml", FileMode.OpenOrCreate))
            {

            }

            //Person person = new Person("Bill", 25);
            //XmlSerializer formatter = new XmlSerializer(typeof(Person));
            //using (FileStream fs = new FileStream("Z:\\816\\Аксёнов Е.Г\\persons.xml", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, person);
            //}
            //using (FileStream fs = new FileStream("Z:\\816\\Аксёнов Е.Г\\persons.xml", FileMode.OpenOrCreate))
            //{
            //    Person newPerson = (Person)formatter.Deserialize(fs);
            //    Console.WriteLine("Имя: {0} --- Возраст: {1}", newPerson.Name, newPerson.Age);
            //}

            //// объект для сериализации
            //Helicopter h = new Helicopter();
            //// для бинарной сериализации применяется класс BinaryFormatter
            //BinaryFormatter formatter = new BinaryFormatter();
            //// получаем поток, куда будем записывать сериализованный объект
            //using (FileStream fs = new FileStream("helicopter.dat", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, h);
            //    Console.WriteLine("Объект сериализован");
            //}
            //// десериализация из файла helicopter.dat
            //using (FileStream fs = new FileStream("helicopter.dat", FileMode.OpenOrCreate))
            //{
            //    Helicopter newHelicopter = (Helicopter)formatter.Deserialize(fs);

            //    Console.WriteLine("Объект десериализован");
            //    Console.WriteLine("Модель: {0}", newHelicopter.Model);
            //}
        }
    }
}
