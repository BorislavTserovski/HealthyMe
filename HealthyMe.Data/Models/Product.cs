using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthyMe.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public TypeOfMeasure Measure { get; set; }

        public int Energy { get; set; }

        public double Fat { get; set; }

        public double Protein { get; set; }

        public double Sugars { get; set; }

        public byte[] Image { get; set; }

        public List<DietProduct> Diets { get; set; } = new List<DietProduct>();
    }
}
