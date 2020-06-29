using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRWebApplication.IntegrationTest
{
    class FakeUserFilter : IAsyncActionFilter
    {
        /// Adds fake claims for user for testing scenarios
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, "SomeID1"),
            new Claim(ClaimTypes.GivenName, "Jan"),
            new Claim(ClaimTypes.Role, "User")
        }));

            await next();
        }
    }
}
