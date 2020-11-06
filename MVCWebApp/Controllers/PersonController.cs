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
            /*Person person = new Person()
            {
                FirstName = "Sam",
                LastName = "Fisher",
                Email = "sam_fisher@gmail.com",
                PhoneNum = "206-111-1111"
            };

            _dbContext.Add(person);
            _dbContext.SaveChanges();*/

            Person person = new Person();
            List<Person> persons = _dbContext.Persons.ToList<Person>();
            person.Persons = persons;

            return View(persons);
        }

        // GET: Person/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Person person = _dbContext.Find<Person>(id);
            return View(person);
        }

        // GET: Person/Edit
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Person/Edit
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            return View();
        }

        // GET: Person/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind("FirstName, LastName, Email, PhoneNum")] Person newPerson)
        {
            try
            {
                _dbContext.Add(newPerson);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _dbContext.Remove(new Person { ID = id });
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
