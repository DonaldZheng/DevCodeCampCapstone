using Microsoft.AspNetCore.Mvc;
using RentalEquipmentCapstone.Helpers;
using RentalEquipmentCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            return View();
        }
    }
}
