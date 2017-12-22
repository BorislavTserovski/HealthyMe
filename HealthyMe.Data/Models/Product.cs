using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Range(0, 10000)]
        public int Energy { get; set; }

        [Range(0, 10000)]
        public double Fat { get; set; }

        [Range(0, 10000)]
        public double Protein { get; set; }

        [Range(0, 10000)]
        public double Sugars { get; set; }

        public byte[] Image { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public List<DietProduct> Diets { get; set; } = new List<DietProduct>();

        public List<UserProduct> Users { get; set; } = new List<UserProduct>();
    }
}