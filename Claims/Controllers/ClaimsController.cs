/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Aug 31, 2019
LAST MODIFIED ON    :   -
DESCRIPTION         :   ClaimsController
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Claims.AuthorizationAttributes;
using Microsoft.AspNetCore.Mvc;

namespace Claims.Controllers
{
    public class ClaimsController : Controller
    {
        public IActionResult Index() => View();

        [YearsWorked(2)]
        public IActionResult TwoYearRewards() => View();
        
        [YearsWorked(5)]
        public IActionResult FiveYearRewards() => View();

        [YearsWorked(10)]
        public IActionResult TenYearRewards() => View();
    }
}