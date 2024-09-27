using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staticing
{
    internal record struct Item(int Id, string Name, DateTime Time);

    internal class ItemGenerator
    {
        //public Item GenerateItem()
        //{
        //    return new Item(1, "Item1", DateTime.Now);
        //}

        public Item GenerateItem(IDateProvider dateProvider)
        {
            return new Item(1, "Item1", dateProvider.GetCurrentDateTime());
        }

    }
}
