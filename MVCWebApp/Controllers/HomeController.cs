using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCWebApp.Models;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppSettings> _appSettings;

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;     // unused for now
        }

        // Home page using Index.cshtml view under Home folder
        // GET: Home/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // using an internal API
            HttpClient client = new HttpClient();
            string loans = await client.GetStringAsync("https://localhost:5001/api/loanevents");

            // build request for track ID
            client.SetBearerToken(App.CurrentUser.AccessToken);
            string url = App.baseUrl + "api/ping";
            Debug.WriteLine("Pinging the FMX service.");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
            
            return View();
        }

        // Privacy page using Privacy.cshtml view under Home folder
        // GET: Home/Privacy
        [HttpGet]
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
