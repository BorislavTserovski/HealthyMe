﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthyMe.Web.Models;
using HealthyMe.Services.Admin;
using HealthyMe.Web.Areas.Admin.Models.Products;
using HealthyMe.Services.Admin.Models;

namespace HealthyMe.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService products;

        public HomeController(IProductService products)
        {
            this.products = products;
        }

        public async Task<IActionResult> Index(string searchBy, string searchTerm)
        {
            var result = await this.products.Search(searchBy, searchTerm);
            if ((searchBy == null && searchTerm == null))
            {
                return View(new List<ProductListingModel>());
            }
            
            else
            {
                return View(result);
            }
            
           
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
