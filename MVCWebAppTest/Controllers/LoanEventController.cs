using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebAppTest.Models;

namespace MVCWebAppTest.Controllers
{
    /// <summary>
    /// Unused controller for LoanEvent model.
    /// </summary>
    public class LoanEventController : Controller
    {
        public LoanEventController()
        {
        }

        public IActionResult Index()
        {
            LoanEvent loan = new LoanEvent(0, 1, "John Smith", DateTime.Now, DateTime.Now.AddDays(5));
            return View(loan);
        }
    }
}