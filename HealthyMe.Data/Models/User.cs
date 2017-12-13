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

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public double BodyMassIndex { get; set; }

        public int AllowedCalories { get; set; }

        public DateTime? Day { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();

        public List<UserProduct> Products { get; set; } = new List<UserProduct>();

        public List<Diet> Diets { get; set; } = new List<Diet>();

       

    }
}
