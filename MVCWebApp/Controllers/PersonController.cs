using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Data;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class PersonController : Controller
    {
        private ApplicationDbContext _dbContext;

        public PersonController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Person person = new Person()
            {
                ID = 1,
                FirstName = "Sam",
                LastName = "Fisher",
                Email = "sam_fisher@gmail.com",
                PhoneNum = "206-111-1111"
            };

            _dbContext.Add(person);
            _dbContext.SaveChanges();

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
