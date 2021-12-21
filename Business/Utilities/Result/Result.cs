using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Result
{
    public class Result<T> : IResult<T>
    {
        public string Message { get;}
        public T Data { get; }
        public List<string> Errors { get; set; }
        public bool Success { get; }
        public Result(T data,bool success,string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }
        public Result(List<string> errors,bool success, string message)
        {
            Errors = errors;
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
