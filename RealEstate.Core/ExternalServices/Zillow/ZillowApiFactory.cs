using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices.Zillow
{
    internal class ZillowApiFactory : IApiFactory
    {
        public readonly ZillowApiConfig _config;
        private readonly IServiceProvider _serviceProvider;

        public ZillowApiFactory(ZillowApiConfig config, IServiceProvider serviceProvider)
        {
            _config = config;
            _serviceProvider = serviceProvider;
        }

        public IApi CreateApi()
        {
            return (IApi)_serviceProvider.GetService(typeof(ZillowApi));
        }
    }
}
