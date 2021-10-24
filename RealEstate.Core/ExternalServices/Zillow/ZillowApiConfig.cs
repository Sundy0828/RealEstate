using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstate.Core.ExternalServices.Zillow
{
    public class ZillowApiConfig : IApiConfig
    {
        [Required]
        public Uri Host { get; set; }
        [Required]
        public string ApiKey { get; set; }
    }
}
