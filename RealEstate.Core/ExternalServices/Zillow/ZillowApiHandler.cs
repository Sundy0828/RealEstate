using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices.Zillow
{
    public class ZillowApiHandler : IApi
    {
        private readonly ILogger<ZillowApiHandler> _logger;
        private readonly ZillowApi _api;

        public ZillowApiHandler(ILogger<ZillowApiHandler> logger, ZillowApi api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public void GetProperty()
        {
            _api.GetProperty();
        }
    }
}
