using System.ComponentModel.DataAnnotations;

namespace HealthyMe.Web.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(10, 500)]
        [Display(Name = "Weight in KGs")]
        public double Weight { get; set; }

        [Range(50, 300)]
        [Display(Name = "Height in centimeters")]
        public double Height { get; set; }

        public string StatusMessage { get; set; }
    }
}