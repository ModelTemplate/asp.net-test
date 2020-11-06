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

        // GET: LoanEvent
        [HttpGet]
        public IActionResult Index()
        {
            /*LoanEvent loan = new LoanEvent()
            {
                LoanerID = 1,
                BorrowerName = "John Smith",
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(5),
                ReturnDate = DateTime.Now.AddDays(5)
            };

            _dbContext.Add(loan);
            _dbContext.SaveChanges();*/

            LoanEvent loan = new LoanEvent();
            List<LoanEvent> loans = _dbContext.Loans.ToList<LoanEvent>();
            loan.Loans = loans;

            return View(loans);
        }

        // GET: LoanEvent/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            LoanEvent loan = _dbContext.Find<LoanEvent>(id);
            return View(loan);
        }

        // GET: LoanEvent/Edit
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        // GET: LoanEvent/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanEvent/Create
        [HttpPost]
        public ActionResult Create(LoanEvent newLoan)
        {
            try
            {
                _dbContext.Add(newLoan);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanEvent/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _dbContext.Remove(new LoanEvent { ID = id });
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
