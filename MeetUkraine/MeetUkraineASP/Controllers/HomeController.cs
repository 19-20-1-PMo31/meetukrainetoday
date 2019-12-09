using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeetUkraineASP.Models;
using Microsoft.AspNetCore.Authorization;
using Domain;
using Domain.Entities;

namespace MeetUkraineASP.Controllers
{
    [Authorize(Roles ="Admin,Traveller")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string a = "hey";
            ViewBag.data = a;
            List<Place> places = new List<Place>();
            using(var ctx = new MeetUkraineContext())
            {
                places = ctx.Places.ToList();
            }
            ViewBag.places = places;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ActionResult SetNewPlace(Place newPlace)
        {
            using (var a = new MeetUkraineContext() )
            {
                a.Places.Add(new Place());
                a.SaveChanges();
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult AddComent(int PlaceId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddComent(int PlaceId , PlaceComment comment)
        {
            using (var a = new MeetUkraineContext())
            {
                Place test = a.Places.Where(item => item.PlaceId == PlaceId).FirstOrDefault();
                test.PlaceComments.Add(comment);
                a.SaveChanges();
            }
            return View();
        }
    }
}
