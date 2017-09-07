using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Welcome.Extensions;
using Welcome.Infrastructure;
using Welcome.Models;

namespace Welcome.Controllers
{
    public class HomeController: Controller
    {
        private Greeter greeter;

        public HomeController(Greeter _greeter)
        {
            greeter = _greeter;
        }
        private string GetMessage()
        {
            if (DateTime.Now.Hour > 12)
            {
                return $"{greeter.EveningMessage} User!";
            }
            else
            {
                return $"{greeter.MorningMessage} User!";
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeeGreeting()
        {   
            return View("Get", GetMessage());
        }

        public IActionResult About()
        {   
            return View("About", GetMessage());
        }

        public IActionResult Contact()
        {   
            return View("Contact", GetMessage());
        }

        [HttpGet]
        public IActionResult SetGreeting()
        {
            return View("Set");
        }

        [HttpPost]
        public IActionResult SetGreeting(Greeter greeter)
        {
            HttpContext.Session.Set<Greeter>("greeting", greeter);
            return RedirectToAction("SeeGreeting");
        }
    }
}