using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class LoanEventController : Controller
    {
        public LoanEventController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoanEvent loan = new LoanEvent(0, 1, "John Smith", DateTime.Now, DateTime.Now.AddDays(5), new DateTime());
            return View(loan);
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
