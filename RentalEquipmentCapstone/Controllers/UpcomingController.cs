using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalEquipmentCapstone.Data;
using RentalEquipmentCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Controllers
{
    public class UpcomingController : Controller
    {
        private ApplicationDbContext _context;
        public UpcomingController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: UpcomingController
        public ActionResult Index()
        {
            var returnList = _context.Upcomings.ToList();
            return View(returnList);

        }

        // GET: UpcomingController/Details/5
        public ActionResult Details(int id)
        {
            var details = _context.Upcomings.Find(id);
            return View(details);
        }

        // GET: UpcomingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UpcomingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Upcoming upcoming)
        {
            try
            {
                _context.Upcomings.Add(upcoming);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                Console.WriteLine("Error!");
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: UpcomingController/Edit/5
        public ActionResult Edit(int id)
        {
            var editSuperhero = _context.Upcomings.Find(id);
            return View(editSuperhero);
        }

        // POST: UpcomingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Upcoming upcoming)
        {
            try
            {
                _context.Upcomings.Update(upcoming);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error!");
                return View();
            }
        }

        // GET: UpcomingController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteSuperhero = _context.Upcomings.Find(id);
            return View(deleteSuperhero);
        }

        // POST: UpcomingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Upcoming upcoming)
        {
            try
            {
                _context.Upcomings.Remove(upcoming);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error!");
                return View();
            }
        }
    }
}
