using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerationg
{
    internal static class Numerics
    {
        public static int Counter;
        public static IEnumerable<int> Evens(int start, int stop)
        {
            Counter = 0;
            List<int> list = new List<int>();
            for (int index = start; index < stop; index++)
            {
                Counter++;
                if (index % 2 == 0)
                {
                    list.Add(index);
                }
            }
            return list;
        }

        public static IEnumerable<int> YieldEvens(int start, int stop)
        {
            Console.WriteLine("Starting yield evens");
            Counter = 0;
            for (int index = start; index < stop; index++)
            {
                Console.WriteLine("Incrementing counter");
                Counter++;
                if (index % 2 == 0)
                {
                    Console.WriteLine("Yielding");
                    yield return index;
                    yield return index;
                }
            }
        }

        public static IEnumerable<int> YieldEvens2(int start, int stop)
        {
            Console.WriteLine("Starting yield evens");
            Counter = 0;
            int index = start;
            while (true)
            {
                Console.WriteLine("Incrementing counter");
                Counter++;
                if (index % 2 == 0)
                {
                    Console.WriteLine("Yielding");
                    yield return index;
                    yield return index;
                }
                index += 1;
                if (index >= stop)
                {
                    yield break;
                }
            }
        }

    }
}
