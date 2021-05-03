using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalEquipmentCapstone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Controllers
{
    public class CustomerProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CustomerProductController
        public ActionResult Index()
        {
            var cart = _context.CustomerProducts.Include(c => c.Product).ToList();
            return View(cart);
        }

        // GET: CustomerProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerProductController/Create
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

        // GET: CustomerProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CustomerProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
