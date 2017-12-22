using HealthyMe.Common.Mapping;
using HealthyMe.Data.Models;

namespace HealthyMe.Services.Admin.Models
{
    public class AdminListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}