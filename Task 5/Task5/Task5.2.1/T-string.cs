using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5._2._1
{
    class Program
    {
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

            public static Set<T> Intersection(Set<T> set1, Set<T> set2)
            {
                Set<T> resultSet = new Set<T>();

                if (set1.Count < set2.Count)
                {
                    foreach (var i in set1.num)
                    {
                        if (set2.num.Contains(i)) // определяет находится ли элемент в списке
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
            Set<string> s1 = new Set<string>(new string[] { "Hello", "Hey", "Hi", "Sup", "Goodday", "Goodmorning" });
            Set<string> s2 = new Set<string>(new string[] { "Bye", "Hello", "Chao", "Hi", "Goodbye" });

            Console.WriteLine("Set 1: ");
            s1.ShowElements();
            Console.WriteLine("Set 2: ");
            s2.ShowElements();

            Console.WriteLine("Union: ");
            //Set<string> s3 = Set<string>.Union(s1, s2);
            Set<string> s3 = s1 + s2;
            s3.ShowElements();

            Console.WriteLine("Intersection: ");
            //Set<string> s4 = Set<string>.Intersection(s1, s2);
            //Set<string>.Intersect(s1, s2);
            Set<string> s4 = s1 * s2;
            s4.ShowElements();

            Console.WriteLine("Difference: ");
            //Set<string> s5 = Set<string>.Difference(s1, s2);
            Set<string> s5 = s1 - s2;
            s5.ShowElements();

            Console.WriteLine("SymetricDifference: ");
            //Set<string> s6 = Set<string>.SymetricDifference(s1, s2);
            Set<string> s6 = s1 % s2;
            s6.ShowElements();

            Set<string> s7 = new Set<string>(new string[] { "Hello", "Hey", "Hi" });
            Set<string> s8 = new Set<string>(new string[] { "Hi", "Sup", "Goodday" });
            Set<string> s9 = new Set<string>(new string[] { "Bye", "Sup", "Chao", "Hi", "Goodday", "Goodbye" });

            Console.WriteLine("\nSet 7: ");
            s7.ShowElements();
            Console.WriteLine("Set 8: ");
            s8.ShowElements();
            Console.WriteLine("Set 9: ");
            s9.ShowElements();

            Console.WriteLine($"Is Set 7 a subset of Set 9: ");
            //Console.WriteLine($"{Set<string>.IsSubsetOf(s7, s9)}");
            Console.WriteLine($"{s7 > s9}");

            Console.WriteLine("Is Set 8 a subset of Set 9: ");
            //Console.WriteLine($"{Set<string>.IsSubsetOf(s8, s9)}");
            Console.WriteLine($"{s8 < s9}");
        }
    }
}
