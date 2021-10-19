using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.ExternalServices
{
    public abstract class Api
    {
        private readonly ILogger _logger;

        protected Api(ILogger logger)
        {
            _logger = logger;
        }
        protected virtual T GetResponseData<T>(IRestResponse response) where T : new ()
        {
            if (String.IsNullOrWhiteSpace(response.Content))
            {
                return new T();
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (JsonReaderException jex)
            {
                return new T();
            }

        }
    }
}
