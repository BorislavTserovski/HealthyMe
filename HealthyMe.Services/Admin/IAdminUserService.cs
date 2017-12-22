using HealthyMe.Data.Models;
using HealthyMe.Services.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyMe.Services.Admin
{
    public interface IAdminUserService
    {
        Task<IEnumerable<AdminListingServiceModel>> AllAsync();

        User GetUserById(string id);

        Task<int> GetUserAllowedCalories(string userId);

        Task SetUserDayToCurrent(string userId);

        Task Delete(string id);
    }
}