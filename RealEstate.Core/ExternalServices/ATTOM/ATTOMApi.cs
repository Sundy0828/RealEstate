using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices.ATTOM
{
    public class ATTOMApi : Api, IApi
    {
        private readonly ATTOMApiConfig _config;
        private readonly ILogger<ATTOMApi> _logger;

        public ATTOMApi(ATTOMApiConfig config, ILogger<ATTOMApi> logger) : base(logger) 
        {
            _config = config;
            _logger = logger;
        }

        public void GetProperty()
        {
            if (_config == null)
            {
                throw new ArgumentNullException(nameof(_config));
            }

            RestClient client = new RestClient($"{_config.Host}");
            RestRequest request = new RestRequest(Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("APIKey", $"{_config.ApiKey}");

            IRestResponse response = client.Execute(request);
            //return GetResponseData<T>(response);
        }
    }
}
