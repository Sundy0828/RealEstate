using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Models
{
    public class ExceptionResponse
    {
        public ExceptionResponse(bool success, int code, string message)
        {
            Success = success;
            Code = code;
            Message = message;
        }

        public bool Success { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
