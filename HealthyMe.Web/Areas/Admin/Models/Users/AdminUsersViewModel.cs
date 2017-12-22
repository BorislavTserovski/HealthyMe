using HealthyMe.Services.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HealthyMe.Web.Areas.Admin.Models.Users
{
    public class AdminUsersViewModel
    {
        public IEnumerable<SelectListItem> Roles { get; set; }

        public IEnumerable<AdminListingServiceModel> Users { get; set; }
    }
}