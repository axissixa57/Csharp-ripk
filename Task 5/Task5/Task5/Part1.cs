using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Part1
    {
        class Set
        {
            private List<int> num = new List<int>();

            public int Count
            {
                get { return num.Count; }
            }
                
            public Set(int[] arr)
            {
                foreach(var i in arr)
                {
                    if(!num.Contains(i))
                        num.Add(i);
                }
            }

            public Set()
            {

            }

            public void Add(int x)
            {
                bool check = false;

                foreach(var i in num)
                {
                     if (x == i)
                        check = true;
                }

                if(check == false)
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
                    if (i == x)
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
                foreach(var i in num)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }

            public static Set Union(Set set1, Set set2)
            {
                Set resultSet = new Set();
                List<int> items = new List<int>();

                items.AddRange(set1.num); // добавляет диапозон данных в конец списка
                items.AddRange(set2.num);

                resultSet.num = items.Distinct().ToList(); // удаляет все дубликаты и преобразует к листу; без .ToList() не может неявно преобразовать System.Collections.Generic.IEnumerable<int> к System.Collections.Generic.List<int> 

                return resultSet;
            }

            public static Set Intersection(Set set1, Set set2)
            {
                Set resultSet = new Set();

                if(set1.Count < set2.Count)
                {
                    foreach(var i in set1.num)
                    {
                        if (set2.num.Contains(i)) // определяет находится ли элемент в списке
                            resultSet.Add(i);
                    }
                }
                else
                {
                    foreach(var i in set2.num)
                    {
                        if (set1.num.Contains(i))
                            resultSet.Add(i);
                    }
                }

                return resultSet;
            }

            public static Set Difference(Set set1, Set set2)
            {
                Set resultSet = new Set();

                foreach(var i in set1.num)
                {
                    if(!set2.num.Contains(i))
                        resultSet.Add(i);
                }

                return resultSet;
            }

            public static Set SymetricDifference(Set set1, Set set2)
            {
                Set resultSet = new Set();

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

            public static bool IsSubsetOf(Set set1, Set set2)
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
        }

        static void Main(string[] args)
        {

            Set s1 = new Set(new int[] { 3, 3, 3, 4, 4, 7, 2, -3 });
            Set s2 = new Set(new int[] { 6, 3, 1, -3, 8, 13, 2 });

            Console.WriteLine("Set 1: ");
            s1.ShowElements();
            Console.WriteLine("Set 2: ");
            s2.ShowElements();

            Console.WriteLine("Union: ");
            Set s3 = Set.Union(s1, s2);
            s3.ShowElements();

            Console.WriteLine("Intersection: ");
            Set s4 = Set.Intersection(s1, s2);
            s4.ShowElements();

            Console.WriteLine("Difference: ");
            Set s5 = Set.Difference(s1, s2);
            s5.ShowElements();

            Console.WriteLine("SymetricDifference: ");
            Set s6 = Set.SymetricDifference(s1, s2);
            s6.ShowElements();

            Set s7 = new Set(new int[] { 1, 3, 6 });
            Set s8 = new Set(new int[] { 3, 5, 8, 4 });
            Set s9 = new Set(new int[] { 3, 4, 5, 6, 7, 8 });

            Console.WriteLine("\nSet 7: ");
            s7.ShowElements();
            Console.WriteLine("Set 8: ");
            s8.ShowElements();
            Console.WriteLine("Set 9: ");
            s9.ShowElements();

            Console.WriteLine($"Is Set 7 a subset of Set 9: ");
            Console.WriteLine($"{Set.IsSubsetOf(s7, s9)}");

            Console.WriteLine("Is Set 8 a subset of Set 9: ");
            Console.WriteLine($"{Set.IsSubsetOf(s8, s9)}");
        }
    }
}
