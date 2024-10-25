using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attributing
{
    internal class PersonBuilder : IDisposable
    {
        private Person person = new Person();
        private bool disposedValue;

        private bool CanHaveSpaces(string propertyName)
        {
            //should spaces be allowed?
            var property = typeof(Person).GetProperty(propertyName);
            var attribute = property?.GetCustomAttribute<AllowSpaceAttribute>();
            if (attribute == null)
            {
                return true;
            }
            return attribute.IsAllowed;
        }

            public PersonBuilder WithFirstName(string firstName)
        {
            ObjectDisposedException.ThrowIf(disposedValue, nameof(PersonBuilder));

            if (!CanHaveSpaces(nameof(Person.FirstName)))
            {
                if (firstName.Contains(' '))
                {
                    throw new ArgumentException("First name cannot contain spaces");
                }
            }
            person.FirstName = firstName;
            return this;
        }

        public PersonBuilder WithLastName(string lastName)
        {
            ObjectDisposedException.ThrowIf(disposedValue, nameof(PersonBuilder));
            if (!CanHaveSpaces(nameof(Person.LastName)))
            {
                if (lastName.Contains(' '))
                {
                    throw new ArgumentException("Last name cannot contain spaces");
                }
            }
            person.LastName = lastName;
            return this;
        }

        public PersonBuilder WithMiddleName(string middleName)
        {
            ObjectDisposedException.ThrowIf(disposedValue, nameof(PersonBuilder));
            if (!CanHaveSpaces(nameof(Person.MiddleName)))
            {
                if (middleName.Contains(' '))
                {
                    throw new ArgumentException("Middle name cannot contain spaces");
                }
            }
            person.MiddleName = middleName;
            return this;
        }

        public PersonBuilder WithAge(int age)
        {
            ObjectDisposedException.ThrowIf(disposedValue, nameof(PersonBuilder));
            person.Age = age;
            return this;
        }

        public Person Build()
        {
            ObjectDisposedException.ThrowIf(disposedValue, nameof(PersonBuilder));
            try
            {
                return person;
            }
            finally
            {
                Dispose();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
