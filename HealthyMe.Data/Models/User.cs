using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe.Data.Models
{
   
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        [Range(10, 500)]
        [Display(Name = "Weight in KGs")]
        public double Weight { get; set; }

        [Range(50, 300)]
        [Display(Name = "Height in centimeters")]
        public double Height { get; set; }

        [Range(1, 130)]
        public int Age { get; set; }

        public double BodyMassIndex { get; set; }

        public int AllowedCalories { get; set; }

        public DateTime? Day { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();

        public List<UserProduct> Products { get; set; } = new List<UserProduct>();

        public List<Product> MyProducts { get; set; } = new List<Product>();

        public List<Diet> Diets { get; set; } = new List<Diet>();

        public List<UserTraining> Trainings { get; set; } = new List<UserTraining>();



    }
}
