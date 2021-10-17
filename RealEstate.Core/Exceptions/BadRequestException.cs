using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RealEstate.Core.Exceptions
{
    class BadRequestException : REException
    {
        public override HttpStatusCode HttpCode => HttpStatusCode.BadRequest;

        public override string ErrorMessage => "The server could not understand the request due to invalid syntax.";
        public BadRequestException() : base(string.Empty)
        {

        }
        public BadRequestException(string errorMessage) : base(errorMessage)
        {

        }
        public BadRequestException(List<string> errorDetails) : base(errorDetails)
        {

        }
    }
}
