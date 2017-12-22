using AutoMapper.QueryableExtensions;
using HealthyMe.Data;
using HealthyMe.Data.Models;
using HealthyMe.Services.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Delete(string id)
        {
            var user = this.db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
            {
                return;
            }
            this.db.Users.Remove(user);

            await this.db.SaveChangesAsync();
        }

        public async Task<int> GetUserAllowedCalories(string userId)
        {
            var user = this.db.Users.Where(u => u.Id == userId).FirstOrDefault();
            var BMI = Math.Round(user.Weight / ((user.Height / 100) * (user.Height / 100)), 2);
            user.BodyMassIndex = BMI;

            if (user.Gender == Gender.male)
            {
                if (BMI >= 18.5 && BMI <= 25)
                {
                    user.AllowedCalories = 2500;
                }
                else if (BMI > 25)
                {
                    user.AllowedCalories = 2100;
                }
                else if (BMI < 18.5)
                {
                    user.AllowedCalories = 2800;
                }
            }
            else if (user.Gender == Gender.female)
            {
                if (BMI >= 18.5 && BMI <= 25)
                {
                    user.AllowedCalories = 1900;
                }
                else if (BMI > 25)
                {
                    user.AllowedCalories = 1700;
                }
                else if (BMI < 18.5)
                {
                    user.AllowedCalories = 2100;
                }
            }

            await db.SaveChangesAsync();

            return user.AllowedCalories;
        }

        public User GetUserById(string id)
        => this.db.Users.Where(u => u.Id == id)
            .FirstOrDefault();

        public async Task SetUserDayToCurrent(string userId)
        {
            var user = this.db.Users.Where(u => u.Id == userId).FirstOrDefault();

            user.Day = DateTime.Today;
            await this.db.SaveChangesAsync();
        }
    }
}