using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthyMe.Services.Models;
using HealthyMe.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace HealthyMe.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly HealthyMeDbContext db;

        public UserService(HealthyMeDbContext db)
        {
            this.db = db;
        }

        public async Task ClearFoodAndDrinksList(string userId)
        {
            var user = this.db.Users.Where(u => u.Id == userId).FirstOrDefault();
            foreach (var product in this.db.Products)
            {
                if (product.UserId==userId)
                {
                    product.UserId = null;
                }
            }
            user.MyProducts.Clear();
            await this.db.SaveChangesAsync();
        }

        public async Task<UserWithProductsServiceModel> MyProducts(string userId)
        => await this.db.Users
            .Where(u => u.Id == userId)
            .ProjectTo<UserWithProductsServiceModel>()
            .FirstOrDefaultAsync();
            

            
            
    }
}
