using BxlForm.DemoSecurity.Infrastructure.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Infrastructure.Security

{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter))
        {
        }

        private class AuthRequiredFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                ISessionManager sm = (ISessionManager)context.HttpContext.RequestServices.GetService(typeof(ISessionManager));

                if (sm.User is null)
                {
                    context.Result = new RedirectToActionResult("Login", "Auth", null);
                }
                
            }
        }
    }
}
