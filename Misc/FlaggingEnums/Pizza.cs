using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaggingEnums
{
    internal class Pizza
    {
        public static Pizza MakePizza(List<bool> toppings)
        {
            return new Pizza();
        }

        //public static Pizza MakePizza(int toppings)
        //{
        //    return new Pizza();
        //}

        public static Pizza MakePizza(PizzaToppings toppings)
        {
            Console.WriteLine($"Making pizza with {toppings} toppings");
            return new Pizza();
        }
    }
}
