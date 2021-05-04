using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentalEquipmentCapstone.Data.Repository;
using RentalEquipmentCapstone.Models;
using RentalEquipmentCapstone.Models.Comments;
using Stripe;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RentalEquipmentCapstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository _repo;

        public HomeController(ILogger<HomeController> logger, IRepository repo)
        {
            _logger = logger;
            _repo = repo;

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FileManager()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel vm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Post", new
                {
                    id = vm.PostId
                });

            var post = _repo.GetPost(vm.PostId);
            if (vm.MainCommentId == 0)
            {
                post.MainComments = post.MainComments ?? new List<MainComment>();

                post.MainComments.Add(new MainComment
                {
                    Message = vm.Message,
                    Created = DateTime.Now,
                });

                _repo.UpdatePost(post);
            }
            else
            {
                var comment = new SubComment
                {
                    MainCommentId = vm.MainCommentId,
                    Message = vm.Message,
                    Created = DateTime.Now,
                };
                _repo.AddSubComment(comment);
            }

            await _repo.SaveChangesAsync();

            return RedirectToAction("Post", new
            {
                id = vm.PostId
            });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description= "Test Payment",
                Currency= "USD",
                Customer = customer.Id,
                ReceiptEmail = stripeEmail,
                Metadata = new Dictionary<string, string>()
                {
                    {"OrderId", "01" },
                    {"PostCode", "53202" }
                }


            });
            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId; // if successful give balance transaction #
                return View();
            }
            else
            {
                
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
