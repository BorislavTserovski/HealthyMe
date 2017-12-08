using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthyMe.Data.Models
{
    public class Diet
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public List<DietProduct> Products { get; set; } = new List<DietProduct>();
    }
}
