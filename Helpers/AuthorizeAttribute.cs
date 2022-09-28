using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CafeSimpleManagementSystem.Models;
using CafeSimpleManagementSystem.Wrappers;

namespace CafeSimpleManagementSystem.Helpers;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymous>().Any();
        if (allowAnonymous)
        {
            return;
        }

        var user = (User?)context.HttpContext.Items["User"];
        if (user == null)
        {
            var payload = new Response<object>()
            {
                Status = 401,
                Message = "Unauthorized"
            };
            context.Result = new JsonResult(payload);
        }
    }
}