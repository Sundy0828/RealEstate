using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices
{
    public interface IApiFactory
    {
        public Api GetApi(ExternalApiTypeEnum apiType);
    }
}
