/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Sept 05, 2019
LAST MODIFIED ON    :   -
DESCRIPTION         :   Policy Controller
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Policys.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult Index() => View();

        [Authorize(Policy = "WorkedTwoYears")]
        public IActionResult TwoYearRewards() => View();

        [Authorize(Policy = "WorkedFiveYears")]
        public IActionResult FiveYearRewards() => View();

        [Authorize(Policy = "WorkedTenYears")]
        public IActionResult TenYearRewards() => View();
    }
}
