using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RealEstate.Core.Extensions
{
    public static class RestSharpExtensions
    {
        public static bool IsSuccessful(this IRestResponse response)
        {
            return response.StatusCode.IsSuccessStatusCode() && response.ResponseStatus == ResponseStatus.Completed;
        }

        public static bool IsSuccessStatusCode(this HttpStatusCode responseCode)
        {
            int numericResponse = (int)responseCode;
            return numericResponse >= 200
                && numericResponse <= 399;
        }
    }
}
