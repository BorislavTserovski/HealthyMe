using HealthyMe.Services.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyMe.Services
{
    public interface IDietService
    {
        void Add(string name, string description, IFormFile file, string userId);

        IEnumerable<DietListingModel> All(int page = 1, int pageSize = 5);

        DietFormModel Details(int id);

        void Edit(int id, string name, string description, IFormFile file);

        void Delete(int id);

        DietFormModel GetById(int id);

        int Total();
    }
}
