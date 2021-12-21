using AuthManager.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AuthManager.Utilities.AuthorizeMessage
{


    public class ResponseFormatterMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseFormatterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            if (context.Response.StatusCode == StatusCodes.Status403Forbidden || context.Response.StatusCode==StatusCodes.Status401Unauthorized)
            {
                await context.Response.WriteAsync(
                    JsonConvert.SerializeObject(new Result<object>(false,Message.UnAuthorized)));
            }
        }
        public class Result<T> 
        {
            public string Message { get; }
            public T Data { get; }
            public bool Success { get; }
            public Result(T data, bool success, string message)
            {
                Data = data;
                Success = success;
                Message = message;
            }
         
            public Result(bool success, string message)
            {
                Success = success;
                Message = message;
            }


        }
    }

 
}
    

