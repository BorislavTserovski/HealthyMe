using AutoMapper.QueryableExtensions;
using HealthyMe.Data;
using HealthyMe.Data.Models;
using HealthyMe.Services.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public User GetUserById(string id)
        =>  this.db.Users.Where(u => u.Id == id)
            .FirstOrDefault();
    }
}
