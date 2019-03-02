//Сериализация
//Напишите программу с применением механизма сериализации для
//вашего класса из второго задания.Программа должна хранить список
//объектов вашего класса(изначально пустой). Пользователь должен иметь
//возможность: 
//а.создавать новые объекты класса(вводя параметры для конструктора);
//б.удалять существующие объекты; 
//в.Выводить информацию обо всех объектах в списке.
//г.Выполнять сериализацию(сохранение объектов в файл). 
//При запуске программы должна происходить десериализация, т.е.
//считывание объектов из файла, и добавление их в список внутри программы.
//Таким образом, при перезапуске программы в списке сразу должны быть
//сохранённые объекты от предыдущего сеанса работы. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Serializable
{
    public class Serializable
    {
        //[Serializable]
        [DataContract]
        public class Person
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public int Age { get; set; }

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
                Console.WriteLine($"Имя: {Name} --- Возраст: {Age}");
            }
        }

        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            //XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Person>));

            Menu();

            string name = " ";
            int age = 0;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.D1)
                    {
                        Console.Clear();

                        Console.WriteLine("Введите имя и возраст студента.\n");

                        Console.Write("Введите имя: ");
                        name = Console.ReadLine();

                        Console.Write("Введите возраст: ");
                        age = int.Parse(Console.ReadLine());

                        Console.Clear();

                        Console.WriteLine($"Студент создан!\n"); // Имя: {name}, Возраст: {age}

                        Menu();
                    }
                    else if (keyInfo.Key == ConsoleKey.D2)
                    {
                        Console.Clear();

                        list.Add(new Person(name, age));

                        Console.Clear();

                        Console.WriteLine($"Студент добавлен!\n");

                        Menu();
                    }
                    else if (keyInfo.Key == ConsoleKey.D3)
                    {
                        Console.Clear();

                        if(list.Count == 0)
                        {
                            Console.WriteLine($"Нет записей.");
                        }

                        foreach (var student in list)
                        {
                            student.Info();
                        }

                        Console.Write("Желаете выйти в меню? (Да/ Нет) ");
                        string str = Console.ReadLine();
                        if (str == "Да")
                        {
                            Console.Clear();
                            Menu();
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.D4)
                    {
                        Console.Clear();

                        Console.WriteLine("Введите имя и возраст студента.");

                        Console.Write("Введите имя: ");
                        string n = Console.ReadLine();

                        Console.WriteLine();

                        Console.Write("Введите возраст: ");
                        int a = int.Parse(Console.ReadLine());

                        Console.WriteLine();

                        for (int i = 0; i < list.Count; i++) // удаляет по имени
                        {
                            if(list[i].Name == n)
                            {
                                list.RemoveAt(i);
                            }
                        }

                        Console.Clear();

                        Console.WriteLine($"Студент удалён!");

                        Menu();
                    }
                    else if (keyInfo.Key == ConsoleKey.D5)
                    {
                        Console.Clear();

                        using (FileStream fs = new FileStream("A:\\C#\\Сериализация\\Serializable\\Serializable\\people.json", FileMode.OpenOrCreate))
                        {
                            //formatter.Serialize(fs, list);
                            jsonFormatter.WriteObject(fs, list);
                        }

                        Console.WriteLine($"Сериализация выполнена!");

                        Menu();
                    }
                    else if (keyInfo.Key == ConsoleKey.D6)
                    {
                        using (FileStream fs = new FileStream("A:\\C#\\Сериализация\\Serializable\\Serializable\\people.json", FileMode.OpenOrCreate))
                        {
                            //List<Person> newlist = (List<Person>)formatter.Deserialize(fs);
                            List<Person> newlist = (List<Person>)jsonFormatter.ReadObject(fs);

                            Console.Clear();

                            Console.WriteLine($"Данные десериализованы!");

                            foreach (var s in newlist)
                            {
                                //Console.WriteLine("Имя: {0}. Возраст: {1}", s.Name, s.Age);
                                s.Info();
                            }
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                        break;
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("База данных: Студенты\n");
            Console.WriteLine("1. Новый студент");
            Console.WriteLine("2. Добавить студента в базу");
            Console.WriteLine("3. Просмотреть студентов в базе");
            Console.WriteLine("4. Удалить студента из базы");
            Console.WriteLine("5. Cериализовать базу данных");
            Console.WriteLine("6. Десериализация данных из файла");
            Console.Write("\nВведите цифру пункта меню: ");
        }
    }
}
