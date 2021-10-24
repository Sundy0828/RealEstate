using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices
{
    public interface IExternalApiFactory
    {
        public IApi GetExternalAPIHandler(ExternalApiTypeEnum apiType);
        public List<IApi> GetAllExternalAPIHandlers();
    }
}
