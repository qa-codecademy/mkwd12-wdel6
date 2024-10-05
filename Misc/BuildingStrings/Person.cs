using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingStrings
{
    internal class LocalPerson
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({Age})";
        }
    }
}
