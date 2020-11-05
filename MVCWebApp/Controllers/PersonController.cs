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

        // GET: Person
        [HttpGet]
        public IActionResult Index()
        {
            Person person = new Person()
            {
                FirstName = "Sam",
                LastName = "Fisher",
                Email = "sam_fisher@gmail.com",
                PhoneNum = "206-111-1111"
            };

            _dbContext.Add(person);
            _dbContext.SaveChanges();

            return View(person);
        }

        // GET: Person/Edit
        public ActionResult Edit()
        {
            return View();
        }

        // GET: Person/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}
