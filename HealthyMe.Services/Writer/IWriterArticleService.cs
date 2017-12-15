using HealthyMe.Services.Writer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthyMe.Services.Writer
{
    public interface IWriterArticleService
    {
        Task CreateAsync(string title, string content, string authorId);

        Task<IEnumerable<WriterArticleListingServiceModel>> AllAsync(int page = 1);

        Task<int> TotalAsync();

        Task<WriterArticleDetailsServiceModel> ById(int id);
    }
}
