using CapstoneOne.Models;
using Microsoft.AspNetCore.Mvc;
using RentalEquipmentCapstone;
using RentalEquipmentCapstone.Data;
using RentalEquipmentCapstone.Models;
using System;
using System.Linq;
using System.Security.Claims;

namespace CapstoneOne.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminController
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(a => a.IdentityUserId == userId).ToList();
            if (customer == null)
            {
                return RedirectToAction(nameof(Create));
            }

            var customerMatch = _context.Customers.ToList();

            return View(customerMatch);
        }


        // GET: AdminController/Details/5
        public IActionResult Details(int id)
        {
            ViewData["APIkeys"] = APIkeys.GoogleAPIKey;

            var details = _context.Customers.Find(id);
            return View(details);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Admin admin)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                admin.IdentityUserId = userId;
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var admin = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(admin);

        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public IActionResult Delete(int id)
        {
            var deleteCustomer = _context.Customers.Find(id);
            return View(deleteCustomer);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Customer customer)
        {
            try
            {
                var customerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = customerId;
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
