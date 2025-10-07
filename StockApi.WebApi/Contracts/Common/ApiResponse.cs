using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApi.WebApi.Contracts.Common
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public T Result { get; set; }

        public ApiResponse(int code, T result)
        {
            Code = code;
            Result = result;
        }
    }
}