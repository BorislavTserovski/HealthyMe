using HealthyMe.Data.Models;
using HealthyMe.Services.Html;
using HealthyMe.Services.Writer;
using HealthyMe.Web.Areas.Writer.Models.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyMe.Web.Areas.Writer.Controllers
{
    [Area(WebConstants.WriterArea)]
    [Authorize(Roles = WebConstants.WriterRole)]
    public class ArticlesController : Controller
    {
        private readonly IHtmlService html;
        private readonly IWriterArticleService articles;
        private readonly UserManager<User> userManager;

        public ArticlesController(IHtmlService html, IWriterArticleService articles, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.articles = articles;
            this.html = html;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        => View(new ArticleListingViewModel
        {
            Articles = await this.articles.AllAsync(page),
            TotalArticles = await this.articles.TotalAsync(),
            CurrentPage = page

        });

     



        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(PublishArticleFormModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Content = this.html.Sanitize(model.Content);
            var userId = this.userManager.GetUserId(User);
            await this.articles.CreateAsync(model.Title, model.Content, userId, file);

            return RedirectToAction(nameof(Index));

        }
    }
}
