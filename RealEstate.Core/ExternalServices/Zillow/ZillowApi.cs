using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices.Zillow
{
    internal class ZillowApi : Api, IApi
    {
        private readonly ZillowApiConfig _config;
        private readonly ILogger<ZillowApi> _logger;

        public ZillowApi(ZillowApiConfig config, ILogger<ZillowApi> logger) : base(logger)
        {
            _config = config;
            _logger = logger;
        }

        public void GetProperty()
        {
            throw new NotImplementedException();
        }
    }
}
