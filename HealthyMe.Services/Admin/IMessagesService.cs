using HealthyMe.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthyMe.Services.Admin
{
    public interface IMessagesService
    {
        Task<IEnumerable<MessagesListingModel>> AllAsync();
    }
}
