using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Data;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext _dbContext;

        // GET: ItemController
        public ItemController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Items page using Items.cshtml view
        [HttpGet]
        public IActionResult Index()
        {
            Item item = new Item(0, "Hammer", "My trusty hammer.", 9.99f, 0);
            List<Item> items = _dbContext.Items.ToList<Item>();

            return View(item);
        }

        // GET: ItemController/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: ItemController/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // GET: ItemController/Delete/5
        [HttpDelete]
        public ActionResult Delete()
        {
            return View();
        }
    }
}
