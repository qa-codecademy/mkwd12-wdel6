using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    internal class PersonClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }


    internal struct PersonStruct
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
