using HealthyMe.Data.Models;
using HealthyMe.Services.Admin.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthyMe.Services.Admin
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListingModel>> AllAsync();

        Task Create(string name, Category category, int energy, double fats,
            double proteins, double sugars, IFormFile file);
    }
}
