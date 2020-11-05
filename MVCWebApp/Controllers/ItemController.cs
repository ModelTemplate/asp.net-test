using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using MVCWebApp.Data;
using MVCWebApp.Models;

namespace MVCWebApp.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext _dbContext;

        // GET: Item
        public ItemController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Item
        [HttpGet]
        public IActionResult Index()
        {
            // primer for database
            Item item = new Item()
            {
                Name = "Hammer",
                Description = "My trusty hammer.",
                Cost = 9.99f,
                DepreciationRate = 0
            };

            _dbContext.Add(item);   // adding item to database
            _dbContext.SaveChanges();   // commiting changes
            // List<Item> Items = _dbContext.Items.ToList<Item>();

            item.Items = _dbContext.Items.ToList<Item>();

            return View(item);
        }

        // GET: Item/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            Item item = _dbContext.Find<Item>(id);
            return View(item);
        }

        // GET: Item/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Item/Create
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

        // GET: Item/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            _dbContext.Find<Item>(id);
            // _dbContext.Update<Item>(id);
            _dbContext.SaveChanges();
            return View();
        }

        // GET: ItemController/Delete/5
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
    }
}
