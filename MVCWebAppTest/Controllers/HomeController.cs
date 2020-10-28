using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCWebAppTest.Models;
using Microsoft.Extensions.Options;

namespace MVCWebAppTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IOptions<AppSettings> _appSettings;
        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;     // unused for now
        }

        // Home page using Index.cshtml view
        public IActionResult Index()
        {
            return View();
        }

        // Items page using Items.cshtml view
        public IActionResult Items()
        {
            Item item = new Item(0, "Hammer", "My trusty hammer.", 9.99f);
            return View(item);
        }

        public IActionResult Loans()
        {
            LoanEvent loan = new LoanEvent(0, 1, "John Smith", DateTime.Now, DateTime.Now.AddDays(5));
            return View(loan);
        }

        public IActionResult Loaners()
        {
            Person person = new Person(1, "Sam", "Fisher", "sam_fisher@gmail.com", "206-111-1111");
            return View(person);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
