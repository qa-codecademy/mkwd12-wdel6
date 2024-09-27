using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staticing
{
    internal static class StateStatic
    {
        private static string Title = "State Static";

        public static void Prepare(string title)
        {
            Title = title;
        }

        public static void Run()
        {
            Console.WriteLine(Title);
        }
    }
}
