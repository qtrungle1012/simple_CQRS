using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.WebApi.Contracts.Common
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }



        public ApiResponse(int code, string message, T result)
        {
            Code = code;
            Result = result;
            Message = message;
        }
        public ApiResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public ApiResponse(int code, T result)
        {
            Code = code;
            Result = result;
        }
    }
}