using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RealEstate.Core.Exceptions
{
    class NotFoundException : REException
    {
        public override HttpStatusCode HttpCode => HttpStatusCode.NotFound;

        public override string ErrorMessage => "The server can not find the requested resource.";
        public NotFoundException() : base(string.Empty)
        {

        }
        public NotFoundException(string errorMessage) : base(errorMessage)
        {

        }
        public NotFoundException(List<string> errorDetails) : base(errorDetails)
        {

        }
    }
}
