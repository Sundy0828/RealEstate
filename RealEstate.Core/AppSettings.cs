using RealEstate.Core.ExternalServices.ATTOM;
using RealEstate.Core.ExternalServices.Zillow;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core
{
    public class AppSettings
    {
        public ATTOMApiConfig ATTOMConfig { get; set; }
        public ZillowApiConfig ZillowConfig { get; set; }
    }
}
