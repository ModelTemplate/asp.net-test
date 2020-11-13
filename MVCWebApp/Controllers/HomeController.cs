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
using Microsoft.AspNetCore.Identity;

namespace MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings, 
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _appSettings = appSettings;     // unused for now
            _userManager = userManager;
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
            // client.SetBearerToken(App.CurrentUser.AccessToken);
            string url = "https://localhost:5001/api/ping";
            Debug.WriteLine("Pinging the LoanEvents API.");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
            request.Headers.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("Loan Tracker"));

            try
            {
                await client.SendAsync(request)
                    .ContinueWith(taskWithMsg =>
                    {
                        HttpResponseMessage response = taskWithMsg.Result;

                        Debug.WriteLine(response);

                        if (!response.IsSuccessStatusCode)
                        {
                            Debug.WriteLine("Service unreachable: " + response.ToString());
                            return false;
                        }

                        Task<string> reqTask = response.Content.ReadAsStringAsync();

                        string pingResponse = reqTask.Result;

                        if (string.IsNullOrWhiteSpace(pingResponse))
                        {
                            Debug.WriteLine("Unexpected response on service availability: " + response.ToString());
                            return false;
                        }
                        return pingResponse.Equals("Active");
                    });
            }
            catch (Exception error)
            {
                throw error;
            }

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
