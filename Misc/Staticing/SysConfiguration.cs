using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staticing
{
    internal static class SysConfiguration
    {
        public static IDateProvider DateProvider { get; set; } = new DefaultDateProvider();
    }

}
