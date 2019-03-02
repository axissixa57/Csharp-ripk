using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Helicopter
    {
        public delegate void Test();
        public delegate int Test1();

        public void Shoot(Test test)
        {
            //if (shoot != null)
            //    shoot();
            //else
            //    Console.WriteLine($"Helicopter: Pew-paw-Pew-paw-Pew-paw!");
            test();
        }

        public int Shoot1(Test1 test)
        {
            //if (shoot != null)
            //    shoot();
            //else
            //    Console.WriteLine($"Helicopter: Pew-paw-Pew-paw-Pew-paw!");
            return test();
        }
    }

    class Test
    {
        
        public static void Main(string[] args)
        {
            Helicopter h = new Helicopter();
            h.
            var a = h.Shoot1(() => { return 2 + 2; } );
            Console.WriteLine(a);
        }
    }
}
