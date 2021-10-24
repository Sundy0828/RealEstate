using Microsoft.Extensions.Logging;
using RealEstate.Core.ExternalServices;
using RealEstate.Core.ExternalServices.ATTOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core
{
    public class ApiLogic
    {
        private readonly ILogger<ApiLogic> _logger;
        private readonly IExternalApiFactory _apiFactory;

        public ApiLogic(ILogger<ApiLogic> logger, IExternalApiFactory apiFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _apiFactory = apiFactory ?? throw new ArgumentNullException(nameof(apiFactory));
        }

        public void GetProperty(string source)
        {
            IApi apiHandler = _apiFactory.GetExternalAPIHandler(Enum.Parse<ExternalApiTypeEnum>(source));

            apiHandler.GetProperty();
        }
    }
}
