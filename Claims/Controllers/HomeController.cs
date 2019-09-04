/*==========================================================================================
AUTHOR              :   Manan Pandya
CREATED ON          :   Aug 31, 2019
LAST MODIFIED ON    :   -
DESCRIPTION         :   HomeController
============================================================================================
REVISION HISTORY : 
Name:                 Date:                 Description
============================================================================================*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Claims.Models;
using Microsoft.AspNetCore.Mvc;

namespace Claims.Controllers
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