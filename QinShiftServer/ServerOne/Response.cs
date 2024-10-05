using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerOne
{
    internal class Response
    {
        public StatusCode StatusCode { get; set; } = StatusCode.InternalServerError;

        public string Body { get; set; } = string.Empty;

        public Headers Headers { get; set; } = new Headers();

        public Response()
        {
        }

    }

}
