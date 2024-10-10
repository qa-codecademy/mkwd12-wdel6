using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptional
{

    internal class ExceptionalException : ApplicationException
    {
        public ExceptionalException(string message):base(message) { }
    }

    internal class LastNameException: ExceptionalException
    {
        public LastNameException() : base("Last name is invalid")
        {
        }
    }
}
