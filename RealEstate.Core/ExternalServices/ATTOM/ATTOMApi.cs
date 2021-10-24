using Microsoft.Extensions.Logging;
using RealEstate.Core.Utility;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices.ATTOM
{
    public class ATTOMApi : Api
    {
        private readonly ATTOMApiConfig _config;
        private readonly ILogger<ATTOMApi> _logger;

        public ATTOMApi(ILogger<ATTOMApi> logger, ATTOMApiConfig config) : base(logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void GetProperty()
        {
            Request request = new Request($"{_config.Host}property/basicprofile");

            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"address1", "4529 Winona Court"},
                {"address2", $"Denver, CO"}
            };

            Dictionary<string, string> headers = new Dictionary<string, string>()
            {
                {"Accept", "application/json"},
                {"APIKey", $"{_config.ApiKey}"}
            };

            IRestResponse response = request.MakeRequest(Method.GET, parameters, headers);

            //return GetResponseData<T>(response);
        }
    }
}
