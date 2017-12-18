using HealthyMe.Data.Models;
using HealthyMe.Services;
using HealthyMe.Services.Admin;
using HealthyMe.Web.Areas.Admin.Models.Products;
using HealthyMe.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
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

        private readonly IAdminUserService adminUserService;

        private readonly IUserService userService; 

        public ProductsController(IProductService products,
            UserManager<User> users,
            IAdminUserService adminUserService,
            IUserService userService)
        {
            this.products = products;
            this.users = users;
            this.adminUserService = adminUserService;
            this.userService = userService;
        }

        [Authorize]
        public async Task<IActionResult> Index(int page = 1)
        {
            var userId = this.users.GetUserId(User);
            var user = this.adminUserService.GetUserById(userId);
            if (user.Day == null)
            {
                await this.adminUserService.SetUserDayToCurrent(userId);
                user.AllowedCalories = await this.adminUserService.GetUserAllowedCalories(userId);
            }
            if (user.Day != DateTime.Today)
            {
                user.AllowedCalories = await this.adminUserService.GetUserAllowedCalories(userId);
                await this.adminUserService.SetUserDayToCurrent(userId);
            }
           return View(new ProductListingViewModel
              {
                  Products = await this.products.AllAsync(page),
                  TotalProducts = await this.products.TotalAsync(),
                  CurrentPage = page

              });
        }

        [Authorize]
        public async Task<IActionResult>AddToDay(int id)
        {
            var userId = this.users.GetUserId(User);
            await this.products.AddToDay(id, userId);
            var user = this.adminUserService.GetUserById(userId);
            var product = this.products.GetProductById(id);
            if (user.AllowedCalories >=0)
            {
                TempData.AddSuccessMessage($"Successfully added product {product.Name}. You have {user.AllowedCalories} allowed more callories for the day.");
            }
            else
            {
                TempData.AddSuccessMessage($"Successfully added product {product.Name}. You have exceede your allowed calories  with {Math.Abs(user.AllowedCalories)}!");
            }
          
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult>ViewMyProducts()
        {
            string userId = this.users.GetUserId(User);

            var userWithProducts = await this.userService.MyProducts(userId);

            return View(userWithProducts);

        }

        [Authorize]
        public async Task<IActionResult> ClearList()
        {
            string userId = this.users.GetUserId(User);
            var user = this.adminUserService.GetUserById(userId);
            user.AllowedCalories = await this.adminUserService.GetUserAllowedCalories(userId);

            await this.userService.ClearFoodAndDrinksList(userId);

            return RedirectToAction(nameof(ViewMyProducts));

        }
    }
}
