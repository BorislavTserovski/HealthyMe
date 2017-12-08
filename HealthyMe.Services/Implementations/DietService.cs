using System;
using System.Collections.Generic;
using System.Text;
using HealthyMe.Services.Models;
using Microsoft.AspNetCore.Http;
using HealthyMe.Data;
using HealthyMe.Data.Models;
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
            Diet diet = this.db.Diets.Find(id);

            DietFormModel model = new DietFormModel()
            {
                Id = diet.Id,
                Name = diet.Name,
                Description = diet.Description,
                Image = diet.Image
            };
            return model;
            
        }

        public IEnumerable<DietListingModel> All(int page = 1, int pageSize = 5)
        {
            return this.db.Diets.OrderByDescending(d => d.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(d => new DietListingModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    Image = d.Image
                }).ToList();
        }

        public void Delete(int id)
        {
            Diet diet = this.db.Diets.Find(id);
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

    }
}
