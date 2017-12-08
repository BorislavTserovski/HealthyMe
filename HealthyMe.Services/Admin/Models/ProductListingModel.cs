using HealthyMe.Common.Mapping;
using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace HealthyMe.Services.Admin.Models
{
    public class ProductListingModel : IMapFrom <Product> 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public int Energy { get; set; }

        public double Fat { get; set; }

        public double Protein { get; set; }

        public double Sugars { get; set; }

        public byte[] Image { get; set; }

  
        
    }
}
