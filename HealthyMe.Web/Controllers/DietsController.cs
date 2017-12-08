using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HealthyMe.Data.Models;
using HealthyMe.Services;
using HealthyMe.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace HealthyMe.Web.Controllers
{
    public class DietsController : Controller
    {
        private const int PageSize = 6;
        private readonly UserManager<User> userManager;
        private IDietService diets;

        public DietsController(IDietService diets, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.diets = diets;
        }

        public IActionResult All(int page = 1)
        {
            return View(new DietsPageListingViewModel
            {
                Diets = this.diets.All(page, PageSize),
                CurrentPage = page,
                TotalPages = (this.diets.Total() % PageSize == 0) ?
                (this.diets.Total() / PageSize) : ((this.diets.Total() / PageSize) + 1)
            });
        }

        [Authorize]
        public IActionResult Create()
        => View();

       
        [HttpPost]
        [Authorize]
        public IActionResult Create(DietFormModel dietModel, IFormFile file)
        {
            string userId = userManager.GetUserId(User);

            this.diets.Add(dietModel.Name, dietModel.Description, file, userId);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Details(int id) => View(this.diets.Details(id));

        [Authorize]
        public IActionResult Edit(int id)
        {
           var model =  this.diets.GetById(id);
            if (model==null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, DietFormModel model,  IFormFile file)
        {
            if (ModelState.IsValid)
            {
                this.diets.Edit(id, model.Name, model.Description, file);
                return RedirectToAction(nameof(All));
            }
            return View(model);
           
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var model = this.diets.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Destroy(int id)
        {
            this.diets.Delete(id);
            return RedirectToAction(nameof(All));
        }

    }
}