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
using HealthyMe.Services.Html;

namespace HealthyMe.Web.Controllers
{
    public class DietsController : Controller
    {
        private const int PageSize = 5;
        private readonly UserManager<User> userManager;
        private readonly IDietService diets;
        private readonly IHtmlService html;

        public DietsController(IDietService diets, UserManager<User> userManager, IHtmlService html)
        {
            this.userManager = userManager;
            this.diets = diets;
            this.html = html;
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
            if (!ModelState.IsValid)
            {
                return View(dietModel);
            }
            string userId = userManager.GetUserId(User);
            string sanitizedDescription = this.html.Sanitize(dietModel.Description);
            this.diets.Add(dietModel.Name, sanitizedDescription, file, userId);

            return RedirectToAction(nameof(All));
        }

       
        public IActionResult Details(int id) => View(this.diets.Details(id));

        [Authorize]
        public IActionResult Edit(int id)
        {
            string userId = this.userManager.GetUserId(User);
            if (!this.diets.isUserAuthor(userId, id) && !User.IsInRole(WebConstants.AdministratorRole))
            {
                return Unauthorized();
            }
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
            string userId = this.userManager.GetUserId(User);
            if (!this.diets.isUserAuthor(userId, id) && !User.IsInRole(WebConstants.AdministratorRole))
            {
                return Unauthorized();
            }
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
            string userId = this.userManager.GetUserId(User);
            if (!this.diets.isUserAuthor(userId, id)&&!User.IsInRole(WebConstants.AdministratorRole))
            {
                return Unauthorized();
            }
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
            string userId = this.userManager.GetUserId(User);
            if (!this.diets.isUserAuthor(userId, id) && !User.IsInRole(WebConstants.AdministratorRole))
            {
                return Unauthorized();
            }
            this.diets.Delete(id);
            return RedirectToAction(nameof(All));
        }

    }
}