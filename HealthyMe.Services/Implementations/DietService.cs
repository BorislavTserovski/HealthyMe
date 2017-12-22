using AutoMapper.QueryableExtensions;
using HealthyMe.Data;
using HealthyMe.Data.Models;
using HealthyMe.Services.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HealthyMe.Services.Implementations
{
    public class DietService : IDietService
    {
        private HealthyMeDbContext db;

        public DietService(HealthyMeDbContext db)
        {
            this.db = db;
        }

        public void Add(string name, string description, IFormFile file, string userId)
        {
            Diet diet = new Diet();
            using (MemoryStream ms = new MemoryStream())
            {
                if (file != null)
                {
                    file.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    diet.Image = array;
                }
            }

            diet.Name = name;
            diet.Description = description;
            diet.AuthorId = userId;

            this.db.Diets.Add(diet);
            this.db.SaveChanges();
        }

        public DietFormModel GetById(int id)
        {
            return this.db.Diets.Where(d => d.Id == id)
                 .ProjectTo<DietFormModel>()
                 .FirstOrDefault();
        }

        public IEnumerable<DietListingModel> All(int page = 1, int pageSize = 5)
        {
            return this.db.Diets.OrderByDescending(d => d.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<DietListingModel>()
                .ToList();
        }

        public void Delete(int id)
        {
            Diet diet = this.db.Diets.Find(id);

            if (diet == null)
            {
                return;
            }
            this.db.Remove(diet);
            this.db.SaveChanges();
        }

        public DietFormModel Details(int id)
        {
            Diet diet = this.db.Diets.Find(id);
            return new DietFormModel
            {
                Id = diet.Id,
                Name = diet.Name,
                Description = diet.Description,
                Image = diet.Image,
            };
        }

        public void Edit(int id, string name, string description, IFormFile file)
        {
            Diet diet = this.db.Diets.Find(id);
            using (MemoryStream ms = new MemoryStream())
            {
                if (file != null)
                {
                    file.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    diet.Image = array;
                }
            }

            diet.Name = name;
            diet.Description = description;

            this.db.SaveChanges();
        }

        public int Total() => this.db.Diets.Count();

        public bool isUserAuthor(string userId, int dietId)
        {
            var diet = this.db.Diets.FirstOrDefault(d => d.Id == dietId);
            if (userId == null)
            {
                return false;
            }

            return diet.AuthorId == userId;
        }
    }
}