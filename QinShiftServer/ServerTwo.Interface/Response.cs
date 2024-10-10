using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTwo.Interface
{
    public class Response
    {
        public StatusCode StatusCode { get; init; } = StatusCode.InternalServerError;

        public string Body { get; init; } = string.Empty;

        public Headers Headers { get; init; } = new Headers();

        public Response()
        {
        }

    }

}
