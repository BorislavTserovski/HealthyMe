using HealthyMe.Services.Writer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthyMe.Services.Writer
{
    public interface IWriterArticleService
    {
        Task CreateAsync(string title, string content, string authorId, IFormFile file);

        Task<IEnumerable<WriterArticleListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<WriterArticleDetailsServiceModel> ById(int id);
    }
}
