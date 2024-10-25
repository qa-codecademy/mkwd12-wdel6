using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributing
{
    internal class Person
    {
        [AllowSpace(false)]
        public string? FirstName { get; set; }

        [AllowSpace(true)]
        public string? MiddleName { get; set; }

        public string? LastName { get; set; }
        public int Age { get; set; }

        override public string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName} ({Age})";
        }


    }
}
