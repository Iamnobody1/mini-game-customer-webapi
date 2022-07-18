using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Yoda.Services.Identity.Attribute;

public class CustomAuthorizeAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;
        
        var bearerToken = context.HttpContext.Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(bearerToken))
        {
            var token = bearerToken.ToString().Split(' ')[1];
            if (token != "abc")
            {
                context.Result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
            }
        }
    }
}