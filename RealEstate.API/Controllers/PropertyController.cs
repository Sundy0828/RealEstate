using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RealEstate.Core;
using RealEstate.Core.ExternalServices;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {

        private readonly ILogger<PropertyController> _logger;
        private readonly IServiceProvider _serviceProvider;

        public PropertyController(ILogger<PropertyController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public IActionResult Get()
        {
            ApiLogic logic = ActivatorUtilities.GetServiceOrCreateInstance<ApiLogic>(_serviceProvider);
            logic.GetProperty();

            return Ok();
        }
    }
}
