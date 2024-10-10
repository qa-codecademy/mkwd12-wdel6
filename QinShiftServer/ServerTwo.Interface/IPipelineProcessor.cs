using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTwo.Interface
{
    public interface IPipelineProcessor
    {
        bool CanProcess(Request request);
        Response Process(Request request);
    }
}
