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
    [Authorize(Roles = "Admin,Traveller")]

    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] MeetUkraineContext ctx)
        {
            string a = "hey";
            ViewBag.data = a;

            //using (var ctx = new MeetUkraineContext() )

            List<Place> places = new List<Place>();
            places = ctx.Places.ToList();
            //places.Count();
            //ViewBag.places = ctx.Places.ToList();
            ViewBag.Places = places;
            ViewBag.Size = places.Count;


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ActionResult SetNewPlace([FromServices] MeetUkraineContext a, Place newPlace)
        {
            //using (var a = new MeetUkraineContext() )
            {
                a.Places.Add(newPlace);
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
        public ActionResult AddComent(int PlaceId, PlaceComment comment)
        {
            using (var a = new MeetUkraineContext())
            {
                Place test = a.Places.Where(item => item.PlaceId == PlaceId).FirstOrDefault();
                test.PlaceComments.Add(comment);
                a.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddNewPlace()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewPlace(Place newPlace)
        {
            using (var a = new MeetUkraineContext())
            {
                a.Places.Add(newPlace);
                a.SaveChanges();
            }
            return View("Index");
        }
    }
}
