using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthyMe.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [DisplayName("Category")]
        [StringLength(30)]
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
