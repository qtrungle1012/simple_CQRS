using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.WebApi.Contracts.Common
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public ErrorResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}