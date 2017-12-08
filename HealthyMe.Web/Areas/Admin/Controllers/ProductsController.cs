using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthyMe.Data;
using HealthyMe.Data.Models;
using Microsoft.AspNetCore.Authorization;
using HealthyMe.Services.Admin;
using HealthyMe.Web.Areas.Admin.Models.Products;
using Microsoft.AspNetCore.Http;

namespace HealthyMe.Web.Areas.Admin.Controllers
{
    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class ProductsController : Controller
    {
        private readonly IProductService products;

        public ProductsController(IProductService products)
        {
            this.products = products;
        }


        public async Task<IActionResult> Index()
        {
            var products = await this.products.AllAsync();
            return View(products);
        }


        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }



        //    return View();
        //}


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductFormModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
               
            }
            await this.products.Create(model.Name, model.Category, model.Energy, model.Fat
                , model.Protein, model.Sugars, file);

            return RedirectToAction(nameof(Index));
        }

        //// GET: Admin/Products/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", product.CategoryId);
        //    return View(product);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,Measure,Energy,Fat,Protein,Sugars,Image")] Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", product.CategoryId);
        //    return View(product);
        //}

        //// GET: Admin/Products/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .Include(p => p.Category)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}


        //[HttpPost]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}


    }
}
