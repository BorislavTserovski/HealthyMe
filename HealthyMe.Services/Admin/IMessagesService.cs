using HealthyMe.Services.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyMe.Services.Admin
{
    public interface IMessagesService
    {
        Task<IEnumerable<MessagesListingModel>> AllAsync();

        Task Delete(int id);

        Task<MessagesListingModel> GetById(int id);
    }
}