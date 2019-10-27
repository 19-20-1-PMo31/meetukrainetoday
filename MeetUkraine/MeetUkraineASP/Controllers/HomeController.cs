using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeetUkraineASP.Models;
using Microsoft.AspNetCore.Authorization;

namespace MeetUkraineASP.Controllers
{
    [Authorize(Roles ="Admin,Traveller")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string a = "hey";
            ViewBag.data = a;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
