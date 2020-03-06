using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AE.Domain.Abstract
{
    public class Response<T>
    {
        public bool Success { get; }
        public string Message { get; }
        public T Data { get; private set; }
        public Exception Exception { get; private set; }
        public Response(Exception exception, string message = null, bool success = false)
        {
            Success = success;
            Message = message;
            Exception = exception;
        }

        public Response(T data, string message = null, bool success = true)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
