using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recording
{
    internal record PersonRecord(string FirstName, string LastName, int Age);
    //{
    //    public string FullName => $"{FirstName} {LastName}";
    //}

    internal record struct PersonRecordStruct(string FirstName, string LastName, int Age);
    

    public class PersonClass(string firstName, string lastName, int age)
    {
        public string FirstName { get; init; } = firstName;
        public string LastName { get; init; } = lastName;
        public int Age { get; init; } = age;

        public string FullName => $"{FirstName} {LastName}";
    }

    public struct PersonStruct
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public readonly string FullName => $"{FirstName} {LastName}";

        public PersonStruct(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}