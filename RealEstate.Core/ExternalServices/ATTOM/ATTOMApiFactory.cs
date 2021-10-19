using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices.ATTOM
{
    public class ATTOMApiFactory : IApiFactory
    {
        public readonly ATTOMApiConfig _config;
        private readonly IServiceProvider _serviceProvider;

        public ATTOMApiFactory(ATTOMApiConfig config, IServiceProvider serviceProvider)
        {
            _config = config;
            _serviceProvider = serviceProvider;
        }

        public IApi CreateApi()
        {
            return (IApi)_serviceProvider.GetService(typeof(ATTOMApi));
        }
    }
}
