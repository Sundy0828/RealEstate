using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RealEstate.API.Models;
using RealEstate.Core;
using RealEstate.Core.ExternalServices;
using Swashbuckle.AspNetCore.Annotations;

namespace RealEstate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "The server could not understand the request due to invalid syntax.", Type = typeof(ExceptionDetailsResponse))]
    [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Network credentials are no longer valid.", Type = typeof(ExceptionDetailsResponse))]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "The client does not have access rights to the content.", Type = typeof(ExceptionDetailsResponse))]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "The server can not find the requested resource.", Type = typeof(ExceptionDetailsResponse))]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Internal server error", Type = typeof(ExceptionResponse))]
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
        [Route("{Source}")]
        [SwaggerOperation(
            Summary = "Get Property",
            Description = "Get a properties details."
        )]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get a properties details.", Type = typeof(ExceptionDetailsResponse))]
        public IActionResult Get(string Source)
        {
            ApiLogic logic = ActivatorUtilities.GetServiceOrCreateInstance<ApiLogic>(_serviceProvider);
            logic.GetProperty(Source);

            return Ok();
        }
    }
}
