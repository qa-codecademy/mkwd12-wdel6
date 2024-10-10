using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTwo.Interface
{
    public class QinshiftServerException : ApplicationException
    {
        public QinshiftServerException(string? message) : base(message)
        {
        }
    }
}
