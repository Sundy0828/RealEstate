using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices.ATTOM
{
    public class ATTOMApiHandler : IApi
    {
        private readonly ILogger<ATTOMApiHandler> _logger;
        private readonly ATTOMApi _api;

        public ATTOMApiHandler(ILogger<ATTOMApiHandler> logger, ATTOMApi api)
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
