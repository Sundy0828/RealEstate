using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.API.Models
{
    public class ExceptionDetailsResponse
    {
        public ExceptionDetailsResponse(bool success, int code, string message, List<string> details)
        {
            Success = success;
            Code = code;
            Message = message;
            Details = details;
        }

        public bool Success { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public List<string> Details { get; set; }
    }
}
