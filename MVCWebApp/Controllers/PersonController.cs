using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class PersonController : Controller
    {
        public PersonController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            Person person = new Person(1, "Sam", "Fisher", "sam_fisher@gmail.com", "206-111-1111");
            return View(person);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}
