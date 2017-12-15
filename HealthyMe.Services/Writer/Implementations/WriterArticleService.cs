using AutoMapper.QueryableExtensions;
using HealthyMe.Data;
using HealthyMe.Data.Models;
using HealthyMe.Services.Writer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyMe.Services.Writer.Implementations
{
    public class WriterArticleService : IWriterArticleService
    {
        private HealthyMeDbContext db;

        public WriterArticleService(HealthyMeDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<WriterArticleListingServiceModel>> AllAsync(int page = 1)
        => await this.db.Articles
            .OrderByDescending(a => a.PublishDate)
            .Skip((page - 1) * ServiceConstants.ArticlePageSize)
            .Take(ServiceConstants.ArticlePageSize)
            .ProjectTo<WriterArticleListingServiceModel>()
            .ToListAsync();

        public async Task<WriterArticleDetailsServiceModel> ById(int id)
       => await this.db.Articles
            .Where(a => a.Id == id)
            .ProjectTo<WriterArticleDetailsServiceModel>()
            .FirstOrDefaultAsync();

        public async Task CreateAsync(string title, string content, string authorId)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                PublishDate = DateTime.UtcNow,
                AuthorId = authorId
            };

            this.db.Add(article);

            await this.db.SaveChangesAsync();
        }

        public async Task<int> TotalAsync()
        => await this.db.Articles.CountAsync();


    }
}
