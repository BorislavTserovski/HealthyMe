using HealthyMe.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyMe.Web.Areas.Admin.Models.Products
{
    public class ProductFormModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int Energy { get; set; }

        public double Fat { get; set; }

        public double Protein { get; set; }

        public double Sugars { get; set; }

        public byte[] Image { get; set; }
    }
}
