using HealthyMe.Data.Models;
using HealthyMe.Services.Admin;
using HealthyMe.Web.Infrastructure.Extensions;
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

        private readonly IAdminUserService userService;

        public ProductsController(IProductService products, UserManager<User> users, IAdminUserService userService)
        {
            this.products = products;
            this.users = users;
            this.userService = userService;
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
            var user = this.userService.GetUserById(userId);
            var product = this.products.GetProductById(id);
            TempData.AddSuccessMessage($"Successfully added product {product.Name}. You have {user.AllowedCalories} allowed more callories for the day.");
            return RedirectToAction(nameof(Index));
        }
    }
}
