using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staticing
{
    internal class ItemUser
    {
        public void UseItem(Item item)
        {
            Console.WriteLine($"Item: {item.Id}, {item.Name}, {item.Time}");
        }
    }
}
