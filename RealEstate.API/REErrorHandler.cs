using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RealEstate.API.Models;
using RealEstate.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RealEstate.API
{
    public class REErrorHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is REException)
            {
                REException ex = filterContext.Exception as REException;
                filterContext.HttpContext.Response.StatusCode = (int)ex.HttpCode;

                if (ex.ErrorDetails != null)
                {
                    filterContext.Result = new ObjectResult(new ExceptionDetailsResponse(false, (int)ex.HttpCode, ex.ErrorMessage, ex.ErrorDetails));
                }
                else
                {
                    filterContext.Result = new ObjectResult(new ExceptionResponse(false, (int)ex.HttpCode, ex.ErrorMessage));
                }
            }
            else
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                filterContext.Result = new ObjectResult(new ExceptionResponse(false, (int)HttpStatusCode.InternalServerError, "Internal server error"));
            }
        }
    }
}
