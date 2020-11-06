using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
            /*Item item = new Item()
            {
                Name = "Hammer",
                Description = "My trusty hammer.",
                Cost = 9.99f,
                DepreciationRate = 0
            };*/

            // _dbContext.Add(item);   // adding item to database
            // _dbContext.SaveChanges();   // commiting changes
            // List<Item> items = _dbContext.Items.ToList<Item>();

            // getting all items from database

            Item item = new Item();
            List<Item> items = _dbContext.Items.ToList<Item>();
            item.Items = items;

            return View(items);
        }

        // GET: Item/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Item item = _dbContext.Find<Item>(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // GET: Item/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        // TO protect from overposting attacks, please enable this specific properties you
        // want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(
            [Bind("Name, Description, Cost, DepreciationRate")] Item newItem)
        {
            // binding specific properties and including validation of data
            if (ModelState.IsValid)
            {
                _dbContext.Add(newItem);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(newItem);
        }

        // TODO
        // GET: Item/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Item item = _dbContext.Find<Item>(id);
            if (item == null)
            {
                return NotFound();
            }
            _dbContext.Update<Item>(item);
            _dbContext.SaveChanges();
            return View();
        }

        // TODO
        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(
            [Bind("Name, Description, Cost, DepreciationRate")] Item updatedItem)
        {
            try
            {
                _dbContext.Update(updatedItem);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                // below executes two SQL statements; one to retrieve item
                // and another to actually delete it
                // _dbContext.Remove(_dbContext.Find<Item>(id));
                _dbContext.Remove(new Item { ID = id });    // executes one SQL statement
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/All
        [HttpGet]
        public ActionResult Delete(string param)
        {
            try
            {
                foreach (Item item in _dbContext.Items)
                {
                    _dbContext.Remove(item);
                }
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
