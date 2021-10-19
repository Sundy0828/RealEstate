using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Core.ExternalServices.ATTOM
{
    public class ATTOMApiConfig
    {
        [Required]
        public Uri Host { get; set; }
        [Required]
        public string ApiKey { get; set; }
    }
}
