/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Aug 31, 2019
LAST MODIFIED ON    :   -
DESCRIPTION         :   Authorize Claim Validation
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using Claims.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Reflection;

namespace Claims.AuthorizationAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class YearsWorkedAttribute : TypeFilterAttribute
    {
        public YearsWorkedAttribute(int years)
            : base(typeof(YearsWorkedFilter))
        {
            Arguments = new object[] { years };
        }
    }

    public class YearsWorkedFilter : IAuthorizationFilter
    {
        public YearsWorkedFilter(int years) => Years = years;

        public int Years { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Claims.FirstOrDefault() != null)
            {
                if (!context.HttpContext.User.Identity.IsAuthenticated)
                    context.Result = new UnauthorizedResult();
                var started = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "DateStarted").Value;
                var dateStarted = DateTime.Parse(started);

                if (DateTime.Now.Subtract(dateStarted).TotalDays < 365 * Years)
                    context.Result = new ForbidResult();
            }
            else
            {
                // Uncomment below line to display "Access denied" error.
                //context.Result = new ForbidResult();

                // Uncomment below line to display "401 Unauthorized" error.
                //context.Result = new UnauthorizedResult();

                // Redirect user to Login page if not authorized.
                context.Result = new RedirectResult(@"~/Identity/Account/Login");
            }
        }
    }
}
