using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebAppTest.Models;

namespace MVCWebAppTest.Controllers
{
    /// <summary>
    /// Unused controller for Person model.
    /// </summary>
    public class PersonController : Controller
    {
        public PersonController()
        {
        }

        public IActionResult Index()
        {
            // Person person = new Person();
            return View();
        }
    }
}