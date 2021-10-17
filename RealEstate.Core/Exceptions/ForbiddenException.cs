using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RealEstate.Core.Exceptions
{
    class ForbiddenException : REException
    {
        public override HttpStatusCode HttpCode => HttpStatusCode.Forbidden;

        public override string ErrorMessage => "The client does not have access rights to the content.";
        public ForbiddenException() : base(string.Empty)
        {

        }
        public ForbiddenException(string errorMessage) : base(errorMessage)
        {

        }
        public ForbiddenException(List<string> errorDetails) : base(errorDetails)
        {

        }
    }
}
