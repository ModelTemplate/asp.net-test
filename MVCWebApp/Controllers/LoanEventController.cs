using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Data;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class LoanEventController : Controller
    {
        private ApplicationDbContext _dbContext;

        public LoanEventController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoanEvent loan = new LoanEvent(0, 1, "John Smith", DateTime.Now, 
                DateTime.Now.AddDays(5), DateTime.Now.AddDays(5));
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
