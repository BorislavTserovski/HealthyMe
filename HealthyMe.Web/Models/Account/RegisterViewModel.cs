﻿using HealthyMe.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
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

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}