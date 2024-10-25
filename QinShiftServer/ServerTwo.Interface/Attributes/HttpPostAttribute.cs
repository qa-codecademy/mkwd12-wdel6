using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTwo.Interface.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpPostAttribute(string? endpointName = null) : BaseMethodAttribute(endpointName)
    {
    }
}
