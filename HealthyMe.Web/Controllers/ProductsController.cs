using HealthyMe.Data.Models;
using HealthyMe.Services.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyMe.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService products;

        private readonly UserManager<User> users;

        public ProductsController(IProductService products, UserManager<User> users)
        {
            this.products = products;
            this.users = users;
        }

        public async Task<IActionResult> Index()
        {
            var products = await this.products.AllAsync();
            return View(products);
        }

        public async Task<IActionResult>AddToDay(int id)
        {
            var userId = this.users.GetUserId(User);
            await this.products.AddToDay(id, userId);

            return RedirectToAction(nameof(Index));
        }
    }
}
