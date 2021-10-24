using RealEstate.Core.ExternalServices.ATTOM;
using RealEstate.Core.ExternalServices.Zillow;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices
{
    public enum ExternalApiTypeEnum
    {
        NONE,
        ATTOM,
        ZILLOW
    }
    public class ExternalApiFactory : IExternalApiFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ExternalApiFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public List<IApi> GetAllExternalAPIHandlers()
        {
            List<IApi> apiHandlers = new List<IApi>();

            apiHandlers.Add(GetExternalAPIHandler(ExternalApiTypeEnum.ATTOM));
            apiHandlers.Add(GetExternalAPIHandler(ExternalApiTypeEnum.ZILLOW));

            return apiHandlers;
        }

        public IApi GetExternalAPIHandler(ExternalApiTypeEnum apiType)
        {
            switch (apiType)
            {
                case ExternalApiTypeEnum.ATTOM:
                    return (IApi) _serviceProvider.GetService(typeof(ATTOMApiHandler));
                case ExternalApiTypeEnum.ZILLOW:
                    return (IApi) _serviceProvider.GetService(typeof (ZillowApiHandler));
                default:
                    throw new Exception("External API Not Implemented");
            }
        }
    }
}
