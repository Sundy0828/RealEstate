using RealEstate.Core.ExternalServices;
using RealEstate.Core.ExternalServices.ATTOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Core
{
    public class ApiLogic
    {
        private readonly IApi _api;

        public ApiLogic(IApiFactory apiFactory)
        {
            _api = apiFactory.CreateApi();
        }

        public void GetProperty()
        {
            _api.GetProperty();
        }
    }
}
