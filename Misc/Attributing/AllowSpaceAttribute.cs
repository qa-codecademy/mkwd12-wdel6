using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributing
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class AllowSpaceAttribute: Attribute
    {
        public bool IsAllowed { get; init; } = true;

        public AllowSpaceAttribute(bool isAllowed = true) {
            IsAllowed = isAllowed;
            Console.WriteLine("Created an allow space attribute instance");
        }
    }
}
