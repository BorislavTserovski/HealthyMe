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
using System.Linq;
using HealthyMe.Web.Areas.Admin.Models.Products;
using Microsoft.AspNetCore.Authorization;

namespace HealthyMe.Services.Admin.Implementations
{
    public class ProductService : IProductService
    {
        private readonly HealthyMeDbContext db;

        public ProductService(HealthyMeDbContext db)
        {
            this.db = db;
        }

        public async Task AddToDay(int id, string userId)
        {
            Product product = this.db.Products.Where(p => p.Id == id).FirstOrDefault();
            User user = this.db.Users.Where(u => u.Id == userId).FirstOrDefault();
            user.AllowedCalories -= product.Energy;

            await this.db.SaveChangesAsync();


        }

        [AllowAnonymous]
        public async Task<IEnumerable<ProductListingModel>> AllAsync(int page = 1)
        => await this.db.Products
            .OrderBy(p => p.Id)
            .Skip((page - 1) * ServiceConstants.ProductsPageSize)
            .Take(ServiceConstants.ProductsPageSize)
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

        public async Task Delete(int id)
        {
            var product = this.db.Products.Where(p => p.Id == id).FirstOrDefault();

            if (product == null)
            {
                return;
            }

            this.db.Products.Remove(product);

            await this.db.SaveChangesAsync();
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        => await
            this.db.Products
                .Where(p => p.Id == id)
                .ProjectTo<ProductViewModel>()
                .FirstOrDefaultAsync();

        public Product GetProductById(int id)
        => this.db.Products.Where(p => p.Id == id)
            .FirstOrDefault();

        public async Task<IEnumerable<ProductListingModel>> Search(string searchBy, string searchTerm)
        {
            if (searchBy == "Name")
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return new List<ProductListingModel>();
                }
                var result = await this.db.Products
                    .Where(p => p.Name.ToLower()
                    .Contains(searchTerm.ToLower()))
                    .ProjectTo<ProductListingModel>()
                    .ToListAsync();

                return result;
            }

            else if (searchBy == "Category")
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return new List<ProductListingModel>();
                }
                var result = await this.db.Products
                    .Where(p => p.Category.ToString().ToLower()
                    .Contains(searchTerm.ToLower()))
                    .ProjectTo<ProductListingModel>()
                    .ToListAsync();

                return result;
            }

            return null;
        }

        public async Task<int> TotalAsync()
        =>  await this.db.Products.CountAsync();
    }
}
