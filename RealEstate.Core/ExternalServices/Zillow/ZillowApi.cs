using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices.Zillow
{
    public class ZillowApi : Api
    {
        private readonly ZillowApiConfig _config;
        private readonly ILogger<ZillowApi> _logger;

        public ZillowApi(ILogger<ZillowApi> logger, ZillowApiConfig config) : base(logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void GetProperty()
        {
            throw new NotImplementedException();
        }
    }
}
