/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Sept 05, 2019
LAST MODIFIED ON    :   -
DESCRIPTION         :   Home Controller
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Policys.Models;
using Microsoft.AspNetCore.Mvc;

namespace Policys.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Errors()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}