using AutoMapper.QueryableExtensions;
using HealthyMe.Data;
using HealthyMe.Services.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthyMe.Services.Admin.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly HealthyMeDbContext db;

        public AdminUserService(HealthyMeDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminListingServiceModel>> AllAsync()
        => await this.db
            .Users
            .ProjectTo<AdminListingServiceModel>()
            .ToListAsync();
    }
}
