using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RealEstate.Core.Exceptions
{
    class UnauthorizedException : REException
    {
        public override HttpStatusCode HttpCode => HttpStatusCode.Unauthorized;

        public override string ErrorMessage => "Network credentials are no longer valid.";
        public UnauthorizedException() : base(string.Empty)
        {

        }
        public UnauthorizedException(string errorMessage) : base(errorMessage)
        {

        }
        public UnauthorizedException(List<string> errorDetails) : base(errorDetails)
        {

        }
    }
}
