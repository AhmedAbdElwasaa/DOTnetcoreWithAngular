using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTnetcore.Controllers
{
    public class AppController:Controller
    {
        public IActionResult Index()
        {
            //throw new InvalidOperationException("bad thing happened !!");
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }
    }
}
