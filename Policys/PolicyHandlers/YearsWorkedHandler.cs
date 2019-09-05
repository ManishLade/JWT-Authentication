/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Sept 05, 2019
LAST MODIFIED ON    :   -
DESCRIPTION         :   YearsWorkedHandler for Policy.
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Policys.PolicyHandlers
{
    public class MinimumYearsWorkedRequirement : IAuthorizationRequirement
    {
        public int Years { get; }

        public MinimumYearsWorkedRequirement(int yearsWorked)
        {
            Years = yearsWorked;
        }
    }

    public class YearsWorkedHandler : AuthorizationHandler<MinimumYearsWorkedRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumYearsWorkedRequirement requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
                return Task.CompletedTask;

            var started = context.User.Claims.FirstOrDefault(x => x.Type == "DateStarted").Value;
            var dateStarted = DateTime.Parse(started);

            if (DateTime.Now.Subtract(dateStarted).TotalDays > 365 * requirement.Years)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
