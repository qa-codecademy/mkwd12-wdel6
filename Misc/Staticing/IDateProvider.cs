using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Staticing
{
    internal interface IDateProvider
    {
        DateTime GetCurrentDateTime();
    }

    internal class DefaultDateProvider : IDateProvider
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }

    internal class MockDateProvider : IDateProvider
    {
        public DateTime GetCurrentDateTime()
        {
            return new DateTime(1900, 1, 1);
        }
    }

}
