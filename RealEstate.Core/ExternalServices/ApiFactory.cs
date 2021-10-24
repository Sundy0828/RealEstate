using RealEstate.Core.ExternalServices.ATTOM;
using RealEstate.Core.ExternalServices.Zillow;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices
{
    public class ApiFactory : IApiFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ApiFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Api GetApi(ExternalApiTypeEnum apiType)
        {
            switch (apiType)
            {
                case ExternalApiTypeEnum.ATTOM:
                    return (Api)_serviceProvider.GetService(typeof(ATTOMApi));
                case ExternalApiTypeEnum.ZILLOW:
                    return (Api)_serviceProvider.GetService(typeof(ZillowApi));
                default:
                    throw new Exception("External API Not Implemented");
            }
        }
    }
}
