using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTwo.Interface
{
    public abstract class BaseResponse
    {
        public StatusCode StatusCode { get; init; } = StatusCode.InternalServerError;
        public Headers Headers { get; init; } = new Headers();

        public abstract byte[] GetBodyBytes();

    }

    public abstract class Response<T>: BaseResponse
    {

        public T Body { get; init; } = default;

    }

    public class Response : Response<string>
    {
        public Response()
        {
        }

        public override byte[] GetBodyBytes()
        {
            return Encoding.UTF8.GetBytes(Body);
        }
    }

    public class BinaryResponse : Response<byte[]>
    {
        public BinaryResponse()
        {
        }

        public override byte[] GetBodyBytes()
        {
            return Body;
        }
    }

    public class InvalidResponse : Response
    {
        public InvalidResponse()
        {
            StatusCode = StatusCode.InternalServerError;
        }

        public InvalidResponse(string message)
        {
            StatusCode = StatusCode.InternalServerError;
            Body = message;
        }

        public static InvalidResponse InvalidRequest(string message)
        {
            return new InvalidResponse(message) { StatusCode = StatusCode.BadRequest };
        }
    }

}
