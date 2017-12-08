using HealthyMe.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthyMe.Services.Admin.Models;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using HealthyMe.Data.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HealthyMe.Services.Admin.Implementations
{
    public class ProductService : IProductService
    {
        private readonly HealthyMeDbContext db;

        public ProductService(HealthyMeDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ProductListingModel>> AllAsync()
        => await this.db.Products
            .ProjectTo<ProductListingModel>()
            .ToListAsync();

        public async Task Create(string name, Category category, int energy, double fats,
            double proteins, double sugars, IFormFile file)
        {
            var product = new Product
            {
                Name = name,
                Category = category,
                Energy = energy,
                Fat = fats,
                Protein = proteins,
                Sugars = sugars,
            };
            using (MemoryStream ms = new MemoryStream())
            {
                if (file != null)
                {
                    file.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    product.Image = array;
                }
            }

            this.db.Add(product);
            await this.db.SaveChangesAsync();
        }
    }
}
