using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaggingEnums
{
    [Flags]
    internal enum PizzaToppings
    {
        None = 0,
        Pepperoni = 1,
        Sausage = 2,
        Mushrooms = 4,
        Onions = 8,
        Ham = 16,
        Pineapple = 32,
        Bacon = 64,
        BlackOlives = 128,
        GreenPeppers = 256,
        Spinach = 512,
        Anchovies = 1024,
        // Presets
        Capriciosa = Ham | Mushrooms,
        //Capriciosa = 20,
        Hawaii = Ham | Pineapple,
        MeatLovers = Ham | Pepperoni | Sausage | Bacon,
        Vegetarian = Mushrooms | Onions | GreenPeppers | BlackOlives,
    }
}
