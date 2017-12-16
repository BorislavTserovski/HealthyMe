using HealthyMe.Common.Mapping;
using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe.Services.Admin.Models
{
    public class ProductListingModel : IMapFrom <Product> 
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public Category Category { get; set; }

        [Range(0,10000)]
        public int Energy { get; set; }

        [Range(0,10000)]
        public double Fat { get; set; }

        [Range(0, 10000)]
        public double Protein { get; set; }

        [Range(0, 10000)]
        public double Sugars { get; set; }

        public byte[] Image { get; set; }

       
        



    }
}
