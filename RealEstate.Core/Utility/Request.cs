using RealEstate.Core.Extensions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core.Utility
{
    public class Request
    {
        private readonly RestClient _client;
        public Request(string url)
        {
            _client = new RestClient(url);
        }

        public IRestResponse MakeRequest(Method method, Dictionary<string, string> parameters, Dictionary<string, string> headers, object body = null)
        {
            RestRequest request = new RestRequest(method);

            request.AddHeaders(headers);

            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    request.AddQueryParameter(param.Key, param.Value);
                }
            }

            if (body != null)
            {
                request.AddJsonBody(body);
            }

            IRestResponse response = _client.Execute(request);
            if (!response.IsSuccessful())
            {
                throw new Exception();
            }

            return response;
        }
    }
}
